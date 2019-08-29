select vin, marca, modelo, count(*) as danios from vehiculo
inner join registrodanios as registro on
registro.idvehiculo=vehiculo.idvehiculo
left join actualiza on actualiza.vehiculo1=vehiculo.idvehiculo
and actualiza.registro1=registro.idregistro
where actualiza.registro1 is null
group by vin, marca, modelo
order by danios desc
