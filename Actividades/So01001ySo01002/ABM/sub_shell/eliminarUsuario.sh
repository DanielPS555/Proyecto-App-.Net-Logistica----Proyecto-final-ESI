#!/bin/bash

eliminarUsuarios()
{
	verif5=0
	while test $verif5 -eq 0
	do
		echo "Ingrese el nombre del usuario a eliminar, si no ingresa nada se cancelara el proseso"
		read dato
		if ! test -z $dato
		then 
			if test $(grep -e "^$dato:" '/etc/passwd' | wc -l) -eq 1
			then
				echo "¿Desea eliminar tambien el directorio de trabajo del usuario? [s/n]"
				echo "Ingrese una opcion invalida para volver a ingresar el nombre"
				read ele				
				if test $ele == 's' 2> /dev/null
				then
					userdel $dato > '/dev/null'
					verif5=1	
					echo "Usuario eliminado con exito"
				else
					if test $ele == 'n' 2> /dev/null
					then			
						userdel -r $dato > '/dev/null'
						verif5=1
						echo "Usuario eliminado con exito"
					else
						echo "Opcion invalida"
					fi
				fi			
			else
				verif5=1
			fi
		else
			echo "No se realizaran modificacione" 
			verif5=1
		fi
		
	done
	echo "Ingrese cualquier boton para continuar"
	read ff
}
