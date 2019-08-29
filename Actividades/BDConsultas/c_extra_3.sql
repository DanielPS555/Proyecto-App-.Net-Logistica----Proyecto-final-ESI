select lugar.nombre as lugar, tipotransporte.nombre as mediante,
count(*) as transportes from lugar
inner join lote on lugar.idlugar=lote.origen
inner join transporta on lote.idlote=transporta.idlote
inner join transporte on transporta.transporteid=transporte.transporteid
inner join tipotransporte on transporte.idtipo=tipotransporte.idtipo
group by lugar.nombre, tipotransporte.nombre
order by lugar.nombre, transportes
