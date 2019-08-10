select idan.id, informedanios.descripcion,
concat(usuario.primernombre, concat(" ", usuario.primerapellido)) as autor,
informedanios.fecha as fecha,
lugar.nombre as lugar,
idan.regs from
(select informedanios.id, count(*) as regs from informedanios
inner join registrodanios on informedanios.id=registrodanios.informedanios
group by informedanios.id
having id=?) as idan
inner join informedanios on idan.id=informedanios.id
inner join usuario on informedanios.idusuario=usuario.idusuario
inner join lugar on informedanios.idlugar=lugar.idlugar
