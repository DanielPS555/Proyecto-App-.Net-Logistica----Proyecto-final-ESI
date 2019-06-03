#!/bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)
source lib/lib_error.sh
clear
comando=()
usuario=""
gs=()
orden=1
echo "Se prosedera a crear el usuario (podra ingresar -1 en cualquier momento para volver al menu" 

while test $orden -lt 12
do 
	case $orden in
	1)
		echo "Ingrese el nombre de usuario" 
	;;
	2)
		echo "Ingrese el UID (Se usara el por defecto si no lo ingresa) (de 4 cifras)" 
	;;	
	3)
		echo "Ingrese la direccion del directorio de trabajo (Se usara el por defecto si no ingresa ninguna)"
		echo "Debe estar en /home por politicas de los administradores"
		echo "Use una ruta absoluta" 
	;;	
	4)
		echo "Ingrese el nombre del grupo principal(se usara el por defecto si no ingresa ninguno)" 
		echo "Ingrese 'help' para visualizar todos los grupos del sistema, ingrese 'q' para salir"
	;;
	5) 
		echo "Ingrese un grupo secundario, puede dejarlo vacio. Cuando termine de seleccionar los grupos ingrese 0"
		echo "Ingrese help para visualizar los grupos, para salir ingrese 'q'"
	;;
	6) 
		echo "Ingrese la direcion del shell de inicio (se usara el por defecto si no ingresa nada)" 
	;;
	7) 
		echo "Ingresar la fecha de expiracion del usuario (si no ingresa ninguna se podra la por defecto"
		echo "El formato de la fecha a ingresar es el sigiente: day-month-year"
	;;

	8)
		echo "Ingrese el numero de dias luego de que expire la cuenta antes que la misma sea eliminada (No mas de 4 digitos)" 
		echo "No ingrese ninguna para que use la predeterminada"  
	;;
	
	9)
		echo "Ingrese la contraseña a utilizar (puede dejarlo vacio)"
		echo "Si ingresa un contraseña que tenga entre 8 y 20 caracteres, SOLO LETRAS Y NUMEROS"
		echo "Su primer caracter debe ser una letra, se debera poder a lo largo de la contraseña al menos una mayuscula"
	;;
	
	10)
		echo "Ingrese el tiempo por el cual las contraseñas seran validas (Sino ingresa ninguna quedara por defecto (no mas de 4 dijitos)"
		 
	;;

	11)
		echo "Numero de dias antes del bloqueo de la cuenta (Sino ingresa quedara por defecto) (No mas de 4 dijitos)  "
	;;

	esac	
	
	read dato

	if test $dato -eq '-1' 2> /dev/null
	then
		orden=13
	else 
		case $orden in
		1)
			if test $(echo "$dato" | grep -e '[a-zA-Z][a-zA-Z0-9]\+$'| wc -l ) -eq 1
			then
				if ! test -z $dato && test $(cat '/etc/passwd'| cut -d: -f1| grep "$dato"| wc -l) -eq 0 
				then			
					usuario=$dato
					orden=$[$orden+1]
				else
					error "Usuario ya ingrezado" 
				fi
			else 
				error "Formato no valido " 
			fi	
		;;
		2)
			if ! test -z $dato 
			then
	 			if test $(cat '/etc/passwd'| cut -d: -f3| grep "$dato"| wc -l) -eq 0
				then
					if test $(echo $dato| grep -e "^[1-9][0-9]\{3\}$"|wc -l) -eq 1
					then	 			
						comando[0]=$dato
						orden=$[$orden+1]
					else
						error "Formato del numero invalido (debe ser de 4 cifras)"
					fi
				else
					error "Ese UID ya existe, toque enter para continuar" 
				fi
			else 
				orden=$[$orden+1] 
				comando[0]="POR DEFECTO"
			fi
		;;	
		3)
			if test -z $dato
			then
				echo "Se usara la direcion por defecto"
				orden=$[$orden+1] 
				comando[1]="POR DEFECTO"
			else 		
				if test $(echo $dato|grep '^/home'|wc -l) -eq 1 && test $(echo "$dato" | grep '^[a-zA-Z/]\+$'| wc -l ) -eq 1  #todos los simbolos menos el / son aseptados por el sistema ([<>*/#\$ ]') 
				then
						
					if test -d $dato 
					then
						verif2=0			
						while test $verif2 -eq 0
						do
							verif2=1
							echo "ADEVERTENCIA: Sepa que el directorio ya exsiste, ¿desea continuar o elegir otro? [s/n]"
							read opcion
							if test $opcion = "s"
							then 														
								comando[1]="$dato"
								orden=$[$orden+1]
							else
								if ! test $opcion = "n"	
								then
									verif2=0	
									error "Opcion incorrecta, ingrese otra" 
									read fff						
								fi
							fi 
						done

					else 
						if test -d $(echo "$dato"|sed -e 's/\(\/[a-zA-Z/]\+\/\)\(.\+\)/\1/')
						then
							comando[1]="$dato"
							orden=$[$orden+1]
						else	
							error "El directorio donde quiere crear el directorio no existe, por favor cree el directorio $(echo "$dato"|sed -e 's/\(\/[a-zA-Z/]\+\/\)\(.\+\)/\1/')"
						fi
										
						

					fi 
				else
					error "Dirrecion incorrecta"		
				fi 
			fi
		;;	
		 4)
			if test -z $dato
			then
				orden=$[$orden+1]
				comando[2]="POR DEFECTO"
			else
				if test $dato = "help"
				then
					cut -d: -f1 /etc/group| less 
				else
					if test $(grep "$dato:" /etc/group| wc -l) -eq 1
					then
						comando[2]="$dato"
						orden=$[$orden+1]
					else
						error "Ese grupo no exsiste, creelo o ingrese otro " 
					fi
				fi  
			fi
		 ;;
		 5) 
			if test -z $dato
			then
				if test ${#gs[@]} -eq 0
				then			
					comando[3]="POR DEFECTO"
					orden=$[$orden+1]
				else
					error "ya ha comenzado a cargar grupos, ¿Desea dejalo por defecto?[s/n]"
					read se
					if test $se == 's'
					then
						comando[3]="POR DEFECTO"
						orden=$[$orden+1]	
					fi
				fi 

			else		
				if test $dato = '0' 2>/dev/null
				then	
					if ! test ${#gs[@]} -eq 0
					then	
					yy=""
					for var2 in $(seq 0 1 $[${#gs[@]}-1])
						do
							if test $var2 -eq 0
							then						
								yy="$yy${gs[$var2]}"
							else	
								yy="$yy,${gs[$var2]}"
							fi				
						done
					comando[3]=$yy
					orden=$[$orden+1]
					else
						error "Debe ingresar un grupo primero"
					fi
				else
					if test $dato = "help"
					then
						cut -d: -f1 /etc/group| less 
					else
						if test $(cut -d: -f1 /etc/group|grep "$dato"| wc -l) -eq 1
						then
							vvee=1					
							if test ${#gs[@]} -ne 0
							then
								for var2 in $(seq 0 1 $[${#gs[@]}-1])
								do
									if test ${gs[$var2]} = $dato 
									then
										vvee=0
									fi
								done			
							fi
							if test $vvee -eq 1 && ! test $dato == ${comando[2]}
							then
								gs[${#gs[@]}]="$dato"
							else
								error "Ese grupo ya ha sido cargado" 
							fi
					
						else
							error "Ese grupo no exsiste, creelo o ingrese otro " 
						fi
					fi  
				fi
			fi

		 ;;
		 6) 
			if test -z $dato 
			then
				comando[4]="POR DEFECTO"
				orden=$[$orden+1]
			else
				if test -f $dato
				then
					comando[4]=$dato
					orden=$[$orden+1]
				else
					error "Ese archivo no existe "
				fi
			fi
		 ;;
		 7) 
			if test -z $dato 
			then
				comando[5]="POR DEFECTO"
				orden=$[$orden+1]
			else			
				if test $(echo "$dato" | grep -e "^[0-9]\{1,2\}-[0-9]\{1,2\}-[1-9][0-9]\+$"|wc -l) -eq 1 
				then
					day=$(echo "$dato"| sed -e 's/^\([0-9]\+\)\-\([0-9]\+\)\-\([0-9]\+\)$/\1/')	
					month=$(echo "$dato"| sed -e 's/^\([0-9]\+\)\-\([0-9]\+\)\-\([0-9]\+\)$/\2/')
					year=$(echo "$dato"| sed -e 's/^\([0-9]\+\)\-\([0-9]\+\)\-\([0-9]\+\)$/\3/')			
					if test $(cal $day $month $year 2>/dev/null | wc -l) -ne 0
					then 					
						if test $(date +%s) -lt $(date -d "$year-$month-$day" +%s)
						then
							orden=$[$orden+1]
							comando[5]="\"$year-$month-$day\""
						else
							error "Esa fecha ya paso, debera elegir una posterior a la actual" 
						fi
					else 
						error "Fecha invalida, no existe" 
					fi
				else
					error "El formato no es el correcto, este debe ser DD-MM-YYYY"	
				fi 
			fi	
		 ;;

		 8)
			 if ! test -z $dato 
			 then 
				if test $(echo "$dato" | grep -e "^[1-9][0-9]\{0,3\}$\|^[0-9]$" | wc -l ) -eq 1 
				then
					orden=$[$orden+1]
					comando[6]="$dato"
				else
					error "Entrada invalida, debe ser solo numerica, y no mayor a 4 cifras" 
				fi

			 else 		
				orden=$[$orden+1]
				comando[6]="POR DEFECTO"
			
			 fi 
		 ;;
	
		 9)
			if test -z $dato
			then
				orden=$[$orden+1]
				comando[7]="POR DEFECTO"	
			else
				if test $(echo $dato | grep -ie "^[a-z][a-z0-9]\{7,19\}$") && test $(echo $dato | grep -e "[A-Z]")
				then
					orden=$[$orden+1]
					comando[7]=$dato
				else
					error "La contraseña no es valida" 
				fi
			fi 
		 ;;
	
		 10)
			if ! test -z $dato 
			 then 
				if test $(echo "$dato" | grep -e "^[1-9][0-9]\{0,3\}$\|^[0-9]$" | wc -l ) -eq 1 
				then
					orden=$[$orden+1]
					comando[8]="$dato"
				else
					error "Entrada invalida, debe ser solo numerica, y no mayor a 4 cifras" 
				fi

			 else 		
				orden=$[$orden+1]
				comando[8]="POR DEFECTO"
			 fi 
		 ;;

		 11)
			if ! test -z $dato 
			 then 
				if test $(echo "$dato" | grep -e "^[1-9][0-9]\{0,3\}$\|^[0-9]$" | wc -l ) -eq 1 
				then
					orden=$[$orden+1]
					comando[9]="$dato"
				else
					error "Entrada invalida, debe ser solo numerica, y no mayor a 4 cifras" 
				fi

			 else 		
				orden=$[$orden+1]
				comando[9]="POR DEFECTO"
			 fi 
		;;

		 esac
	fi

	
	
done

if test $orden -eq 12
then
	echo "Lista de datos ingrezados" 
	echo "Nombre:                                                $usuario"
	echo "UID:                                                   ${comando[0]}"
	echo "Directorio de trabajo:                                 ${comando[1]}"
	echo "Grupo Principal                                        ${comando[2]}"
	echo "Grupo Secundario                                       ${comando[3]}"
	echo "Shell de inicio:                                       ${comando[4]}"
	echo "fecha expiracion usuario                               ${comando[5]}"      
	echo "N° dias previo al bloqueo                              ${comando[6]}"
	echo "Password                                               ${comando[7]}"
	echo "Tiempo de valides password                             ${comando[8]}"
	echo "N° dias previo al bloqueo por expiracion de contraseña ${comando[9]}"

	opci=('-u' '-d' '-g' '-G' '-s' '-e' '-f' ' ' 'x' 'i')
	echo "Desea crear al usuario [s/n]"
	read confirme
	if test $confirme = "s"
	then 
		comandoFinal=""
		for var3 in $(seq 0 1 6)
		do
			if ! test $(echo ${comando[$var3]}|grep "POR DEFECTO"|wc -l) -eq 1
			then
				comandoFinal="$comandoFinal ${opci[$var3]} ${comando[$var3]}"
			fi	
		done
	fi
	
	useradd $(echo "$comandoFinal $usuario") >/dev/null
	if ! test $(echo ${comando[7]}|grep "POR DEFECTO"|wc -l) -eq 1	
	then		
		echo "${comando[7]}" | passwd --stdin $usuario > /dev/null
	else
		passwd -d $usuario	
	fi
	passwd -x ${comando[8]} $usuario > /dev/null
	passwd -i ${comando[9]} $usuario > /dev/null
	echo "Usuario creado con exito, resive en 'lista usuario' para comprobarlo, Toque cualquier boton para continuar" 
	read fff 
fi


