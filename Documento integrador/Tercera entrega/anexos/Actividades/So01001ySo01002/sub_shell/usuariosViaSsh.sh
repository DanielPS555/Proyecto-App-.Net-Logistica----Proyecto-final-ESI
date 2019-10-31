#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
function usuariosConectados()
{
	# se crea una instancia de sshd por cada usuario, por ende cada instancia de sshd es una conexión de usuario
    instancias_ssh=$(ps ax -o pid,args | grep "sshd: " | grep -v "grep")
	# el nombre es 'sshd: $(usuario)' por ende al pasarle por uniq tendremos la lista de usuarios y no la de conexiones
    usuarios=($(echo $instancias_ssh | cut -d' ' -f3 | cut -d'@' -f1 | uniq))
	for i in $(seq $[${#usuarios[@]}-1] -1 0); do
    #for ((i=0;i<${#usuarios[@]};++i)); do
	echo $i")" ${usuarios[$i]}
    done
    echo -n "Desea desconectar un usuario? Inserte el numero si desea hacerlo, no inserte nada en caso contrario: "
    read uidx
    if echo $uidx | grep -E "^[0-9]{1,9}$" >/dev/null
    then
	if [ \( $uidx -ge 0 \) -a \( $uidx -lt ${#usuarios[@]} \) ]
	then
	    usuario=${usuarios[$uidx]}
	    echo "Se desconectará a $usuario"
	    instances=($(echo $instancias_ssh | grep $usuario | cut -d' ' -f1))
	    for i in $instances; do
		echo "Matando instancia con PID $i de sshd..."
		kill -9 $i
	    done
	    echo -n "Listo!"
	    read ff
	fi
    fi
}
