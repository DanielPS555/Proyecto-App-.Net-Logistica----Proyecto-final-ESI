
# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)



fechaIgual() #Metodo encargado de comparar dos fechas y decir si estas son iguales o no
{
	if test $(date -d"$1" +%s) -eq $(date -d"$2" +%s 2> /dev/null) 2> /dev/null #+%s devuelve los segundos que trascurieron desde 1970-1-1 hasta dicha fecha
	then
		respuesta='1'
	else
		respuesta='0'
	fi
}


fechaMayorque() #Su funcion es comparar si la primera fecha es mayor o igual a la segunda 
{
	if test $(date -d"$1" +%s) -ge $(date -d"$2" +%s 2> /dev/null) 2> /dev/null
	then
		respuesta='1'
	else
		respuesta='0'
	fi

}

fechaMenorque() #Su funcion es comparar si la primera fecha es menor que la segunda 
{
	if test $(date -d"$1" +%s) -le $(date -d"$2" +%s 2> /dev/null) 2> /dev/null
	then
		respuesta='1'
	else
		respuesta='0'
	fi
}


rangoDeFechas() #su funcion determinar si la primera fecha se encuentra entre la primera y la segunda 
{
	if test $(date -d"$1" +%s) -ge $(date -d"$2" +%s 2> /dev/null) 2> /dev/null && test $(date -d"$1" +%s) -le $(date -d"$3" +%s 2> /dev/null) 2> /dev/null
	then
		respuesta='1'
	else
		respuesta='0'
	fi

}
