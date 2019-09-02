#Version 2 SEGUNDA ENTREGA Bit
source /etc/profile.d/zz_configInformix.sh
su informix -c "source /etc/profile"
su informix -c "oninit -ivy"
su informix -c "onmode -vky"
su informix -c "oninit -vy"
systemctl start informix
systemctl enable informix
rm -f /var/DataConfiguracionABMusuariosSO/I_Inxo
echo "Informix instalado con exito"