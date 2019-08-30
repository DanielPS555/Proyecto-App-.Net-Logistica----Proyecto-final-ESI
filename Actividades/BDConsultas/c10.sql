select vehiculo.vin, vehiculo.marca, vehiculo.modelo,
t.transporteid as nroembarque,
lote.idlote as nrolote, lote.nombre as nombrelote,
usuario.primerapellido, usuario.primernombre,
usuario.nombredeusuario
from
(select first 1 transporteid from transporte order by fechahorasalida desc) as t
inner join transporta on transporta.transporteid=t.transporteid
inner join lote on lote.idlote=transporta.idlote
inner join integra on integra.lote=lote.idlote
inner join usuario on integra.idusuario=usuario.idusuario
inner join vehiculo on vehiculo.idvehiculo=integra.idvehiculo
where vehiculo="VIN"
