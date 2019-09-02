#!/bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

listarUsuarios()
{
	eu1=('Listar_todos_los_usuarios' 'Panel_De_informacion_de_un_usuario' 'Buscador_multicriterio_de_usuarios')
	eu2=('listaCompleta' 'infoParticular' 'buscador')	
	
	menu 'eu1[@]' 'eu2[@]'	#Imprime todas las opciones de listar usuarios 

}

listaCompleta()
{
	echo "Ingrese 'q' para salir"	
	touch $carpetaBase/Temp/listar #Crea la lista temp 
	for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}" |cut -d: -f1) #Recore a todos los usuarios del sistema que tengan UID mayor a 1000
	do
		lineaInformacion $var2
		echo $respuesta >> $carpetaBase/Temp/listar #carga los resultados en la lista temp 
		echo "" >> $carpetaBase/Temp/listar
	done
	read f
	less $carpetaBase/Temp/listar #Muestra la lista temp 
	rm -f $carpetaBase/Temp/listar #elimina la lista 
	
}

infoParticular()
{
	verifUser #Ingrese un USER valido 
	LUser=$respuesta
	if ! test -z $LUser #Si ingreso alguno imprime la informacion, sino cancela la proseso 
	then
			echo "PANEL DE INFORMACION DEL USUARIO:  $LUser"
			estadoPass $LUser #calcula es estado del usuario 
			if test $(echo $respuesta| grep -x "PS"|wc -l) -eq 1
			then
				echo "Estado: Activo"
			else

				if test $(echo $respuesta| grep -x "NP"|wc -l) -eq 1
				then
					echo "Estado: Activo pero sin contraseña"
				else
					echo "Estado: Bloqueado"
				fi
				#Imprime el estado del usuario dependiendo del anterior calculo 
			fi
			mostrarUDI $LUser
			echo "UDI: $respuesta" #Imprime la UID
			mostrarDT $LUser
			echo "Directorio principal $respuesta" #Imprime el directorio principal 
			mostrarGP $LUser
			echo "Grupo principal: $respuesta" #Imprime el nombre del GP
			mostrarGS $LUser 
			gss=($respuesta)
			echo "Grupos secundarios" #Muestra todos los grupos secundarios 
			for var2 in $(seq 0 1 $[${#gss[@]}-1])	
			do
				admin "${gss[$var2]}" "$ModUsuario" 
				echo "${gss[$var2]} Admin: $respuesta" #Imprime el nombre y si es admin o no 
			done
			mostrarShell $LUser
			echo "Shell de incio: $respuesta" #Imprime el shell de inicio 
			mostrarExUser $LUser
			echo "Expiracion usuario $respuesta"  #Imprime la fecha de expiracion del usuario, si no tiene ninguna lo deja vacio 
			FechModificacionPass $LUser
			echo "La ultima fecha de modificacion de la password: $respuesta" #Imprime la ultima fecha de modificacion de la password 
			mostrarNumD '1' $LUser
			echo "El N° de dias de advertencia (password): $respuesta" #Imprime la los dias de advertencia
			mostrarNumD '2' $LUser
			echo "El N° de dias de valides de la password: $respuesta" 
			mostrarNumD '3' $LUser
			echo "El N° de dias de valides de la cuenta caducada la password: $respuesta"
			echo ""
			echo "Ingrese enter para continuar"	
	else
		echo "Operacion cancelada, toque cualquier boton para continuar"
	fi
	read ff
}

buscador()
{
	eu1=('Buscar_por_nombre' 'Buscar_por_UID' 'Buscar_Por_Grupo_principal' 'Buscar_por_grupo_secundario' 'Buscar_por_todos_los_grupos' 'Buscar_por_fecha' 'Buscar_por_estado')
	eu2=('buscarPorNombre' 'buscarPorUID' 'bucarPorGID' 'buscarPorGrupoSecundario' 'buscarPorTodosLosGrupos' 'buscarPorFechas' 'buscarPorEstados')	
	
	menu 'eu1[@]' 'eu2[@]'	#Llama al menu con las opciones para el buscador multicriterios 

}

buscarPorNombre()
{
	echo "Ingrese el conjunto de caracteres a buscar por nombre o parte de el"
	read dato #ingresa el nombre o los primeros caracteres a el 

	if test $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"| grep -ie "^$dato.*:"|wc -l) -eq 0 #Busca la cantidad de todos los nombres que comiencen con esa secuencia de caracteres
	then
		echo "Sin respultados, ingrese cualquier boton para continuar"
		read f 
	else
		touch $carpetaBase/Temp/listar
		for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}" | grep -ie "^$dato.*:") #Busca todos los nombres que comiencen con esa secuencia de caracteres
		do		
			parametro=$(echo $var2|cut -d: -f1)
			lineaInformacion $parametro
			echo $respuesta >> $carpetaBase/Temp/listar #imprime la salida en la lista Temp
			echo "" >> $carpetaBase/Temp/listar
		done
		echo "Ingrese 'q' para salir"	
		read ff
		less $carpetaBase/Temp/listar #Muestra la lista 
		rm -f $carpetaBase/Temp/listar
	fi
}


buscarPorUID()
{
		echo "Ingrese el UID valida"
		read num1
		if test $(echo $num1| grep -e "^[1-9][0-9]\{3\}$"|wc -l) -eq 1 #El numero tiene que ser de 4 cifras numericas 
		then
			
			if test $(cut -d: -f3 '/etc/passwd'|grep -xe "$num1"|wc -l) -eq 0 #Busca todos los usuarios con esa UID
			then
				echo "Sin resultados, ingrese enter para continuar " 
				read f
			else
				touch $carpetaBase/Temp/listar
				echo "Ingrese 'q' para salir" 
				read f
				for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":$num1"|cut -d: -f1)
				do
					lineaInformacion $var2
					echo $respuesta >> $carpetaBase/Temp/listar #Ingresa el resultado en la lista 
					echo "" >> $carpetaBase/Temp/listar
				done
				less $carpetaBase/Temp/listar
				rm -f $carpetaBase/Temp/listar
			fi	
		else
			echo "Formato de ingreso incorrecto, ingrese enter para continuar"
			read f
		fi		
}

bucarPorGID()
{
	echo "Ingrese el nombre de grupo principal de los usuarios a buscar (deje vacio para cancelar la operacion)"
	read dato
	if test -z $dato #compureba si la entrada es vacia 
	then
		echo "Operacion cancelada, toque enter para continuar" 
		read ff
	else
		touch $carpetaBase/Temp/listar
		for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
		do
			mostrarGP $var2 #Calcula su GP
			if test $(echo $respuesta| grep -xe "$dato"|wc -l) -eq 1 #Compara si el GP es el mismo que el de la entrada 
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
			less $carpetaBase/Temp/listar
		fi
		rm -f $carpetaBase/Temp/listar
	fi
	
}

buscarPorGrupoSecundario() #Este metodo solo imprime los usuarios que su grupo secundario es el ingresado 
{
	echo "Ingrese el nombre de grupo secundario (o parte de el) de los usuarios a buscar (deje vacio para cancelar la operacion)"
	read dato
	if test -z $dato #Comprueba si la entrada no es vacia 
	then
		echo "Operacion cancelada, toque cualquier boton para continuar"
		read ff
	else
		if test $(grep -e "^$dato" '/etc/group'| wc -l) -eq 0 #Se fija si el grupo exsiste 
		then
			echo "No existe ningun grupo que comienze asi o se llame asi, ingrese enter para continuar"
			read ff
		else
			touch $carpetaBase/Temp/listar
			echo "Prosesando...."
			for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
			do
				mostrarGS $var2 #calculos el conjunto de grupos secundario para cada usuario 
				ve=0		
				users=($respuesta)
				for var3 in $(seq 0 1 $[${#users[@]}-1])
				do
					if test $(echo ${users[$var3]}| grep -xe "$dato"|wc -l) -eq 1 #Nos fijamos si alguno de esos grupo coinside con el buscado 
					then			
						ve=1	
					fi
				done

				if test $ve -eq 1 
				then 
					lineaInformacion $var2
					echo $respuesta >> $carpetaBase/Temp/listar #Imprime la informacion del usuario que coiside 
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
				less $carpetaBase/Temp/listar #Muestra los resultados
			fi
			rm -f $carpetaBase/Temp/listar
		fi
	fi
}

buscarPorTodosLosGrupos()
{
	echo "Ingrese el nombre de grupo (O parte de el) (sea principal o secundario) de los usuarios a buscar (deje vacio para cancelar la operacion)"
	read dato
	if test -z $dato
	then
		echo "Operacion cancelada, toque cualquier boton para continuar"
		read ff
	else
		if test $(grep -e "^$dato" '/etc/group'| wc -l) -eq 0 #Busca los grupos que comiencen asi 
		then
			echo "No existe ningun grupo que comienze asi o se llame asi, ingrese enter para continuar"
			read ff
		else
			touch $carpetaBase/Temp/listar
			echo "Prosesando...."
			for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
			do
				mostrarGS $var2
				ve=0		
				users=($respuesta)
				mostrarGP $var2
				for var3 in $(seq 0 1 $[${#users[@]}-1]) #Busca si alguno de los GS de los usuario concuerda  
				do
					if test $(echo ${users[$var3]}| grep -e "^$dato"|wc -l) -eq 1
					then			
						ve=1	
					fi
				done
		
				if test $(echo $respuesta| grep -e "^$dato"|wc -l) -eq 1 #Busca si alguno de los GP de los usuarios concuerda 
				then			
					ve=1
				fi

				if test $ve -eq 1 
				then 
					lineaInformacion $var2
					echo $respuesta >> $carpetaBase/Temp/listar #carga los datos en la lista
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
				less $carpetaBase/Temp/listar #Imprime los datos 
			fi
			rm -f $carpetaBase/Temp/listar
		fi
	fi
}

buscarPorFechas() #este medio nos proporciona las heramientas para buscar por fechas sea de expiracion o cambio de password 
{
	verif6=0
	while test $verif6 -eq 0
	do	
		echo "1) Para buscar por fecha de expiracion"
		echo "2) Para buscar por fecha de cambio de password"
		echo "0) Para salir"
		read ing
		case $ing in 
			1)
				verif7=0
				while test $verif7 -eq 0 
				do	
					echo "1) Fecha unica"      #Menu con todos los criterios de busqueda 
					echo "2) Fecha menor que"
					echo "3) Fecha mayor que"
					echo "4) Rango de fechas"
					echo "0) Salir"
					read ing
					case $ing in 
						1)
							cambiarExUser '3' #Ingreso de la fecha 
							if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
							then 
								echo "Operacion cancelada" #Si la salida es vacia
							else
								fech=$respuesta
								touch $carpetaBase/Temp/listar
								for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1) #Recore a todos los usuarios
								do
									mostrarExUser $var2 #Calcula la fecha de expiracion del usuario 
									fechR=$respuesta								
									fechaIgual $fech $fechR #Se fija si son iguales las dos 
									if test $respuesta -eq 1
									then			
										lineaInformacion $var2
										echo $respuesta >> $carpetaBase/Temp/listar #Imprime los datos en la lista Temp
										echo "" >> $carpetaBase/Temp/listar
									fi
								done
								if test $(wc -l $carpetaBase/Temp/listar|cut -d" " -f1) -eq 0
								then
									echo "Sin resultados, toque cualquier boton para continuar"
									read f
								else
									less $carpetaBase/Temp/listar #Imprime el conjunto de usuarios que tiene dicha fecha 
								fi
								rm -f $carpetaBase/Temp/listar
							fi		
						;;

						2)
							cambiarExUser '3' #Ingreso de datos
							fech=$respuesta
							if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
							then 
								echo "Operacion cancelada"
							else
								touch $carpetaBase/Temp/listar
								for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
								do
									mostrarExUser $var2
									fechR=$respuesta								
									fechaMenorque $fechR $fech #Comprueba que la primera fecha ingresada sea menor a la segunda 
									if test $respuesta -eq 1
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
									less $carpetaBase/Temp/listar #Imprime los resultados
								fi
								rm -f $carpetaBase/Temp/listar
							fi
						;;

						3)
							cambiarExUser '3' #Ingreso de datos
							if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
							then 
								echo "Operacion cancelada"
							else
								fech=$respuesta
								touch $carpetaBase/Temp/listar
								for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
								do
									mostrarExUser $var2
									fechR=$respuesta								
									fechaMayorque $fechR $fech #Comprueba que la primera fecha ingresada sea menor a la segunda 
									if test $respuesta -eq 1
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
									less $carpetaBase/Temp/listar #Imprime la salida 
								fi
								rm -f $carpetaBase/Temp/listar
							fi
						;;

						4)
							cambiarExUser '3' #Ingreso del limite inferior 
							if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
							then 
								echo "Operacion cancelada"
							else
								fech=$respuesta							
								cambiarExUser '4' #Ingreso del limite superior
								if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
								then 
									echo "Operacion cancelada"
								else
									fech2=$respuesta
									touch $carpetaBase/Temp/listar
									for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
									do
										mostrarExUser $var2
										fechR=$respuesta								
										rangoDeFechas $fechR $fech $fech2 #Nos fijamos que la primera fecha este entre la primera y la segunda 
										if test $respuesta -eq 1
										then			
											lineaInformacion $var2
											echo $respuesta >> $carpetaBase/Temp/listar #cargamos los datos
											echo "" >> $carpetaBase/Temp/listar
										fi
									done
									if test $(wc -l $carpetaBase/Temp/listar|cut -d" " -f1) -eq 0
									then
										echo "Sin resultados, toque cualquier boton para continuar"
										read f
									else
										less $carpetaBase/Temp/listar #los mostramos 
									fi
									rm -f $carpetaBase/Temp/listar
								fi
							fi

						;;

						0)
						  	verif7=1
						;;

						*)
							echo "Opcion incorrecta"
						;;

					esac
				done
			;;

			2)
				verif7=0
				while test $verif7 -eq 0
				do	
					echo "1) Fecha unica"
					echo "2) Fecha menor que"
					echo "3) Fecha mayor que"
					echo "4) Rango de fechas"
					echo "0) Salir"
					read ing
					case $ing in 
						1)
							cambiarExUser '3' #Ingreso de datos
							if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
							then 
								echo "Operacion cancelada"
							else
								fech=$respuesta
								touch $carpetaBase/Temp/listar
								for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
								do
									FechModificacionPass $var2 #Nos devuelve la fecha de modificacion del usuario 
									fechR=$respuesta								
									fechaIgual $fech $fechR #Compara la 1° y 2° fechas si son iguales 
									if test $respuesta -eq 1
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
									less $carpetaBase/Temp/listar #Muestra los datos
								fi
								rm -f $carpetaBase/Temp/listar
							fi		
						;;

						2)
							cambiarExUser '3'
							fech=$respuesta
							if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
							then 
								echo "Operacion cancelada"
							else
								touch $carpetaBase/Temp/listar
								for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
								do
									FechModificacionPass $var2
									fechR=$respuesta								
									fechaMenorque $fechR $fech
									if test $respuesta -eq 1
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
									less $carpetaBase/Temp/listar
								fi
								rm -f $carpetaBase/Temp/listar
							fi
						;;

						3)
							cambiarExUser '3'
							if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
							then 
								echo "Operacion cancelada"
							else
								fech=$respuesta
								touch $carpetaBase/Temp/listar
								for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
								do
									FechModificacionPass $var2
									fechR=$respuesta								
									fechaMayorque $fechR $fech
									if test $respuesta -eq 1
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
									less $carpetaBase/Temp/listar
								fi
								rm -f $carpetaBase/Temp/listar
							fi
						;;

						4)
							cambiarExUser '3'
							if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
							then 
								echo "Operacion cancelada"
							else
								fech=$respuesta							
								cambiarExUser '4'
								if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
								then 
									echo "Operacion cancelada"
								else
									fech2=$respuesta
									touch $carpetaBase/Temp/listar
									for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
									do
										FechModificacionPass $var2
										fechR=$respuesta								
										rangoDeFechas $fechR $fech $fech2
										if test $respuesta -eq 1
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
										less $carpetaBase/Temp/listar
									fi
									rm -f $carpetaBase/Temp/listar
								fi
							fi

						;;

						0)
						  	verif7=1
						;;

						*)
							echo "Opcion incorrecta"
						;;

					esac
				done
			;;

			0)
			  	verif6=1
			;;

			*)
				echo "Opcion incorrecta"
			;;

		esac
	done
}

buscarPorEstados()
{
	verif6=0
	while test $verif6 -eq 0
	do
		echo "1) Activo"
		echo "2) Activo y sin contraseña"
		echo "3) Bloqueado"
		echo "0) Salir"
		read ing
		case $ing in 
			1)
				estate 'PS' #Devuelve los usuarios activos y con contraseña
			;;	
			
			2)
				estate 'NP' #Devuelve los usuarios acivos pero sin contraseña
			;;

			3)
				estate 'LK' #Devuelve los usuarios bloqueados
			;;

			0)
				verif6=1
			;;

		esac
	done
}

estate() #Lista los usuarios segun su estado 
{

		touch $carpetaBase/Temp/listar
		for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1) #Recore todos los usuarios cuyo UID es mayor a 1000
		do
			estadoPass $var2 #devuelve el estado del usuario 
			if test $(echo $respuesta| grep -x "$1"|wc -l) -eq 1
			then			
				lineaInformacion $var2
				echo $respuesta >> $carpetaBase/Temp/listar #Imprime la informacion en el archivo temp 
				echo "" >> $carpetaBase/Temp/listar
			fi
		done
		if test $(wc -l $carpetaBase/Temp/listar|cut -d" " -f1) -eq 0
		then
			echo "Sin resultados, toque cualquier boton para continuar"
			read f
		else
			less $carpetaBase/Temp/listar #Muestra la informacion de la busqueda 
		fi
		rm -f $carpetaBase/Temp/listar


}

lineaInformacion() #Imprime una linea con la informacion mas importante del usuario para ser mostrado como item de la lista
{
	mostrarGP $1	
	ngp=$respuesta
	mostrarUDI $1
	nuid=$respuesta
	FechModificacionPass $1
	fmpass=$respuesta
	respuesta=$(echo "$1) UID:$nuid  / Grupo principal: $ngp / Fecha modificacion password: $fmpass")
}
