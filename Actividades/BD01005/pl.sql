create function crear_lugar(nombrel like lugar.nombre, pos_x like lugar.geox, pos_y like lugar.geoy, tipo like lugar.tipo, capacidad like lugar.capacidad, creador like lugar.usuariocreador)
   returning integer
	DEFINE lugarid int;
	IF capacidad < 1 THEN
		return -1;
	END IF
	IF tipo not in ('Puerto', 'Patio', 'Establecimiento') THEN
		return -2;
	END IF
	insert into lugar
	(idlugar, nombre, geox, geoy, capacidad, usuariocreador, tipo, fecharegistro)
	values
	(0,       nombrel,pos_x,pos_y,capacidad, creador,        tipo, current);
	select dbinfo('sqlca.sqlerrd1') into lugarid from systables where tabid=1;
	return lugarid;
end function;

CREATE FUNCTION maximo_ancestro(lugarid LIKE lugar.idlugar)
	returning integer
	define ttx int;
	IF lugarid NOT IN (SELECT menor FROM incluye) THEN
		RETURN lugarid;
	END if;
	select min(mayor) into ttx from incluye start with menor=lugarid connect by menor = prior mayor;
	return ttx;
END FUNCTION;

create function crear_subzona(nombrez like lugar.Nombre, enLugar like lugar.IDLugar, capacidadz int)
   returning integer
	DEFINE existelugar, capacidadlugar, creador, lugarid int;
	DEFINE gx, gy float;
	SELECT count(*), capacidad, geox, geoy, usuariocreador
	into existelugar, capacidadlugar, gx, gy, creador
	from lugar where idlugar=enLugar and tipo='Zona'
	group by idlugar, capacidad, geox, geoy, usuariocreador;
	IF existelugar < 1 THEN
		return -1;
	END IF;
	IF capacidadlugar < capacidadz THEN
		return -1;
	END IF;
	IF gx is null or gy is null THEN
	END IF;
	insert into lugar(idlugar, nombre, capacidad, geox, geoy,
			usuariocreador, tipo,fechaRegistro)
		values(0, nombrez, capacidadz, gx, gy, creador, 'Subzona',current);
	select dbinfo('sqlca.sqlerrd1') into lugarid from systables where tabid=1;
	insert into incluye values(lugarid, enLugar);
	return lugarid;
end function;

create function crear_zona(nombrez like lugar.Nombre, enLugar like lugar.IDLugar, capacidadz int)
   returning integer
	DEFINE existelugar, capacidadlugar, creador, lugarid int;
	DEFINE gx, gy float;
	SELECT count(*), capacidad, geox, geoy, usuariocreador
	into existelugar, capacidadlugar, gx, gy, creador
	from lugar where idlugar=enLugar and tipo in ('Puerto', 'Patio')
	group by idlugar, capacidad, geox, geoy, usuariocreador;
	IF existelugar < 1 THEN
		return -1;
	END IF;
	IF capacidadlugar < capacidadz THEN
		return -1;
	END IF;
	insert into lugar(idlugar, nombre, capacidad, geox, geoy,
			usuariocreador, tipo,fechaRegistro) values(0, nombrez, capacidadz, gx, gy, creador, 'Zona', current);
	select dbinfo('sqlca.sqlerrd1') into lugarid from systables where tabid=1;
	insert into incluye values(lugarid, enLugar);
	return lugarid;
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
	  where lugar.tipo="Zona" and inhabilitado='f'
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
	  where lugar.tipo="Subzona" and inhabilitado='f'
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
	  where lugar.tipo="Subzona" and inhabilitado='f'
	  return idz, nmz, cpz WITH RESUME;
	END FOREACH;
end function;

create function ocupacion_en_lugar(lugarid like lugar.idlugar)
   returning integer
   	DEFINE tipo varchar(15);
	DEFINE ocup integer;
	select lugar.tipo into tipo from lugar where idlugar=lugarid;
	IF tipo <> "Subzona" THEN
	   select count(*)  into ocup
	   from posicionado where hasta is null
	   and idlugar in (select unnamed_col_1 from table(subzonas_en_lugar(lugarid)));
	ELSE
	   select count(*) into ocup
	   from posicionado where hasta is null and idlugar = lugarid;
	END IF;
	return ocup;
end function;

create function subzonas_en_lugar_por_nombre(lugarnombre like lugar.nombre)
   returning integer, varchar(100), integer
	DEFINE idz integer;
	DEFINE nmz varchar(100);
	DEFINE cpz integer;
	DEFINE lugarid integer;
	select lugar.idlugar into lugarid from lugar where nombre=lugarnombre;
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

create function cerrar_lote(loteid like lote.idlote)
    returning boolean
    	DEFINE unverif boolean;
	select count(*) > 0
	into unverif
	from integra
	inner join vehiculo on integra.idvehiculo=vehiculo.idvehiculo and integra.lote=loteid and integra.invalidado='f'
	inner join lote on integra.lote=lote.idlote
	left join informedanios on informedanios.idvehiculo=vehiculo.idvehiculo and informedanios.idlugar=lote.origen
	where informedanios.id is null;
	IF unverif THEN
	return 'f';
	ELSE
	update lote set estado="Cerrado" where idlote=loteid;
	return 't';
	END IF;
end function;
