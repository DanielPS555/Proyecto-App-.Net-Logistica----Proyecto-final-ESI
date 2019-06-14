#!/bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarUDI() #encargado de la verificacion y devolver un codigo UDI valido 
{
verif=0
while test $verif -eq 0 
do
	echo "Ingrese el UID (Se usara el por defecto si no lo ingresa) (de 4 cifras)" 
	read dato #Ingreo de informacion 	
	if ! test -z $dato 
		then
		if test $(cat '/etc/passwd'| cut -d: -f3| grep "$dato"| wc -l) -eq 0 #Verifica que ña UID no exista 
		then
			if test $(echo $dato| grep -e "^[1-9][0-9]\{3\}$"|wc -l) -eq 1 #El numero tiene que ser de 4 cifras numericas 
			then	 			
				respuesta=$dato #salida de informacion
				verif=1 #rompe el bucle 
			else
				echo  "Formato del numero invalido (debe ser de 4 cifras)"
			fi
		else
			echo  "Ese UID ya existe, toque enter para continuar" 
		fi
		else 			
			respuesta="POR DEFECTO" #Salida por defecto 
			verif=1 #rompe el bucle 
									
	fi

done
}


mostrarUDI() #A partir de un usuario pasado por parametros nos devuelve su UID 
{
	respuesta=$(grep "$1:" '/etc/passwd'|cut -d: -f3) 
}
