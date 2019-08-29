select count(*) as vehiculos_sin_inspeccion from lugar
inner join posicionado on lugar.idlugar=posicionado.idlugar and
posicionado.hasta is null
inner join vehiculo on posicionado.idvehiculo=vehiculo.idvehiculo
left join informedanios on vehiculo.idvehiculo=informedanios.idvehiculo
and informedanios.idlugar=lugar.idlugar
where lugar.tipo="Puerto"
