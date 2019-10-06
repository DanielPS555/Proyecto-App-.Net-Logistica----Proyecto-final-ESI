#!/bin/bash
#VERCION 3.0 - 25/10 TERCERA ENTREGA desarrolado por Bit (3°BD 2019)

menuFirewall()
{
	source /var/DataConfiguracionABMusuariosSO/lib/fireMod.sh
	firemenu=0
	while test $firemenu -eq 0 
	do
		echo "1) Ver estado del firewall"
		echo "2) Cambiar modo 0"
		echo "3) cambiar a modo 1"
		echo "4) Cambiar a modo 2"
		echo "0) Salir"
		read fireEntrada

		case $fireEntrada in
		1)
			fufu=$(cat /var/DataConfiguracionABMusuariosSO/fire.data)
			case $fufu in
			0) 
				echo "Modo 0, todos los puertos estan abiertos, SIN PROTECION"
			;;

			1)
				echo "Modo 1, solamente SSH(20022) activo , NO GIT NI INFORMIX"
			;;

			2)
				echo "Modo 2, solamente SSH(20022) y ODBC(9088) activos , NO GIT"
			;;

			esac
		;;

		2)
			if test $(cat /var/DataConfiguracionABMusuariosSO/fire.data) -ne 0
			then
				fireMod0
			else
				echo "Ya esta este modo activo"
			fi
		;;

		3)
			if test $(cat /var/DataConfiguracionABMusuariosSO/fire.data) -ne 1
			then
				fireMod1
			else
				echo "Ya esta este modo activo"
			fi
		;;

		4)
			if test $(cat /var/DataConfiguracionABMusuariosSO/fire.data) -ne 2
			then
				fireMod2
			else
				echo "Ya esta este modo activo"
			fi
		;;


		0)
			firemenu=1
		;;

		esac

	done


}


