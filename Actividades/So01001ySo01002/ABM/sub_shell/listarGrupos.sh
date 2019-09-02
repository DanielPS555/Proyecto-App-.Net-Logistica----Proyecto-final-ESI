MenuListarGrupos()
{
	eu1=('Listar_todos_los_grupos' 'Panel_de_informcion_de_un_grupo' 'Buscar_Por_nombre')
	eu2=('listarTodosLosGrupos' 'GrupoParticular' 'buscarPorNombre')	
	
	menu 'eu1[@]' 'eu2[@]'	#Llama a un menu para acceder a todas las caracteristicas del listado de grupo 

}

listarTodosLosGrupos() #Su funcion es listar a todos los usuarios del sistema en forma de lista 
{
	echo "Ingrese 'q' para salir"	
	touch $carpetaBase/Temp/listar #Crea un archivo temporal que se mostrara en forma de lista posteriormente 
	for var2 in $(cut -d: -f1,3 '/etc/group'|grep ":[1-9][0-9]\{3\}$" |cut -d: -f1) #Lista a todos los grupos 
	do
		infoGrupo $var2 #Crea una linia de informacion de cada grupo 
		echo $respuesta >> $carpetaBase/Temp/listar #Imprime esa linea en el archivo temporal 
		echo "" >> $carpetaBase/Temp/listar
	done
	read f
	less $carpetaBase/Temp/listar #Muestra el archivo temporal 
	rm -f $carpetaBase/Temp/listar #Elimina el archivo temporal 
}



infoGrupo()
{
	verGIDGrupo $1	#calcula el GID del grupo 
	respuesta=$(echo "Nombre: $1 / GID: $respuesta") #devuelve la linea de informacion 
}


buscarPorNombre()
{
	echo "Ingrese el conjunto de caracteres a buscar por grupo o parte de el"
	read dato #Ingreso el nombre a buscar o parte de el 

	if test $(cut -d: -f1,3 '/etc/group'|grep "^$dato.*:[1-9][0-9]\{3\}$"|wc -l) -eq 0 #Busca el numero de todos los grupos que comiencen con ese conjunto de caracteres
	then
		echo "Sin respultados, ingrese cualquier boton para continuar" #Si no encuentra resultados
		read f 
	else
		touch $carpetaBase/Temp/listar #Crea el temp 
		for var2 in $(cut -d: -f1,3 '/etc/group'|grep "^$dato.*:[1-9][0-9]\{3\}$") #Recore la lista cn todos los elementos que comiencen con esos caracteres y su GID sea de 4 cifras 
		do		
			parametro=$(echo $var2|cut -d: -f1) #Toma el nombre del grupo  
			infoGrupo $parametro #Crea la linea de informacion 
			echo $respuesta >> $carpetaBase/Temp/listar #Imprime la linea de informacion en el archivo temp 
			echo "" >> $carpetaBase/Temp/listar
		done
		echo "Ingrese 'q' para salir"	
		read ff
		less $carpetaBase/Temp/listar #Muestra la lista 
		rm -f $carpetaBase/Temp/listar #elimina el temp 
	fi
}

GrupoParticular() #Ingresa el nombre de un grupo particula a mostrar su panel de informacion completa 
{
	verif5=0
 	while test $verif5 -eq 0 
	do
		echo "Ingrese el nombre del grupo a buscar (no ingrese nada para dejarlo vacio)"
		read dato #Ingreso de informacion 
		if test -z $dato #Comprueba si el ingreso esta vacio 
		then
			verif5=1
			echo "Operacion cancelada, toque enter para continuar"
			read ff
		else
			if test $(cut -d: -f1,3 '/etc/group'|grep "^$dato:[1-9][0-9]\{3\}$"|wc -l) -eq 1 #Compurbe aque el grupo exista que su GID sea de de 1000-9999
			then
				panelInfoGrupo $dato #imprime la informacion 
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
		verGIDGrupo $1 #Calculamos el GID del grupo 
		echo "GID: $respuesta"
		echo "Ingrese 1 para ver los integrantes del grupo, 2 para salir"
		read d
		case $d in 
		1)
			#Prosedemos a mostrar todos los integrantes del grupo, sea su grupo princpal o secundario 
			touch $carpetaBase/Temp/listar
			echo "Prosesando...."
			for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1) #Recore todos los usuarios cuyo UID sea mayor a 1000
			do
				mostrarGS $var2 #Calculamos todos los grupos secundarios del usuario 
				ve=0		
				users=( $respuesta) #cargamos los resultados en el array users 
				mostrarGP $var2 #calculamos el GP del usuario 
				for var3 in $(seq 0 1 $[${#users[@]}-1]) #recoremos los GS del usuarios
				do
					if test $(echo ${users[$var3]}| grep -e "^$1"|wc -l) -eq 1 #Comrpobamos que el grupo pertenece a los GS del usuario 
					then			
						ve=1	
					fi
				done
		
				if test $(echo $respuesta| grep -e "^$1"|wc -l) -eq 1 #Comprobamos que el grupo pertenece sea el GP del usuario 
				then			
					ve=1
				fi

				if test $ve -eq 1 #Si coiside con alguna de las anterior lo carga en la lista Temp 
				then 
					lineaInformacion $var2
					echo $respuesta >> $carpetaBase/Temp/listar
					echo "" >> $carpetaBase/Temp/listar
				fi

			done
			if test $(wc -l $carpetaBase/Temp/listar|cut -d" " -f1) -eq 0 #si la lista no tiene elemenos no la imprime 
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
			verif6=1 #sale del panel 
		;;

		*)
			echo "Opcion incorecta, toque enter para continuar"
			read ff
		;;
		esac
	done
	
}


