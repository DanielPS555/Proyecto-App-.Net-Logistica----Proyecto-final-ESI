create view medioshabilitados as
select lugar.nombre as lugar, tipotransporte.nombre as medio
from lugar
inner join habilitado on habilitado.idlugar=lugar.idlugar
inner join tipotransporte on tipotransporte.idtipo=habilitado.idtipo
