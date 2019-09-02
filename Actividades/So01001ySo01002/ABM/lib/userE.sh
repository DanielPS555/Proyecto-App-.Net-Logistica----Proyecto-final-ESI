
# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

verifUser() #Esta funcion de encarga del correcto ingreso del nombre de un usuario perteneciente al sistema
{
	verifM=0
	while test $verifM -eq 0
	do
		echo "Por favor ingrese el nombre del usuario que va a modificar, no ingrese nada para cancelar "  
		read dato
		if ! test -z $dato
			then
			if test \( $(grep "^$dato:x:[1-9][0-9]\{3\}:*" '/etc/passwd'|wc -l) -ne 0 \) -o \( \( "$dato" == "root" \) -a \( -n "$1" \) \) #Verifica que haya algun resultado para dicho usuario en el registro de usuarios del sistema, cuya GID sea de 4 cifras 
			then
				respuesta=$dato #devuelve el dato
				verifM=1 #rompe el bucle 
			else
				echo  "Dicho usuario no existe en el sistema" 
			fi
		else
			verifM=2 
			respuesta=''
		fi
	done
}
