#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)

# NO ES USO POR EL MOMENTO 

cp informix.service /etc/systemd/system/
cp sysconfig.informix /etc/sysconfig/informix
systemctl start informix
systemctl enable informix
