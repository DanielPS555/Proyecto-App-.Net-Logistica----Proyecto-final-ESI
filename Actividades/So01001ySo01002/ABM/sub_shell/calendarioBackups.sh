#version 2 segunda entrega bit
function calendarioBackups()
{
    hora=$(date +%H)
    mes=$(date +%m)
    dias_en_mes=$(date +%d -d "$mes/1 +1 month -1 day")
    dia=$(date +%d)
    for ((i=0;i<24;++i)); do
	rH=$[$hora + $i];
        nrH=$[$rH % 24];
        case $nrH in
	0)
	    tipoBack="total";;
	*)
	    tipoBack="incremental";;
	esac
	fcha=$[$dia + ($rH/24)];
	nFcha=$[(($fcha-1)%$dias_en_mes)+1];
	echo $nFcha - $nrH: $tipoBack;
    done
    read k
}
