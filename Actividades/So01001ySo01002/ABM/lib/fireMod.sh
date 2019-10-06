#!/bin/bash
#VERCION 3.0 - 25/10 TERCERA ENTREGA desarrolado por Bit (3°BD 2019)

fireMod1() 
{
 fluchFire
 politD
 iptables -A INPUT -p tcp -m tcp --dport 20022 -j ACCEPT #PErmitimos entrada del ssh (Se cambio el puerto) 
 iptables -A OUTPUT -p tcp -m tcp --sport 20022 -m state --state ESTABLISHED,RELATED -j ACCEPT
 if test  $1 -eq 1 2>/dev/null
 then 
   return   
 fi   
  echo "1" > /var/DataConfiguracionABMusuariosSO/fire.data
  service iptables save
}

fireMod2()
{
 fluchFire
 politD
 iptables -A INPUT -p tcp -m tcp --dport 20022 -j ACCEPT #PErmitimos entrada del ssh (Se cambio el puerto) 
 iptables -A OUTPUT -p tcp -m tcp --sport 20022 -m state --state ESTABLISHED,RELATED -j ACCEPT
 iptables -A INPUT -p tcp -m tcp --dport 9088 -j ACCEPT #PErmitimos entrada del ODBC (INFORMIX)
 iptables -A OUTPUT -p tcp -m tcp --sport 9088 -m state --state ESTABLISHED,RELATED -j ACCEPT
 if test  $1 -eq 1 2>/dev/null
 then 
   return   
 fi  
 echo "2" > /var/DataConfiguracionABMusuariosSO/fire.data
 service iptables save
}

fireMod0()
{
 fluchFire
 politA	 
 if test  $1 -eq 1 2>/dev/null
 then 
   return   
 fi  
 echo "0" > /var/DataConfiguracionABMusuariosSO/fire.data
 service iptables save

}

fluchFire()
{
## FLUSH de reglas
iptables -F
iptables -X
iptables -Z
}

politA()
{
## Establecemos politica por defecto
iptables -P INPUT ACCEPT
iptables -P OUTPUT ACCEPT
iptables -P FORWARD ACCEPT
}

politD()
{
## Establecemos politica por defecto
iptables -P INPUT DROP
iptables -P OUTPUT DROP
iptables -P FORWARD DROP
}
