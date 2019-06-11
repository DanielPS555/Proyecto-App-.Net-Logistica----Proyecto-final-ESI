#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

#Funcion encargada de ingresar los grupos secundarios para el usuario 
#Se le debe pasar por parametros el grupo principal del usuario 
#Se le debe pasar por parametro los grupos secundario a los que el usuario ya pertenece 
cambiarGS() 
{

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
			respuesta="POR DEFECTO" #si no se ha ingresado hasta ahora ningun grupo secundario se le permite ingresar el por defecto rapdiamente 
			verif=1 #Rompe el bucle
						
		else
			echo "ya ha comenzado a cargar grupos, ¿Desea dejalo por defecto?[s/n]"
			read se
			if test $se == 's' #Si ya a ingresado algun grupo se le pedira confirmacion antes de dejarlo por defecto
			then
				respuesta="POR DEFECTO"	
				verif=1
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
				echo "Debe ingresar un grupo primero"
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
						echo "Ese grupo ya ha sido cargado" 	
					fi
					
				else
					echo "Ese grupo no exsiste, creelo o ingrese otro " 
				fi
			fi  
		fi
	fi

done
}

mostrarGS() #Como su nombre lo dice es devolver el conjunto de grupo secundario a los que pertenece el usuario 
{
	mostrarGP $1 #Para ello primero que nada deberemos saber el GP, de esta forma nos encargamos que no se repita 
	cGP=$respuesta #Guardamos el resultado del anterior metodo en la variable cGP
	gsp=() #En este array tendremos a todos los grupos secundario que encontremos 
	cont=0
	for var1 in $(grep "$1" /etc/gshadow) #Recoremos las filas de que involucren a usuario a buscar gshadow
	do
		if test $(echo "$var1" | cut -d: -f4 | grep -e ",$1\|$1,\|^$1$" | wc -l) -eq 1 #los usuario de un grupo se encuentra almacenados entre ',' en la ultima fila. Buscamos al usuario alli 
		then	
			temp1="$(echo "$var1" | cut -d: -f1)" 
			if test $(echo $temp1| grep -x "$cGP"| wc -l) -eq 0 #comparamos que el grupo encontrado no sea el mismo que el principal del usuario 
			then
				gsp[$cont]=$temp1 #Se carga el dato en el array 
				cont=$[$cont+1]
			fi
			cont=$[$cont+1]
	
		fi
	
	
	done
	respuesta="${gsp[@]}" #Se devuelven todos los grupos por respuesta 
}


admin() #A partir de un usuario y el nombre de un grupo se nos informa si dicho usuario es o no es el administrador de dicho grupo
{
	if test $(grep -e "^$1:" /etc/gshadow | grep ":$2:"| wc -l) -eq 1 #Los usuarios que se encuentren en la 3° fila del de gshadow son administradores del grupo
	then
		respuesta='s'
	else
		respuesta='n'
	fi	

}


