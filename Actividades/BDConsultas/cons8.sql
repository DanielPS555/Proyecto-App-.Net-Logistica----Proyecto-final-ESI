select VIN, informedanios.id as informe, registrodanios.idregistro as registro,
marca, modelo, color, informedanios.descripcion as descripcion_informe,
registrodanios.descripcion as descripcion_registro,
"como mierda queres que muestre una foto en la terminal pelotudo" as imagen from vehiculo
inner join informedanios on informedanios.idvehiculo=vehiculo.idvehiculo
	and informedanios.descripcion<>"Informe de ingreso"
inner join registrodanios on informedanios.idvehiculo=registrodanios.idvehiculo
	and informedanios.id=registrodanios.informedanios
left join imagenregistro on imagenregistro.vehiculo=registrodanios.idvehiculo
	and imagenregistro.informe=registrodanios.informedanios
	and imagenregistro.nrolista=registrodanios.idregistro
