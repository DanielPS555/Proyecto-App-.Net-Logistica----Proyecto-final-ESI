#!bin/bash
# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

ModUsuario="" #Aqui se guarda el nombre del usuario a modificar su datos


mod_nom()
{
	verif=0
	while test $verif -eq 0 #Bucle que se repite hasta que se ingrese un nombre de usuario valido 
	do	
		echo "Ingrese el nuevo nombre de usuario (no el nombre real) (Dejelo vacio para cancelar la operacion)"	
		read dato #Ingreo de la informacion	
		if ! test -z $dato
		then 
			if test $(echo "$dato" | grep -e '[a-zA-Z][a-zA-Z0-9]\+$'| wc -l ) -eq 1 #Comprueba que el nombre de usuario comienze con una letra, luego podra tener el numero de letras o numeros que dese
			then
				if ! test -z $dato && test $(cat '/etc/passwd'| cut -d: -f1| grep "$dato"| wc -l) -eq 0 #Comprueba que el usuario no exista en el sistema  
				then			
					usermod -l $dato $ModUsuario 2> /dev/null #Modifica el nombre del usuario 
					ModUsuario=$dato #Carga el valor en la variable usuario 					
					verif=1 #Rompe bucle 
				else	
					echo  "Usuario ya ingrezado" #Utiliza el metodo 'echo ' el cual pinta en rojo el echo , de esta forma es mas facil diferenciarlo  
				fi
			else 
				echo  "Formato no valido " 
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
	mostrarUDI $ModUsuario #Muestra el UID del usuario 
	antUID=$respuesta
	if test -z $respuesta 
	then
		echo "Su actual UDI es: NO DETERMINADA"
	else 
		echo "Su actual UDI es: $antUID"
	fi
	cambiarUDI #Llama al metodo encargado del ingreso de la UID
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 # si la salida es por defecto no hay cambios 
	then
		echo "Sin cambios, se mantiene igual"
	else
		usermod $(echo "-u $respuesta $ModUsuario") 2> /dev/null #Modifica la UID del usuario 
 		echo "Operacion realizada, toque enter para continuar"	
	fi
	read ff 

}

Mod_DT()
{
	mostrarDT $ModUsuario #Muestra el actual DT del usuario 
	antDT=$respuesta
	if test -z $respuesta
	then
		echo "Su actual directorio de trabajo es: NO DETERMINADA"
	else 
		echo "Su actual directorio de trabajo es:  $antDT"
	fi
	cambiarDT #Ingresa el nuevo Directorio principal 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo  "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antDT"| wc -l) -eq 1 	
		then
			echo  "No se a modificado la informacion porque es identica a la anterio"
		else
			usermod $(echo "-d $respuesta $ModUsuario") 2> /dev/null #Modifica el directorio 
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi
	read ff 
}

Mod_GP()
{
	mostrarGP $ModUsuario #Muestra el GP actual del usuario 
	antGP=$respuesta
	if test -z $respuesta
	then
		echo "Su actual grupo principal es:  NO DETERMINADA"
	else 
		echo "Su actual grupo principal es:  $antGP"
	fi
	cambiarGPNuevo '2' #Ingreso del nuevo GP
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo  "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antGP"| wc -l) -eq 1 	
		then
			echo  "No se a modificado la informacion porque es identica a la anterio"
		else
			usermod $(echo "-g $respuesta $ModUsuario") 2> /dev/null #cambia el Gp 
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi
	read 
}

Mod_GS() #Este metodo sea el encargado de la gestion de los grupos del usuario 
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
		echo "1) $antGP Admin: $respuesta" #muestra el GP y si es admin de este 
		echo ""
		echo "Grupos secundarios"
		for var2 in $(seq 0 1 $[${#gss[@]}-1])	#Muestra todos los GS a los que pertenece el usuario y es admin de cada uno de ellos o no 
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
			1) #Modifica el GP
				Mod_GP
			;;

			2)
				echo "Ingrese el nombre del grupo que desea ingrezar" 			
				cambiarGPNuevo '3' #Ingreso del nuevo grupo, se usa el mismo algoridmo para verificar este grupo que para verificar la GP 
				nGS=$respuesta
				if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
				then
					echo  "Sin cambios, se mantiene igual"
				else
					veee=1
					if test $(echo $antGP| grep -x "$nGS"|wc -l) -eq 1 #Revisa que no coisida con el GP del usuario 
					then
						veee=0 
					else
						for var2 in $(seq 0 1 $[${#gss[@]}-1])	
						do
							if test $(echo ${gss[$var2]}| grep -x "$nGS"|wc -l) -eq 1 #Revisa que no pertenesca ya a este grupo 
							then
								veee=0
							fi
						done
					fi
					if test $veee -eq 1
					then
						gpasswd -a $ModUsuario $nGS #Realiza lo agrega 
						echo  "Toque enter para continuar"
					else
						echo  "El usuario ya pertenece a alguno de esos grupos"
					fi
				fi
				read ff
			;;

			3)
				echo "Ingrese el nombre del grupo " 			
				cambiarGPNuevo '3' #Ingreso del grupo 
				nGS=$respuesta
				if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
				then
					echo  "Sin cambios, se mantiene igual"
				else
					veee=0
					if test $(echo $antGP| grep -x "$nGS"|wc -l) -eq 1 #revisa que no sea el GP
					then
						echo  "No se puede eliminar del grupo principal, cambielo por otro primero y luego eliminelo"
					else
						for var2 in $(seq 0 1 $[${#gss[@]}-1]) #Revisa si es algo de los GS
						do
							if test $(echo ${gss[$var2]}| grep -x "$nGS"|wc -l) -eq 1
							then
								veee=1 #Si es asi lo modifica 
							fi
						done
					fi
					if test $veee -eq 1
					then
						gpasswd -d $ModUsuario $nGS #Realiza la eliminacion 
						echo  "Toque enter para continuar"
					else
						echo  "El usuario no pertenece el grupo ingresado"
					fi
				fi
				read ff
			;;

			4)
				echo "Ingrese el nombre del grupo" 			
				cambiarGPNuevo '3' #Ingreso del dato 
				nGS=$respuesta
				if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
				then
					echo  "Sin cambios, se mantiene igual"
				else
					veee=0
					if test $(echo $antGP| grep -x "$nGS"|wc -l) -eq 1 #Revisa si pertenese a algo de los grupos 
					then
						veee=1
					else
						for var2 in $(seq 0 1 $[${#gss[@]}-1])	
						do
							if test $(echo ${gss[$var2]}| grep -x "$nGS"|wc -l) -eq 1
							then
								admin "${gss[$var2]}" "$ModUsuario"
								if test $respuesta == 'n' #Comprueba que no se administrador en este grupo 
								then								
									veee=1
								else
									veee=2 
								fi
							fi
						done
					fi
					if test $veee -eq 1
					then
						gpasswd -A $ModUsuario $nGS #si paso todas las comprobaciones se le hace administrador 
						echo  "Toque enter para continuar"
					else
						echo  "El usuario no pertenece el grupo ingresado"
						if test $veee -eq 2
						then
							echo "El usuario ya es administrador del grupo "
						else
							echo  "El usuario no pertenece el grupo ingresado"
							
						fi
					fi
				fi
				read ff
			;;

			0)
				verif3=1
			;;
			*)
				echo  "Opcion incorrecta"
			;;
		esac		
	
		clear
	done 
}

Mod_shell() #Funcion encargada de modificar el shell de inicio 
{
	mostrarShell $ModUsuario #muestrael shell actual 
	antSh=$respuesta
	if test -z $respuesta
	then
		echo "Su actual shell de inicio es: NO DETERMINADA"
	else 
		echo "Su actual shell de inicio es: $antSh"
	fi
	cambiarShell #Ingreso del nuevo shell 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo  "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antSh"| wc -l) -eq 1 	
		then
			echo  "No se a modificado la informacion porque es identica a la anterio"
		else
			usermod $(echo "-s $respuesta $ModUsuario") 2> /dev/null #Modifica el shell 
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi
	read ff 
}

Mod_ExU() #modifica la fecha de expiracion 
{
	mostrarExUser $ModUsuario #Muestra la actual fecha de expiracion 
	antEx=$respuesta
	if test -z $respuesta
	then
		echo "La fecha de expiracion es: NO DETERMINADA"
	else 
		echo "La fecha de expiracion es: $antEx"
	fi
	cambiarExUser '2' #Cambia la fecha 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo  "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antEx"| wc -l) -eq 1 	
		then
			echo  "No se a modificado la informacion porque es identica a la anterio"
		else
			chage -E $[$(date -d "$respuesta" +%s) / 86400] $ModUsuario 2> /dev/null #Realiza el cambio 
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi 
	read ff 
}

Mod_NDias1() #Modifica el numero de dias de advertencia
{
	mostrarNumD '1' $ModUsuario #muestra anterior informacion 
	antn1=$respuesta
	echo "El numero de dias de advertencia de caducidad de la password es: $antn1"
	verifNumDias '1' #Ingreso del nuevo dato 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo  "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antn1"| wc -l) -eq 1 	
		then
			echo  "No se a modificado la informacion porque es identica a la anterio"
		else
			chage -W $respuesta $ModUsuario 2> /dev/null #Realiza el cambio 
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
		echo  "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antn2"| wc -l) -eq 1 	
		then
			echo  "No se a modificado la informacion porque es identica a la anterio"
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
		echo  "Sin cambios, se mantiene igual"
	else
		if test $(echo $respuesta| grep -xe "$antn3"| wc -l) -eq 1 	
		then
			echo  "No se a modificado la informacion porque es identica a la anterio"
		else
			chage -I $respuesta $ModUsuario 2> /dev/null
			echo "Operacion realizada, toque enter para continuar"
		fi	
	fi 
	read ff 
}

Mod_pass()
{
	cambiarPass #Ingreso de la nueva password 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1  #Si la salida es por defecto siginifca que no ingreso nada 
	then
		echo  "¿Desea no cambiar la password (1) o desea eliminarla (2). Eliga una de las sigientes opciones [1/2]"
		verfi4=0		
		while test $verfi4 -eq 0
		do
			read g
			case $g in 
			2)
				passwd -d $ModUsuario > /dev/null	#Se deja al usuario sin password
				verfi4=1
			;;
			1)
				echo  "No se modificara la password "
				verfi4=1
			;;
			*)
				echo  "Opcion incorrecta" 
			;;
			esac
		done
	else
		echo "$respuesta" | passwd --stdin $ModUsuario > /dev/null #Se le asigna la password
		
	fi
	echo "Operacion realizada, toque enter para continuar"
	read ff 
}

Mod_BUlock() #Metodo encargado del bloqueo y desbloqueo de la password 
{
	estadoPass $ModUsuario #Obtiene el estado 
	estB=$respuesta
	verif5=0	
	while test $verif5 -eq 0
	do	
		if test $respuesta == 'LK' #Si esta bloqueado 
		then
			echo "ESTADO: BLOQUEADO"
			echo "1= ACTIVAR, 2 CANCELAR"
		else #Sino esta activo 
			echo "ESTADO: ACTIVO"
			if test $respuesta == 'NP' #Si esta activo pero sin password 	
			then
				echo "(Sin password)"
			fi	
			echo "1= BLOQUEADO, 2 CANCELAR"
		fi
		read data
		if test $data -eq 1 
		then
			if test $respuesta == 'LK'
			then
				usermod -U $ModUsuario 2> /dev/null #Se desbloquea  
				passwd -d $ModUsuario > /dev/null #se le elimina la password para que se active la cuenta 
				echo  "Cuenta activida, ahora la cuenta no tiene password, cambielo."
				echo  "Toque cualquier enter para continuar " 
			else 
				usermod -L $ModUsuario #Bloqueamos 
				echo  "Cuenta bloqueada con exito"
				echo  "Toque cualquier enter para continuar " 
			fi
			verif5=1
		else
			if test $data -eq 2
			then
				verif5=1
				echo  "Toque cualquier enter para continuar " 
			else
				echo  "Oopcion invalida"
			fi 
		fi
	done 
	read ff 
}


ModificarUsuario(){
	verifUser #Ingresa el usuario a modificar 
	ModUsuario=$respuesta #carga el usuario en la variable 
	if ! test -z $ModUsuario 
	then
		eu1=('Modificar_nombreDeUsuario' 'Modificar_el_UID' 'Modificar_el_Directorio_de_trabajo' 'Administrar_todos_los_grupos_del_usuario' 'Modificar_el_shell_de_inicio' 'Modificar_la_fecha_de_expiracion_del_usuario' 'Modificar_el_N°_dias_de_advertencia' 'Modificar_la_password_del_usuario' 'Modificar_el_N°_dias_de_valides_de_la_password' 'Modificar_el_Ndias_antes_del_bloque_luego_que_expira_la_password' 'bloquear/desbloquear')
		eu2=('mod_nom' 'Mod_UID' 'Mod_DT' 'Mod_GS' 'Mod_shell' 'Mod_ExU' 'Mod_NDias1' 'Mod_pass' 'Mod_NDias2' 'Mod_NDias3' 'Mod_BUlock')	
	
		menu 'eu1[@]' 'eu2[@]'	#se llama al menu 
		
	else
		echo "Operacion cancelada,Toque cualquier boton para continuar"
		read ff
	fi
	ary1=(${nombres[@]}) #Al final de los metodos que son llamados por menu principal devemos devolerve sus anteriores valores, solamente si estos metodos utilizan la funcion menu  
		ary2=(${direcionesSetUp[@]})
}


