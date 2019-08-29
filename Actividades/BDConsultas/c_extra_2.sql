select tt.nombre from lote
inner join lugar as l1 on l1.idlugar=lote.origen
inner join lugar as l2 on l2.idlugar=lote.destino
inner join habilitado as h1 on l1.idlugar=h1.idlugar
inner join habilitado as h2 on l2.idlugar=h2.idlugar
			   and h1.idtipo=h2.idtipo
inner join tipotransporte as tt on tt.idtipo=h1.idtipo
where lote.nombre="l_1"
/* tipos de medios a través de los cuales se puede transporatr un loite */
