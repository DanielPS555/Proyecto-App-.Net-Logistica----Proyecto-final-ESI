#!bin/bash

ModUsuario=""


mod_nom()
{
	verif=0
	while test $verif -eq 0 #Bucle que se repite hasta que se ingrese un nombre de usuario valido 
	do	
		echo "Ingrese el nuevo nombre de usuario (no el nombre real) (Dejelo vacio para cancelar la operacion)"	
		read dato	
		if ! test -z $dato
		then 
			if test $(echo "$dato" | grep -e '[a-zA-Z][a-zA-Z0-9]\+$'| wc -l ) -eq 1 #Comprueba que el nombre de usuario comienze con una letra, luego podra tener el numero de letras o numeros que dese
			then
				if ! test -z $dato && test $(cat '/etc/passwd'| cut -d: -f1| grep "$dato"| wc -l) -eq 0 #Comprueba que el usuario no exista en el sistema  
				then			
					usermod -l $dato $ModUsuario 2> /dev/null
					ModUsuario=$dato #Carga el valor en la variable usuario 					
					verif=1 #Rompe bucle 
				else	
					error "Usuario ya ingrezado" #Utiliza el metodo 'error' el cual pinta en rojo el error, de esta forma es mas facil diferenciarlo  
				fi
			else 
				error "Formato no valido " 
			fi	
		else
			echo "Operacion cancelada, toque cualquier boton para continuar"
			read ff
			verif=2
		fi
	done
}


Mod_UID()
{
	mostrarUDI $ModUsuario
	antUID=$respuesta
	if test -z $respuesta
	then
		echo "Su actual UDI es: NO DETERMINADA"
	else 
		echo "Su actual UDI es: $antUID"
	fi
	cambiarUDI 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "Sin cambios, se mantiene igual"
	else
		usermod $(echo "-u $respuesta $ModUsuario") 2> /dev/null
		echo "Operacion realizada, toque enter para continuar"	
	fi
	read ff 

}

Mod_DT()
{
	mostrarDT $ModUsuario
	antDT=$respuesta
	if test -z $respuesta
	then
		echo "Su actual directorio de trabajo es: NO DETERMINADA"
	else 
		echo "Su actual directorio de trabajo es:  $antDT"
	fi
	cambiarDT
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		error "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antDT"| wc -l) -eq 1 	
		then
			error "No se a modificado la informacion porque es identica a la anterio"
		else
			usermod $(echo "-d $respuesta $ModUsuario") 2> /dev/null
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi
	read ff 
}

Mod_GP()
{
	mostrarGP $ModUsuario
	antGP=$respuesta
	if test -z $respuesta
	then
		echo "Su actual grupo principal es:  NO DETERMINADA"
	else 
		echo "Su actual grupo principal es:  $antGP"
	fi
	cambiarGPNuevo '2'
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		error "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antGP"| wc -l) -eq 1 	
		then
			error "No se a modificado la informacion porque es identica a la anterio"
		else
			usermod $(echo "-g $respuesta $ModUsuario") 2> /dev/null
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi
	read 
}

Mod_GS()
{
	verif3=0
	while test $verif3 -eq 0 
	do	
		mostrarGP $ModUsuario
		antGP=$respuesta
		mostrarGS $ModUsuario 
		gss=($respuesta)
		admin "$antGP" "$ModUsuario"
		echo "Grupo principal"
		echo "1) $antGP Admin: $respuesta"
		echo ""
		echo "Grupos secundarios"
		for var2 in $(seq 0 1 $[${#gss[@]}-1])	
		do
			admin "${gss[$var2]}" "$ModUsuario"
			echo "$[$var2+2]) ${gss[$var2]} Admin: $respuesta"
		done
		echo ""
		echo "OPCIONES"
		echo "1) Modificar el primario"	
		echo "2) Agregar a un grupo"
		echo "3) Eliminar de un grupo"
		echo "4) Convertir en admin de un grupo"
		echo "0) salir"	
		echo "Ingrese la opcion"
		read ing
		case $ing in
			1)
				Mod_GP
			;;

			2)
				echo "Ingrese el nombre del grupo que desea ingrezar" 			
				cambiarGPNuevo '3'
				nGS=$respuesta
				if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
				then
					error "Sin cambios, se mantiene igual"
				else
					veee=1
					if test $(echo $antGP| grep -x "$nGS"|wc -l) -eq 1
					then
						veee=0
					else
						for var2 in $(seq 0 1 $[${#gss[@]}-1])	
						do
							if test $(echo ${gss[$var2]}| grep -x "$nGS"|wc -l) -eq 1
							then
								veee=0
							fi
						done
					fi
					if test $veee -eq 1
					then
						gpasswd -a $ModUsuario $nGS
						error "Toque enter para continuar"
					else
						error "El usuario ya pertenece a alguno de esos grupos"
					fi
				fi
				read ff
			;;

			3)
				echo "Ingrese el nombre del grupo " 			
				cambiarGPNuevo '3'
				nGS=$respuesta
				if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
				then
					error "Sin cambios, se mantiene igual"
				else
					veee=0
					if test $(echo $antGP| grep -x "$nGS"|wc -l) -eq 1
					then
						error "No se puede eliminar del grupo principal, cambielo por otro primero y luego eliminelo"
					else
						for var2 in $(seq 0 1 $[${#gss[@]}-1])	
						do
							if test $(echo ${gss[$var2]}| grep -x "$nGS"|wc -l) -eq 1
							then
								veee=1
							fi
						done
					fi
					if test $veee -eq 1
					then
						gpasswd -d $ModUsuario $nGS
						error "Toque enter para continuar"
					else
						error "El usuario no pertenece el grupo ingresado"
					fi
				fi
				read ff
			;;

			4)
				echo "Ingrese el nombre del grupo" 			
				cambiarGPNuevo '3'
				nGS=$respuesta
				if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
				then
					error "Sin cambios, se mantiene igual"
				else
					veee=0
					if test $(echo $antGP| grep -x "$nGS"|wc -l) -eq 1
					then
						veee=1
					else
						for var2 in $(seq 0 1 $[${#gss[@]}-1])	
						do
							if test $(echo ${gss[$var2]}| grep -x "$nGS"|wc -l) -eq 1
							then
								admin "${gss[$var2]}" "$ModUsuario"
								if test $respuesta == 'n'
								then								
									veee=1
								else
									error "Este usuario ya es administrador en este grupo" 
								fi
							fi
						done
					fi
					if test $veee -eq 1
					then
						gpasswd -A $ModUsuario $nGS
						error "Toque enter para continuar"
					else
						error "El usuario no pertenece el grupo ingresado"
					fi
				fi
				read ff
			;;

			0)
				verif3=1
			;;
			*)
				error "Opcion incorrecta"
			;;
		esac		
	
		clear
	done 
}

Mod_shell()
{
	mostrarShell $ModUsuario
	antSh=$respuesta
	if test -z $respuesta
	then
		echo "Su actual shell de inicio es: NO DETERMINADA"
	else 
		echo "Su actual shell de inicio es: $antSh"
	fi
	cambiarShell
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		error "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antSh"| wc -l) -eq 1 	
		then
			error "No se a modificado la informacion porque es identica a la anterio"
		else
			usermod $(echo "-s $respuesta $ModUsuario") 2> /dev/null
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi
	read ff 
}

Mod_ExU()
{
	mostrarExUser $ModUsuario
	antEx=$respuesta
	if test -z $respuesta
	then
		echo "La fecha de expiracion es: NO DETERMINADA"
	else 
		echo "La fecha de expiracion es: $antEx"
	fi
	cambiarExUser '2'
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		error "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antEx"| wc -l) -eq 1 	
		then
			error "No se a modificado la informacion porque es identica a la anterio"
		else
			chage -E $[$(date -d "$respuesta" +%s) / 86400] $ModUsuario 2> /dev/null
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi 
	read ff 
}

Mod_NDias1()
{
	mostrarNumD '1' $ModUsuario
	antn1=$respuesta
	echo "El numero de dias de advertencia de caducidad de la password es: $antn1"
	verifNumDias '1'
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		error "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antn1"| wc -l) -eq 1 	
		then
			error "No se a modificado la informacion porque es identica a la anterio"
		else
			chage -W $respuesta $ModUsuario 2> /dev/null
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi 
	read ff 
}

Mod_NDias2()
{
	mostrarNumD '2' $ModUsuario
	antn2=$respuesta
	echo "El numero de dias de valides de la password: $antn2"
	verifNumDias '2'
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		error "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antn2"| wc -l) -eq 1 	
		then
			error "No se a modificado la informacion porque es identica a la anterio"
		else
			chage -M $respuesta $ModUsuario 2> /dev/null
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi 
	read ff 
}

Mod_NDias3() 
{
	mostrarNumD '3' $ModUsuario
	antn3=$respuesta
	if test -z $respuesta
	then
		echo "El N° dias de duracion en la que la cuenta segira activa luego de caducada la password: NO DETERMINADA"
	else 
		echo "El N° dias de duracion en la que la cuenta segira activa luego de caducada la password: $antn3"
	fi
	verifNumDias '3'
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		error "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antn3"| wc -l) -eq 1 	
		then
			error "No se a modificado la informacion porque es identica a la anterio"
		else
			chage -I $respuesta $ModUsuario 2> /dev/null
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi 
	read ff 
}

Mod_pass()
{
	cambiarPass
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		error "¿Desea no cambiar la contraseña (1) o eliminarla (2). Eliga una de las sigientes opciones [1/2]"
		verfi4=0		
		while test $verfi4 -eq 0
		do
			read g
			case $g in 
			2)
				passwd -d $ModUsuario > /dev/null	#Se deja al usuario sin contraseña
				verfi4=1
			;;
			1)
				error "No se modificara la password "
				verfi4=1
			;;
			*)
				error "Opcion incorrecta" 
			;;
			esac
		done
	else
		echo "$respuesta" | passwd --stdin $ModUsuario > /dev/null #Se le asigna la contraseña
		
	fi
	echo "Operacion realizada, toque enter para continuar"
	read ff 
}

Mod_BUlock()
{
	estadoPass $ModUsuario
	estB=$respuesta
	verif5=0	
	while test $verif5 -eq 0
	do	
		if test $respuesta == 'LK'
		then
			echo "ESTADO: BLOQUEADO"
			echo "1= ACTIVAR, 2 CANCELAR"
		else 
			echo "ESTADO: ACTIVO"
			if test $respuesta == 'NP'	
			then
				echo "(Sin contraseña)"
			fi	
			echo "1= BLOQUEADO, 2 CANCELAR"
		fi
		read data
		if test $data -eq 1 
		then
			if test $respuesta == 'LK'
			then
				usermod -U $ModUsuario 2> /dev/null
				passwd -d $ModUsuario > /dev/null
				error "Cuenta activida, ahora la contraseña la cuenta no tiene contraseña, cambielo."
				error "Toque cualquier enter para continuar " 
			else 
				usermod -L $ModUsuario
				error "Cuenta bloqueada con exito"
				error "Toque cualquier enter para continuar " 
			fi
			verif5=1
		else
			if test $data -eq 2
			then
				verif5=1
				error "Toque cualquier enter para continuar " 
			else
				error "Oopcion invalida"
			fi 
		fi
	done 
	read ff 
}


ModificarUsuario(){
	verifUser
	ModUsuario=$respuesta
	if ! test -z $ModUsuario 
	then
		eu1=('Modificar_nombreDeUsuario' 'Modificar_el_UID' 'Modificar_el_Directorio_de_trabajo' 'Modificar_los_Grupo_secundario' 'Modificar_el_shell_de_inicio' 'Modificar_la_fecha_de_expiracion_del_usuario' 'Modificar_el_N°_dias_de_advertencia' 'Modificar_la_password_del_usuario' 'Modificar_el_N°_dias_de_valides_de_la_password' 'Modificar_el_Ndias_antes_del_bloque_luego_que_expira_la_password' 'bloquear/desbloquear')
		eu2=('mod_nom' 'Mod_UID' 'Mod_DT' 'Mod_GS' 'Mod_shell' 'Mod_ExU' 'Mod_NDias1' 'Mod_pass' 'Mod_NDias2' 'Mod_NDias3' 'Mod_BUlock')	
	
		menu 'eu1[@]' 'eu2[@]'	
		
	else
		echo "Operacion cancelada,Toque cualquier boton para continuar"
		read ff
	fi
	ary1=(${nombres[@]})
		ary2=(${direcionesSetUp[@]})
}


