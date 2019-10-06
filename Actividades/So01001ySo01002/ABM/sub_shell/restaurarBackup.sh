#!/bin/bash
#VERCION 3.0 - 25/9 Tercera ENTREGA desarrolado por Bit (3°BD 2019)

restaturarReal()
{
	source /var/DataConfiguracionABMusuariosSO/lib/fireMod.sh
         fireMod0 '1'
	depen=""
	if test $(echo $texto|grep ":I:" | wc -l) -eq 1
	then
 		numOrden=$(echo $texto| cut -d: -f6)
		depen=$(echo $texto| cut -d: -f7)
		mkdir /var/respaldos/$depen/desTemp
		tar -xzvf /var/respaldos/$depen/$depen.tgz -C /var/respaldos/$depen/desTemp
		cat /var/respaldos/master| grep ":$depen:"| while read nana
		do
			if test $numOrden -ge $(echo $nana| cut -d: -f6) 
			then
				noo=$(echo $nana| cut -d: -f1)
				if ! test -e /var/respaldos/$depen/$noo.tgz
				then
					rm -rf /var/respaldos/$depen/desTemp
					echo "ERROR no se encuentra el documento /var/respaldos/$depen/$noo.tgz"
					return 
				fi
				tar -xzvf /var/respaldos/$depen/$noo.tgz -C /var/respaldos/$depen/desTemp
			fi
		done
		'cp' -af /var/respaldos/$depen/desTemp/home/* /home/ #Envio Informacion a Home
		'cp' -af /var/respaldos/$depen/desTemp/var/respaldos/$depen/informixTemp/* /var/respaldos/$depen/desTemp/var/respaldos/$depen/informix/
		restaurarBBDD "/var/respaldos/$depen/desTemp/var/respaldos/$depen/informix/"
		rm -rf /var/respaldos/$depen/desTemp
	else
		depen=$(echo $texto| cut -d: -f1)
		mkdir /var/respaldos/$depen/desTemp
		tar -xzvf /var/respaldos/$depen/$depen.tgz -C /var/respaldos/$depen/desTemp
		'cp' -af /var/respaldos/$depen/desTemp/home/* /home/ #Envio Informacion a Home
		restaurarBBDD "/var/respaldos/$depen/desTemp/var/respaldos/$depen/informix/"
		rm -rf /var/respaldos/$depen/desTemp
	fi
	
	sed -i 's/^\(.*\):ACTUAL:\(.*\)$/\1:ANTERIOR:\2/' /var/respaldos/master
	sed -i "s/^\($depen:.*\):A.*:\(.*\)$/\1:ACTUAL:\2/" /var/respaldos/master
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
	echo "Se ha restaurado de forma exitosa, ANTENCION: solo se modificaron los archivos que no estaba en el sistema pero si en el Backup y los comunes entre ellos dos. Las Base de datos y documentos que no se encontraban en los respaldos no se modificaron" 
	read kkk
}

restaurarBBDD()
{
	source /var/DataConfiguracionABMusuariosSO/lib/FuncionesBBDD.sh
	ruu=$(pwd)
	cd $1
	ls | grep ".*.exp$" | sed "s/^\(.*\).exp$/\1/" | while read je
							do
								comrpobarBBDD $je
								if test $respuesta -eq 0
								then
									eliminarBBDD $je
								fi
								dbimport $je -d rootdbs >/dev/null #Deveriamos poner DATOSDBS luego 
							done
	cd $ruu
}

restaurar2()
{
	if ! test -d /var/respaldos || ! test -f /var/respaldos/master || test $(cat /var/respaldos/master| wc -l) -eq 0
	then
		echo "Error: Sin informacion que mostrar. Por favor cree algun respaldo total"
		read fff
		return 
	fi
	source /var/DataConfiguracionABMusuariosSO/sub_shell/listarBackups.sh
	gtg=0
	while test $gtg -eq 0
	do
		numMax=$(cat /var/respaldos/master| wc -l)
		echo "Ingrese el numero del backup que desea restaurar. Entre (1 y $numMax)"
		echo "Para mostrarlos por favor ingrese 'help'. NO INGRESE NADA PARA SALIR"
		read data
		if test $(echo $data| grep -xi "help"| wc -l) -eq 1
		then
			listaReal
		elif test -z $data
		then
			gtg=1

		else
			if test $(echo "$data" | grep "^[1-9][0-9]*$"| wc -l) -gt 0
			then
				if test $data -gt 0 && test $data -le $numMax
				then
					texto=$(head -n$data /var/respaldos/master| tail -n1)
					nomBack=$(head -n$data /var/respaldos/master| tail -n1 | cut -d: -f1)
					echo "Confirmacion:"
					echo "Nombre $nomBack"
					if test $(echo $texto |cut -d: -f2|grep -xi "T"| wc -l) -eq 1
					then
						echo "Tipo: Total"
					else
						echo "Tipo: Incremental"
					fi
					echo "Fecha: $(echo $texto| cut -d: -f3,4,5)"
					echo "¿Confirma? [1=si 0=no]"
					read de						
					case $de in 
					1)
						restaturarReal $texto	
					;;

					*)
						echo "Operacion cancelada"
						
					;;
					esac
					gtg=1
				else
					echo "El id del backup elegido debe estar dentro del rango antes dicho"
				fi
			else
				echo "El Id elegido debe ser numerico y no negativo"
			fi  
		fi
	done
	

}
