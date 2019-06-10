#! /bin/bash

eliminarGrupo()
{
	verif5=0
	while test $verif5 -eq 0
	do
		echo "Ingrese el nombre del grupo a eliminar, si no ingresa nada se cancelara el proseso"
		read dato
		if ! test -z $dato
		then 
			if test $(grep -e "^$dato:" '/etc/group' | wc -l) -eq 1
			then
				groupdel $dato 2> /dev/null
				echo "Grupo eliminado con exito"
				verif5=1	
			else
				echo "El usuario no existe "
			fi
		else
			echo "No se realizaran modificacione" 
			verif5=1
		fi
		
	done
	echo "Ingrese cualquier boton para continuar"
	read ff
}
