create view vehiculos_entregados as
select cliente.nombre, vehiculo.vin
from lugar inner join lote on lote.destino=lugar.idlugar and lugar.tipo='Establecimiento'
inner join transporta on transporta.idlote=lote.idlote and transporta.estado='Exitoso'
inner join integra on integra.lote=lote.idlote
inner join vehiculo on vehiculo.idvehiculo=integra.idvehiculo
inner join cliente on vehiculo.cliente=cliente.idcliente;
