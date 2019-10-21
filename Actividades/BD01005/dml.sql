
	/*USUARIO*/
insert into usuario values (0,"Felipe3","aaaagria","felip49@gmail.com", "27/8/1981", "09877745",
"Felipe","Camacho", "Cual fue su primer juego", "lol", null, "20/3/2018" , 'M','A', null,'f');
/*NO SE PONE CONTRASEÑA AQUI POR EL FUNCIONAMIENTO DE LA ENCRIPTACION DEL PROGRAMA*/
insert into usuario values (0,"Fernanda1654","","ferti49@gmail.com",  "27/8/1981", "098545574"
,"Fernanda","Lopes", "Cual fue su primer telefono" , "Un poquet", 1, "21/3/2018" , 'F','A', null,'f');
insert into usuario values (0,"Pepe12","aaaagria","e1@gmail.com", "27/8/1981", "098167462"
,"Pepe","Miranda", "Cual es tu color favorito" , "Rojo" , 1, "21/3/2018", 'M','O', null,'f');
insert into usuario values (0,"Juan24","aaaagria","re2@outlook.com", "27/8/1981", "098427894"
,"Juan","Simon", "Cual es el nombre de tu perro" , "fido", 1, "21/3/2018", 'F','O', null,'f');
insert into usuario values (0,"Anto322","","anti@gmail.com", "27/8/1981", "098456782"
,"Antonio","Pardiñas", "Cual es el nombre de su pelicula favorita" , "Blanca nieves", 1, "21/3/2018",'O','T', null,'f');
insert into usuario values (0,"PedroB43","","Pedro43563@outlook.com", "27/8/1981", "098452746"
,"Pedro","Couto", "El nomrbe de mi cancion favorita" , "Hello", 1, "21/3/2018", 'M','T', null,'f');
insert into usuario values (0,"JulioMS", "","pachecodemicorazon@adinet.com.uy", "1/1/1928", "911",
 "Julio", "Sanguinetti","15vs19","19",1,"25/3/2017","M","T", null,'f');
/*9*/


	/*LINK*/
insert into link values ("http://maps.com",(select idusuario from usuario where primernombre = "Antonio"));
insert into link values ("http://maps2.com",(select idusuario from usuario where primernombre = "Pedro"));
/*16*/
		/*CLIENTE*/
insert into cliente(IDCliente, RUT, Nombre, fechaRegistro, invalido, usuarioregistro) values(0, 185769246724, "Sevel", "2019-7-10", 'f', 1);
insert into cliente(IDCliente, RUT, Nombre, fechaRegistro, invalido, usuarioregistro) values(0, 785349658722, "Chevrolet UY", "2014-8-8", 'f', 1);

	/*LUGAR*/
insert into lugar(idlugar, nombre, capacidad, geox, geoy, usuariocreador,fechaRegistro, tipo) values (0,"Deposito piedras blancas", 3500, -34.882456, -56.194172,(select idusuario from usuario where primernombre = "Felipe"),'2019-5-2 19:21:00',"Patio");
insert into lugar(idlugar, nombre, capacidad, geox, geoy, usuariocreador,fechaRegistro, tipo) values (0,"Deposito de maldonado", 500, -34.948760, -54.924569,(select idusuario from usuario where primernombre = "Felipe"),'2019-5-3 19:21:00',"Patio");
insert into lugar(idlugar, nombre, capacidad, geox, geoy, usuariocreador,fechaRegistro, tipo) values (0,"Puerto de montevideo", 1200, -34.987460, -56.254790,(select idusuario from usuario where primernombre = "Felipe"),'2019-4-2 16:21:00',"Puerto");
insert into lugar(idlugar, nombre, capacidad, geox, geoy, usuariocreador,fechaRegistro, tipo) values (0,"Puerto de aguas profundas rocha", 2000, -34.658827, -54.152534,(select idusuario from usuario where primernombre = "Felipe"),'2019-5-1 12:01:00',"Puerto");
insert into lugar(idlugar, nombre, capacidad, geox, geoy, usuariocreador,fechaRegistro, tipo) values (0,"Patio de Sevel", null, -34.882799, -56.088555, (select idusuario from usuario where primernombre = "Felipe"),'2019-2-1 12:01:00', "Establecimiento");
insert into perteneceA(IDLugar, ClienteID) values ((select idlugar from lugar where nombre="Patio de Sevel"), (select IDCliente from cliente where Nombre="Sevel"));
insert into lugar(idlugar, nombre, capacidad, geox, geoy, usuariocreador,fechaRegistro, tipo) values (0,"Patio de Chevrolet Ur a gay", null, -33.882799, -56.088555, (select idusuario from usuario where primernombre = "Felipe"),'2019-5-16 19:21:00', "Establecimiento");
insert into perteneceA(IDLugar, ClienteID) values ((select idlugar from lugar where nombre="Patio de Chevrolet Ur a gay"), (select IDCliente from cliente where Nombre="Chevrolet UY"));

/*20*/

	/*TRABAJA EN */
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Deposito de maldonado"),
	(select idusuario from usuario where primernombre = "Pepe"), "26/6/2019","4/9/2019");
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
	(select idusuario from usuario where primernombre = "Pepe"),"26/6/2019",null);
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Deposito piedras blancas"),
	(select idusuario from usuario where primernombre = "Juan"),"13/6/2019",null);
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Puerto de montevideo"),
	(select idusuario from usuario where primernombre = "Juan"),"13/6/2019",null);
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Deposito de maldonado"),
	(select idusuario from usuario where primernombre = "Juan"), "15/6/2019","17/6/2019");
/*25*/
	/*CONEXCION*/
	insert into conexion values (1,"2019-6-27 8:02:00", "2019-6-27 18:06:00",(select idusuario from usuario where primernombre = "Pepe"));
	insert into conexion values (1,"2019-6-28 23:02:00","2019-6-29 02:01:00",(select idusuario from usuario where primernombre = "Pepe"));
	insert into conexion values (1,"2019-6-30 10:20:00","2019-6-30 16:06:00",(select idusuario from usuario where primernombre = "Pepe"));
	insert into conexion values (2,"2019-7-1 8:04:00","2019-6-27 19:06:00",(select idusuario from usuario where primernombre = "Pepe"));
	insert into conexion values (2,"2019-7-2 7:04:00","2019-6-27 18:06:00",(select idusuario from usuario where primernombre = "Pepe"));
	insert into conexion values (2,"2019-7-4 9:04:00","2019-6-27 18:06:00",(select idusuario from usuario where primernombre = "Pepe"));
	insert into conexion values (2,"2019-6-28 20:00:00","2019-6-28 22:00:00",(select idusuario from usuario where primernombre = "Pepe"));
	insert into conexion values (3,"2019-6-13 7:04:00","2019-6-13 12:06:00",(select idusuario from usuario where primernombre = "Juan"));
	insert into conexion values (3,"2019-6-15 12:02:00","2019-6-15 18:01:00",(select idusuario from usuario where primernombre = "Juan"));
  insert into conexion values (3,"2019-6-18 10:17:00","2019-6-18 16:09:00",(select idusuario from usuario where primernombre = "Juan"));
	insert into conexion values (3,"2019-7-4 10:00:00","2019-7-4 18:00:00",(select idusuario from usuario where primernombre = "Juan"));
	insert into conexion values (3,"2019-7-8 10:00:00","2019-7-8 19:00:00",(select idusuario from usuario where primernombre = "Juan"));
  insert into conexion values (4,"2019-6-14 9:02:00","2019-6-14 18:29:00",(select idusuario from usuario where primernombre = "Juan"));
  insert into conexion values (4,"2019-6-15 10:02:00","2019-6-29 11:01:00",(select idusuario from usuario where primernombre = "Juan"));
  insert into conexion values (4,"2019-6-19 10:20:00","2019-6-30 20:06:00",(select idusuario from usuario where primernombre = "Juan"));
  insert into conexion values (4,"2019-6-16 10:20:00","2019-6-30 18:02:00",(select idusuario from usuario where primernombre = "Juan"));
	insert into conexion values (4,"2019-6-29 10:40:00","2019-6-29 14:15:00",(select idusuario from usuario where primernombre = "Juan"));
	insert into conexion values (4,"2019-7-3 8:45:00","2019-7-3 17:15:00",(select idusuario from usuario where primernombre = "Juan"));
  insert into conexion values (5,"2019-6-20 22:09:00","2019-6-21 02:01:00",(select idusuario from usuario where primernombre = "Juan"));
  insert into conexion values (5,"2019-6-22 10:20:00","2019-6-22 17:06:00",(select idusuario from usuario where primernombre = "Juan"));
	insert into conexion values (null,"2019-7-3 9:20:00","2019-7-2 17:06:00",(select idusuario from usuario where primernombre = "Felipe"));
	insert into conexion values (null,"2019-7-2 9:20:00","2019-7-2 17:06:00",(select idusuario from usuario where primernombre = "Felipe"));

		/*ZONA*/
	execute function crear_zona("Zona A_pb", (select IDLugar from lugar where nombre="Deposito piedras blancas"), 1500);
	execute function crear_zona("Zona B_pb", (select IDLugar from lugar where nombre="Deposito piedras blancas"), 1500);
	execute function crear_zona("Zona A_md", (select IDLugar from lugar where nombre="Deposito de maldonado"), 500);
	execute function crear_zona("Zona A_mvd", (select IDLugar from lugar where nombre="Puerto de montevideo"), 800);
	execute function crear_zona("Zona B_mvd", (select IDLugar from lugar where nombre="Puerto de montevideo"), 400);
	execute function crear_zona("Zona A_papr", (select IDLugar from lugar where nombre="Puerto de aguas profundas rocha"), 200);
	execute function crear_zona("Zona B_papr", (select IDLugar from lugar where nombre="Puerto de aguas profundas rocha"), 800);
	execute function crear_zona("Zona C_papr", (select IDLugar from lugar where nombre="Puerto de aguas profundas rocha"), 1000);
	/*Subzona*/
	execute function crear_subzona("Zona A_1_pb",(select idlugar from lugar where nombre="Zona A_pb"), 1000);
	execute function crear_subzona("Zona A_2_pb", (select idlugar from lugar where nombre="Zona A_pb"), 500);
	execute function crear_subzona("Zona B_1_pb", (select IDLugar from lugar where nombre="Zona B_pb"), 800);
	execute function crear_subzona("Zona B_2_pb", (select idlugar from lugar where nombre="Zona B_pb"), 700);
	execute function crear_subzona("Zona A_1_md", (select IDLugar from lugar where nombre="Zona A_md"), 500);
	execute function crear_subzona("Zona A_1_mvd", (select idlugar from lugar where nombre="Zona A_mvd"), 300);
	execute function crear_subzona("Zona A_2_mvd", (select idlugar from lugar where nombre="Zona A_mvd"), 500);
	execute function crear_subzona("Zona B_1_mvd", (select idlugar from lugar where nombre="Zona B_mvd"), 400);
	execute function crear_subzona("Zona A_1_papr", (select idlugar from lugar where nombre="Zona A_papr"), 200);
	execute function crear_subzona("Zona B_1_papr", (select idlugar from lugar where nombre="Zona B_papr"), 480);
	execute function crear_subzona("Zona C_1_papr", (select idlugar from lugar where nombre="Zona C_papr"), 500);
	execute function crear_subzona("Zona C_2_papr", (select idlugar from lugar where nombre="Zona C_papr"), 500);

		/*VEHIUCLO*/
		insert into vehiculo values(0, "1GH2J83LED0987547","Fiat","Cronos", "6ead26",
		"Auto", 2011, (select IDCliente from cliente where Nombre="Sevel"));
		insert into vehiculo values(0, "1HGYN4HTEL8372649","Fiat","Toro", "cecece",
		"Auto", 2015, (select IDCliente from cliente where Nombre="Sevel"));
		insert into vehiculo values(0, "2GH2JJEBTE0987547","Chevrolet","Aveo",
		"c92222", "SUV", 2016, (select IDCliente from cliente where Nombre="Chevrolet UY"));
		insert into vehiculo values(0, "1GH2HGRLED0988472","Chevrolet","Volt",
		"6ead26", "MiniVan", 2018, (select IDCliente from cliente where Nombre="Chevrolet UY"));
		insert into vehiculo values(0, "KHBEHGRLED0988442","Chevrolet","Volt",
		"6e2327", "MiniVan", 2018, (select IDCliente from cliente where Nombre="Chevrolet UY"));
		insert into vehiculo(vin, cliente, tipo)
		       values("1L0V36I113UWU1112", (select IDCliente from cliente where Nombre="Sevel"), "Auto");

		/*vehiculoIngresa*/
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="1L0V36I113UWU1112"), "2019-4-11 13:00:55","Precarga", (select idusuario from usuario where primernombre = "Fernanda"));
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"), "2019-4-11 9:00:55","Precarga",(select idusuario from usuario where primernombre = "Fernanda"));
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),"2019-6-28 19:18:45","Alta",(select idusuario from usuario where primernombre = "Pepe"));
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="1HGYN4HTEL8372649"),"2019-4-11 12:40:55","Precarga",(select idusuario from usuario where primernombre = "Fernanda"));
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="1HGYN4HTEL8372649"),"2019-6-29 13:45:55","Alta",(select idusuario from usuario where primernombre = "Juan"));
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="2GH2JJEBTE0987547"),"2019-3-20 18:20:55","Precarga",(select idusuario from usuario where primernombre = "Felipe"));
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="2GH2JJEBTE0987547"),"2019-7-3 12:00:55","Alta",(select idusuario from usuario where primernombre = "Juan"));
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),"2019-3-20 8:01:00","Precarga",(select idusuario from usuario where primernombre = "Felipe"));
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),"2019-6-26 11:00:15","Alta",(select idusuario from usuario where primernombre = "Fernanda"));
		insert into vehiculoIngresa(idvehiculo, fecha, tipoingreso, usuario) values ((select idvehiculo from vehiculo where VIN="KHBEHGRLED0988442"),"2019-3-20 16:30:22","Precarga",(select idusuario from usuario where primernombre = "Felipe"));

		/*informedanios*/
		insert into informedanios values (0,"Informe de ingreso","2019-6-28", "Parcial",
			(select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha")
		,(select idusuario from usuario where primernombre = "Pepe"));
		insert into informedanios values (0,"Luego del Granizo","2019-7-1", "Parcial",
			(select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
		(select idusuario from usuario where primernombre = "Pepe"));
		insert into informedanios values (0,"Informe de ingreso","2019-7-2", "Parcial",
			(select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),(select IDLugar from lugar where Nombre="Deposito de maldonado"),
		(select idusuario from usuario where primernombre = "Juan"));
		insert into informedanios values (0,"Informe de ingreso","2019-6-29", "Parcial",
			(select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),(select IDLugar from lugar where Nombre="Puerto de montevideo")
		,(select idusuario from usuario where primernombre = "Juan"));
		insert into informedanios values (0,"Informe de ingreso","2019-7-3", "Parcial",
			(select idvehiculo from vehiculo where VIN="2GH2JJEBTE0987547"),(select IDLugar from lugar where Nombre="Puerto de montevideo")
		,(select idusuario from usuario where primernombre = "Juan"));

		insert into informedanios values (0,"Informe de ingreso","2019-7-8", "Parcial",
			(select idvehiculo from vehiculo where VIN="2GH2JJEBTE0987547"),(select IDLugar from lugar where Nombre="Deposito piedras blancas")
		,(select idusuario from usuario where primernombre = "Juan"));

		insert into informedanios values (0,"Informe de ingreso","2019-6-28", "Parcial",
			(select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha")
		,(select idusuario from usuario where primernombre = "Pepe"));

		insert into informedanios values (0,"Informe de ingreso","2019-7-2", "Parcial",
			(select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),(select IDLugar from lugar where Nombre="Deposito de maldonado")
		,(select idusuario from usuario where primernombre = "Pepe"));

		insert into informedanios values (0,"Informe de ingreso","2019-7-4", "Parcial",
			(select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),(select IDLugar from lugar where Nombre="Deposito piedras blancas")
		,(select idusuario from usuario where primernombre = "Juan"));
		/*registrodanios*/
		insert into registrodanios values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),1,0,"Rayon");
		insert into registrodanios values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),2,0,"Roptura en la puerta");
		insert into registrodanios values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),4,0,"No se ha encontrado el rayon");
		insert into registrodanios values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),4,0,"La roptura de la puerta a aumentado");
		insert into registrodanios values ((select idvehiculo from vehiculo where VIN="2GH2JJEBTE0987547"),5,0,"Daño en el motor");
		insert into registrodanios values ((select idvehiculo from vehiculo where VIN="2GH2JJEBTE0987547"),6,0,"No se encontraron daños en el motor");
		insert into registrodanios values ((select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),7,0,"Agujero en el techo");
		insert into registrodanios values ((select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),9,0,"Creio el agujero");
			/*actualiza*/
		insert into actualiza values (
		(select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),4,3,
		(select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),1,1,"Anulacion");
		insert into actualiza values (
		(select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),4,4,
		(select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),2,2, "Correccion");
		/*LA TABLA IMAGEN REGISTRO NO SE CARGA YA QUE NO SE PUEDE INGRESAR UNA imagen
		EN BYTE DIRECTAMENTE POR AQUI, HAY QUE USAR EL ODBC, POR ESO SE INGREZAN DESDE EL PROGRAMA*/


		/*Posicionado*/

			insert into posicionado values ((select idlugar from lugar where nombre="Zona A_1_papr"),(select idvehiculo from vehiculo where vin="1GH2J83LED0987547"),"2019-6-28 19:18:45", "2019-6-29 06:05:00",14,(select idusuario from usuario where primernombre = "Pepe"));
			insert into posicionado values ((select idlugar from lugar where nombre="Zona A_1_mvd"),(select idvehiculo from vehiculo where vin="1GH2J83LED0987547"),"2019-6-29 12:35:04", "2019-6-29 13:03:21",14,(select idusuario from usuario where primernombre = "Pepe"));
			insert into posicionado values ((select idlugar from lugar where nombre="Zona A_1_mvd"),(select idvehiculo from vehiculo where vin="1GH2J83LED0987547"),"2019-6-29 13:03:32",'2019-6-30 12:02:02',18,(select idusuario from usuario where primernombre = "Pepe"));
			insert into posicionado values ((select idlugar from lugar where nombre="Zona A_1_md"),(select idvehiculo from vehiculo where vin="1GH2J83LED0987547"),"2019-7-8 17:15:32",'2019-7-8 15:00:02',18,(select idusuario from usuario where primernombre = "Pepe"));

			insert into posicionado values ((select idlugar from lugar where nombre="Zona A_2_mvd"),(select idvehiculo from vehiculo where vin="1HGYN4HTEL8372649"),"2019-6-29 12:11:23", "2019-7-5 10:09:32",22,(select idusuario from usuario where primernombre = "Juan"));
			
			insert into posicionado values ((select idlugar from lugar where nombre="Zona B_1_pb"),(select idvehiculo from vehiculo where vin="1HGYN4HTEL8372649"),"2019-7-5 12:25:21", null ,25,(select idusuario from usuario where primernombre = "Juan"));

			insert into posicionado values ((select idlugar from lugar where nombre="Zona A_2_mvd"),(select idvehiculo from vehiculo where vin="2GH2JJEBTE0987547"),"2019-7-3 14:14:09","2019-7-5 10:25:22",6,(select idusuario from usuario where primernombre = "Juan"));
			insert into posicionado values ((select idlugar from lugar where nombre="Zona B_1_pb"),(select idvehiculo from vehiculo where vin="2GH2JJEBTE0987547"),"2019-7-5 12:31:32","2019-7-8 15:00:03",5,(select idusuario from usuario where primernombre = "Juan"));
			insert into posicionado values ((select idlugar from lugar where nombre="Zona B_2_pb"),(select idvehiculo from vehiculo where vin="2GH2JJEBTE0987547"),"2019-7-8 15:50:23",'2019-7-8 15:00:02',2,(select idusuario from usuario where primernombre = "Juan"));

			insert into posicionado values ((select idlugar from lugar where nombre="Zona C_1_papr"),(select idvehiculo from vehiculo where vin="1GH2HGRLED0988472"),"2019-6-26 14:10:32","2019-7-2 15:21:32",19,(select idusuario from usuario where primernombre = "Pepe"));
			insert into posicionado values ((select idlugar from lugar where nombre="Zona B_1_pb"),(select idvehiculo from vehiculo where vin="1GH2HGRLED0988472"),"2019-7-2 16:10:21","2019-7-4 15:32:55",28,(select idusuario from usuario where primernombre = "Pepe"));
			insert into posicionado values ((select idlugar from lugar where nombre="Zona A_1_pb"),(select idvehiculo from vehiculo where vin="1GH2HGRLED0988472"),"2019-7-4 18:30:21",'2019-7-8 15:00:02',74,(select idusuario from usuario where primernombre = "Juan"));

      /*Medios de transporte*/
      insert into TipoTransporte values (0, "Camion");
      insert into TipoTransporte values (0, "Maritimo");
      insert into TipoTransporte values (0, "Trenvía");

insert into habilitado values(
(select idlugar from lugar where nombre='Deposito piedras blancas'), 1);

insert into habilitado values(
(select idlugar from lugar where nombre='Deposito de maldonado'), 1);

insert into habilitado values(
(select idlugar from lugar where nombre='Puerto de montevideo'), 1);

insert into habilitado values(
(select idlugar from lugar where nombre='Puerto de aguas profundas rocha'), 1);

insert into habilitado values
((select idlugar from lugar where nombre='Patio de Sevel'), 1);

insert into habilitado values
((select idlugar from lugar where nombre='Patio de Chevrolet Ur a gay'), 1);

insert into habilitado values((select idlugar from lugar where nombre = 'Deposito piedras blancas'), 2);
insert into habilitado values((select idlugar from lugar where nombre = 'Deposito de maldonado'), 2);
insert into habilitado values((select idlugar from lugar where nombre = 'Puerto de montevideo'), 2);
insert into habilitado values((select idlugar from lugar where nombre = 'Puerto de aguas profundas rocha'), 2);
insert into habilitado values((select idlugar from lugar where nombre = 'Patio de Sevel'), 2);
insert into habilitado values((select idlugar from lugar where nombre = 'Patio de Chevrolet Ur a gay'), 2);

insert into Habilitado values ((select idlugar from lugar where nombre="Puerto de montevideo"), 3);
insert into Habilitado values ((select idlugar from lugar where nombre="Puerto de aguas profundas rocha"), 3);

      insert into MedioTransporte values (1, "24GHBYEGV81874679","Fiat Moustro1","Camion",
        (select idusuario from usuario where primernombre = "Felipe"), "4-5-17", 1,10,5,3,5);
      insert into MedioTransporte values (1, "HGU63YEGV81845879","Chevrolet Moustro2","Camion",
        (select idusuario from usuario where primernombre = "Felipe"), "8-8-16", 2, 8,3,2,3);

      insert into MedioTransporte values (2, "La virgen del Rio de la Plata", "Barcodio", "Maritimo",
       (select idusuario from usuario where primernombre = "Felipe"), "8-8-15",
       0, 2, 1, 0, 1);

      insert into MedioTransporte values (3,"AFE:32", "A!Train", "Trenvía",
	(select idusuario from usuario where primernombre="Felipe"), "8-3-07", 0, 5, 5, 5, 5);

      insert into permite values (1,"24GHBYEGV81874679",(select idusuario from usuario where primernombre = "Antonio"),
      "f");
      insert into permite values (3, "AFE:32",
				  (select idusuario from usuario where primernombre = "Julio"), "f");

insert into permite values (1,"HGU63YEGV81845879",(select idusuario from usuario where primernombre = "Pedro"),
      "f");

insert into permite values (2,"La virgen del Rio de la Plata",(select idusuario from usuario where primernombre = "Antonio"),
      "f");

      insert into lote values (0,"pl_1", (select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
      (select IDLugar from lugar where Nombre="Puerto de montevideo"),
       (select idusuario from usuario where primernombre = "Pepe"), "2019-5-20", "Normal", "Cerrado",'f');

       insert into lote values (0, "il_1", (select IDLugar from lugar where Nombre="Puerto de montevideo"),
       (select IDLugar from lugar where nombre = "Deposito de maldonado"),
       (select IDUsuario from usuario where primernombre = "Pepe"), "2019-6-26",
       'Normal', 'Cerrado','f');

      insert into lote values (0,"l_1",(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
      (select IDLugar from lugar where Nombre="Deposito de maldonado"),
       (select idusuario from usuario where primernombre = "Pepe"), "2019-6-26", 'Normal', 'Cerrado','f');

      insert into lote values (0,"l_2",(select IDLugar from lugar where Nombre="Puerto de montevideo"),
      (select IDLugar from lugar where Nombre="Deposito piedras blancas"),
       (select idusuario from usuario where primernombre = "Juan"), "2019-6-29",'Normal','Cerrado','f');

      insert into lote values (0,"l_3",(select IDLugar from lugar where Nombre="Deposito de maldonado"),
      (select IDLugar from lugar where Nombre="Deposito piedras blancas"),
       (select idusuario from usuario where primernombre = "Pepe"), "2019-7-4",'Normal','Cerrado','f');
		
		insert into lote values (0,"l_4",(select IDLugar from lugar where Nombre="Deposito piedras blancas"),
      (select IDLugar from lugar where Nombre="Patio de Sevel"),
       (select idusuario from usuario where primernombre = "Juan"),"2019-6-29",'Normal','Abierto','f');
	   
	   insert into lote values (0,"l_5",(select IDLugar from lugar where Nombre="Deposito de maldonado"),
      (select IDLugar from lugar where Nombre="Patio de Chevrolet Ur a gay"),
       (select idusuario from usuario where primernombre = "Pepe"),"2019-6-30",'Normal','Cerrado','f');

      insert into lote values (0,"l_6",(select IDLugar from lugar where Nombre="Deposito piedras blancas"),
	(select IDLugar from lugar where Nombre="Patio de Sevel"),
	(select IDUsuario from usuario where primernombre = "Pepe"), "2019-7-4", "Normal", "Cerrado",'f');

insert into integra values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),3,"2019-6-28 14:02",'t',(select idusuario from usuario where primernombre = "Pepe"));
insert into integra values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),1,"2019-6-29 14:00",'f',(select idusuario from usuario where primernombre = "Pepe"));
insert into integra values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),2,"2019-7-02 14:02",'f',(select idusuario from usuario where primernombre = "Pepe"));
      insert into integra values ((select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),3,"2019-6-26 15:08",'f',(select idusuario from usuario where primernombre = "Pepe"));
      insert into integra values ((select idvehiculo from vehiculo where VIN="1HGYN4HTEL8372649"),4,"2019-6-29 16:25",'f',(select idusuario from usuario where primernombre = "Juan"));
      insert into integra values ((select idvehiculo from vehiculo where VIN="2GH2JJEBTE0987547"),4,"2019-7-3 11:47",'f',(select idusuario from usuario where primernombre = "Juan"));
      insert into integra values ((select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),5,"2019-7-4 12:07",'f',(select idusuario from usuario where primernombre = "Pepe"));
	  insert into integra values ((select idvehiculo from vehiculo where VIN="1HGYN4HTEL8372649"),6,"2019-6-29 11:00",'f',(select idusuario from usuario where primernombre = "Juan"));
	  insert into integra values ((select idvehiculo from vehiculo where VIN="1GH2J83LED0987547"),7,"2019-6-30 12:00",'f',(select idusuario from usuario where primernombre = "Pepe"));
	  insert into integra values ((select idvehiculo from vehiculo where VIN="1GH2HGRLED0988472"),8,"2019-7-5 17:00",'f',(select idusuario from usuario where primernombre = "Juan"));
	  insert into integra values ((select idvehiculo from vehiculo where VIN="2GH2JJEBTE0987547"),8,"2019-7-4 16:25",'f',(select idusuario from usuario where primernombre = "Juan"));



insert into transporte values (0,
       (select idusuario from usuario
       where primernombre = "Antonio"),2, "La virgen del Rio de la Plata",
       "2019-6-29 06:00", "2019-6-29 06:05");

insert into transporte values (0,
       (select idusuario from usuario
       where primernombre = "Antonio"),1,"24GHBYEGV81874679",
       "2019-6-30 12:00", "2019-6-30 12:02");

      insert into transporte values (0,
      (select idusuario from usuario
       where primernombre = "Antonio"),1,"24GHBYEGV81874679",
      "2019-7-2 15:00", "2019-7-2 15:00");

      insert into transporte values (0,
      (select idusuario from usuario
       where primernombre = "Julio"),3,"AFE:32",
      "2019-7-5 9:40", "2019-7-5 10:00");

      insert into transporte values (0,
      (select idusuario from usuario
       where primernombre = "Antonio"),1,"24GHBYEGV81874679",
      "2019-7-2 15:00", "2019-7-4 15:00");

      insert into transporte values (0,
      (select idusuario from usuario
       where primernombre = "Antonio"),1,"24GHBYEGV81874679",
      "2019-7-8 15:00", "2019-7-8 15:00");

      insert into transporta values (1,1, "Exitoso",
       "2019-6-29 08:00", "2019-6-29 08:30");
      insert into transporta values (2,2, "Exitoso",
       "2019-6-30 16:30", "2019-6-30 16:53");
      insert into transporta values (3,3, "Exitoso",
      "2019-7-2 16:00", "2019-7-2 16:02");
      insert into transporta values (4,4, "Exitoso",
      "2019-7-5 12:00", "2019-7-5 12:25");
      insert into transporta values (5,5, "Exitoso",
      "2019-7-4 18:00", "2019-7-4 17:45");
      insert into transporta values (6,7, "Exitoso",
      "2019-7-8 18:00", "2019-7-8 22:00");
      insert into transporta values (6,8, "Exitoso",
      "2019-7-8 23:00", "2019-7-9 01:00");
