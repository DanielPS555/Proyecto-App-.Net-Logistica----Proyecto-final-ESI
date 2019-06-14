
#!/bin/bash
#Imprencion de texto
echo " _____________________________________________"
echo " |                                           |"
echo " |                                           |"
echo " |          Bienvenidos Al servidor          |"
echo " |                  por Bit                  |"
echo " |                                           |"
echo " |___________________________________________|"
echo "  Usuario: $USER" #Muestra el nombre del usuario
echo "  Ultimo Ingreso: $(lastlog  -u root |grep "$USER"| cut -c45-80)" #muestra el ultimo ingreso al sistema
