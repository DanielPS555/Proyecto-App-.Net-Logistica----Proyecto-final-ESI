select lugar.nombre as lugar, count(*) as daniados from vehiculo inner join
 informedanios on informedanios.idvehiculo=vehiculo.idvehiculo
inner join
 lugar on informedanios.idlugar=lugar.idlugar
where year(informedanios.fecha) = year(current)
group by lugar.nombre
order by daniados
