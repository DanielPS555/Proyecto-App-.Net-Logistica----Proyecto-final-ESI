#version 2 segunda entrega bit
function configurarRed()
{
    interfaces_red=$(ip link | grep "<BROADCAST" | cut -d':' -f2 | tr -d ' ')
    for i in "${!interfaces_red[@]}"; do
	echo "$i) ${interfaces_red[$i]}"
    done
    iface_idx=-1
    while [ $iface_idx -lt 0 ]
    do
	echo -n "Qué interfaz desea configurar? [0-${#interfaces_red[@]}): "
	read iface_idx
	if [ "$iface_idx" = "" ]
	then
	    return
	fi
	if ! echo $iface_idx | grep -E "^[0-9]+$"
	then
	    iface_idx=-1
	    echo "Rango válido es [0-${#interfaces_red[@]})"
	elif [ \( $iface_idx -ge ${#interfaces_red[@]} \) -o \( $iface_idx -lt 0 \) ]
	then
	    iface_idx=-1
	    echo "Rango válido es [0-${#interfaces_red[@]})"
	fi
    done
    dev=${interfaces_red[$iface_idx]}
    echo "Configuración actual del dispositivo:"
    echo "IP:" $(ip addr show dev $dev | head -3 | tail -1 | cut -d' ' -f6)
    echo "Gateway:" $(ip route show dev $dev | head -1 | cut -d' ' -f3)
    echo -n "Desea cambiar estas opciones? (y/N) "
    read verif
    if [ "$verif" == "y" ]
    then
	submask=-1
	while [ $submask -lt 0 ]
	do
	    echo -n "Nueva IP/máscara: "
	    read newip
	    if [ $(echo $newip | grep -E '/[1-3]{0,1}[0-9]{1}$' | wc -l) -eq 1 ]
	    then
		ip=$(echo $newip | cut -d'/' -f1)
		if ! ipcalc -c $ip 2>/dev/null
		then
		    echo "La ip $ip no es válida"
		else
		    submask=$(echo $newip | cut -d'/' -f2)
		    if [ $submask -gt 32 ]
		    then
			echo "La submascara $submask es invalida"
			submask=-1
		    fi
		fi
	    else
		echo "Debe ingresar una IP con submáscara"
	    fi
	done
	network=$(ipcalc -n $newip)
	smask=$(ipcalc -m $newip)
	gway=""
	while [ "$gway" == "" ]
	do
	    echo -n "Puerta de enlace (si no escribe nada, se utilizará la primera IP de la red): "
	    read gway
	    if [ "$gway" == "" ]
	    then	    
		lastoct=$(echo $network | cut -d. -f4)
		lastoct=$[$lastoct + 1]
		gway=$(echo $network | cut -d= -f2 | cut -d. -f1,2,3).$lastoct
		echo "Puerta de enlace por defecto: $gway"
	    else
		if ! ipcalc -c $gway
		then
		    echo "La IP $gway no es válida"
		    gway=""
		elif [ "$(ipcalc -n $gway $(echo $smask | cut -d= -f2))" != "$network" ]
		then
		    echo "La IP $gway no está en la misma red que la IP $ip"
		    gway=""
		fi
	    fi
	done
	cfguid="UUID="$(uuidgen $dev)
	echo -n "IP de la DNS (si no escribe nada, se utilizará el gateway por defecto): "
	read dnsip
	if [ "$dnsip" == "" ]
	then
	    dnsip=$gway
	fi
	gway="GATEWAY=$gway"
	echo "Interfaz: " $dev
	echo "IP: " $ip
	echo "Máscara: " $(echo $smask | cut -d= -f2)
	echo "Red: " $(echo $network | cut -d= -f2)
	echo "Gateway: " $(echo $gway | cut -d= -f2)
	echo "DNS: " $(echo $dnsip | cut -d= -f2)
	echo -n "Desea confirmar? (y/N) "
	read conf
	if [ "$conf" == "y" ]
	then
	    printf "NAME=%s\nDEVICE=%s\nPEERDNS=yes\nDNS1=%s\n%s\n%s\nIPADDR=%s" \
		$dev $dev $dnsip "$smask" "$gway" "$ip" > /etc/sysconfig/network-scripts/ifcfg-$dev
	    ifdown $dev
	    ifup $dev
	fi
    fi
}
