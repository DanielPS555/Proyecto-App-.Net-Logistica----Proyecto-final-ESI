#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
function listarWtmp()
{
    echo -n "Inserte el usuario cuyos loggeos exitosos desea ver (o deje vacío para ver todos): "
    verifUser
    usr=$respuesta
    echo "Para salir de la sigiente lista ingrese 'q'. Para continuar ingrese cualquier tecla"
    read fff
    for i in $(ls /var/log/wtmp*); do
	    last -f $i $usr | head -n -2 | less #Lista los logs corespondientes 
    done
}

function listarBtmp()
{
    echo -n "Inserte el usuario cuyos loggeos fallidos desea ver (o deje vacío para ver todos): "
    verifUser
    usr=$respuesta
    echo "Para salir de la sigiente lista ingrese 'q'. Para continuar ingrese cualquier tecla"
    read fff
    for i in $(ls /var/log/btmp*); do
	    lastb -f $i $usr | head -n -2 | less less #Lista los logs corespondientes 
    done
}
