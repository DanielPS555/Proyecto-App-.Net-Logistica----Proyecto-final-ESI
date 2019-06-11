#! /bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

eliminarGrupo() #Esta funcion es la encargada de la eliminacion de los grupos del sistema 
{
	verif5=0
	while test $verif5 -eq 0
	do
		echo "Ingrese el nombre del grupo a eliminar, si no ingresa nada se cancelara el proseso"
		read dato
		if ! test -z $dato #Comprueba que la entrada no sea vacia
		then 
			if test $(grep -e "^$dato:" '/etc/group' | wc -l) -eq 1 #comprueba que realmente exista dicho grupo 
			then
				groupdel $dato 2> /dev/null #Elimina el grupo 
				echo "Grupo eliminado con exito"
				verif5=1 #Rompe bucle	
			else
				echo "El usuario no existe "
			fi
		else
			echo "No se realizaran modificacione" 
			verif5=1 #rompe bucle
		fi
		
	done
	echo "Ingrese cualquier boton para continuar"
	read ff
}
