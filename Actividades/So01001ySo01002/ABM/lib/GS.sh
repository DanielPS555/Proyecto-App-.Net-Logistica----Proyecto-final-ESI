#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

#Funcion encargada de ingresar los grupos secundarios para el usuario 
#Se le debe pasar por parametros el grupo principal del usuario 
#Se le debe pasar por parametro los grupos secundario a los que el usuario ya pertenece 
cambiarGS() 
{

source lib/lib_error.sh #carga dicha lib para usar la funcion error
gs=($(echo ${!2})) #Array con todos los grupos secundarios 
verif=0 #Variable para controlar el bucle while
while test $verif -eq 0
do
	echo "Ingrese un grupo secundario, puede dejarlo vacio. Cuando termine de seleccionar los grupos ingrese 0"
	echo "Ingrese help para visualizar los grupos, para salir ingrese 'q'"
	read dato #Ingreso de datos
	
	if test -z $dato #se ejecuta si no ingreso nada 
	then
		if test ${#gs[@]} -eq 0 
		then	
			if test $3 -eq 1 #si el 3° parametro es 1 se habilitara la salida por defecto, de lo contrario estara bloqueada
			then
				respuesta="POR DEFECTO" #si no se ha ingresado hasta ahora ningun grupo secundario se le permite ingresar el por defecto rapdiamente 
				verif=1 #Rompe el bucle
			else
				error "No se puede usar la salida por defecto, debe ingresar un valor"
			fi			
		else
			if test $3 -eq 1 #si el 1° parametro es 1 se habilitara la salida por defecto, de lo contrario estara bloqueada
			then
				error "ya ha comenzado a cargar grupos, ¿Desea dejalo por defecto?[s/n]"
				read se
				if test $se == 's' #Si ya a ingresado algun grupo se le pedira confirmacion antes de dejarlo por defecto
				then
					respuesta="POR DEFECTO"	
					verif=1
				fi
			else
				error "Para continuar ingrese otro grupo o guardelos con 0"
			fi
		
			
		fi 

	else		
		if test $dato = '0' 2>/dev/null #Si su ingreso fue 0
		then	
			if ! test ${#gs[@]} -eq 0 #Permite estableser los grupos secundarios solamente si 
			then	
				yy=""
				for var2 in $(seq 0 1 $[${#gs[@]}-1]) #Solo permite prosegir si ha cargado algun grupo secundario, incluso si ya lo tenia cargado 
				do
					if test $var2 -eq 0
					then						
						yy="$yy${gs[$var2]}" #El primer elemento delante ni lleva coma 
					else	
						yy="$yy,${gs[$var2]}" #Luego los demas elementos llevan coma al inicio Elemento1, Elemento2 , Elemento3
					fi				
				done
			        respuesta=$yy #Se cargan los datos en la variable de salida
				verif=1
			else
				error "Debe ingresar un grupo primero"
			fi
		else
			if test $dato = "help"
			then
				cut -d: -f1 /etc/group| less #Muestra todos los grupos del sistema, a modo de ayuda cuando se ingresa 'help'
			else
				if test $(cut -d: -f1 /etc/group|grep "$dato"| wc -l) -eq 1 #Es true solamente si el grupo que se ingreso es un grupo cargado en el sistema 
				then
					vvee=1	#Se da por hecho que no hay ningun grupo repetido, en un primer momento 				
					if test ${#gs[@]} -ne 0 #Comprueba que no se repita ningun grupo solamente si ya se cargo algun grupo secundario
					then
						for var2 in $(seq 0 1 $[${#gs[@]}-1]) #Recore la lista de los grupos secundarios ya ingrezados
						do
							if test ${gs[$var2]} = $dato #Comprueba que el grupo ingrezado no sea ninguno de los que pertenecen al array 
							then
								vvee=0 #Si alguno se repite se marca 
							fi
						done			
					fi
					if test $vvee -eq 1 && test $(echo $1|grep "$dato"|wc -l) -eq 0 #Si ningun grupo secundario ya cargado ni el grupo principal son iguales a ingrezado entonces lo carga en el array 
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

done


}
