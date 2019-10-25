#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
echo " _____________________________________________"
echo " |                                           |"
echo " |                                           |"
echo " |        Bienvenidos Al servidor  V3        |"
echo " |                  por Bit                  |"
echo " |                                           |"
echo " |___________________________________________|"
echo "  Usuario: $USER" #Muestra el nombre del usuario
echo "  Ultimo Ingreso: $(lastlog  -u root |grep "$USER"| cut -c44-80)" #muestra el ultimo ingreso al sistema
