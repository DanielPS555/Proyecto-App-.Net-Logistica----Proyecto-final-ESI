select registrodanios.informedanios,
       registrodanios.idregistro,
	registrodanios.descripcion,
	count(*) as imagenes from registrodanios
inner join imagenregistro on
imagenregistro.informe=registrodanios.informedanios
group by registrodanios.informedanios, registrodanios.idregistro,
registrodanios.descripcion
having registrodanios.informedanios=? and registrodanios.idregistro=?
