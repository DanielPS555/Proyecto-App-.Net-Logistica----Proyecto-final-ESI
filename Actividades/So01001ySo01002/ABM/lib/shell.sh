#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarShell() #encargado de verificar y devolver una direcion de un shell para un usuario, al poder tener muchos tipos de shell y estos al ser todos archivos regulares no hay muchas forma de verificar que realmente se trate de un shell 
{
source lib/lib_error.sh
verif=0
while test $verif -eq 0
do
	echo "Ingrese la direcion del shell de inicio (se usara el por defecto si no ingresa nada)" 	
	read dato #Ingreso de informacion
	if test -z $dato 
	then
		if test $1 -eq 1 #si el 1° parametro es 1 se habilitara la salida por defecto, de lo contrario estara bloqueada
		then
			respuesta="POR DEFECTO" #salida por defecto
			verif=1 #rompe el bucle 
		else
			error "No se puede usar la salida por defecto, debe ingresar un valor"
		fi		
		
	else
		if test -f $dato #verifica que la ruta del archivo exista y ademas sea un archivo regular 
		then
			respuesta=$dato #salida de la informacion
			verif=1
		else
			error "Ese archivo no existe "
		fi
	fi
done
}
