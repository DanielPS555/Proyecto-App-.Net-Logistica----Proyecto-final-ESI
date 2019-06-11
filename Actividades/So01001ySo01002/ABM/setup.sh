#!/bin/bash
# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

ConfiguracionDelAmbienteDeTrabajo() #Funcion encarga de la instalacion 
{
	echo "Desea comenzar el proseso de instalacion? (1= si 0=no)"
	read de		
	if test $de -eq 1 2> /dev/null #Comprueba que el dato ingresado sea 1
	then
		carpeta="/var" #La carpeta de instalacion sea /var
		ex=0
		if test -d $carpeta/DataConfiguracionABMusuariosSO #comprobamos que no exista el directorio de instalacion 
		then
			echo "La carpeta ya existe, ¿desea sobre escribir? (1= si 0=no)" #Si existe preguntamos si desea sobreescribir 
			read d		
			if test $d -eq 1 2> /dev/null #En caso que desde sobre escribir se prosedera con lo sigiente
			then
				rm -rf $carpeta/DataConfiguracionABMusuariosSO #Borrara el directorio donde estaba instalado el programa
				rm -f /root/setup.sh #Borrara el enlase donde estaba el acceso al setup 
				ex=1			
			else
				echo "Operacion cancelada"	
			fi
		else
			ex=1
		fi

		if test $ex -eq 1 #Si desea sobrescribir o la carpeta no existe se prosesdera con la instalacion, de lo contrario se terminara la ejecucion de la funcion 
		then
			ruta=$(pwd) #guardamos en la variable ruta la direcion actual donde se ejecuto el setup de instalacion 
			cd $carpeta #Nos movemos a /var
			git clone https://github.com/Daniel2242014/DataConfiguracionABMusuariosSO
			#Subido en la direcion url que se puede ver en la linea anterior se tiene subido todos los shell script y funciones nesesarias para el correcto funcionamiento de la ABM. De esta forma el usuario no debera tener todos los archivos, solamente el shell setup para la instalacion

	
			if ! test -f /etc/ArchivoConfiguracionAutomotora #Si no existe este archivo se creara, de lo contrario solamente se cambiara su contenido por /var
			then
				touch '/etc/ArchivoConfiguracionAutomotora' # se crea el archivo 
			fi

			echo "$carpeta/DataConfiguracionABMusuariosSO">/etc/ArchivoConfiguracionAutomotora #Guardamos la ubicacion de la instalacion 
			cd DataConfiguracionABMusuariosSO/ #entramos dentro de la carpeta de instalacion
			rm -f $ruta/setup.sh #eliminamos la instancia del setup que esta utilizando el usuario ahora, la cual se va a sustituir por un enlase del setup de los archivos de instalacion 
			ln setup.sh /root/setup.sh #creamos en enlase 
			mkdir Backup Temp #Creamos la carpeta BackUp y Temp 
			cd $ruta 
			if test $(grep -e "^Operario:" /etc/passwd| wc -l) -eq 0 # si el usuario operario existe 
 			then
				useradd Operario #Este usuario se crea para el acceso de los operarios al sistema
				echo "ope_bit2019" | passwd --stdin Operario > /dev/null #Se le asigna la contraseña al operario
			fi

			if test $(grep -e "^Trasportista:" /etc/passwd| wc -l) -eq 0 #si el usuario trasportisa existe 
			then
				useradd Trasportista #Este usuario se crea para el acceso de los trasportista al sistema
				echo "tras_bit2019" | passwd --stdin Trasportista > /dev/null #Se le asigna la contraseña al trasportista 
			fi	

			if test $(grep -e "^Administrador:" /etc/passwd| wc -l) -eq 0
			then
				useradd Administrador #Este usuario se crea para el acceso de los administradores al sistema 
				echo "admin_bit2019" | passwd --stdin Administrador > /dev/null #Se le asigna la contraseña al administrador
			fi
			echo "Proseso terminado con exito, revise la carpeta /root para acceder al panel setup de la aplicacion"
			
			exit
		fi
	fi

}


if test $USER = "root" #Solo se le permite acceder a la abm y a la instalacion al root del sistema
then
	if test -f '/etc/ArchivoConfiguracionAutomotora' #Si existe este archivo, significa que el sistema fue instalado, de todas formas se puede volver a reinstalar el software 
	then
		carpetaBase=$(cat /etc/ArchivoConfiguracionAutomotora) #Se carga la direcion del la instalacion del archivo ArchivoConfiguracionAutomotora
		clear
		#Se importan un conjunto de archivos llenos de metodos a utilizar en la ABM
		source $carpetaBase/lib/lib_menu.sh
		source $carpetaBase/lib/lib_error.sh
		source $carpetaBase/lib/DT.sh
		source $carpetaBase/lib/expiracionUsuario.sh
		source $carpetaBase/lib/GP.sh
		source $carpetaBase/lib/GS.sh
		source $carpetaBase/lib/NDiasHasta.sh
		source $carpetaBase/lib/pass.sh
		source $carpetaBase/lib/shell.sh
		source $carpetaBase/lib/UDI.sh
		source $carpetaBase/lib/userE.sh
		source $carpetaBase/lib/fechacal.sh
		source $carpetaBase/sub_shell/agregarUsuario.sh 
		source $carpetaBase/sub_shell/ModificarUsuario.sh 
		source $carpetaBase/sub_shell/eliminarUsuario.sh
		source $carpetaBase/sub_shell/listarUsuarios.sh 
		source $carpetaBase/sub_shell/agregarGrupo.sh 
		source $carpetaBase/sub_shell/ModificarGrupo.sh 
		source $carpetaBase/sub_shell/EliminarGrupo.sh 
		source $carpetaBase/sub_shell/listarGrupos.sh 
		source $carpetaBase/sub_shell/Preferencias.sh 


		respuesta="" #El dato pasado por los return solo puede ser numerico, entonces utilizamos una variable externa donde se cargen las salidas, como si fuera un $? pero con mayor capasidad 

		echo "   _____________________________________________  "
		echo "   |                                           | "
		echo "   |                                           | "
		echo "   |           ABM usuarios y grupos           | "
		echo "   |                  por Bit                  | "
		echo "   |                                           | "
		echo "   |___________________________________________| "
		echo "" 
		# se carga un array con los nombre de las opciones del menu 
		nombres=('Agregar_usuario' 'Modificar_usuarios' 'Eliminar_usuarios' 'Listar_usuarios' 'Agregar_grupo' 'editar_grupo' 'eliminar_grupo' 'Listar_grupo' 'Editar_preferencias' 'Instalar')
		# se carga el nombre de los metodos que llaman dichas opciones 
		direcionesSetUp=('agregarUsuario' 'ModificarUsuario' 'eliminarUsuarios' 'listarUsuarios' 'agregarGrupo' 'ModificarGrupo' 'eliminarGrupo' 'MenuListarGrupos' 'Preferencias' 'ConfiguracionDelAmbienteDeTrabajo')

		menu 'nombres[@]' 'direcionesSetUp[@]' #se llama al metodo menu 

	else
		echo "   _____________________________________________  "
		echo "   |                                           | "
		echo "   |                                           | "
		echo "   |           ABM usuarios y grupos           | "
		echo "   |                  por Bit                  | "
		echo "   |                                           | "
		echo "   |___________________________________________| "
		echo "" 
		
		echo "debe instalar el softare para utilizarlo" 

		ConfiguracionDelAmbienteDeTrabajo #se prosesde con la instalacion del sistema 
	fi

else
	echo "Debe ser root para ejecutar este software"
fi
