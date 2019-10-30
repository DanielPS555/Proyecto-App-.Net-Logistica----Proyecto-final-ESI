#!/bin/bash
#VERCION 3.0 - 1/11 TERCERA ENTREGA desarrolado por Bit (3°BD 2019)
reinicioExterior()
{
 if systemctl restart $1
    then
	echo "Servicio reiniciado"
    else
	echo "Error desconocido: $?"
 fi
}

function desactivarServicio()
{
    if systemctl disable $nombre
    then
	echo "Servicio desactivado"
    else
	echo "Error desconocido: $?"
    fi
    read a
}

function activarServicio()
{
    if systemctl enable $nombre
    then
	echo "Servicio activado"
    else
	echo "Error desconocido: $?"
    fi
    read a
}

function correrServicio()
{
    if systemctl start $nombre
    then
	echo "Servicio iniciado"
    else
	echo "Error desconocido: $?"
    fi
    read a
}

function reiniciarServicio()
{
    if systemctl restart $nombre
    then
	echo "Servicio reiniciado"
    else
	echo "Error desconocido: $?"
    fi
    read a
}

function pararServicio()
{
    if systemctl stop $nombre
    then
	echo "Servicio parado"
    else
	echo "Error desconocido: $?"
    fi
    read a
}

#ver via journalctl los mensajes correspondientes a la unidad del servicio
#automaticamente sale via less
function mensajesServicio()
{
    journalctl -xe --unit=$nombre
    read a
}

#buscar y afectar un servicio
function buscarServicio() # Muestra y busca servicios 
{
conff=0
while test $conff -eq 0
do 
    echo  "Ingrese el Id del servicio a buscar (ingrese 'help' para ver id de cada servicio). No ingrese nada para salir"
    read sname

	if test -z $sname
	then
	 return 	
	fi

 	if test $(echo $sname|grep -xi "help")
	then
	   vertodosLosservicios
	fi

	if  test $(echo $sname | grep -E "^[0-9]{1,9}$"|wc -l) -eq 0
	then
	    echo "Debe ser un número"

	else
		numero=$(systemctl list-unit-files --state=enabled,disabled | tail -n +2 | head -n -2 | cut -d' ' -f1 | grep -vE "target|@"|wc -l)
		if test $sname -gt $numero || test $sname -lt 1
		then 
			echo "Id incorrecto"
		else
			nombre=$(systemctl list-unit-files --state=enabled,disabled | tail -n +2 | head -n -2 | cut -d' ' -f1 | grep -vE "target|@" | head -n$sname | tail -n1)
			 state=$(systemctl status $nombre | grep "Loaded" | cut -d' ' -f7 | tr -d ';')
			 activ=$(systemctl status $nombre | grep "Active" | cut -d' ' -f6 | tr -d '()')
			 echo "$nombre": $state $activ
			 nombres_s1=("Activar", "Desactivar", "Correr", "Detener", "Ver_Mensajes" "Reiniciar")
			 direcciones_s1=(activarServicio desactivarServicio correrServicio pararServicio mensajesServicio reiniciarServicio)
			 menu "nombres_s1[@]" "direcciones_s1[@]"
			 conff=1

		fi
	fi



   
done
}

vertodosLosservicios()
{
	touch $carpetaBase/Temp/listar #Crea la lista temp 
	cont=1        
	systemctl list-unit-files --state=enabled,disabled | tail -n +2 | head -n -2 | cut -d' ' -f1 | grep -vE "target|@"| while read vart
	do
	echo "$cont)$vart" >> $carpetaBase/Temp/listar
	cont=$[$cont+1]
	done
	echo "Ingrese 'q' para salir"
	less $carpetaBase/Temp/listar #Muestra la lista temp 
	rm -f $carpetaBase/Temp/listar #elimina la lista 

}

function estadoServicios()
{
    vertodosLosservicios
}
