select usuario, transporte.transporteid, fechahorallegadaestm, fechahorallegadareal,
fechahorallegadareal-fechahorallegadaestm as demora
from transporte
inner join transporta on transporte.transporteid=transporta.transporteid
inner join lote on lote.idlote=transporta.idlote
inner join lugar on lote.destino=lugar.idlugar and lugar.idlugar=1
where YEAR(transporta.fechahorallegadareal)=YEAR(CURRENT)
and MONTH(transporta.fechahorallegadareal)=MONTH(CURRENT)
