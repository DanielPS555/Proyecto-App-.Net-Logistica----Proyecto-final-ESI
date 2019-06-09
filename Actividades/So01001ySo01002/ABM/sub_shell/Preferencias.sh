#sed -e 's/\(GROUP=\)\(.*\)$/\1Juan /' /etc/default/useradd
# sed -e 's/\(PASS_MAX_DAYS.\)\(.*\)$/\1Juan /' /etc/login.defs

Preferencias()
{
	eu1=('Mostrar_preferencias' 'Modificar_El_directorio_principal_por_defecto' 'Modificar_el_shell_de_inicio_por_defecto' 'Modificar_fecha_de_expiracion_por_defecto' 'Modificar_N°_dias_advertencia_por_defecto' 'Modificar_N°_de_dias_de_actividad_luego_de_caducada_la_password_por_defecto' 'Modificar_N°_dias_max_de_valides_de_la_passoword_por_defecto')
	eu2=('mostrarPreferencias' 'MHome' 'MShell' 'MExpire' 'MPassWarn' 'MInactivo' 'MPassDuracion')	
	
	menu 'eu1[@]' 'eu2[@]'	

	ary1=(${nombres[@]})
	ary2=(${direcionesSetUp[@]})
}


mostrarPreferencias()
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


MHome()
{
	cambiarDT 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(HOME=\)\(.*\)$|\1$respuesta|g" /etc/default/useradd

	fi
	

}

MInactivo()
{
	verifNumDias '3' 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(INACTIVE=\)\(.*\)$|\1$respuesta|g" /etc/default/useradd

	fi
}

MExpire()
{
	cambiarExUser '2' 
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(EXPIRE=\)\(.*\)$|\1$respuesta|g" /etc/default/useradd

	fi
}

MShell()
{
	cambiarShell
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(SHELL=\)\(.*\)$|\1$respuesta|g" /etc/default/useradd

	fi
}

MPassDuracion()
{
	verifNumDias '2'
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(PASS_MAX_DAYS.\)\(.*\)$|\1$respuesta|g" /etc/login.defs

	fi
}

MPassWarn()
{
	verifNumDias '1'
	if test $(echo $respuesta| grep -e "POR DEFECTO"| wc -l) -eq 1 
	then
		echo "No se realizaran cambios"
		read ff
	else
		sed -i "s|\(PASS_WARN_AGE.\)\(.*\)$|\1$respuesta|g" /etc/login.defs

	fi
}
