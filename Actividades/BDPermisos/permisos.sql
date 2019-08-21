revoke all on usuario from PUBLIC;
revoke all on cliente from PUBLIC;
revoke all on lugar from PUBLIC;
revoke all on incluye from PUBLIC;
revoke all on pertenecea from PUBLIC;
revoke all on trabajaen from PUBLIC;
revoke all on conexion from PUBLIC;
revoke all on vehiculo from PUBLIC;
revoke all on vehiculoingresa from PUBLIC;
revoke all on informedanios from PUBLIC;
revoke all on registrodanios from PUBLIC;
revoke all on imagenregistro from PUBLIC;
revoke all on actualiza from PUBLIC;
revoke all on posicionado from PUBLIC;
revoke all on tipotransporte from PUBLIC;
revoke all on habilitado from PUBLIC;
revoke all on mediotransporte from PUBLIC;
revoke all on permite from PUBLIC;
revoke all on lote from PUBLIC;
revoke all on integra from PUBLIC;
revoke all on transporte from PUBLIC;
revoke all on transporta from PUBLIC;
revoke all on link from PUBLIC;

create role operario;
create role transportista;
create role administrativo;
grant all on usuario to administrativo;
grant all on cliente to administrativo;
grant all on lugar to administrativo;
grant all on incluye to administrativo;
grant all on pertenecea to administrativo;
grant all on trabajaen to administrativo;
grant all on conexion to administrativo;
grant all on vehiculo to administrativo;
grant all on vehiculoingresa to administrativo;
grant all on informedanios to administrativo;
grant all on registrodanios to administrativo;
grant all on imagenregistro to administrativo;
grant all on actualiza to administrativo;
grant all on posicionado to administrativo;
grant all on tipotransporte to administrativo;
grant all on habilitado to administrativo;
grant all on mediotransporte to administrativo;
grant all on permite to administrativo;
grant all on lote to administrativo;
grant all on integra to administrativo;
grant all on transporte to administrativo;
grant all on transporta to administrativo;
grant all on link to administrativo;

grant select on link to transportista;

grant select on usuario to operario, transportista;
grant update on usuario to operario, transportista;

grant select on permite to operario;

grant select on mediotransporte to transportista;

grant select on tipotransporte  to transportista;

grant select on trabajaen to transportista, operario;

grant select on conexion to operario, transportista;
grant update on conexion to operario, transportista;
grant insert on conexion to operario, transportista;

grant select on lugar to operario, transportista;

grant select on habilitado to operario, transportista;

grant select on incluye to operario, transportista;

grant select on perteneceA to operario, transportista;

grant select on cliente to operario, transportista;

grant select on posicionado to operario, transportista;
grant update on posicionado to operario, transportista;
grant insert on posicionado to operario, transportista;

grant select on vehiculo to operario;
grant update on vehiculo to operario;

grant select on vehiculoingresa to operario;
grant insert on vehiculoingresa to operario;

grant select on informedanios to operario;
grant update on informedanios to operario;
grant insert on informedanios to operario;

grant select on registrodanios to operario;
grant update on registrodanios to operario;
grant insert on registrodanios to operario;

grant select on imagenregistro to operario;
grant insert on imagenregistro to operario;

grant select on actualiza to operario;
grant insert on actualiza to operario;
grant update on actualiza to operario;

grant select on integra to operario, transportista;
grant insert on integra to operario;
grant update on integra to operario;

grant select on lote to operario, transportista;
grant insert on lote to operario;
grant update on lote to operario;

grant insert on transporta to transportista;
grant update on transporta to transportista;

grant select on transporte to transportista;
grant update on transporte to transportista;
grant insert on transporte to transportista;
