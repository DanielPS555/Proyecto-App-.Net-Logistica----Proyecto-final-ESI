select lote.nombre, tt.nombre, mt.nombre from (select nombre,
(select count(*) from integra inner join vehiculo
on vehiculo.idvehiculo=integra.idvehiculo and vehiculo.tipo="Auto"
and integra.lote=lote.idlote) as autos,
(select count(*) from integra inner join vehiculo
on vehiculo.idvehiculo=integra.idvehiculo and vehiculo.tipo="Camion"
and integra.lote=lote.idlote) as camiones,
(select count(*) from integra inner join vehiculo
on vehiculo.idvehiculo=integra.idvehiculo and vehiculo.tipo="Van"
and integra.lote=lote.idlote) as vans,
(select count(*) from integra inner join vehiculo
on vehiculo.idvehiculo=integra.idvehiculo and vehiculo.tipo="SUV"
and integra.lote=lote.idlote) as suvs,
(select count(*) from integra inner join vehiculo
on vehiculo.idvehiculo=integra.idvehiculo and vehiculo.tipo="MiniVan"
and integra.lote=lote.idlote) as minivans
from lote) as lote
inner join mediotransporte as mt on mt.cantcamiones >= lote.camiones
and mt.cantautos >= lote.autos
and mt.cantvan >= lote.vans
and mt.cantsuv >= lote.suvs
and mt.cantminivan >= lote.minivans
inner join tipotransporte as tt on mt.idtipo=tt.idtipo
/* medios de transporte que pueden transportar ciertos lotes */
