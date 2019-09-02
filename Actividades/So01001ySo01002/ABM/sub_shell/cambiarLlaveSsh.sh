#version 2 segunda entrega bit
function cambiarLlave()
{
    verifUser
    usr=$respuesta
    if test -z "$usr"
    then
	return
    fi
    uhome=$(getenv passwd $usr | cut -d: -f6)
    if ! test -f "$uhome/.ssh/authorized_keys"
    then
	echo "El usuario $usr no tiene una clave SSH configurada. Por favor utilice la función de _agregar_ clave ssh"
    else
        echo "Por favor, almacene la nueva clave publica del usuario en /tmp/pub_key-$usr.enc"
	read ff
	chown $usr:root /tmp/pub_key-$usr.enc
	chmod 640 /tmp/pub_key-$usr.enc
        sudoUserFunction $usr cambiarLlave_USER /tmp/pub_key-$usr.enc
    fi
}

function cambiarLlave_USER()
{
    echo -n "Sólo podrá cambiar su clave si posee la clave anterior. Desea continuar? [S/n] "
    read input
    if [ "$input" == "S" ];
    then
	head /dev/urandom | tr -dc A-Za-z0-9 | head -c10 > /tmp/pwd
	mypwd=$(cat /tmp/pwd)
	openssl rand -out /tmp/skey 32
	openssl aes-256-cbc -in /tmp/pwd -out /tmp/pwd.enc -pass file:/tmp/pwd
	openssl rsautl -encrypt -oaep -pubin -inkey <(ssh-keygen -e -f ~/.ssh/id_rsa.pub -m PKCS8) -in /tmp/skey -out /tmp/skey.enc
	rm /tmp/skey
	rm /tmp/pwd
	echo "Conectese via scp al servidor y copie los archivos '/tmp/{pwd.enc, skey.enc}' a su computadora."
	echo "Utilizando su clave privada, desencripte skey.enc. En OpenSSL, el comando es 'openssl rsautl -decrypt -oaep -inkey <archivo de clave privada> -in skey.enc -out skey'"
	echo "En 'skey' tendrá un archivo que utilizará como clave simétrica. Usando la misma, desencripte pwd.enc. En OpenSSL, el comando es 'openssl aes-256-cbc -d -in pwd.enc -out pwd.txt -pass file:skey'. En 'pwd.txt', tendrá una clave de 10 caracteres. Insértela a continuación para verificar que usted posee la clave privada actual."
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
