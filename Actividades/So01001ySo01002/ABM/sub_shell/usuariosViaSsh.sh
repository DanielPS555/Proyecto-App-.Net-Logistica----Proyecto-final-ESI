#version 2 segunda entrega bit
function usuariosConectados()
{
    instancias_ssh=$(ps ax -o pid,args | grep "sshd: " | grep -v "grep")
    usuarios=($(echo $instancias_ssh | cut -d' ' -f3 | cut -d'@' -f1 | uniq))
    for ((i=0;i<${#usuarios[@]};++i)); do
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
