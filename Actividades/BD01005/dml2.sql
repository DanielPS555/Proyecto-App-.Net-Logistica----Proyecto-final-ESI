insert into vehiculo(VIN, Tipo, Cliente) values ('47873NZU8380A767A', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='47873NZU8380A767A'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('90178I019R528517Y', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='90178I019R528517Y'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('L8573188776273553', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='L8573188776273553'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('42U250431U2BE4647', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='42U250431U2BE4647'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('2253L8H7333288935', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='2253L8H7333288935'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('89359C28W17416520', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='89359C28W17416520'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('18V1644631538S876', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='18V1644631538S876'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('305407447Q6635053', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='305407447Q6635053'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('724194YF2138736F5', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='724194YF2138736F5'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('117437W6J15823PY6', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='117437W6J15823PY6'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('D667Q409338316134', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='D667Q409338316134'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('M68447H89489258W4', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='M68447H89489258W4'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('94243921029924C6Z', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='94243921029924C6Z'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('244112948447W5214', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='244112948447W5214'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('J625508526J7S5063', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='J625508526J7S5063'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('1465CP125729C4646', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='1465CP125729C4646'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('714425708D3488438', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='714425708D3488438'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('0L197640391490510', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='0L197640391490510'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('002M0859H98LI4Y10', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='002M0859H98LI4Y10'), current year to day, 'Precarga', 1);
insert into vehiculo(VIN, Tipo, Cliente) values ('21761862Q65525166', 'Auto', 1);
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='21761862Q65525166'), current year to day, 'Precarga', 1);

insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values
((select IDVehiculo from vehiculo where vin='47873NZU8380A767A'),
 "2019-07-10 12:35:04", 'Alta', 1);
insert into posicionado values
((select idlugar from lugar where nombre="Zona A_1_mvd"),
 (select idvehiculo from vehiculo where vin="47873NZU8380A767A"),
 "2019-07-10 12:35:04", "2019-06-29 13:03:21",18,
 (select idusuario from usuario where primernombre = "Pepe"));
insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario, Detalle) values
((select IDVehiculo from vehiculo where vin='47873NZU8380A767A'), "2019-07-10 15:50:00", 'Baja', 1,
 '{"tipo": "destruccion", "idlugar": 1, "mensaje": "ndeah alto tsundere tsunami kyuun"}'::json);