create view conexiones_usuarios as
select usuario.nombredeusuario as usuario,
conexion.horaingreso, conexion.horasalida,
lugar.nombre as lugar
from usuario
inner join conexion on conexion.usuario=usuario.idusuario
left join trabajaen on trabajaen.id=conexion.idtrabajaen
left join lugar on lugar.idlugar=trabajaen.idlugar;
