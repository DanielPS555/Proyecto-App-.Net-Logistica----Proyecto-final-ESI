select l1.nombre as desde, tt.nombre as mediante, l2.nombre as hacia from lugar as l1
inner join habilitado as h1 on l1.idlugar = h1.idlugar
inner join habilitado as h2 on h1.idtipo=h2.idtipo
	and h1.idlugar <> h2.idlugar
inner join lugar as l2 on h2.idlugar=l2.idlugar
inner join tipotransporte as tt on h1.idtipo=tt.idtipo
