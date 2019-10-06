#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
function killProc()
{
    echo -n "PID del proceso a matar: "
    read pid
    if test $(echo $pid | grep -E "^[0-9]{1,9}$"|wc -l) -eq 1 && test $(ps --pid $pid|wc -l) -eq 2
    then
	if ! kill -9 $pid
	then
	  echo "No se pudo matar al proceso $pid"
	else
	  echo "Proceso $pid tumbado con éxito"
        fi
    else
	echo "No es un número de PID válido"	
    fi
	echo "Toque enter para continuar"
	read fff
    
}
