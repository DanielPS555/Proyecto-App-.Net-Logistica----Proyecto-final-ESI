MenuListarGrupos()
{
	eu1=('Listar_todos_los_grupos' 'Panel_de_informcion_de_un_grupo' 'Buscar_Por_nombre')
	eu2=('listarTodosLosGrupos' 'GrupoParticular' 'buscarPorNombre')	
	
	menu 'eu1[@]' 'eu2[@]'	

	ary1=(${nombres[@]})
	ary2=(${direcionesSetUp[@]})
}

listarTodosLosGrupos()
{
	echo "Ingrese 'q' para salir"	
	touch $carpetaBase/Temp/listar
	for var2 in $(cut -d: -f1,3 '/etc/group'|grep ":[1-9][0-9]\{3\}$" |cut -d: -f1)
	do
		infoGrupo $var2
		echo $respuesta >> $carpetaBase/Temp/listar
		echo "" >> $carpetaBase/Temp/listar
	done
	read f
	less $carpetaBase/Temp/listar
	rm $carpetaBase/Temp/listar
}



infoGrupo()
{
	verGIDGrupo $1	
	respuesta=$(echo "Nombre: $1 / GID: $respuesta")
}


buscarPorNombre()
{
	echo "Ingrese el conjunto de caracteres a buscar por grupo o parte de el"
	read dato

	if test $(cut -d: -f1,3 '/etc/group'|grep "^$dato.*:[1-9][0-9]\{3\}$"|wc -l) -eq 0
	then
		echo "Sin respultados, ingrese cualquier boton para continuar"
		read f 
	else
		touch $carpetaBase/Temp/listar
		for var2 in $(cut -d: -f1,3 '/etc/group'|grep "^$dato.*:[1-9][0-9]\{3\}$")
		do		
			parametro=$(echo $var2|cut -d: -f1)
			infoGrupo $parametro
			echo $respuesta >> $carpetaBase/Temp/listar
			echo "" >> $carpetaBase/Temp/listar
		done
		echo "Ingrese 'q' para salir"	
		read ff
		less $carpetaBase/Temp/listar
		rm -f $carpetaBase/Temp/listar
	fi
}

GrupoParticular()
{
	verif5=0
	while test $verif5 -eq 0 
	do
		echo "Ingrese el nombre del grupo a buscar (no ingrese nada para dejarlo vacio)"
		read dato
		if test -z $dato
		then
			verif5=1
			echo "Operacion cancelada, toque enter para continuar"
			read ff
		else
			if test $(cut -d: -f1,3 '/etc/group'|grep "^$dato:[1-9][0-9]\{3\}$"|wc -l) -eq 1
			then
				panelInfoGrupo $dato
				verif5=1 
			else
				echo "Dato incorrecto"
			fi
		fi	

	done

}


panelInfoGrupo()
{
	verif6=0
	while test $verif6 -eq 0
	do
		echo "PANEL INFORMCION DEL GRUPO $1"
		verGIDGrupo $1
		echo "GID: $respuesta"
		echo "Ingrese 1 para ver los integrantes del grupo, 2 para salir"
		read d
		case $d in
		1)
			
			touch $carpetaBase/Temp/listar
			echo "Prosesando...."
			for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
			do
				mostrarGS $var2
				ve=0		
				users=( $respuesta)
				mostrarGP $var2
				for var3 in $(seq 0 1 $[${#users[@]}-1])
				do
					if test $(echo ${users[$var3]}| grep -e "^$1"|wc -l) -eq 1
					then			
						ve=1	
					fi
				done
		
				if test $(echo $respuesta| grep -e "^$1"|wc -l) -eq 1
				then			
					ve=1
				fi

				if test $ve -eq 1 
				then 
					lineaInformacion $var2
					echo $respuesta >> $carpetaBase/Temp/listar
					echo "" >> $carpetaBase/Temp/listar
				fi

			done
			if test $(wc -l $carpetaBase/Temp/listar|cut -d" " -f1) -eq 0
			then
				echo "Sin resultados, toque cualquier boton para continuar"
				read f
			else
				echo "Ingrese 'q' para salir"
				read ff
				less $carpetaBase/Temp/listar
			fi
			rm -f $carpetaBase/Temp/listar
				
			
		;;

		2)
			verif6=1
		;;

		*)
			echo "Opcion incorecta, toque enter para continuar"
			read ff
		;;
		esac
	done
	
}


