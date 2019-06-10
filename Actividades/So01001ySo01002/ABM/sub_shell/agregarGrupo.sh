#!/bin/bash 

agregarGrupo()
{
	grupo=''
	verif=0
	while test $verif -eq 0 #Bucle que se repite hasta que se ingrese un nombre de usuario valido 
	do	
		echo "Ingrese el nombre de grupo a crear (no el nombre real) (Dejelo vacio para cancelar la operacion)"	
		read dato	
		if ! test -z $dato
		then 
			if test $(echo "$dato" | grep -e '[a-zA-Z][a-zA-Z0-9]\+$'| wc -l ) -eq 1 #Comprueba que el nombre de grupo comienze con una letra, luego podra tener el numero de letras o numeros que dese
			then
				if ! test -z $dato && test $(cat '/etc/group'| cut -d: -f1| grep "$dato"| wc -l) -eq 0 #Comprueba que el grupo no exista en el sistema  
				then			
					grupo=$dato #Carga el valor en la variable grupo 
					verif=1 #Rompe bucle 
				else	
					echo "grupo ya ingrezado" #Imprime el mensaje de error 
				fi
			else 
				echo "Formato no valido " 
			fi	
		else
			verif=2
		fi
	done

	if test $verif -eq 2 
	then
		echo "Operacion cancelada, toque cualquier boton para continuar"
		read ff
	else
		verif=0
		while test $verif -eq 0 
		do
			echo "Ingrese el GID (Se usara el por defecto si no lo ingresa) (de 4 cifras)" 
			read dato #Ingreo de informacion 	
			if ! test -z $dato 
			then
				if test $(cat '/etc/group'| cut -d: -f3| grep "$dato"| wc -l) -eq 0 #Verifica que ña UID no exista 
				then
					if test $(echo $dato| grep -e "^[1-9][0-9]\{3\}$"|wc -l) -eq 1 #El numero tiene que ser de 4 cifras numericas 
					then	 			
						groupadd -g $dato $grupo 2> /dev/null
						verif=1 #rompe el bucle 
						echo "Operacion realizada, toque enter para continuar"
						read f
					else
						error "Formato del numero invalido (debe ser de 4 cifras)"
					fi
				else
					error "Ese GID ya existe, toque enter para continuar" 
				fi
			else 			
				echo "Confirme la creacion del grupo cuyo nombre es $grupo [s/n]"
				read e
				if test $e=='s' 2> /dev/null
				then				
					groupadd $grupo 2> /dev/null
					echo "Exito, toque enter para continuar "
					read f
				else
					echo "Operacion cancelada, toque enter para continuar"
					read f
				fi
				verif=1 #rompe el bucle 									
			fi

		done
	fi
}
