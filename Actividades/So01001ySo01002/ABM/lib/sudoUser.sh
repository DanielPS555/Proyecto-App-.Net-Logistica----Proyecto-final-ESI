#V2 2da entrega bit
function sudoUserFunction() # La función llamada via $1 en esta función no puede utilizar funciones del shell ya que se ejecuta en otro shell en el cual sólo se declara la función a ser ejecutada.
{
    LUser=$1
    if test -z $LUser
    then
	return
    elif test "$LUser" == "root"
    then
	echo "No puede acceder a esta función como root"
    else
	FUNC=$(declare -f $2)
	RS="$FUNC; ${@:2}"
	sudo -u $LUser -c 'bash -xc "$RS"'
    fi
}
