cat >> /etc/profile <<EOF
export INFORMIXDIR=/opt/informix
export ONCONFIG=onconfig.bit
export INFORMIXSERVER=bit
export INFORMIXSQLHOSTS='$INFORMIXDIR/etc/sqlhosts'
export DBDATE=DMY4/
export TERM=vt100
export TERMCAP='$INFORMIXDIR/etc/termcap'
EOF

cd /opt/informix
mkdir dbspaces
chmod 770 dbspaces
chown informix:informix dbspaces
cd dbspaces
touch rootdbs
chmod 660 rootdbs
chown informix:informix rootdbs
touch tempdbs
chmod 660 tempdbs
chown informix:informix tempdbs
touch root_mirror
chmod 660 root_mirror
chown informix:informix root_mirror
cd ../etc
cp onconfig.std onconfig.bit
sed -i "s/ROOTNAME.*/ROOTNAME rootdbs/" onconfig.bit
sed -i 's/ROOTPATH.*/ROOTPATH $INFORMIXDIR\/dbspaces\/rootdbs/' onconfig.bit
sed -i "s/ROOTSIZE.*/ROOTSIZE 1000000/" onconfig.bit
sed -i 's/MIRRORPATH.*/MIRRORPATH $INFORMIXDIR\/dbspaces\/root_mirror/' onconfig.bit
sed -i 's/DBSPACETEMP.*/DBSPACETEMP $INFORMIXDIR\/dbspaces\/tempdbs/' onconfig.bit
sed -i "s/SERVERNUM.*/SERVERNUM 0/" onconfig.bit
sed -i "s/DBSERVERNAME.*/DBSERVERNAME bit/" onconfig.bit
sed -i "s/TAPEDEV.*/TAPEDEV \/dev\/null/" onconfig.bit
sed -i "s/LTAPEDEV.*/LTAPEDEV \/dev\/null/" onconfig.bit
cat >>/opt/informix/etc/sqlhosts <<EOF
bit onipcshm vmInformix bit
bit onsoctcp vmInformix bit
EOF
echo "El sistema se reiniciará, por favor ejecute setup.sh nuevamente"
touch .postinstalled
read k
systemctl reboot
