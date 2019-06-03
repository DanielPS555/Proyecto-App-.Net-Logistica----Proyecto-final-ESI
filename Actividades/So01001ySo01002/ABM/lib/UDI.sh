#!/bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarUDI() #encargado de la verificacion y devolver un codigo UDI valido 
{
source lib/lib_error.sh
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
				error "Formato del numero invalido (debe ser de 4 cifras)"
			fi
		else
				error "Ese UID ya existe, toque enter para continuar" 
			fi
		else 
			if test $1 -eq 1 #si el 1° parametro es 1 se habilitara la salida por defecto, de lo contrario estara bloqueada
			then
				respuesta="POR DEFECTO" #Salida por defecto 
				verif=1 #rompe el bucle 
			else
				error "No se puede usar la salida por defecto, debe ingresar un valor"
			fi						
	fi

done
}

mostrarUDI() 
{
echo "falta" 
}
