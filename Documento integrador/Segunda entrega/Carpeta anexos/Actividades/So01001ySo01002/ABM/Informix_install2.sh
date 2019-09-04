#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
source /etc/profile.d/zz_configInformix.sh
su informix -c "source /etc/profile"
su informix -c "oninit -ivy"
su informix -c "onmode -vky"
su informix -c "oninit -vy"
cp /var/DataConfiguracionABMusuariosSO/informix.service /etc/systemd/system/
cp /var/DataConfiguracionABMusuariosSO/sysconfig.informix /etc/sysconfig/informix
systemctl start informix
systemctl enable informix
rm -f /var/DataConfiguracionABMusuariosSO/I_Inxo
echo "Informix instalado con exito"
