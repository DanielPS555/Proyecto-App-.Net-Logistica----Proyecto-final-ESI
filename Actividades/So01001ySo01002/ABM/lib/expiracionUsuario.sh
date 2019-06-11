#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarExUser() #Funcion encargada de devolvernos una fecha para la expiracion del usuario la cual sea valida 
{
verif=0
while test $verif -eq 0
do
	case $1 in #Nos permite mostrar multiples mensajes, dependiendo el proposito de esta verificacion de fecha
	1)
		echo "Ingresar la fecha de expiracion del usuario (Si lo deja vacio se usara la por defecto )"
	;;
	2)
		echo "Ingresar la fecha de expiracion del usuario (Si lo deja vacio no se realizaran cambios)"
		
	;;
	3)
		echo "Ingrese la primera fecha, si lo deja vacio se cancela la operacion"
	;;

	4)
		echo "Ingrese la segunda fecha, si lo deja vacio se cancela la operacion"
	;;
	esac
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
				if test $1 -eq 3 || test $1 -eq 4
				then
					respuesta="$year-$month-$day" #salida de la informacion
						verif=1 #Romple bucle 
				else				
					if test $(date +%s) -lt $(date -d "$year-$month-$day" +%s) #Con date +%s imprime un numero unico para cada fecha el cual se puede comprar la saber si una fecha es mejor o mayor
					then
						respuesta="$year-$month-$day" #salida de la informacion
						verif=1 #Romple bucle 
					else
						echo "Esa fecha ya paso, debera elegir una posterior a la actual" 
					fi
				fi
			else 
				echo "Fecha invalida, no existe" 
			fi
		else
			echo "El formato no es el correcto, este debe ser DD-MM-YYYY"	
		fi 
	fi	
	
done

}

mostrarExUser()
{				
	if ! test -z $(grep -e "^$1:" /etc/shadow|cut -d: -f8) #Si el usuario tiene una fecha de expiracion ingresa al then
	then
		respuesta=$(date -d "1970-1-1 $(grep -e "^$1:" /etc/shadow|cut -d: -f8) days" +%'Y'-'%m'-'%d') 
		#Hace los calculos con el comando date para calcular la fecha de expiracion (tengan presente que el dato que devuelve el grep es el numero de dias entre 1970-1-1 y la fecha de expiracion 
	else	
		respuesta="" #Si no existe fecha de expiracion devuelve nada 	
	fi
}

