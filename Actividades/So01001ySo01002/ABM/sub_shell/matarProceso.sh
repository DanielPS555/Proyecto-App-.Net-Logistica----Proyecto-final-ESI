#version 2 segunda entrega
function killProc()
{
    echo -n "PID del proceso a matar: "
    read pid
    if test $(echo $pid | grep -E "^[0-9]{1,9}$"|wc -l) -eq 1 && test $(ps --pid $pid|wc -l) -eq 2
    then
	if ! kill $pid
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
