#!/bin/bash

# VERCION 3.0 - 25/10 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

sysmaster()
{
if test -d /opt/IBM/Informix_Software_Bundle/
then
	
		if test -e /opt/IBM/Informix_Software_Bundle/etc/conv/rebuildsmi.sh
		then
			su informix -c "sh /opt/IBM/Informix_Software_Bundle/etc/conv/rebuildsmi.sh"
			read fff
		else
			echo "ERROR CRITICO: no se encuentra el documento rebuildsmi.sh, por favor solucione y vuelva a ejecutar, sujerimos reinstalar informix"
			echo "Toque cualquier boton para salir " 
			read fff
		fi 
 	
	
else
echo "Instale informix primero "
		read fff
fi

}
