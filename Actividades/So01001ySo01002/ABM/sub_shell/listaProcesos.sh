#version 2 segunda entrega bit
function todosProcesos()
{
    ps -o pid,ruser=Usuario,comm=Proceso a
}

function procesosUsuario()
{
    respuesta="a"
    while [ "$respuesta" != "" ]
    do
	verifUser
	if [ "$respuesta" != "" ]
	then
	    pCount=$(ps -U "$respuesta" -o pid,comm=Proceso | wc -l)
	    if [ $pCount -eq 1 ]
	    then
		echo "No hay procesos abiertos por el usuario $respuesta"
	    else
		ps -U "$respuesta" -o pid,comm=Proceso
		echo "Enter para continuar..."
		read ff
	    fi
	fi
    done
}

function detalleProceso()
{
    input=0
    while [ $input -ge 0 ]
    do
	echo -n "Inserte un número de PID (menor que 0 saldrá de la función): "
	read input
	if test $input -le 0 2> /dev/null
	then
		echo "Cancelado, toque enter para continuar"		
		return 
	fi

	if test $(echo $input | grep -E "^[0-9]{1,9}$"|wc -l) -eq 1 && test $(ps --pid $input|wc -l) -eq 2
	then
            pCount=$(ps --pid $input -o comm=Proceso,%cpu=CPU,%mem=RAM,euid=UID_Efectivo,ruid=UID_Real | wc -l)
	    if [ $pCount -eq 0 ]
	    then
		echo "No hay procesos con PID=$input..."
		read k
	    else
		_ppid=$(ps --pid $input -o ppid | tail -1)
		ps --pid $input -o comm=Proceso,%cpu=CPU,%mem=RAM,euid=UID_Efectivo,ruid=UID_Real
		echo "1 para ver padre, 2 para ver hijos, 3 para salir"
		read k
		if [ "$(echo $k | grep -E "^[1-3]{1}$" | wc -l)" -eq 1 ]
		then
		    if [ $k -eq 1 ]
		    then
			ps --pid $_ppid -o comm=Proceso,%cpu=CPU,%mem=RAM,euid=UID_Efectivo,ruid=UID_Real
			echo "Enter para continuar..."
			read k
		    elif [ $k -eq 2 ]
		    then
			ps --ppid $input -o comm=Proceso,%cpu=CPU,%mem=RAM,euid=UID_Efectivo,ruid=UID_Real
			echo "Enter para continuar..."
			read k
		    fi
		fi
	    fi
	else
            echo "Proseso no encontrado" 
	fi
    done
}

function listaProcesos()
{
    echo -n "Desea ver procesos de todo el sistema (1), de un usuario (2), o detalles de un proceso (3)? "
    read input
    if [ $input -eq 1 ]
    then
	todosProcesos
    elif [ $input -eq 2 ]
    then
	procesosUsuario
    else
	detalleProceso
    fi
    read ff
}
