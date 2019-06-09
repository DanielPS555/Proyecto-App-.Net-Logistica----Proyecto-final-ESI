
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
	echo "Ingrese 'q' para salir"	
	touch $carpetaBase/Temp/listar
	for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}" |cut -d: -f1)
	do
		lineaInformacion $var2
		echo $respuesta >> $carpetaBase/Temp/listar
		echo "" >> $carpetaBase/Temp/listar
	done
	read f
	less $carpetaBase/Temp/listar
	rm $carpetaBase/Temp/listar
	
}

infoParticular()
{
	verifUser
	LUser=$respuesta
	if ! test -z $LUser
	then
			echo "PANEL DE INFORMACION DEL USUARIO:  $LUser"
			estadoPass $LUser
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
		
			fi
			mostrarUDI $LUser
			echo "UDI: $respuesta" 
			mostrarDT $LUser
			echo "Directorio principal $respuesta"
			mostrarGP $LUser
			echo "Grupo principal: $respuesta"
			mostrarGS $LUser 
			gss=($respuesta)
			echo "Grupos secundarios"
			for var2 in $(seq 0 1 $[${#gss[@]}-1])	
			do
				admin "${gss[$var2]}" "$ModUsuario"
				echo "${gss[$var2]} Admin: $respuesta"
			done
			mostrarShell $LUser
			echo "Shell de incio: $respuesta"
			mostrarExUser $LUser
			echo "Expiracion usuario $respuesta" 
			FechModificacionPass $LUser
			echo "La ultima fecha de modificacion de la password: $respuesta"
			mostrarNumD '1' $LUser
			echo "El N° de dias de advertencia (password): $respuesta"
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
	
	menu 'eu1[@]' 'eu2[@]'	

	ary1=('Listar_todos_los_usuarios' 'Panel_De_informacion_de_un_usuario' 'Buscador_multicriterio_de_usuarios')
	ary2=('listaCompleta' 'infoParticular' 'buscador')
}

buscarPorNombre()
{
	echo "Ingrese el conjunto de caracteres a buscar por nombre o parte de el"
	read dato

	if test $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"| grep -ie "^$dato.*:"|wc -l) -eq 0
	then
		echo "Sin respultados, ingrese cualquier boton para continuar"
		read f 
	else
		touch $carpetaBase/Temp/listar
		for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}" | grep -ie "^$dato.*:")
		do		
			parametro=$(echo $var2|cut -d: -f1)
			lineaInformacion $parametro
			echo $respuesta >> $carpetaBase/Temp/listar
			echo "" >> $carpetaBase/Temp/listar
		done
		echo "Ingrese 'q' para salir"	
		read ff
		less $carpetaBase/Temp/listar
		rm -f $carpetaBase/Temp/listar
	fi
}


buscarPorUID()
{
		echo "Ingrese el UID valida"
		read num1
		if test $(echo $ri| grep -e "^[1-9][0-9]\{3\}$"|wc -l) -eq 1 #El numero tiene que ser de 4 cifras numericas 
		then
			
		if test $(cut -d: -f1,3 '/etc/passwd'|grep ":$num1"|wc -l) -eq 0
		then
			echo "Sin resultados" 
		else
			touch $carpetaBase/Temp/listar
			echo "Ingrese 'q' para salir" 
			read f
			for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":$num1"|cut -d: -f1)
			do
				lineaInformacion $var2
				echo $respuesta >> $carpetaBase/Temp/listar
				echo "" >> $carpetaBase/Temp/listar
			done
			less $carpetaBase/Temp/listar
			rm -f $carpetaBase/Temp/listar
		fi	
		else
			echo "Formato de ingreso incorrecto"
		fi		
}

bucarPorGID()
{
	echo "Ingrese el nombre de grupo principal (O parte de el) de los usuarios a buscar"
	read dato
	if test -z $dato
	then
		echo "Operacion cancelada, toque enter para continuar" 
		read ff
	else
		touch $carpetaBase/Temp/listar
		for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
		do
			mostrarGP $var2
			if test $(echo $respuesta| grep -e "^$dato"|wc -l) -eq 1
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

buscarPorGrupoSecundario()
{
	echo "Ingrese el nombre de grupo secundario (O parte de el) de los usuarios a buscar"
	read dato
	if test $(grep -e "^$dato" '/etc/group'| wc -l) -eq 0
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
			for var3 in $(seq 0 1 $[${#users[@]}-1])
			do
				if test $(echo ${users[$var3]}| grep -e "^$dato"|wc -l) -eq 1
				then			
					ve=1	
				fi
			done

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
	fi
}

buscarPorTodosLosGrupos()
{
	#OJO con el espacio en blanco6
	echo "Ingrese el nombre de grupo (O parte de el) (sea principal o secundario) de los usuarios a buscar"
	read dato
	if test $(grep -e "^$dato" '/etc/group'| wc -l) -eq 0
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
			for var3 in $(seq 0 1 $[${#users[@]}-1])
			do
				if test $(echo ${users[$var3]}| grep -e "^$dato"|wc -l) -eq 1
				then			
					ve=1	
				fi
			done
		
			if test $(echo $respuesta| grep -e "^$dato"|wc -l) -eq 1
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
	fi
}

buscarPorFechas()
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
					echo "1) Fecha unica"
					echo "2) Fecha menor que"
					echo "3) Fecha mayor que"
					echo "4) Rango de fechas"
					echo "0) Salir"
					read ing
					case $ing in 
						1)
							cambiarExUser '3'
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
									fechaIgual $fech $fechR
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
									mostrarExUser $var2
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
									mostrarExUser $var2
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
										mostrarExUser $var2
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
									fechaIgual $fech $fechR
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
				estate 'PS'
			;;	
			
			2)
				estate 'NP'
			;;

			3)
				estate 'LK'
			;;

			0)
				verif6=1
			;;

		esac
	done
}

estate()
{

		touch $carpetaBase/Temp/listar
		for var2 in $(cut -d: -f1,3 '/etc/passwd'|grep ":[1-9][0-9]\{3\}"|cut -d: -f1)
		do
			estadoPass $var2
			if test $(echo $respuesta| grep -x "$1"|wc -l) -eq 1
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


}

lineaInformacion()
{
	mostrarGP $1	
	ngp=$respuesta
	mostrarUDI $1
	nuid=$respuesta
	FechModificacionPass $1
	fmpass=$respuesta
	respuesta=$(echo "$1) UID:$nuid  / Grupo principal: $ngp / Fecha modificacion password: $fmpass")
}
