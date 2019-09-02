#version 2 segunda entrega bit
function habilitarSsh()
{
    if ! [ -f "/etc/ssh/allowed" ]
    then
	touch /etc/ssh/allowed
    fi
    echo "Usuarios con permiso por ssh: "
    cat /etc/ssh/allowed
    echo -n "Desea agregar un usuario? (y/N): "
    read conf
    if [ "$conf" == "y" ]
    then
	echo -n "Nombre del usuario que quiere autorizar: "
	verifUser allowRoot
	usr=$respuesta
	if [ -n $usr ]
	then
	    if [ $(grep $usr /etc/ssh/allowed | wc -l) -eq 0 ]
	    then
		echo $usr >> /etc/ssh/allowed
	    else
		echo "El usuario ya tiene permisos via ssh."
		return
	    fi
	    allowedToSshd
	else
	    return
	fi
    fi
}
