#!/bin/bash
#VERCION 3.0 - 25/9 Tercera ENTREGA desarrolado por Bit (3°BD 2019)
listaReal()
{
	touch $carpetaBase/Temp/listar 
	con=1
	cat /var/respaldos/master | while read nan
			           do
					if test $(echo $nan| grep ":I:" | wc -l) -eq 0
					then
						echo "$con) Respaldo Total del $(echo $nan| cut -d: -f3,4,5)" >> $carpetaBase/Temp/listar 
					else
						echo "$con) --> Respaldo Incremental del $(echo $nan| cut -d: -f3,4,5)" >> $carpetaBase/Temp/listar 
					fi
					con=$[$con+1]
				   done
	echo "Ingrese q para salir de la lista. Para continuar toque cualquier boton"
	less $carpetaBase/Temp/listar 

	rm -f $carpetaBase/Temp/listar 

	
}

function listarBackups()
{
	if ! test -d /var/respaldos || ! test -f /var/respaldos/master || test $(cat /var/respaldos/master| wc -l) -eq 0
	then
		echo "Error: Sin informacion que mostrar. Por favor cree algun respaldo total"
		read fff
		return 
	fi
	
	listaReal
}



