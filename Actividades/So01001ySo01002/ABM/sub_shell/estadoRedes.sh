#Version 2 segunda entrega bit
function estadoRedes() {
    ip addr | grep "BROADCAST" | while read network
    do
	dev=$(echo $network | cut -d' ' -f2 | tr -dC 'A-Za-z0-9')
	addr=$(ip addr show dev $dev | grep 'inet ' | cut -d' ' -f6)
	brdc=$(ipcalc -b $addr | cut -d'=' -f2)
	stat=$(ip addr show dev $dev | grep "state" | cut -d' ' -f9)
	gtwy=$(ip route show dev $dev | grep "default" | cut -d' ' -f3)
	echo -n "Dispositivo: $dev"
	if [ "$stat" == "UP" ];
	then
	    echo -n " ($addr), broadcast $brdc"
	    echo -n " a través de $gtwy"
	fi
	echo " está $stat"
    done
    read ff
}
