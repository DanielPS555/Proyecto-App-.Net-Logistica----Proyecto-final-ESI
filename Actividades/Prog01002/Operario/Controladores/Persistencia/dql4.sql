(select first 1 origen from lote inner join integra on integra.lote=lote.idlote
inner join vehiculo on vehiculo.idvehiculo=1
	and integra.idvehiculo=vehiculo.idvehiculo

where invalidado='f'
order by fecha)
union all
(select destino from lote inner join integra on
integra.lote=lote.idlote inner join vehiculo on vehiculo.idvehiculo=1
	and integra.idvehiculo=vehiculo.idvehiculo
where invalidado='f'
order by fecha)
