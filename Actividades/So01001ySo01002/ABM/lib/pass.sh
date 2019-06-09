#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarPass() #Verifica y devuelve una contraseña valida para el usuario 
{
verif=0
while test $verif -eq 0
do
	echo "Ingrese la contraseña a utilizar (puede dejarlo vacio)"
	echo "Si ingresa un contraseña que tenga entre 8 y 20 caracteres, SOLO LETRAS Y NUMEROS"
	echo "Su primer caracter debe ser una letra, se debera poder a lo largo de la contraseña al menos una mayuscula"
	read dato
	if test -z $dato
	then
		respuesta="POR DEFECTO" #salida por defecto
		verif=1	#Se rompe el bucle 
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

estadoPass()
{
	respuesta=$(passwd -S $1 | cut -d' ' -f2)
}

FechModificacionPass()
{				
	respuesta=$(date -d "1970-1-1 $[$(grep -e "^$1:" /etc/shadow|cut -d: -f3)-1] days" +%'Y'-'%m'-'%d') 
}
