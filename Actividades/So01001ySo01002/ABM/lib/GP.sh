#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarGPNuevo() #Nos devuelve el nombre de un grupo para ser usuado como principal, esta funcion solo puede ser usada para crear un usuario, ya que tolera la salida por defecto y ademas no soporta el hecho que ya haya otro grupo principal para ese usuario 
{
source lib/lib_error.sh
verif=0
while test $verif -eq 0
do
	echo "Ingrese el nombre del grupo principal(se usara el por defecto si no ingresa ninguno)" 
	echo "Ingrese 'help' para visualizar todos los grupos del sistema, ingrese 'q' para salir"
	read dato #Ingreso de la informacion
	if test -z $dato
	then
		respuesta="POR DEFECTO" #Salida por defecto 
		verif=1
	else
		if test $dato = "help" 
		then
			cut -d: -f1 /etc/group| less #Imprime el conjunto de todos los grupos del sistema  
		else
			if test $(grep "$dato:" /etc/group| wc -l) -eq 1 #Si el grupo existe en el sistema lo accepta 
			then
				respuesta="$dato" #Salida de la informacion 
				verif=1 #se rompe el bucle
			else
				error "Ese grupo no exsiste, creelo o ingrese otro " 
			fi
		fi  
	fi	
done
}