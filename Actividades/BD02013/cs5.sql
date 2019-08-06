/* ID del vehiculo, ID del usuario, ID del lugar, ID del vehiculo, posicion */
update posicionado set hasta=current year to second where idvehiculo=?
and hasta is null;
insert into posicionado(idusuario, idlugar, idvehiculo, desde, posicion)
values(?,?,?,current year to second, ?);
