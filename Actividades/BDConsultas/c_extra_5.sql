select l1.nombre as origen, l2.nombre as destino, lote.nombre
from lote
inner join lugar as l1 on l1.idlugar=origen and not lote.invalido and
lote.estado = 'Cerrado'
inner join lugar as l2 on l2.idlugar=destino
left join transporta on transporta.estado='Exitoso'
where transporta.estado is null
/* lotes disponibles */
