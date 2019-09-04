#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
function cambiarLlave()
{
    verifUser # usuario cuya clave será cambiada
    usr=$respuesta
    if test -z "$usr"
    then
	return
    fi
    uhome=$(getent passwd $usr | cut -d: -f6) # obtenemos su carpeta via getent
    if ! test -f "$uhome/.ssh/authorized_keys" # Debemos crear una clave para cambiarla
    then
		echo "El usuario $usr no tiene una clave SSH configurada. Por favor utilice la función de _agregar_ clave ssh"
    else
        echo "Por favor, almacene la nueva clave publica del usuario en /tmp/pub_key-$usr.enc"
	read ff
	chown $usr:root /tmp/pub_key-$usr.enc
	chmod 640 /tmp/pub_key-$usr.enc
    sudoUserFunction $usr cambiarLlave_USER /tmp/pub_key-$usr.enc # Ejecuta la función como ese usuario
    fi
}


# El mambo viene así:
# Primero le pedimos al usuario que nos envíe la clave pública de la nueva llave
# que quiere autorizar para su acceso ssh
# La misma deberá ser generada en el cliente, via ssh o via puttygen
# luego generamos un string aleatorio de 10 caracteres
# al cual encriptamos con su clave pública actual
# se la hacemos disponible en /tmp
# el usuario deberá desencriptar el string con su clave privada actual y devolvernos el string desencriptado
# y si es correcto, autorizamos su clave
function cambiarLlave_USER()
{
    echo -n "Sólo podrá cambiar su clave si posee la clave anterior. Desea continuar? [S/n] "
    read input
    if [ "$input" == "S" ];
    then
	# generar el string
	head /dev/urandom | tr -dc A-Za-z0-9 | head -c10 > /tmp/pwd
	mypwd=$(cat /tmp/pwd)
	# clave asimétrica de 32 bytes
	openssl rand -out /tmp/skey 32
	# encriptamos el string con dicha clave
	openssl aes-256-cbc -in /tmp/pwd -out /tmp/pwd.enc -pass file:/tmp/pwd
	# encriptamos la clave asimétrica con la clave privada de la llave simétrica actual del usuario
	openssl rsautl -encrypt -oaep -pubin -inkey <(ssh-keygen -e -f ~/.ssh/id_rsa.pub -m PKCS8) -in /tmp/skey -out /tmp/skey.enc
	# eliminamos los archivos sin encriptar
	rm /tmp/skey
	rm /tmp/pwd

	echo "Conectese via scp al servidor y copie los archivos '/tmp/{pwd.enc, skey.enc}' a su computadora."
	echo "Utilizando su clave privada, desencripte skey.enc. En OpenSSL, el comando es"
	echo "'openssl rsautl -decrypt -oaep -inkey <archivo de clave privada> -in skey.enc -out skey'"
	echo "En 'skey' tendrá un archivo que utilizará como clave simétrica. Usando la misma, desencripte pwd.enc. En OpenSSL, el comando es "
	echo "'openssl aes-256-cbc -d -in pwd.enc -out pwd.txt -pass file:skey'."
	echo "En 'pwd.txt', tendrá una clave de 10 caracteres. Insértela a continuación para verificar que usted posee la clave privada actual."
	echo -n "Clave de 10 caracteres: "

	read -s pass
	if [ "$pass" == "$mypwd" ];
	then
	    echo "Clave verificada con éxito"
	    cp $1 ~/.ssh/authorized_keys
	    chmod 644 ~/.ssh/authorized_keys
	else
	    echo "No pudo validarse la clave."
	fi
    fi
}
