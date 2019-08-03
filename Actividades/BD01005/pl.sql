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

create function zonas_en_lugar(lugarid like lugar.idlugar)
   returning integer, varchar(100), integer
	DEFINE idz integer;
	DEFINE nmz varchar(100);
	DEFINE cpz integer;
	FOREACH cursor1 FOR
	  select lugar.idlugar, nombre, capacidad
	  into idz, nmz, cpz
	  from lugar inner join
	  (select menor as idlugar from incluye
	   start with mayor=lugarid
	   connect by prior menor=mayor) as children on lugar.idlugar=children.idlugar
	  where lugar.tipo="Zona"
	  return idz, nmz, cpz WITH RESUME;
	END FOREACH;
end function;

create function subzonas_en_zona(lugarid like lugar.idlugar, zonaid like lugar.idlugar)
   returning integer, varchar(100), integer
	DEFINE idz integer;
	DEFINE nmz varchar(100);
	DEFINE cpz integer;
	FOREACH cursor1 FOR
	  select lugar.idlugar, nombre, capacidad
	  into idz, nmz, cpz
	  from lugar inner join
	  (select menor as idlugar from incluye
	   start with mayor=lugarid and menor=zonaid
	   connect by prior menor=mayor) as children on lugar.idlugar=children.idlugar
	  where lugar.tipo="Subzona"
	  return idz, nmz, cpz WITH RESUME;
	END FOREACH;
end function;

create function subzonas_en_lugar(lugarid like lugar.idlugar)
   returning integer, varchar(100), integer
	DEFINE idz integer;
	DEFINE nmz varchar(100);
	DEFINE cpz integer;
	FOREACH cursor1 FOR
	  select lugar.idlugar, nombre, capacidad
	  into idz, nmz, cpz
	  from lugar inner join
	  (select menor as idlugar from incluye
	   start with mayor=lugarid
	   connect by prior menor=mayor) as children on lugar.idlugar=children.idlugar
	  where lugar.tipo="Subzona"
	  return idz, nmz, cpz WITH RESUME;
	END FOREACH;
end function;
