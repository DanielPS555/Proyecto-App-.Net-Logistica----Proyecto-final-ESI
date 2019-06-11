#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

cambiarDT() #Esta funcion tendra como funcion brindar una direcion valida para el directorio de trabajo la cual es ingresada por el usuario 
{
verif=0
while test $verif -eq 0
do
	echo "Ingrese la direccion del directorio de trabajo (Si esta creando un usuaio puede dejar vacio para usar la por defecto, si esta modificandolo si lo deja vacio no se haran cambios)"
	echo "Debe estar en /home por politicas de los administradores"
	echo "Use una ruta absoluta" 
	read dato
	if test -z $dato #Ingreso de la informacion 
	then
		echo "Se usara la direcion por defecto"
		respuesta="POR DEFECTO"
		verif=1
	else 		
		if test $(echo $dato|grep '^/home'|wc -l) -eq 1 && test $(echo "$dato" | grep '^[a-zA-Z/][a-zA-Z/0-9]\+$'| wc -l ) -eq 1  #Solo se dejaran pasar aquelos directorios que esten en /home y no tengan caracteres extraños 
		then
			if test -d $dato #Si la direcion existe siginifica que useradd no creara la carpeta 
			then
				verif2=0			
				while test $verif2 -eq 0 #no se rompera el bucle hasta que se haya ingresado un valor (s-n) valido
				do
					verif2=1
					echo "ADEVERTENCIA: Sepa que el directorio ya exsiste, ¿desea continuar o elegir otro? [s/n]"
					read opcion #Si el directorio existe el contenido de /etc/skel/
					if test $opcion = "s"
					then 														
						respuesta="$dato" #Salida de la informacion 
						verif=1 #Rompe bucle
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
				if test -d $(echo "$dato"|sed -e 's/\(\/[a-zA-Z/]\+\/\)\(.\+\)/\1/') #Debe existir la direcion donde se va a crear el directorio de trabajo
				then
			 		respuesta="$dato" #Salida de datos
					verif=1
				else	
					echo "El directorio donde quiere crear el directorio no existe, por favor cree el directorio $(echo "$dato"|sed -e 's/\(\/[a-zA-Z/]\+\/\)\(.\+\)/\1/')"
				fi
			fi 
		else
			echo "Dirrecion incorrecta"		
		fi 
	fi
done
}


mostrarDT()
{
	respuesta=$(grep -e "^$1:" '/etc/passwd'|cut -d: -f6) #Muestra la 6| columa de passwd cuya fila es la del usuario igresado por parametros, osea la direcion del su directorio de trabajo 
}




