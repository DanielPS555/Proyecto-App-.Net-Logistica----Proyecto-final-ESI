#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarShell() #encargado de verificar y devolver una direcion de un shell para un usuario, al poder tener muchos tipos de shell y estos al ser todos archivos regulares no hay muchas forma de verificar que realmente se trate de un shell 
{
verif=0
while test $verif -eq 0
do
	echo "Ingrese la direcion del shell de inicio (se usara el por defecto si no ingresa nada)" 	
	read dato #Ingreso de informacion
	if test -z $dato 
	then
		respuesta="POR DEFECTO" #salida por defecto
		verif=1 #rompe el bucle 		
		
	else
		if test $(grep -x "$dato" /etc/shells | wc -l) -eq 1 #verifica que la ruta del archivo exista y ademas sea un archivo regular 
		then
			respuesta=$dato #salida de la informacion
			verif=1
		else
			echo  "Ese archivo no existe "
		fi
	fi
done
}

mostrarShell() #Nos devuelve la ubicacion del shell para el usuario pasado por parametros 
{
	respuesta=$(grep -e "^$1:" '/etc/passwd'| cut -d: -f7)
}
