#!/bin/bash
#Version 2 SEGUNDA ENTREGA Bit
function crearTotal()
{
    curdir=$(pwd)
    cd /
    if ! [ -d "var/backups" ]
    then
        mkdir var/backups
    fi
    bname=total_$(date +%d-%m-%Y)
    tar cvzf var/backups/$bname.tgz -g var/backups/$bname.snar opt/informix var/log/btmp.* var/log/wtmp.* var/log/messages.* home
    if ! [ -f "var/backups/backups.csv" ]
    then
	echo NOMBRE,DEPENDENCIA > var/backups/backups.csv
    fi
    echo $bname,null >> var/backups/backups.csv
    echo $bname > var/backups/last_total
    echo $bname > var/backups/latest
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
    if ! [ -d "var/backups" ]
    then
        mkdir var/backups
    fi
    last_total=$(cat var/backups/last_total)
    last_date=$(echo $last_total | cut -d_ -f2)
    bname=diferencial_$(date +%d-%m-%Y)
    cp var/backups/$last_total.snar var/backups/$bname.snar
    tar cvzf var/backups/$bname.tgz -g var/backups/$bname.snar opt/informix var/log/btmp.* var/log/wtmp.* var/log/messages.*
    if ! [ -f "var/backups/backups.csv" ]
    then
	echo NOMBRE,DEPENDENCIA > var/backups/backups.csv
    fi
    echo $bname,$last_total >> var/backups/backups.csv
    echo $bname > var/backups/latest
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
    if ! [ -d "var/backups" ]
    then
        mkdir var/backups
    fi
    last=$(cat var/backups/latest)
    echo Based on $last
    bname=incremental_$(date +%d-%m-%Y)
    echo 'Copying last.snar ($last.snar) to $bname.snar'
    cp var/backups/$last.snar var/backups/$bname.snar
    stat var/backups/$last.snar
    stat var/backups/$bname.snar
    read k
    tar cvzf var/backups/$bname.tgz -g var/backups/$bname.snar opt/informix var/log/btmp.* var/log/wtmp.* var/log/messages.*
    if ! [ -f "var/backups/backups.csv" ]
    then
	echo NOMBRE,DEPENDENCIA > var/backups/backups.csv
    fi
    echo $bname,$last >> var/backups/backups.csv
    echo $bname >> var/backups/latest
    cd $curdir
}

function incrementalManual()
{
    crearIncremental
    echo "Incremental creado: $bname"
    read k
}
