create function crear_subzona(nombrez like lugar.Nombre, enLugar like lugar.IDLugar, capacidadz int)
   returning boolean
	DEFINE existelugar, capacidadlugar, creador, lugarid int;
	DEFINE gx, gy float;
	SELECT count(*), capacidad, geox, geoy, usuariocreador
	into existelugar, capacidadlugar, gx, gy, creador
	from lugar where idlugar=enLugar and tipo='Zona'
	group by idlugar, capacidad, geox, geoy, usuariocreador;
	IF existelugar < 1 THEN
		return 'f';
	END IF;
	IF capacidadlugar < capacidadz THEN
		return 'f';
	END IF;
	IF gx is null or gy is null THEN
		return 'f';
	END IF;
	insert into lugar(idlugar, nombre, capacidad, geox, geoy,
			usuariocreador, tipo)
		values(0, nombrez, capacidadz, gx, gy, creador, 'Subzona');
	select dbinfo('sqlca.sqlerrd1') into lugarid from systables where tabid=1;
	insert into incluye values(lugarid, enLugar);
	return 't';
end function;

create function crear_zona(nombrez like lugar.Nombre, enLugar like lugar.IDLugar, capacidadz int)
   returning boolean
	DEFINE existelugar, capacidadlugar, creador, lugarid int;
	DEFINE gx, gy float;
	SELECT count(*), capacidad, geox, geoy, usuariocreador
	into existelugar, capacidadlugar, gx, gy, creador
	from lugar where idlugar=enLugar and tipo in ('Puerto', 'Patio')
	group by idlugar, capacidad, geox, geoy, usuariocreador;
	IF existelugar < 1 THEN
		return 'f';
	END IF;
	IF capacidadlugar < capacidadz THEN
		return 'f';
	END IF;
	insert into lugar(idlugar, nombre, capacidad, geox, geoy,
			usuariocreador, tipo) values(0, nombrez, capacidadz, gx, gy, creador, 'Zona');
	select dbinfo('sqlca.sqlerrd1') into lugarid from systables where tabid=1;
	insert into incluye values(lugarid, enLugar);
	return 't';
end function;

create function zonas_en_lugar(nombrelugar like lugar.Nombre)
   returning integer, varchar(100)
	DEFINE idz integer;
	DEFINE nmz varchar(100);
	FOREACH cursor1 FOR
	  SELECT l1.idlugar, l1.nombre into idz, nmz
	  FROM lugar as l1
		inner join incluye on incluye.menor=l1.idlugar
		inner join lugar as l2 on incluye.mayor=l2.idlugar
	  WHERE l2.nombre=nombrelugar AND l1.tipo='Zona'
	  return idz, nmz WITH RESUME;
	END FOREACH;
end function;
