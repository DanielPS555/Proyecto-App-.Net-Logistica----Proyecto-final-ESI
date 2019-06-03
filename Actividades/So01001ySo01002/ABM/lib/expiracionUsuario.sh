#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarExUser() #Funcion encargada de devolvernos una fecha para la expiracion del usuario la cual sea valida 
{
source lib/lib_error.sh
verif=0
while test $verif -eq 0
do
	echo "Ingresar la fecha de expiracion del usuario (si no ingresa ninguna se podra la por defecto"
	echo "El formato de la fecha a ingresar es el sigiente: day-month-year"
	read dato #Ingreso de informacion
	if test -z $dato 
	then
		respuesta="POR DEFECTO" #salida por defecto 
		verif=1
	else			
		if test $(echo "$dato" | grep -e "^[0-9]\{1,2\}-[0-9]\{1,2\}-[1-9][0-9]\+$"|wc -l) -eq 1 #Solo permite ingresar aquelas fechas las cuales tengan el sigiente formato day-month-year
		then
			day=$(echo "$dato"| sed -e 's/^\([0-9]\+\)\-\([0-9]\+\)\-\([0-9]\+\)$/\1/')	#Nos devuelve el dia
			month=$(echo "$dato"| sed -e 's/^\([0-9]\+\)\-\([0-9]\+\)\-\([0-9]\+\)$/\2/')	#Nos devuelve el mes 
			year=$(echo "$dato"| sed -e 's/^\([0-9]\+\)\-\([0-9]\+\)\-\([0-9]\+\)$/\3/')	#Nos devuelve el anio		
			if test $(cal $day $month $year 2>/dev/null | wc -l) -ne 0 #Verifica la valides de la fecha con el comando cal, para ello si la fecha es invalida la salida sera 0 porque fue redirijida a /dev/null, sino intentara imprimir el calendario el cual esta conformado por las de 0 lineas, por eso mismo esa fecha sea valida 
			then 					
				if test $(date +%s) -lt $(date -d "$year-$month-$day" +%s) #Con date +%s imprime un numero unico para cada fecha el cual se puede comprar la saber si una fecha es mejor o mayor
				then
					respuesta="$day-$month-$year" #salida de la informacion
					verif=1 #Romple bucle 
				else
					error "Esa fecha ya paso, debera elegir una posterior a la actual" 
				fi
			else 
				error "Fecha invalida, no existe" 
			fi
		else
			error "El formato no es el correcto, este debe ser DD-MM-YYYY"	
		fi 
	fi	
	
done

}
