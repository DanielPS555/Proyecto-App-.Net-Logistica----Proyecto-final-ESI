source /var/DataConfiguracionABMusuariosSO/lib/backup_functions.sh

if [ ! -d /var/backups ]
then
    mkdir /var/backups
    crearTotal
elif ls /var/backups 2>/dev/null | grep snar
     # Merece una explicación porque va contra toda lógica
     # Cuando grep no encuentra el patrón en su entrada, devuelve 1
     # Lo cual en bash es equivalente a true
     # Uno esperaría que al no encontrar devolvería false
     # Pero esto es porque $? > 0 significa error
     # O sea que un error es verdadero
     # y un éxito es falso
then
    crearTotal
else
    hora=$(date +%H)
    if [ $hora -eq 00 ]
    then
	crearTotal
    else
	crearIncremental
    fi
fi

echo "Se creó el backup $bname"
