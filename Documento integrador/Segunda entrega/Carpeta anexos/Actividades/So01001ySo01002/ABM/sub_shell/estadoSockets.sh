#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
function socketList()
{
    echo -n "Sockets TCP:$tcpcount"
    ss -s -f inet | head -2 | tail -1 | cut -d':' -f2
    ss -s -f inet | head -n +11
    read ff
}
