#version 2 segunda entrega
function crearLlaveSsh()
{
    verifUser
    usr=$respuesta
    if test -z "$usr"
    then
	return
    fi
    uhome=$(getent passwd $usr | cut -d: -f6)
    if test -f "$uhome/.ssh/authorized_keys"
    then
	echo "Este usuario ya tiene una clave SSH configurada. Si desea cambiarla utilice la función cambiar llave."
    else
	echo -n "Inserte la nueva contraseña: "
	read -s pwd
	cd /tmp
	rm -rf *-$usr
	rm -rf *-$usr.*
	ssh-keygen -q -b 2048 -t rsa -N "$pwd" -f ./id_rsa-$usr
	mv id_rsa-$usr.pub pub_key-$usr.key
	mv id_rsa-$usr priv_key-$usr.key
	chmod 400 /tmp/priv_key-$usr.key
	chmod 400 /tmp/pub_key-$usr.key
	mkdir -p $uhome/.ssh
	cp /tmp/pub_key-$usr.key $uhome/.ssh/authorized_keys
	chown $usr:root $uhome/.ssh/authorized_keys
	chown $usr:root /tmp/pub_key-$usr.key
	chown $usr:root /tmp/priv_key-$usr.key
	chmod 644 $uhome/.ssh/authorized_keys
	echo "Clave pública instalada en ~$usr/.ssh/authorized_keys!"
	echo "Copie la llave pública y privada via scp en /tmp/"
	confrm="n"
	while [ "$confrm" != "y" ]
	do
	    echo -n "Confirme (y): "
	    read confrm
	done
	rm -f /tmp/priv_key-$usr.key /tmp/pub_key-$usr.key
    fi
}
