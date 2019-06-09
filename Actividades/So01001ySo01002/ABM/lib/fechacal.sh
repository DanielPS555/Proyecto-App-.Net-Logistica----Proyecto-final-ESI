

#Primera siempre es la fecha a comprar, las demas son los rangos 
fechaIgual()
{
	if test $(date -d"$1" +%s) -eq $(date -d"$2" +%s 2> /dev/null) 2> /dev/null
	then
		respuesta='1'
	else
		respuesta='0'
	fi
}


fechaMayorque()
{
	if test $(date -d"$1" +%s) -ge $(date -d"$2" +%s 2> /dev/null) 2> /dev/null
	then
		respuesta='1'
	else
		respuesta='0'
	fi

}

fechaMenorque()
{
	if test $(date -d"$1" +%s) -le $(date -d"$2" +%s 2> /dev/null) 2> /dev/null
	then
		respuesta='1'
	else
		respuesta='0'
	fi
}


rangoDeFechas() #
{
	if test $(date -d"$1" +%s) -ge $(date -d"$2" +%s 2> /dev/null) 2> /dev/null && test $(date -d"$1" +%s) -le $(date -d"$3" +%s 2> /dev/null) 2> /dev/null
	then
		respuesta='1'
	else
		respuesta='0'
	fi

}
