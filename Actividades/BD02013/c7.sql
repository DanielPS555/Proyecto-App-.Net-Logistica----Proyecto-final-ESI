select vin, informedanios.id, registrodanios.idregistro,
informedanios.fecha, lugar.nombre, usuario.nombredeusuario
from vehiculo
inner join informedanios
on informedanios.idvehiculo=vehiculo.idvehiculo
inner join registrodanios
on registrodanios.informedanios=informedanios.id
inner join lugar
on informedanios.idlugar=lugar.idlugar
inner join usuario
on informedanios.idusuario=usuario.idusuario
order by vin, informedanios.id
