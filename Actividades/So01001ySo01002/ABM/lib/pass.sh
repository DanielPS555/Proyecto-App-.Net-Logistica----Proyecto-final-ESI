#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarPass() #Verifica y devuelve una contraseña valida para el usuario 
{
source lib/lib_error.sh
verif=0
while test $verif -eq 0
do
	echo "Ingrese la contraseña a utilizar (puede dejarlo vacio)"
	echo "Si ingresa un contraseña que tenga entre 8 y 20 caracteres, SOLO LETRAS Y NUMEROS"
	echo "Su primer caracter debe ser una letra, se debera poder a lo largo de la contraseña al menos una mayuscula"
	read dato
	if test -z $dato
	then
		if test $1 -eq 1 #si el 1° parametro es 1 se habilitara la salida por defecto, de lo contrario estara bloqueada
		then
			respuesta="POR DEFECTO" #salida por defecto
			verif=1	#Se rompe el bucle 
		else
			error "No se puede usar la salida por defecto, debe ingresar un valor"
		fi
		
	else
		if test $(echo $dato | grep -ie "^[a-z][a-z0-9]\{7,19\}$") && test $(echo $dato | grep -e "[A-Z]") #Solo permite ingrezar aquelos valores que tengan entre 8 a 20 caracteres, comiencen por una letra y algun caracter tengan mayuscula 
		then
			respuesta=$dato #salida de datos
			verif=1 #Se rome el bucle
		else
			error "La contraseña no es valida" 
		fi
	fi 
done

}
