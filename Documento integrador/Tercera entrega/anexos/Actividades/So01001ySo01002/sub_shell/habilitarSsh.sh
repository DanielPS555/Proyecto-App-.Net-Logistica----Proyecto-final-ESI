#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
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
		#agregar el usuario a la lista de usuarios permitidos via ssh
		echo $usr >> /etc/ssh/allowed
	    else
		echo "El usuario ya tiene permisos via ssh."
		return
	    fi
		#actualizar la cfg de ssh
	    allowedToSshd
	else
	    return
	fi
    fi
}
