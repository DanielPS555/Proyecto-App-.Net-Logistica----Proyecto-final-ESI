#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
function crearTotal()
{
	source /var/DataConfiguracionABMusuariosSO/lib/fireMod.sh
    fireMod0 '1'
    source /var/DataConfiguracionABMusuariosSO/lib/FuncionesBBDD.sh
    if ! [ -d "/var/respaldos" ] #Si la carpeta de los respaldos no existe la creamos 
    then
       mkdir /var/respaldos
       touch /var/respaldos/master
    fi
    if ! [ -d "/var/respaldos/master" ] #Si la carpeta de los respaldos no existe la creamos 
    then
       touch /var/respaldos/master
    fi

    nm=$(echo "$[$(grep ":T:" /var/respaldos/master| wc -l)+1]") #Nos devuleve el numero del respaldo total 
    mkdir /var/respaldos/T$nm #Creamos la carpeta de este total

    #Creamos la carpeta y comprimimos
     echo "Comprimiendo...."
    if test -d /opt/IBM/Informix_Software_Bundle/
    then
        persistirBBDD "/var/respaldos/T$nm/informix"
        tar -cvzf /var/respaldos/T$nm/T$nm.tgz -g /var/respaldos/T$nm/T$nm.snar /var/respaldos/T$nm/informix var/log/btmp.* var/log/wtmp.* var/log/messages.* /home > /dev/null #Creo el Tar con los datos
        #rm -rf "/var/respaldos/T$NumeroMaster/informix"
    else
        tar -cvzf /var/respaldos/T$nm/T$nm.tgz -g /var/respaldos/T$nm.snar var/log/btmp.* var/log/wtmp.* var/log/messages.* /home > /dev/null  #Creo el Tar con los datos
    fi
    sed -i 's/^\(.*\):ACTUAL:\(.*\)$/\1:ANTERIOR:\2/' /var/respaldos/master
    echo "T$nm:T:$(date +"%Y-%m-%d %H:%M:%S"):ACTUAL:" >> /var/respaldos/master
	fufu=$(cat /var/DataConfiguracionABMusuariosSO/fire.data)
			case $fufu in
			0) 
				fireMod0
			;;

			1)
				fireMod1
			;;

			2)
				fireMod2
			;;

			esac
}

function totalManual2()
{
    crearTotal;
    echo "Total creado"
    read k
}

function diferencialManual()
{
    crearDiferencial;
    echo "Diferencial creado:"
    read k
}

function crearIncremental()
{
	source /var/DataConfiguracionABMusuariosSO/lib/fireMod.sh
    fireMod0 '1'
    source /var/DataConfiguracionABMusuariosSO/lib/FuncionesBBDD.sh
     if ! test -f /var/respaldos/master || test $(grep ":ACTUAL:" /var/respaldos/master| wc -l ) -eq 0
	then 
		echo "Error, primero cree un total" 
		return 
	fi

	dep=$(grep ":ACTUAL:" /var/respaldos/master| cut -d: -f1) #Nos devuelve el nombre del respaldo total del que depende
	Nate=$(grep ":$dep:" /var/respaldos/master| wc -l) #Nos devuelve el numero de respaldos incrementales que tiene como depedencia al anterior roal   
	if test -d /opt/IBM/Informix_Software_Bundle/
        then
		persistirBBDD "/var/respaldos/$dep/informixTemp"
		for i1 in $(ls /var/respaldos/$dep/informixTemp)
		do
			if test -d /var/respaldos/$dep/informixTemp/$i1
			then

				for i2 in $(ls /var/respaldos/$dep/informixTemp/$i1)
				do
					if test -e /var/respaldos/$dep/informix/$i1/$i2 && test $(diff /var/respaldos/$dep/informixTemp/$i1/$i2 /var/respaldos/$dep/informix/$i1/$i2 | wc -l) -eq 0
					then 
						rm -f /var/respaldos/$dep/informixTemp/$i1/$i2
					else
						if test ! -d /var/respaldos/$dep/informix/$i1
						then 
							mkdir /var/respaldos/$dep/informix/$i1
						fi
						'cp' -af /var/respaldos/$dep/informixTemp/$i1/$i2 /var/respaldos/$dep/informix/$i1/$i2
					fi 
				done
				
			else
				if test -e /var/respaldos/$dep/informix/$i1 && test $(diff /var/respaldos/$dep/informixTemp/$i1 /var/respaldos/$dep/informix/$i1| wc -l) -eq 0
				then 
					rm -f /var/respaldos/$dep/informixTemp/$i1
				else
					'cp' -af /var/respaldos/$dep/informixTemp/$i1 /var/respaldos/$dep/informix/$i1
				fi 
			fi
 
		if test -d /var/respaldos/$dep/informixTemp/$i1 && test $(ls /var/respaldos/$dep/informixTemp/$i1| wc -l) -eq 0
		then
			rm -rf /var/respaldos/$dep/informixTemp/$i1
		fi

		done
		tar -cvzf /var/respaldos/$dep/I$Nate-$dep.tgz -g /var/respaldos/$dep/$dep.snar /var/respaldos/$dep/informixTemp/ var/log/btmp.* var/log/wtmp.* var/log/messages.* /home > /dev/null #Creo el Tar con los datos
		rm -rf /var/respaldos/$dep/informixTemp/
	else
		tar -cvzf /var/respaldos/$dep/I$Nate-$dep.tgz -g /var/respaldos/$dep/$dep.snar var/log/btmp.* var/log/wtmp.* var/log/messages.* /home > /dev/null #Creo el Tar con los datos
	fi
    
    	echo "I$Nate-$dep:I:$(date +"%Y-%m-%d %H:%M:%S"):$[$Nate+1]:$dep:" >> /var/respaldos/master
		fufu=$(cat /var/DataConfiguracionABMusuariosSO/fire.data)
			case $fufu in
			0) 
				fireMod0
			;;

			1)
				fireMod1
			;;

			2)
				fireMod2
			;;

			esac
  }  

function incrementalManual2()
{
    crearIncremental
    echo "Incremental creado"
    read k
}
