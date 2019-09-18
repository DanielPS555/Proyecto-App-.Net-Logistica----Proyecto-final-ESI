#!/bin/bash
#VERCION 3.0 - 25/10 TERCERA ENTREGA desarrolado por Bit (3°BD 2019)

actualizarBBDD()
{
    j=0
    for nom in $(cat /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias)
    do 
        if test $(dbschema -d $nom| grep "^*Database not found*$"|wc -l) -gt 0 
        then 
            sed -i '/$nom/d' /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias
        fi
    done

}

comrpobarBBDD()
{
    if [$(dbschema -d $1| grep "^*Database not found*$"|wc -l) -gt 0 ]
        then 
            respuesta=0
        else
            respuesta=1
        fi

}

persistirBBDD() #ME TIENE QUE PASAR LA RUTA DONDE QUIERE QUE LE MANDE LOS ARCHIVOS 
{
    actualizarBBDD #Actualizo los datos de la lista de BBDD para asegurar congruencia
    if test $(cat /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias| wc -l) -eq 0
    then
        echo "SIN BASE DE DATOS QUE RESPALDAR"
    else
        ruta=$(pwd)
        mkdir $1
        cd $1
        for nom in $(cat /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias)
        do 
            echo "Respaldado la base de datos $nom"
            dbexport $nom > /dev/null 
        done
        cd $ruta
    fi

}
