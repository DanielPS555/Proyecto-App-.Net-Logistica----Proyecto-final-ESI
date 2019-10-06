#!/bin/bash
#VERCION 3.0 - 25/10 TERCERA ENTREGA desarrolado por Bit (3°BD 2019)

listarUsuariosConPssh()
{
	touch $carpetaBase/Temp/listar #Crea la lista temp 
	hehe=0
	grep "^[a-zA-Z0-9].*:x:[1-9][0-9]\{3,\}:" /etc/passwd | cut -d: -f1,6 | while read fef
	do
		ruta=$(echo $fef|cut -d: -f2)
		nom=$(echo $fef|cut -d: -f1)
		if test -e $ruta/.ssh/authorized_keys 
		then
			echo "Usuario: $nom" >> $carpetaBase/Temp/listar
			hehe=1
			if test $(cat $ruta/.ssh/authorized_keys | wc -l) -eq 0
			then
				echo "---> SIN CLAVE: $nom" >> $carpetaBase/Temp/listar	
			else
				cat $ruta/.ssh/authorized_keys| while read pele
				do
					echo "---> $(echo $pele | cut -d" " -f3)" >> $carpetaBase/Temp/listar	
				done
			fi
		fi

	done


	if test $(cat $carpetaBase/Temp/listar | wc -l)  -eq 0
	then
		echo "Sin resultados" 
		read fff
	else	
		echo "Ingrese 'q' para salir"	
		less $carpetaBase/Temp/listar #Muestra la lista temp 
	fi	
	rm -f $carpetaBase/Temp/listar #elimina la lista 
	
}
