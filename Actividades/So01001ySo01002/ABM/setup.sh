#!/bin/bash
# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

ConfiguracionDelAmbienteDeTrabajo() #Funcion encarga de la instalacion 
{	
	carpeta="/var" #La carpeta de instalacion sea /var
	ex=0
	if test -d $carpeta/DataConfiguracionABMusuariosSO || test $(echo $PATH | grep "/var/DataConfiguracionABMusuariosSO/"|wc -l) -eq 1 
	then
		echo "El sistema esta instalado, se prosede? (1= si 0=no)" #Si existe preguntamos si desea sobreescribir 
		read d		
		if test $d -eq 1 2> /dev/null #En caso que desde sobre escribir se prosedera con lo sigiente
		then
			desinstalar '1' #Elimina la insltalacion actual 
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

		touch /etc/profile.d/z_ABMConfiguration.sh #Creamos un archivo de configuracion del PATH en /etc/profile.d
		echo "export PATH=$PATH:/var/DataConfiguracionABMusuariosSO/" > /etc/profile.d/z_ABMConfiguration.sh
		PATH="$PATH:/var/DataConfiguracionABMusuariosSO/" #cambia PATH, con SH no te permite hacerlo, por eso debe usar source el usuario 
		export PATH #Exporta PATH
		cd $ruta
		mkdir /var/DataConfiguracionABMusuariosSO/Temp #Creamos la carpeta BackUp y Temp 
		if test $(grep -e "^Operario:" /etc/passwd| wc -l) -eq 0 # si el usuario operario existe 
 		then
			useradd Operario 2> /dev/null #Este usuario se crea para el acceso de los operarios al sistema
			echo "ope_bit2019" | passwd --stdin Operario > /dev/null #Se le asigna la contraseña al operario
		fi

		if test $(grep -e "^Trasportista:" /etc/passwd| wc -l) -eq 0 #si el usuario trasportisa existe 
		then
			useradd Trasportista 2> /dev/null #Este usuario se crea para el acceso de los trasportista al sistema
			echo "tras_bit2019" | passwd --stdin Trasportista > /dev/null #Se le asigna la contraseña al trasportista 
		fi	

		if test $(grep -e "^Administrador:" /etc/passwd| wc -l) -eq 0
		then
			useradd Administrador 2> /dev/null #Este usuario se crea para el acceso de los administradores al sistema 
			echo "admin_bit2019" | passwd --stdin Administrador > /dev/null #Se le asigna la contraseña al administrador
		fi
		chmod 700 /var/DataConfiguracionABMusuariosSO 	
		echo "Proseso terminado con exito, ejecute setup.sh desde la consola"
		rm -f ./setup.sh
	fi

}

desinstalar()
{
		#Subido en la direcion url que se puede ver en la linea anterior se tiene subido todos los shell script y funciones nesesarias para el correcto funcionamiento de la ABM. De esta forma el usuario no debera tener todos los archivos, solamente el shell setup para la instalacion
 		if test -d /var/DataConfiguracionABMusuariosSO/
		then
			rm -rf /var/DataConfiguracionABMusuariosSO/ #Eliminamos el directorio donde esta instalado el software
		fi		
		if test -f /etc/profile.d/z_ABMConfiguration.sh
		then
			rm -f /etc/profile.d/z_ABMConfiguration.sh #eliminamo el archivo de configuracion del PATH
		fi
	
		PATH=$(echo $PATH | sed -e 's/:\/var\/DataConfiguracionABMusuariosSO\///g') #Elimina la ublicacion de la inlstalacion del path 
		export PATH
		if test $(grep -e "^Operario:" /etc/passwd| wc -l) -eq 1 # si el usuario operario existe 
 		then
			userdel Operario #Elimina al operario si exsiste 
		fi

		if test $(grep -e "^Trasportista:" /etc/passwd| wc -l) -eq 1 #si el usuario trasportisa existe 
		then
			userdel Trasportista #Elimina al trasportista si exsiste 
		fi	

		if test $(grep -e "^Administrador:" /etc/passwd| wc -l) -eq 1
		then
			userdel Administrador #Elimina al administrador si exsiste 
		fi
			
		if test -z $1
		then 
			echo "Proseso terminado con exito"	
			read f
			verifMenu=-1
		fi	
}


if test $(w |tail -$[$(w | wc -l)-2] | grep "sh setup" | wc -l) -eq 0 #comprueba que se ejecute con source 
then
	
	if test $USER = "root" # Debe ser el usuario root quien utilice el shell 
	then
		if test $(echo $PATH | grep "/var/DataConfiguracionABMusuariosSO/"|wc -l) -eq 1  #revisa que este la ubicacion de la instalacion 
		then
			clear
			#Se importan un conjunto de archivos llenos de metodos a utilizar en la ABM
			source /var/DataConfiguracionABMusuariosSO/lib/lib_menu.sh
			source /var/DataConfiguracionABMusuariosSO/lib/lib_error.sh
			source /var/DataConfiguracionABMusuariosSO/lib/DT.sh
			source /var/DataConfiguracionABMusuariosSO/lib/expiracionUsuario.sh
			source /var/DataConfiguracionABMusuariosSO/lib/GP.sh
			source /var/DataConfiguracionABMusuariosSO/lib/GS.sh
			source /var/DataConfiguracionABMusuariosSO/lib/NDiasHasta.sh
			source /var/DataConfiguracionABMusuariosSO/lib/pass.sh
			source /var/DataConfiguracionABMusuariosSO/lib/shell.sh
			source /var/DataConfiguracionABMusuariosSO/lib/UDI.sh
			source /var/DataConfiguracionABMusuariosSO/lib/userE.sh
			source /var/DataConfiguracionABMusuariosSO/lib/fechacal.sh
			source /var/DataConfiguracionABMusuariosSO/sub_shell/agregarUsuario.sh 
			source /var/DataConfiguracionABMusuariosSO/sub_shell/ModificarUsuario.sh 
			source /var/DataConfiguracionABMusuariosSO/sub_shell/eliminarUsuario.sh
			source /var/DataConfiguracionABMusuariosSO/sub_shell/listarUsuarios.sh 
			source /var/DataConfiguracionABMusuariosSO/sub_shell/agregarGrupo.sh 
			source /var/DataConfiguracionABMusuariosSO/sub_shell/ModificarGrupo.sh 
			source /var/DataConfiguracionABMusuariosSO/sub_shell/EliminarGrupo.sh 
			source /var/DataConfiguracionABMusuariosSO/sub_shell/listarGrupos.sh 
			source /var/DataConfiguracionABMusuariosSO/sub_shell/Preferencias.sh 
			carpetaBase='/var/DataConfiguracionABMusuariosSO'

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
			nombres=('Agregar_usuario' 'Modificar_usuarios' 'Eliminar_usuarios' 'Listar_usuarios' 'Agregar_grupo' 'editar_grupo' 'eliminar_grupo' 'Listar_grupo' 'Editar_preferencias' 'Reinstalar' 'Desinstalar')
			# se carga el nombre de los metodos que llaman dichas opciones 
			direcionesSetUp=('agregarUsuario' 'ModificarUsuario' 'eliminarUsuarios' 'listarUsuarios' 'agregarGrupo' 'ModificarGrupo' 'eliminarGrupo' 'MenuListarGrupos' 'Preferencias' 'ConfiguracionDelAmbienteDeTrabajo' 'desinstalar')

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
			echo "Desea comenzar el proseso de instalacion? (1= si 0=no)"
			read de		
			if test $de -eq 1 2> /dev/null #Comprueba que el dato ingresado sea 1
			then
				ConfiguracionDelAmbienteDeTrabajo #se prosesde con la instalacion del sistema 
			fi	
		fi
	else
		echo "Debe ser root para ejecutar este software"
	fi
else
	
	echo "No puede ejecuar este shell script con el comando 'sh' use source o el nombre del archivo setup.sh"
fi
