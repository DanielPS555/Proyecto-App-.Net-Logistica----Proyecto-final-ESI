#!/bin/bash
ConfiguracionDelAmbienteDeTrabajo()
{
	echo "Desea comenzar el proseso de instalacion? (1= si 0=no)"
	read de		
	if test $de -eq 1 2> /dev/null
	then
		carpeta="/var"
		ex=0
		if test -d $carpeta/DataConfiguracionABMusuariosSO
		then
			echo "La carpeta ya existe, ¿desea sobre escribir? (1= si 0=no)"
			read d		
			if test $d -eq 1 2> /dev/null
			then
				rm -rf $carpeta/DataConfiguracionABMusuariosSO
				rm -f /root/setup.sh
				ex=1			
			else
				echo "Operacion cancelada"	
			fi
		else
			ex=1
		fi

		if test $ex -eq 1
		then
			ruta=$(pwd)
			cd $carpeta
			git clone https://github.com/Daniel2242014/DataConfiguracionABMusuariosSO
	
			if ! test -f /etc/ArchivoConfiguracionAutomotora
			then
				touch '/etc/ArchivoConfiguracionAutomotora'
			fi

			echo "$carpeta/DataConfiguracionABMusuariosSO">/etc/ArchivoConfiguracionAutomotora
			cd DataConfiguracionABMusuariosSO/
			rm -f $ruta/setup.sh
			ln setup.sh /root/setup.sh
			mkdir Backup Temp
			cd $ruta 
			if test $(grep -e "^Operario:" /etc/passwd| wc -l) -eq 0
			then
				useradd Operario
			fi

			if test $(grep -e "^Trasportista:" /etc/passwd| wc -l) -eq 0
			then
				useradd Trasportista
			fi	

			if test $(grep -e "^Administrador:" /etc/passwd| wc -l) -eq 0
			then
				useradd Administrador
			fi
			echo "Proseso terminado con exito, revise la carpeta /root para acceder al panel setup de la aplicacion"
			
			exit
		fi
	fi

}


if test $USER = "root"
then
	if test -f '/etc/ArchivoConfiguracionAutomotora'
	then
		carpetaBase=$(cat /etc/ArchivoConfiguracionAutomotora)
		clear
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
		
		nombres=('Agregar_usuario' 'Modificar_usuarios' 'Eliminar_usuarios' 'Listar_usuarios' 'Agregar_grupo' 'editar_grupo' 'eliminar_grupo' 'Listar_grupo' 'Editar_preferencias' 'Instalar')

		direcionesSetUp=('agregarUsuario' 'ModificarUsuario' 'eliminarUsuarios' 'listarUsuarios' 'agregarGrupo' 'ModificarGrupo' 'eliminarGrupo' 'MenuListarGrupos' 'Preferencias' 'ConfiguracionDelAmbienteDeTrabajo')

		menu 'nombres[@]' 'direcionesSetUp[@]'

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

		ConfiguracionDelAmbienteDeTrabajo
	fi

else
	echo "Debe ser root para ejecutar este software"
fi
