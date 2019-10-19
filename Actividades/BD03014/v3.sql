create view
vehiculos_lotes(idlote, nombrelote, origenlote, destino, transportado) as
select lote.idlote as idlote, lote.nombre as nombreLote,
origen.nombre as origenLote,
destino.nombre as destinoLote,
(transporta.idlote is not null) as Transportado
from lote
inner join integra on integra.lote=lote.idlote
inner join vehiculo on vehiculo.idvehiculo=integra.idvehiculo
inner join lugar as origen on origen.idlugar=lote.origen
inner join lugar as destino on destino.idlugar=lote.destino
left join transporta on transporta.idlote=lote.idlote
          and transporta.estado='Exitoso';
