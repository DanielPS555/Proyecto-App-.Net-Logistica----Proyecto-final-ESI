#!/bin/bash
#Version 2 SEGUNDA ENTREGA Bit
function crearTotal()
{
    curdir=$(pwd)
    cd /
    if ! [ -d "var/respaldos" ]
    then
        mkdir var/respaldos
    fi
    bname=total_$(date +%d-%m-%Y)
    tar cvzf var/respaldos/$bname.tgz -g var/respaldos/$bname.snar opt/informix var/log/btmp.* var/log/wtmp.* var/log/messages.* home
    if ! [ -f "var/respaldos/respaldos.csv" ]
    then
	echo NOMBRE,DEPENDENCIA > var/respaldos/respaldos.csv
    fi
    echo $bname,null >> var/respaldos/respaldos.csv
    echo $bname > var/respaldos/last_total
    echo $bname > var/respaldos/latest
    cd $curdir
}

function totalManual()
{
    crearTotal;
    echo "Total creado: $bname"
    read k
}

function crearDiferencial()
{
    curdir=$(pwd)
    cd /
    if ! [ -d "var/respaldos" ]
    then
        mkdir var/respaldos
    fi
    last_total=$(cat var/respaldos/last_total)
    last_date=$(echo $last_total | cut -d_ -f2)
    bname=diferencial_$(date +%d-%m-%Y)
    cp var/respaldos/$last_total.snar var/respaldos/$bname.snar
    tar cvzf var/respaldos/$bname.tgz -g var/respaldos/$bname.snar opt/informix var/log/btmp.* var/log/wtmp.* var/log/messages.*
    if ! [ -f "var/respaldos/respaldos.csv" ]
    then
	echo NOMBRE,DEPENDENCIA > var/respaldos/respaldos.csv
    fi
    echo $bname,$last_total >> var/respaldos/respaldos.csv
    echo $bname > var/respaldos/latest
    cd $curdir
}

function diferencialManual()
{
    crearDiferencial;
    echo "Diferencial creado: $bname"
    read k
}

function crearIncremental()
{
    curdir=$(pwd)
    cd /
    if ! [ -d "var/respaldos" ]
    then
        mkdir var/respaldos
    fi
    last=$(cat var/respaldos/latest)
    echo Based on $last
    bname=incremental_$(date +%d-%m-%Y_%H:%M)
    echo 'Copying last.snar ($last.snar) to $bname.snar'
    cp var/respaldos/$last.snar var/respaldos/$bname.snar
    stat var/respaldos/$last.snar
    stat var/respaldos/$bname.snar
    read k
    tar cvzf var/respaldos/$bname.tgz -g var/respaldos/$bname.snar opt/informix var/log/btmp.* var/log/wtmp.* var/log/messages.*
    if ! [ -f "var/respaldos/respaldos.csv" ]
    then
	echo NOMBRE,DEPENDENCIA > var/respaldos/respaldos.csv
    fi
    echo $bname,$last >> var/respaldos/respaldos.csv
    echo $bname >> var/respaldos/latest
    cd $curdir
}

function incrementalManual()
{
    crearIncremental
    echo "Incremental creado: $bname"
    read k
}
