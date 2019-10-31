#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
desinstalar()
{
		#Subido en la direcion url que se puede ver en la linea anterior se tiene subido todos los shell script y funciones nesesarias para el correcto funcionamiento de la ABM. De esta forma el usuario no debera tener todos los archivos, solamente el shell setup para la instalacion
		
		source /var/DataConfiguracionABMusuariosSO/lib/fireMod.sh 		
		fireMod0

		semanage port -d -t ssh_port_t -p tcp 20022
		sed -i "s|Port 20022|#Port 22|" /etc/ssh/sshd_config		
		
		if test -d /var/DataConfiguracionABMusuariosSO/
		then
			rm -rf /var/DataConfiguracionABMusuariosSO/ #Eliminamos el directorio donde esta instalado el software
		fi		
		if test -f /etc/profile.d/z_ABMConfiguration.sh
		then
			rm -f /etc/profile.d/z_ABMConfiguration.sh #eliminamo el archivo de configuracion del PATH
		fi
	
		if test -f /etc/profile.d/Titular.sh
		then
			rm -f /etc/profile.d/Titular.sh #se elimina el titular 
		fi

		PATH=$(echo $PATH | sed -e 's/:\/var\/DataConfiguracionABMusuariosSO\///g') #Elimina la ublicacion de la inlstalacion del path 
		export PATH
		if test $(grep -e "^Operario:" /etc/passwd| wc -l) -eq 1 # si el usuario operario existe 
 		then
			userdel Operario 2> /dev/null #Elimina al operario si exsiste 
		fi

		if test $(grep -e "^Trasportista:" /etc/passwd| wc -l) -eq 1 #si el usuario trasportisa existe 
		then
			userdel Trasportista 2> /dev/null #Elimina al trasportista si exsiste 
		fi	

		if test $(grep -e "^Administrador:" /etc/passwd| wc -l) -eq 1
		then
			userdel Administrador 2> /dev/null #Elimina al administrador si exsiste 
		fi

		echo "\S" > /etc/issue
		echo "Kernel \r on an \m" >> /etc/issue	#Cargamos el contenido por defecto 

		sed -i '/0 * * * * root bkupScript.sh/d' /etc/crontab
		sed -i '/0 0 * * * root logrotate /etc/logrot.cfg/d' /etc/crontab		
		
		if test -d /opt/IBM
		then 
		echo "Usted desea eliminar Informix [1=si 0=no]"
		read d 
		case $d in 
		1)
			eliminacionRealInformix
		;;

		*)
		echo "No se eliminara"
		;;
		
		esac
	fi

	if test -z $1
		then 
			echo "Proseso terminado con exito"	
			read f
			verifMenu=-1
		fi	
}
