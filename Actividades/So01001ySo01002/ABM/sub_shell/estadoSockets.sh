#version 2 segunda entrega bit
function socketList()
{
    echo -n "Sockets TCP:$tcpcount"
    ss -s -f inet | head -2 | tail -1 | cut -d':' -f2
    ss -s -f inet | head -n +11
    read ff
}
