#version 2 segunda entrega bit
function listarWtmp()
{
    echo -n "Inserte el usuario cuyos loggeos exitosos desea ver (o deje vacío para ver todos): "
    verifUser
    usr=$respuesta
    for i in $(ls /var/log/wtmp*); do
	last -f $i $usr | head -n -2 | less
    done
    read ff
}

function listarBtmp()
{
    echo -n "Inserte el usuario cuyos loggeos fallidos desea ver (o deje vacío para ver todos): "
    verifUser
    usr=$respuesta
    for i in $(ls /var/log/btmp*); do
	lastb -f $i $usr | head -n -2 | less
    done
    read ff
}
