#!/bin/bash
#VERCION 3.0 - 25/10 TERCERA ENTREGA desarrolado por Bit (3°BD 2019)

actualizarBBDD()
{
    j=0
    for nom in $(cat /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias)
    do 
        if test $(dbschema -d $nom| grep "^.*Database not found.*$"|wc -l) -eq 1 
        then 
            sed -i "/$nom/d" /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias
        fi
    done

}

comrpobarBBDD()
{
    if test $(dbschema -d $1| grep "^.*Database not found.*$"|wc -l) -eq 0 
        then 
            respuesta=0
        else
            respuesta=1
        fi

}

eliminarBBDD()
{
	echo "drop database $1" | dbaccess - - >/dev/null
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

editarBBDDPermitidas()
{
	echo "Actualizado lista"
	actualizarBBDD
	hhg=0
	while test $hhg -eq 0
	do
		echo "1) Listar base de datos"
		echo "2) Nueva BBDD a respaldar"
		echo "3) Eliminar BBDD"
		echo "0) Salir"
		read data
		case $data in
		1)
			echo "Ingrese q para salir de la lista, para ingresar a ella toque cualquier tecla"
			less /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias
		;;

		2)
			echo "Ingrese el nombre de la BBDD"
			read de
			comrpobarBBDD $de
			if test $respuesta -eq 1
			then
				echo "Error: la base de datos no existe"
			else
				if test $(cat /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias| grep -xi "$de"| wc -l) -eq 0
				then
					echo $de >> /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias
				else
					echo "Error: la base de datos ya fue agregada a este documento"
				fi
			fi
		;;

		3)
			echo "Ingrese el nombre de la BBDD a eliminar de la lista de futuros respaldos"
			read de 
			if test $(cat /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias| grep -xi "$de"| wc -l) -eq 1
			then
				sed -i "/$de/d" /var/DataConfiguracionABMusuariosSO/Registro/DataBaseNesesarias
			else
				echo "Error: no hay ninguna base de datos en la lista con ese nombre "
			fi
			
		;;


		0)
			hhg=1
		;;

		*)
			echo "Error: Opcion incorrecta" 
		;;

		esac	


	done
}
