select vin, nvl(lugar.idlugar, "?") as idlugar,
nvl(lugar.nombre,
"No hay posiciones activas del vehiculo") as nombre,
current year to minute - nvl(posicionado.desde::datetime year to minute, current year to minute)
as tiempo_en_lugar from vehiculo left join posicionado
on vehiculo.idvehiculo=posicionado.idvehiculo and posicionado.hasta is null
left join lugar on lugar.idlugar=posicionado.idlugar
