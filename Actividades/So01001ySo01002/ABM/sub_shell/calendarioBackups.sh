#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
function calendarioBackups()
{
    hora=$(date +%H) # hora actual; se mostrarán los backups de las proximas 24 hs
    mes=$(date +%m)  # mes actual, para manejar el caso en que alguna de las proximas 24hs caiga en otro mes
    dias_en_mes=$(date +%d -d "$mes/1 +1 month -1 day") # ejemplo: es 8/3 -> 1/3 + 1 mes = 1/4 - 1 dia = 30/3
    dia=$(date +%d) # dia de hoy
    #for ((i=0;i<24;++i)); do // los loops de C son mejores
    for i in $(seq 0 23); do
        horaAjustada=$[$hora + $i];
        horaAjustadaNormalizada=$[$horaAjustada % 24];
            case $horaAjustadaNormalizada in
                0)
                    tipoBack="total";; # hacemos backups totales a medio dia
                *)
                    tipoBack="incremental";;
            esac
        fcha=$[$dia + ($horaAjustada/24)]; # Agregar un dia a la fecha cuando estamos mostrando un horario > 24
        nFcha=$[( ($fcha-1) % $dias_en_mes)+1];  # Ajustar a los dias del mes
        echo $nFcha - $horaAjustadaNormalizada: $tipoBack; # Fecha: hora [total/incremental]
    done
    read k
}
