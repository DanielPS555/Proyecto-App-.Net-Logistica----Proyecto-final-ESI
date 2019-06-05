#!/bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

menu()     #Solisita dos array, el primero con el nombre de la opcion y el segundo con la dirrecion del sub shell a llamar desde el menu 
{

ary1=($(echo ${!1})) #Pasamos el array que del parametro de la funcion a un array local 
ary2=($(echo ${!2}))

if test ${#ary1[@]} -eq ${#ary2[@]} #Debo comrpobar el numero de elementos que tengan ambos array sea los mismos 
then 
	verifMenu=0
	while test $verifMenu -eq 0 #Este bucle se repetira hasta que no se haya salido del menu 
	do	
		for var1 in $(seq 0 1 $[${#ary1[@]}-1])	
		do
			echo "$[$var1+1])  ${ary1[$var1]}" #Escribe en consola los elementos del menu 
		done
		echo "0) Salir"
		echo "Ingrese la opcion: " 	
		read opcionM
		if test $opcionM -ge 0 2>/dev/null && test $opcionM -le ${#ary1[@]} 2>/dev/null #Verifica que el numero ingresado sea un numero el cual este entre el 0 y el numero de elemenos de array 
		then
			if test $opcionM -eq 0
			then			
				verifMenu=1 # Si el numero es 0 significa que se va a salir del menu, por ende 'rompe' el while 
			else					
				${ary2[$[$opcionM-1]]} #llama a la funcion
				verifMenu=0			
			fi		
		else 

			echo "Opcion invalida, por favor ingrese una valida (ingrese cualquier boton para continuar)"
			read ff
			clear
		fi
		clear
	done 
else
	echo "Excepcion, los dos array tiene que tener el mismo numero de elementos" 
fi
}
