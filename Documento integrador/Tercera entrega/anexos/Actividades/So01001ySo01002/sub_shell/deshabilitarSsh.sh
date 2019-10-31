#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
function deshabilitarSsh()
{
    echo "Usuarios que tienen permisos ssh:"
    cat /etc/ssh/allowed
    echo "Si desea deshabilitar un usuario, ingrese su nombre: "
    verifUser allowRoot
    usr=$respuesta
    if [ -n "$usr" ]
    then
	pattern="/$usr/d"
	echo $pattern
    #eliminar la linea con el nombre del usuario
	sed -i $pattern /etc/ssh/allowed
    #actualizar la cfg de ssh
	allowedToSshd
    fi
}
