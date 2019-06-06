
listarUsuarios()
{
	eu1=('Listar_todos_los_usuarios' 'Panel_De_informacion_de_un_usuario' 'Buscador_multicriterio_de_usuarios')
	eu2=('listaCompleta' 'infoParticular' 'buscador')	
	
	menu 'eu1[@]' 'eu2[@]'	

		ary1=(${nombres[@]})
		ary2=(${direcionesSetUp[@]})
}

listaCompleta()
{
echo "completa" 
}

infoParticular()
{
echo "particular"
}

buscador()
{
echo "buscador"
}

lineaInformacion()
{
	mostrarGP $1	
	ngp=$respuesta
	mostrarUDI $1
	nuid=$respuesta
	$respuesta=$(echo "$1) UID:$nuid  / Grupo principal: $ngp")
}
