#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)

ConfiguracionDelAmbienteDeTrabajo() #Funcion encarga de la instalacion 
{	
    carpeta="/var" #La carpeta de instalacion sea /var
    ex=0
    if test -d $carpeta/DataConfiguracionABMusuariosSO || test $(echo $PATH | grep "/var/DataConfiguracionABMusuariosSO/"|wc -l) -eq 1 
    then
		echo "El sistema esta instalado, se prosede? (1= si 0=no)" #Si existe preguntamos si desea sobreescribir 
		read d		
		if test $d -eq 1 2> /dev/null #En caso que desde sobre escribir se prosedera con lo sigiente
		then
			desinstalar '1' #Elimina la insltalacion actual 
			ex=1		
		else
	    	echo "Operacion cancelada"	
		fi
    else
		ex=1
    fi

    if test $ex -eq 1 #Si desea sobrescribir o la carpeta no existe se prosesdera con la instalacion, de lo contrario se terminara la ejecucion de la funcion 
    then
		ruta=$(pwd) #guardamos en la variable ruta la direcion actual donde se ejecuto el setup de instalacion 
		cd $carpeta #Nos movemos a /var
		git clone https://github.com/Daniel2242014/DataConfiguracionABMusuariosSO
		unlink /sbin/bkupScript.sh 2> /dev/null
		ln -s /var/DataConfiguracionABMusuariosSO/backup_script.sh /sbin/bkupScript.sh
		ln -s /var/DataConfiguracionABMusuariosSO/updateULogs.sh /sbin/updateLogs.sh
		chmod u+x /sbin/bkupScript.sh /sbin/updateLogs.sh
		sed -i '/0 0 \* \* \* root bkupScript.sh/d' /etc/crontab
		sed -i '/0 0 \* \* \* root logrotate.*/d' /etc/crontab
		sed -i '/0 0 \* \* \* root updateLogs.sh/d' /etc/crontab
		echo "0 * * * * root bkupScript.sh" >> /etc/crontab
		echo "0 * * * * root updateLogs.sh" >> /etc/crontab
		cat > /etc/logrot.cfg <<EOF
/var/log/messages {
	rotate 4
	weekly
	postrotate /usr/bin/killall -HUP rsyslogd
	endscript
}

/var/log/btmp {
	rotate 4
	weekly
	endscript
}

/var/log/wtmp {
	rotate 4
	weekly
	endscript
}
EOF
		echo "0 0 * * * root logrotate /etc/logrot.cfg" >> /etc/crontab
		echo "" > /etc/ssh/allowed
		#Subido en la direcion url que se puede ver en la linea anterior se tiene subido todos los shell script y funciones nesesarias para el correcto funcionamiento de la ABM. De esta forma el usuario no debera tener todos los archivos, solamente el shell setup para la instalacion
		mv /var/DataConfiguracionABMusuariosSO/Titular.sh /etc/profile.d/Titular.sh #Mueve el titular a profile.d, de esta forma se ejecuta al inicio del sistema
		touch /etc/profile.d/z_ABMConfiguration.sh #Creamos un archivo de configuracion del PATH en /etc/profile.d
		echo "export PATH=$PATH:/var/DataConfiguracionABMusuariosSO/" > /etc/profile.d/z_ABMConfiguration.sh
		PATH="$PATH:/var/DataConfiguracionABMusuariosSO/" #cambia PATH, con SH no te permite hacerlo, por eso debe usar source el usuario 
		export PATH #Exporta PATH
		if ! test -d /var/respaldos
		then 
			mkdir /var/respaldos	
		fi
		if ! test -f /var/respaldos/master
		then 
			touch /var/respaldos/master	
		fi
		cd $ruta
		mkdir /var/DataConfiguracionABMusuariosSO/Temp #Creamos la carpeta Temp 
		if test $(grep -e "^Operario:" /etc/passwd| wc -l) -eq 0 # si el usuario operario existe 
		then
			useradd Operario 2> /dev/null #Este usuario se crea para el acceso de los operarios al sistema
			echo "ope_bit2019" | passwd --stdin Operario > /dev/null #Se le asigna la contraseña al operario
		fi


		if test $(grep -e "^Trasportista:" /etc/passwd| wc -l) -eq 0 #si el usuario trasportisa existe 
		then
			useradd Trasportista 2> /dev/null #Este usuario se crea para el acceso de los trasportista al sistema
			echo "tras_bit2019" | passwd --stdin Trasportista > /dev/null #Se le asigna la contraseña al trasportista
		fi	
		if test $(grep -e "^Administrador:" /etc/passwd| wc -l) -eq 0
		then
			useradd Administrador 2> /dev/null #Este usuario se crea para el acceso de los administradores al sistema 
			echo "admin_bit2019" | passwd --stdin Administrador > /dev/null #Se le asigna la contraseña al administrador
		fi
		chmod 700 /var/DataConfiguracionABMusuariosSO 	
		echo "Bienvenido al servidor del sistema SLTA" > /etc/issue #Cargamos issue para el aviso previo al logeo 
		echo "Ingrese su usuario y contraseña" >> /etc/issue


		verifMenu=-1

		source /var/DataConfiguracionABMusuariosSO/sub_shell/configurarRed.sh
		configurarRed
		echo "Desea eliminar FirewallD [0=no , 1=si]"
		read rr
		case $rr in
			1)
				systemctl stop firewalld
				systemctl disable firewalld
				yum remove firewall
			;;

			*)
				echo "No se prosede"
			;;
		esac

		echo "Desea eliminar NetworkManager [0=no , 1=si]"
		read rr
		case $rr in
			1)
				systemctl stop NetworkManager
				systemctl disable NetworkManager
				yum remove NetworkManager
			;;

			*)
				echo "No se prosede"
			;;
		esac
		yum install policycoreutils-python git
		yum install iptables-services 
		sed -i 's|IPTABLES_SAVE_ON_STOP="no"|IPTABLES_SAVE_ON_STOP="yes"|' /etc/sysconfig/iptables-config
		sed -i 's|IPTABLES_SAVE_ON_RESTART="no"|IPTABLES_SAVE_ON_RESTART="yes"|' /etc/sysconfig/iptables-config
		sed -i 's|IPTABLES_SAVE_COUNTER="no"|IPTABLES_SAVE_COUNTER="yes"|' /etc/sysconfig/iptables-config
		sed -i 's|IPTABLES_STATUS_NUMERIC="no"|IPTABLES_STATUS_NUMERIC="yes"|' /etc/sysconfig/iptables-config
		systemctl enable iptables
		systemctl start iptables
		chkconfig iptables
		semanage port -a -t ssh_port_t -p tcp 20022
		sed -i "s|#Port 22|Port 20022|" /etc/ssh/sshd_config
		systemctl restart sshd
	

		if ! test -d /opt/IBM
		then
			echo "¿Desea ademas instalar el gestor de base de datos Informix? [1=si, 0=no]"
			read ddd
			case $ddd in 
			1)
				source informix_install.sh 
			;;
			*)
				echo "No se prosedera"
			;;
			esac
			else
			echo "Informix ya esta instalado en el sistema"
		fi
		touch /var/DataConfiguracionABMusuariosSO/fire.data
		source /var/DataConfiguracionABMusuariosSO/lib/fireMod.sh
		fireMod1
		echo "Proseso terminado con exito, ejecute 'source setup.sh' desde la consola"
		echo "Se recomienda reiniciar el sistema" 
		read fff	
   fi
   
}


if test $(git --help 2>/dev/null | wc -l ) -ne 0
then
    if test $USER = "root" # Debe ser el usuario root quien utilice el shell 
    then
	if test $(echo $PATH | grep "/var/DataConfiguracionABMusuariosSO/"|wc -l) -eq 1 && ! test -f /etc/profile.d/z_ABMConfiguration.sh
	then
	    echo "El sistema ha sido eliminado utilizando setup llamado con el comando sh"
	    echo "Use el comando 'exit' para volver a ingresar al sistema y luego ejecute este software nuevamente"
	else
	    if ! test $(echo $PATH | grep "/var/DataConfiguracionABMusuariosSO/"|wc -l) -eq 1 &&  test -f /etc/profile.d/z_ABMConfiguration.sh
	    then
		echo "ha instalado el sistema sin usar source, salga y vuelva a ingresar al sistema"
	    else
		if [ -d "/var/DataConfiguracionABMusuariosSO" ] #revisa que este la ubicacion de la instalacion 
		then
			if test -f /var/DataConfiguracionABMusuariosSO/I_Inxo
			then
              source Informix_install2.sh 
			fi 
		    source /var/DataConfiguracionABMusuariosSO/adm_tool.sh
		else
		    echo "   _____________________________________________  "
		    echo "   |                                           | "
		    echo "   |        	    INSTALADOR                 | "
		    echo "   |    Centro de computos y Abm usuarios      | "
		    echo "   |                  por Bit                  | "
		    echo "   |                Vercion 3.0                | "
		    echo "   |___________________________________________| "
		    echo "" 
		    echo "debe instalar el softare para utilizarlo" 
		    echo "Desea comenzar el proseso de instalacion? (1= si 0=no)"
		    read de		
		    if test $de -eq 1 2> /dev/null #Comprueba que el dato ingresado sea 1
		    then
			ConfiguracionDelAmbienteDeTrabajo #se prosesde con la instalacion del sistema 
		    fi	
		fi
	    fi	
	fi
    else
	echo "Debe ser root para ejecutar este software"
    fi
else
    echo "Dbe tener instalado Git para utilizar este shell "
fi	
