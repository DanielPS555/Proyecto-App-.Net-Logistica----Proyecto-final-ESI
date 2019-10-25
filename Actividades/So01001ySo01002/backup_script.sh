#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
source /var/DataConfiguracionABMusuariosSO/lib/backup_functions.sh

if [ ! -d /var/respaldos ]
then
    mkdir /var/respaldos
    crearTotal
else	
    if test $(date -d"$(grep ':T:' /var/respaldos/master|tail -n1|cut -d: -f3)" +%s) -lt $(date -d"$(date +"%Y-%m-%d")" +%s) #Se evalua que el anteior Total haya sido el dia anterior, aunque la intencion sea que se realice a la 00:00 horas, si la PC esta apagada a dicha hora no se realizara, por lo tanto apenas se llame este shell se realizara un total en el caso que no se haya realisado ninguno este dia.
    then
	crearTotal
    else
        crearIncremental
    fi		

fi

echo "Se creó el backup "
