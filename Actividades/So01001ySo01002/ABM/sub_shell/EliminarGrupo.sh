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
	    if test $(cut -d: -f1,3 '/etc/group' | grep -e "^$dato:[1-9][0-9]\{1,3\}$" | wc -l) -eq 1 #comprueba que realmente exista dicho grupo 
	    then
		grgid=$(cut -d: -f1,3 '/etc/group' | grep "^$dato" | cut -d: -f2)
		conte=$(cut -d: -f4 '/etc/passwd' | grep "$grgid" | wc -l)
		if test $conte -eq 0
		then
		    err=$(groupdel $dato 2>&1)
		    if [ "$err" == "" ]
		    then
			
			echo "Grupo eliminado con exito"
		    else
			echo "Error eliminando grupo: $err"
		    fi
		    verif5=1 #Rompe bucle
		else
		    echo "No se pueden eliminar el grupo porque hay usuarios cuyo grupo principal es este grupo" 
		fi		
	    else
		echo "El grupo no existe"
	    fi
	else
	    echo "No se realizaran modificacione" 
	    verif5=1 #rompe bucle
	fi
	
    done
    echo "Ingrese cualquier boton para continuar"
    read ff
}
