#!/bin/bash
# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

eliminarUsuarios() #Metodo encargado de la eliminacion de los usuarios 
{
	verif5=0
	while test $verif5 -eq 0
	do
		echo "Ingrese el nombre del usuario a eliminar, si no ingresa nada se cancelara el proseso"
		read dato #Ingreso de la informacion 
		if ! test -z $dato #Comprueba que se haya ingresado informacion 
		then 
			if test $(grep -e "^$dato:" '/etc/passwd' | wc -l) -eq 1 #Comprueba que el usuario exista 
			then
				echo "¿Desea eliminar tambien el directorio de trabajo del usuario? [s/n]"
				echo "Ingrese una opcion invalida para volver a ingresar el nombre"
				read ele				
				if test $ele == 's' 2> /dev/null #comprueba si el usuario desea eliminar el directorio principal 
				then
					userdel -r $dato > '/dev/null' #Elimina el usuario y su directorio principal 
					verif5=1 #Rome el bucle	
					echo "Usuario eliminado con exito"
				else
					if test $ele == 'n' 2> /dev/null
					then			
						userdel $dato > '/dev/null' #Elimina al usuario pero no a su directorio principal 
						verif5=1
						echo "Usuario eliminado con exito"
					else
						echo "Opcion invalida" #Si la entrada no es ni 'n' ni 's' entonces se cancela la operacion 
					fi
				fi			
			else
				echo "El usuario no existe "
			fi
		else
			echo "No se realizaran modificacione" 
			verif5=1 #Rome bucle 
		fi
		
	done
	echo "Ingrese cualquier boton para continuar"
	read ff
}
