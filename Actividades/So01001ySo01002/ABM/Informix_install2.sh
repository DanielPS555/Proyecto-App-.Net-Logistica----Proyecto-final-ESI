#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
source /etc/profile.d/zz_configInformix.sh
su informix -c "source /etc/profile;oninit -ivy;onmode -vky;oninit -vy"
touch /opt/IBM/Informix_Software_Bundle/dbspaces/datosDbs
chown informix:informix /opt/IBM/Informix_Software_Bundle/dbspaces/datosDbs
chmod 660 /opt/IBM/Informix_Software_Bundle/dbspaces/datosDbs
onspaces -c -d DatosDbs -p /opt/IBM/Informix_Software_Bundle/dbspaces/datosDbs -o 0 -s 100000 #Pongo un nuevo DBspace
cp /var/DataConfiguracionABMusuariosSO/informix.service /etc/systemd/system/
cp /var/DataConfiguracionABMusuariosSO/sysconfig.informix /etc/sysconfig/sysconfig.informix
#systemctl start informix
systemctl enable informix
source /var/DataConfiguracionABMusuariosSO/lib/fireMod.sh
fireMod2
rm -f /var/DataConfiguracionABMusuariosSO/I_Inxo
echo "Informix instalado con exito"
