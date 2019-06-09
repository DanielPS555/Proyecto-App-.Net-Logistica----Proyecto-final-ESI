
verifUser()
{
	verifM=0
	while test $verifM -eq 0
	do
		echo "Por favor ingrese el nombre del usuario que va a modificar, no ingrese nada para cancelar "  
		read dato
		if ! test -z $dato
			then
			if test $(grep "^$dato:x:[1-9][0-9]\{3\}:*" '/etc/passwd'|wc -l) -ne 0 
			then
				respuesta=$dato
				verifM=1
			else
				error "Dicho usuario no existe en el sistema" 
			fi
		else
			verifM=2
			respuesta=''
		fi
	done
}
