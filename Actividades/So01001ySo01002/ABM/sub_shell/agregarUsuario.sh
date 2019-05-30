#!/bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)
clear
comando=""
usuario=""
gs=()
orden=1
verif=0
echo "Se prosedera a crear el usuario (podra ingresar -1 en cualquier momento para volver al menu" 

while test $verif -eq 0
do 
	case $orden in
	1)
		echo "Ingrese el nombre de usuario" 
	;;
	2)
		echo "Ingrese el UID (Se usara el por defecto si no lo ingresa)" 
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
		echo "Ingrese un grupo secundario, para continuar con el sigiente paso ingrese '0'"
	;;
	6) 
		echo "Ingrese la direcion del shell de inicio (se usara el por defecto si no ingresa nada" 
	;;
	7) 
		echo "Ingresar la fecha de expiracion del usuario (si no ingresa ninguna se podra la por defecto"
		echo "El formato de la fecha a ingresar es el sigiente: año-mes-dia"
	;;

	8)
		echo "Ingrese el numero de dias luego de que expire la cuenta antes que la misma sea eliminada" 
		echo "No ingrese ninguna para que use la predeterminada"  
	;;
	
	9)
		echo "Ingrese la contraseña a utilizar (puede dejarlo vacio)"
	;;
	
	10)
		echo "Ingrese el tiempo por el cual las contraseñas seran validas (Sino ingresa ninguna quedara por defecto"
	;;

	11)
		echo "Numero de dias antes del bloqueo de la cuenta (Sino ingresa quedara por defecto "
	;;

	esac	
	
	read dato

	case $orden in
	1)
		if test -n $dato && test $(cat '/etc/passwd'| cut -d: -f1| grep "$dato"| wc -l) -eq 0
		then
			if test $(echo "$dato" | grep -e '[a-zA-Z]\+$'| wc -l ) -eq 1
			then			
				usuario=$dato
				orden=$[$orden+1]
			else
				echo "Tiene caracteres incorrectos" 
			fi
		else 
			echo "Ese nombre ya exsiste, toque enter para continuar" 
		fi	
	;;
	2)
		if ! test -z $dato 
		then
 			if test $(cat '/etc/passwd'| cut -d: -f3| grep "$dato"| wc -l) -eq 0
			then
	 			comando=$(echo "$comando -u $dato")
				orden=$[$orden+1]
			else
				echo "Ese UID ya existe, toque enter para continuar" 
			fi
		else 
			orden=$[$orden+1] 
		fi
	;;	
	3)
		if test -z $dato
		then
			echo "Se usara la direcion por defecto"
			orden=$[$orden+1] 
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
							comando="$comando -d $dato "
							orden=$[$orden+1]
						else
							if ! test $opcion = "n"	
							then
								verif2=0	
								echo "Opcion incorrecta, ingrese otra" 
								read fff						
							fi
						fi 
					done

				else 
					comando="$comando -d $dato "
					orden=$[$orden+1]
					directorio=$dato	
				fi 
			else
				echo "Dirrecion incorrecta"		
			fi 
		fi
	;;	
	 4)
		if test -z $dato
		then
			orden=$[$orden+1]
		else
			if test $dato = "help"
			then
				cut -d: -f1 /etc/group| less 
			else
				if test $(grep "$dato:" /etc/group| wc -l) -eq 1
				then
					comando="$comando -g $dato "
					orden=$[$orden+1]
				else
					echo "Ese grupo no exsiste, creelo o ingrese otro " 
				fi
			fi  
		fi
	 ;;
	 5) 
		if test $dato = '0' 2>/dev/null
		then		
			yy="-G "
			for var2 in $(seq 0 1 $[${#gs[@]}-1])
				do
					#CARGRAR LA CADENA DE LA CONSULTA
					
				done
			orden=$[$orden+1]
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
					if test $vvee -eq 1 
					then
						gs[${#gs[@]}]="$dato"
					else
						echo "Ese grupo ya ha sido cargado" 
					fi
					
				else
					echo "Ese grupo no exsiste, creelo o ingrese otro " 
				fi
			fi  
		fi

	 ;;
	 6) 
		if test -f $dato
		then
			
			orden=$[$orden+1]
		else
			
		fi
	 ;;
	 7) 
			
	 ;;

	# 8)
		 
	# ;;
	
	# 9)
		
	# ;;
	
	# 10)
		
	# ;;

	# 11)
		
	# ;;

	 esac


done
