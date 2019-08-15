select vin,
nvl(lugar.idlugar, "?") as idlugar,
nvl(lugar.nombre, "No hay lugares para este vehiculo") as nombrelugar,
nvl(current year to minute - transporte.fechahorallegadareal::datetime year to minute, "?")
as tiempo_en_lugar
from
vehiculo left join integra on integra.idvehiculo=vehiculo.idvehiculo
left join lote on integra.lote=lote.idlote
left join transporta on lote.idlote=transporta.idlote and transporta.estado="Exitoso"
left join transporte on transporta.transporteid=transporte.transporteid
left join lugar on lugar.idlugar=lote.destino and transporta.estado="Exitoso"
where vehiculo.VIN="1L0V36I113UWU1112"
order by tiempo_en_lugar limit 1
