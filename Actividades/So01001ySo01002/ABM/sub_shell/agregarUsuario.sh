#!/bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

respuesta #El dato pasado por los return solo puede ser numerico, entonces utilizamos una variable externa donde se cargen las salidas, como si fuera un $? pero con mayor capasidad  

#Importa un conjunto de librerias que va a utilizar 
source lib/lib_error.sh
source lib/DT.sh
source lib/expiracionUsuario.sh
source lib/GP.sh
source lib/GS.sh
source lib/NDiasHasta.sh
source lib/pass.sh
source lib/shell.sh
source lib/UDI.sh
clear
comando=() #Conjunto de parametros para el comando useradd o los passwd 
usuario="" #nombre del usuario a crear 
grS=() #Conjunto de grupos secundarios ya cargados, es nesesario para la funcion 'cambiarGS'

verif=0
while test $verif -eq 0 #Bucle que se repite hasta que se ingrese un nombre de usuario valido 
do	
	echo "Ingrese el nombre de usuario a crear (no el nombre real) (no se puede dejar vacio)"	
	read dato	
	if test $(echo "$dato" | grep -e '[a-zA-Z][a-zA-Z0-9]\+$'| wc -l ) -eq 1 #Comprueba que el nombre de usuario comienze con una letra, luego podra tener el numero de letras o numeros que dese
	then
		if ! test -z $dato && test $(cat '/etc/passwd'| cut -d: -f1| grep "$dato"| wc -l) -eq 0 #Comprueba que el usuario no exista en el sistema  
		then			
			usuario=$dato #Carga el valor en la variable usuario 
			verif=1 #Rompe bucle 
		else	
			error "Usuario ya ingrezado" #Utiliza el metodo 'error' el cual pinta en rojo el error, de esta forma es mas facil diferenciarlo  
		fi
	else 
		error "Formato no valido " 
	fi	
done
cambiarUDI #Utiliza el metodo cambiarUDI de la lib 'lib/UDI.sh' El mismo se encarga de devolvernos por medio de la variable respuesta un valor valido para el UID
comando[0]=$respuesta #Se almacena dicho valor

cambiarDT #Utiliza el metodo cambiarDT de la lib 'lib/DT.sh'. Este nos devuelve una direcion valida para la carpeta personal de usuario a crear. Se devuelve dicho valor por medio de la variable respuesta
comando[1]=$respuesta	

cambiarGPNuevo #Nos devuelve un grupo principal valido para el usuario
comando[2]=$respuesta

cambiarGS "${comando[2]}" "grS[@]" #Nos devuelve el conjunto de grupos secundarios a los que el usuario pertenece (los antiguos y los viejos)
comando[3]=$respuesta

cambiarShell #Nos devuelve una direcion de un archivo que suponemos que es un shell 
comando[4]=$respuesta

cambiarExUser #Nos devuelve una fecha valida y posterior a la actual para que el usuario expire 
comando[5]=$respuesta

verifNumDias '1' #Nos devuelve el numero de dias luego de la expiracion de la cuenta previo al bloqueo en este caso (por parametro 1) 				
comando[6]=$respuesta

cambiarPass #Nos devuelve una contraseña valida (8-20 dijitos, una o mas mayusculas, etc)
comando[7]=$respuesta

verifNumDias '2' #Nos devuelve el numero de dias por el cual la password sea valida 
comando[8]=$respuesta

verifNumDias '3' #Nos devuelve el numero de dias luego de que la password expire para el bloqueo de la cuenta
comando[9]=$respuesta				 
		
echo "Lista de datos ingrezados" #Se nos lista un conjunto de datos ingrezados para la creacion del usuario 
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

opci=('-u' '-d' '-g' '-G' '-s' '-e' '-f' ' ' 'x' 'i') #Conjunto de los reguladores a poner en el useradd, estan en orden segun los ingrezos de informacion antes hechos 
echo "Desea crear al usuario [s/n]"
read confirme

if test $confirme = "s"
then 
	comandoFinal=""
	for var3 in $(seq 0 1 6)
	do
		if ! test $(echo ${comando[$var3]}|grep "POR DEFECTO"|wc -l) -eq 1 #Solo ingresa los datos que no sean "POR DEFECTO"
		then
			comandoFinal="$comandoFinal ${opci[$var3]} ${comando[$var3]}" #Agrega al comando el nuevo parametro y su respectiva informacion 
		fi	
	done
	useradd $(echo "$comandoFinal $usuario") >/dev/null #Crea al usuario 

	if ! test $(echo ${comando[7]}|grep "POR DEFECTO"|wc -l) -eq 1	#Se le asigna contraseña solamente a los usuario que la hayan ingresado y no la hayan dejado por defecto 
	then		
		echo "${comando[7]}" | passwd --stdin $usuario > /dev/null #Se le asigna la contraseña
 	else
		passwd -d $usuario > /dev/null	#Se deja al usuario sin contraseña
	fi
	passwd -x ${comando[8]} $usuario > /dev/null #Se establese el tipo de valides de la password 
	passwd -i ${comando[9]} $usuario > /dev/null #Se establese el numero de dias luego que las password expire antes que se bloque la cuenta 
	echo "Usuario creado con exito, resive en 'lista usuario' para comprobarlo, Toque cualquier boton para continuar" 
	read fff 
fi
clear


