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
grant all on evento to administrativo;

/*TABLA USUARIO*/
grant select, update on usuario to operario, transportista;

/*TABLA CLIENTE*/
grant select on cliente to operario,transportista;

/*TABLA LUGAR*/
grant select  on lugar to operario, transportista;

/*TABLA iNCLUYE*/
grant select on incluye to operario;
grant select on incluye to transportista;

/*TABLA perteneceA*/
grant select on pertenecea to operario;

/*TABLA trabajaEn*/
grant select on trabajaen to operario;

/*TABLA conexcion*/
grant insert, select, update on conexion to operario, transportista;

/*TABLA vehiculo*/
grant select, update on vehiculo to operario;
grant select on vehiculo to transportista;

/*TABLA VehiculoIngresa*/
grant select, insert, update on vehiculoingresa to operario;

/*TABLA InformeDanios*/
grant select, insert, update on informedanios to operario;

/*TABLA registroDanios*/
grant select, insert, update,delete on registrodanios to operario;

/*TABLA imagenregistro*/
grant select, insert,update, delete on imagenregistro to operario;

/*TABLA actualiza*/
grant select, insert,update, delete on actualiza to operario;

/*TABLA posicionado*/
grant select, insert, update on posicionado to operario, transportista;

/*TABLA tipotransporte*/
grant select on tipotransporte to operario, transportista;

/*TABLA habilitado*/
grant select on habilitado to operario, transportista;

/*TABLA mediotransporte*/
grant select on mediotransporte to operario, transportista;

/*TABLA permite*/
grant select  on permite to operario, transportista;

/*TABLA lote*/
grant select, insert, update on lote to operario;
grant select,update on lote to transportista;

/*TABLA integra*/
grant select,update, insert on integra to operario;
grant select on integra to transportista;

/*TABLA Transporte*/
grant select on transporte to operario;
grant select, insert, update on transporte to transportista;

/*TABLA Transporta*/
grant select on transporta to operario;
grant select, insert, update on transporta to transportista;

/*TABLA Link*/
grant select on link to operario;
grant select, insert, update on link to transportista;

/*TABLA evento*/
grant select, insert, update  on evento to operario,transportista;
