#!/bin/bash
ConfiguracionDelAmbienteDeTrabajo()
{
	carpeta="/var/automotora"
	ex=0
	if test -d $carpeta
	then
		echo "La carpeta ya existe, ¿desea sobre escribir? (1= si 0=no)"
		read d		
		if test $d -eq 1
		then
			rm -rf carpeta
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
	
		if test -f /etc/ArchivoConfiguracionAutomotora
		then
			touch '/etc/ArchivoConfiguracionAutomotora'
		fi

		echo "$carpeta">/etc/ArchivoConfiguracionAutomotora
		cd DataConfiguracionABMusuariosSO/
		ln setup.sh /root/setup.sh
		cd $ruta 
		
		if test $(grep -e "^Operario:" etc/passwd| wc -l) -eq 1
		then
			useradd Operario
		fi

		if test $(grep -e "^Trasportista:" etc/passwd| wc -l) -eq 1
		then
			useradd Trasportista
		fi	

		if test $(grep -e "^Administrador:" etc/passwd| wc -l) -eq 1
		then
			useradd Administrador
		fi
		echo "Proseso terminado con exito, revise la carpeta /root para acceder al panel setup de la aplicacion"
	fi


}

FInstalar()
{
	echo "Primero debe instalar el software, toque enter para continuar"
	read ff
}

if test $USER = "root"
then
	if test -f '/etc/ArchivoConfiguracionAutomotora'
	then
		clear
		source ./lib/lib_menu.sh
		source lib/lib_error.sh
		source lib/DT.sh
		source lib/expiracionUsuario.sh
		source lib/GP.sh
		source lib/GS.sh
		source lib/NDiasHasta.sh
		source lib/pass.sh
		source lib/shell.sh
		source lib/UDI.sh
		source lib/userE.sh
		source lib/fechacal.sh
		source ./sub_shell/agregarUsuario.sh 
		source ./sub_shell/ModificarUsuario.sh 
		source ./sub_shell/eliminarUsuario.sh
		source ./sub_shell/listarUsuarios.sh 
		source ./sub_shell/agregarGrupo.sh 
		source ./sub_shell/ModificarGrupo.sh 
		source ./sub_shell/EliminarGrupo.sh 
		source ./sub_shell/listarGrupos.sh 
		source ./sub_shell/Preferencias.sh 
		source ./sub_shell/ConfiguracionDelAmbienteDeTrabajo.sh 

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
