#!/bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

Preferencias()
{
	eu1=('Mostrar_preferencias' 'Modificar_El_directorio_principal_por_defecto' 'Modificar_el_shell_de_inicio_por_defecto' 'Modificar_fecha_de_expiracion_por_defecto' 'Modificar_N°_dias_advertencia_por_defecto' 'Modificar_N°_de_dias_de_actividad_luego_de_caducada_la_password_por_defecto' 'Modificar_N°_dias_max_de_valides_de_la_passoword_por_defecto')
	eu2=('mostrarPreferencias' 'MHome' 'MShell' 'MExpire' 'MPassWarn' 'MInactivo' 'MPassDuracion')	
	
	menu 'eu1[@]' 'eu2[@]'	#Se llama al menu de preferencias 
}


mostrarPreferencias() #Aqui se muestran todas las preferencias de los archivos /etc/deafult/useradd y /etc/login.defs 
{
	echo "Directorio de trabajo por defecto: $(grep -e '^HOME' /etc/default/useradd| cut -d= -f2)"
	echo "Shell de inicio por defecto: $(grep -e '^SHELL' /etc/default/useradd| cut -d= -f2)"
	echo "fecha de expiracion por defecto: $(grep -e '^EXPIRE' /etc/default/useradd| cut -d= -f2)" 
	echo "N° de dias caducada la password antes del bloqueo $(grep -e '^INACTIVE' /etc/default/useradd| cut -d= -f2)"
	echo "N° de dias maximos de valides de la password por defecto $(grep -e '^PASS_MAX_DAYS' '/etc/login.defs'| cut -c15-20)"
	echo "N° de dias de advertencia antes que la password caduque $(grep -e '^PASS_WARN_AGE' '/etc/login.defs'| cut -c15-20)"
	echo ""
	echo "Toque cualquier enter para continuar"
	read ff
	
}


MHome() #aqui se cambia el directorio principal predeterminado 
{
	cambiarDT #ingreso del dato 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(HOME=\)\(.*\)$|\1$respuesta|g" /etc/default/useradd #se realiza la modificacion en el archivo /etc/deafult/useradd 

	fi
	

}

MInactivo()
{
	verifNumDias '3' #Ingreso de datos
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(INACTIVE=\)\(.*\)$|\1$respuesta|g" /etc/default/useradd #se realiza la modificacion

	fi
}

MExpire()
{
	cambiarExUser '2' #Ingreso de datos
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(EXPIRE=\)\(.*\)$|\1$respuesta|g" /etc/default/useradd #Se realizan las modificaciones 

	fi
}

MShell() #se modifica el shell por defecto 
{
	cambiarShell #Ingreso de datos 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(SHELL=\)\(.*\)$|\1$respuesta|g" /etc/default/useradd #Se realizan las modificaciones 

	fi
}

MPassDuracion() #Se modifica la duracion por defecto la contraseña
{
	verifNumDias '2'
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(PASS_MAX_DAYS.\)\(.*\)$|\1$respuesta|g" /etc/login.defs #Se realiza el cambio 

	fi
}

MPassWarn() #Se modifica la duracion del tiempo de advertencia 
{
	verifNumDias '1'
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(PASS_WARN_AGE.\)\(.*\)$|\1$respuesta|g" /etc/login.defs #Se realiza el cambio 

	fi
}
