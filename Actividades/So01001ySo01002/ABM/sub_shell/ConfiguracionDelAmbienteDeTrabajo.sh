#!/bin/bash

ConfiguracionDelAmbienteDeTrabajo()
{
if test $USER = "root"
then
	carpeta="/var/automotora"
	verif=0
	while test $verif -eq 0
	do
		verif=1
		echo "Ingrese la ruta de la carpeta base de instalacion o presione enter para usar la por defecto(/var)"
		echo "La ruta debe ser absoluta"
		read vartemp
		if test -z "$vartemp" 
		then
			vartemp=$carpeta
		fi	
	
	
		ruta=$(echo "$vartemp"|sed -e 's/\(\/[a-zA-Z/]\+\/\)\(.\+\)/\1/') #Deducimos por sed la direcion del directorio
		directorio=$(echo "$vartemp"|sed -e 's/\(\/[a-zA-Z/]\+\/\)\(.\+\)/\2/') #Deducimos el nombre del directorio 
		if test $(echo "$directorio" | grep '^[a-zA-Z]\+$'| wc -l ) -eq 1 || test $ruta = $directorio #Verificamos que no haya caracteres invalidos		
		then
			if test -d $ruta 
			then
				carpeta="$vartemp"
				if test -d $vartemp
				then
					echo "Atencion, la carpeta elegida ya existe, se prosedera a crear ahi"
					echo "Se sobre escribiran las carpetas relacionadas con los archivos de instalacion" 
				else
					mkdir $carpeta
				fi
			else
					echo "La direcion donde se creara la carpeta no existe"
					verif=0		
			fi

		else
			echo "El nombre del directorio tiene caracteres invalidos" 
				verif=0
		fi	
	
	done
	cd $carpeta
	if ! test -f Backups
	then
		touch ArchivoConfiguracionAutomotora		
	fi

	if test -d Backups
	then
		rm -rf Backups		
	fi

	if test -d Temp
	then
		rm -rf Temp
	fi

	if test -d shell
	then
		rm -rf shell
	
	fi

	if test -d Registro
	then
		rm -rf Registro
	fi

	mkdir Backups Registro shell Temp
	touch Registro/FechasUsuario #:UID:FechaCreacion:FechaEliminacion


	echo "export carpetaBase=\"$carpeta\"">/etc/ArchivoConfiguracionAutomotora
	if test $(grep "/etc/ArchivoConfiguracionAutomotora" /etc/bashrc | wc -l) -eq 0
	then 
		echo "source /etc/ArchivoConfiguracionAutomotora">>/etc/bashrc
	
	fi
	
	source /etc/ArchivoConfiguracionAutomotora 

	#FALTA AGREGAR USUARIOS BASICOS	

else
	echo "Solo el root puede realizar la instalacion " 
fi

}
