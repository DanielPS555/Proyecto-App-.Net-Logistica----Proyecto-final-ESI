#Version 2 SEGUNDA ENTREGA Bit
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
