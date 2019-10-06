#!/bin/bash
#VERCION 3.0 - 25/10 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)

sendless()
{
	echo "Se listaran todos los prosesos, ingrese 'q' para salir de la lista"
	echo "Ingrese cualquier boton para salir" 
	read fff
}

function todosProcesos()
{
    sendless			
    ps axo uid,pid,ppid,stime,time,cmd | less
}

function procesosUsuario()
{
    respuesta="a"
    while [ "$respuesta" != "" ]
    do
	verifUserTODO
	if [ "$respuesta" != "" ]
	then
	    pCount=$(ps -U "$respuesta" -o pid,comm=Proceso | wc -l)
	    if [ $pCount -eq 1 ]
	    then
		echo "No hay procesos abiertos por el usuario $respuesta"
	    else
		sendless
		ps -U "$respuesta" -o pid,comm=Proceso | less
	    fi
	fi
    done
}

function detalleProceso()
{
	echo -n "Inserte un número de PID (Vacio para salir): "
	read input
	if test -z $input 2>/dev/null
	then
		echo "Cancelado, toque enter para continuar"		
		return 
	fi
	
	verificarPID $input
	
	if test $? -eq 1
	then
		ps --pid $input -o comm=Proceso,%cpu=CPU,%mem=RAM,pid=PID,ppid=PPID
		ddd=1			
		while test $ddd -ne 0
		do 
			echo "Para ver los hijos (1), para ver el padre (2), para eliminarlo (3), para salir ingrese enter"
			read ddd
			if test -z $ddd
			then
				echo "Saliendo" 
				return
			fi 
			case $ddd in 
			1) 
				ComprobarEHijo $input 
				if test $? -eq 1 
				then
					devolverHijos $input
				else
					echo "No hay hijos para este proseso"
				fi	
			;;	

			2)
				ComprobarEPadre $input 
				if test $? -eq 1 
				then
					devolverPadre $input
					ente=1
				else
					echo "No hay padres para este proseso"
				fi	
			;;

			3)
				if ! kill -p $input
				then
				  echo "No se pudo matar al proceso $input"
				else
				  echo "Proceso $input tumbado con éxito"
				fi
			;;
		
			esac 	
		done	

	else 
		echo "Error: El proseso cuyo pid es $input no existe"
	fi	
	
}



verificarPID()
{
     if test $(ps axo pid | grep  " $1$"|wc -l) -eq 0
	then
		return 0
	else
		return 1
	fi

}

devolverHijos()
{
	sendless
  	ps --ppid $1 -o comm=Proceso,%cpu=CPU,%mem=RAM,pid=PID,ppid=PPID|less 
}

ComprobarEHijo()
{
	if test $(ps --ppid $1 -o pid=PID 2> /dev/null| wc -l) -gt 1
	then
		return 1
	else
		return 0
	fi 
}

ComprobarEPadre()
{
	if test $(ps --pid $(ps --pid $1 -o ppid=PPID 2> /dev/null| tail -n1 | sed "s/^[ ]*\(.*\)$/\1/"|tail -n1) -o pid=PID 2> /dev/null | wc -l) -gt 1
	then
		return 1
	else
		return 0
	fi 
}

devolverPadre()
{
	sendless
	ps --pid $(ps --pid $1 -o ppid=PPID | tail -n1 | sed "s/^[ ]*\(.*\)$/\1/"|tail -n1) -o comm=Proceso,%cpu=CPU,%mem=RAM,pid=PID,ppid=PPID|less
}


function listaProcesos()
{
	heh=0
    	while test $heh -eq 0
	do
		echo "1) Ver todos los prosesos"
		echo "2) Panel de informacion completa por PID"
		echo "3) Bucar por nombre de Usuario"
		echo "4) Buscar hijos por PID de padre"
		echo "5) Buscar padre por PID de Hijo"
		echo "0) Salir"	
		read data
		case $data in
			1)	
				todosProcesos
			;;
			2)
				detalleProceso
			;;
			3)
				procesosUsuario
			;;
			4)
				ente=0
				while test $ente -eq 0
				do
					echo "Ingrese el PID del proseso a buscar - Nada para salir"
					read entrada
					if test -z $entrada
					then
						ente=1
					else
						if test $(echo $entrada|grep -e "^[1-9][0-9]*$"| wc -l) -eq 1 || test $(echo $entrada|grep -e "^[0-9]$"| wc -l) -eq 1 
						then
							verificarPID $entrada
							if test $? -eq 1
							then
								ComprobarEHijo $entrada 
								if test $? -eq 1 
								then
									devolverHijos $entrada
								else
									echo "No hay hijos para este proseso"
								fi	
							else
								echo "Error: PID no encontrado"
							fi
						else					
							echo "Error: Formato invalido"
						fi		 
					fi
				done
			;;
			5)
				ente=0
				while test $ente -eq 0
				do
					echo "Ingrese el PID del proseso a buscar - Nada para salir"
					read entrada
					if test -z $entrada
					then
						ente=1
					else
						if test $(echo $entrada|grep -e "^[1-9][0-9]*$"| wc -l) -eq 1 || test $(echo $entrada|grep -e "^[0-9]$"| wc -l) -eq 1 
						then
							verificarPID $entrada
							if test $? -eq 1
							then
								ComprobarEPadre $entrada 
								if test $? -eq 1 
								then
									devolverPadre $entrada
									ente=1
								else
									echo "No hay padres para este proseso"
								fi	
							else
								echo "Error: PID no encontrado"
							fi
						else					
							echo "Error: Formato invalido"
						fi
					fi		 
				done
			
			;;

			0)
				heh=1
			;;

			*)
				echo "Entrada incorrecta"
			;;
		esac 

	done
}
