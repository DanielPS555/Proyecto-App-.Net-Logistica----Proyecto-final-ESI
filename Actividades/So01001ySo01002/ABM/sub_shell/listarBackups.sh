#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
function listarBackups()
{
    bks=($(ls -t /var/respaldos/*.tgz | cut -d"/" -f4 | cut -d. -f1))
    if [ "${#bks[@]}" -eq 0 ]
    then
	echo "No hay respaldos"
	read k
	return
    fi
    for i in ${!bks[@]}; do
	tipo=$(echo ${bks[$i]} | cut -d_ -f1)
	echo $i: ${tipo^}: ${bks[$i]}
    done
    echo -n "Desea restaurar algún backup? [0-${#bks[@]}), -1 para salir: "
    read ff
    if test "$(echo $ff | grep -E "^[0-9]{1,}$" | wc -l)" -ne 1
    then
	return
    fi
    cnode=${bks[$ff]}
    # se crea un arbol de dependencias comenzando en el backup indicado
    deptree=("$cnode")
    echo ${deptree[@]}
    # se busca su correspondiente dependencia en el csv
    cnode=$(grep "$cnode" /var/respaldos/respaldos.csv | cut -d, -f2)
    while [ "$cnode" != "null" ]; do
    # se expande el arbol de dependencias con la dependencia del anterior
	deptree=(${deptree[@]} "$cnode")
    # se busca la dependencia del backup dependencia en el csv
	cnode=$(grep "$cnode" /var/respaldos/respaldos.csv  | head -1 | cut -d, -f2)
	echo ${deptree[@]}
    done
    echo -n "Para restaurar ese backup, debe restaurar la cadena: ${deptree[@]} ¿Desea continuar? (y/N): "
    read ff
    if [ "$ff" = "y" ];
    then
	for ((i=$[${#deptree[@]}-1]; i>=0; i--)); do
	    echo ${deptree[$i]}
        #se extraen en orden inverso, es decir, el backup indicado ultimo
	    tar xvf /var/respaldos/${deptree[$i]}.tgz -C /
	done
    fi
    echo "Listo!"
    read p
}
