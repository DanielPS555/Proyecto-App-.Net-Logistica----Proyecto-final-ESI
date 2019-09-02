function allowedToSshd()
{
	au="AllowUsers"
	while read usr; do
	    au=$(echo $au $usr)
	done < /etc/ssh/allowed
	if [ $(grep AllowUsers /etc/ssh/sshd_config | wc -l) -eq 0 ]
	then
	    echo $au >> /etc/ssh/sshd_config
	else
	    sed -i "/AllowUsers/c\\$au" /etc/ssh/sshd_config
	fi
	echo "Debe reiniciar el servicio ssh para que la configuración tome validez"
	echo "Desea realizarlo ahora [1=si / 0=no]"
	read r
	case $r in
		1)
			systemctl restart sshd
			echo "Proseso reiniciado" 
		;;

		*)
			echo "No se reiniciara"
		;;	

	esac
	echo "Ingrese cualquier tecla para continuar"
	read fff
}

