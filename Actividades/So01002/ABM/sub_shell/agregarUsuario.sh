#!/bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)
clear
comando=""
usuario=""
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
		echo "Debe estar en /Home por politicas de los administradores"
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
			usuario=$dato
			orden=$[$orden+1]
		else 
			echo "Ese nombre ya exsiste, toque enter para continuar" 
		fi	
	;;
	2)
		if test -n $dato 
		then
 			if test $(cat '/etc/passwd'| cut -d: -f3| grep "$dato"| wc -l) -eq 0
			then
	 			comando=$(echo "$comando -u $dato")
				orden=$[$orden+1]
			else
				echo "Ese UID ya existe, toque enter para continuar" 
			fi
		fi
	;;	
	3)
		if test $(echo $dato|grep '^/home' )
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
						comando="$comando  -d $dato "
						orden=$[$orden+1]
						#Queda verificar que no me meta cualquier cosa en el nombre del directorio
					else
						if ! test $opcion = "n"	
						then
							verif2=0	
							echo "Opcion incorrecta, ingrese otra" 
							read fff						
						fi
					fi 
				done
			fi 
		else
			echo "Dicha ubicacion no es permitida ya que no esta en /home" 		
		fi 
		echo $comando
	;;	
	# 4)
		
	# ;;
	# 5) 
		
	# ;;
	# 6) 
		
	# ;;
	# 7) 
		
	# ;;

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
