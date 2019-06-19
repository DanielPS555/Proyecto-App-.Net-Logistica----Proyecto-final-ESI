/*DML Primera entrega por BIT*/
/*ROL*/
insert into rol(nombre) values("Operario");
insert into rol(nombre) values("Transportista");
insert into rol(nombre) values("Administrador");

	/*USUARIO*/
insert into usuario values (0,"Felipe3","","felip49@gmail.com", "27/8/1981", "09877745",
"Felipe","","Camacho", "" , "Cual fue su primer juego" , "Lol" , 'M',3);
/*NO SE PONE CONTRASEÑA AQUI POR EL FUNCIONAMIENTO DE LA ENCRIPTACION DEL PROGRAMA*/
insert into usuario values (0,"Fernanda1654","","ferti49@gmail.com", "25/2/1985", "098545574"
,"Fernanda","Miranda","Lopes", "" , "Cual fue su primer telefono" , "Un poquet" , 'F',3);
insert into usuario values (0,"Pepe12","","e1@gmail.com", "25/5/1925", "098167462"
,"Pepe","Lorenzo","Miranda", "Lopes" , "Cual es tu color favorito" , "Rojo" , 'M',1);
insert into usuario values (0,"Juan24","","re2@outlook.com", "25/7/1945", "098427894"
,"Juan","Lorenzo","Simon", "Antonio" , "Cual es el nombre de tu perro" , "fido" , 'F',1);
insert into usuario values (0,"Anto322","","anti@gmail.com", "27/4/1995", "098456782"
,"Antonio","","Pardiñas", "" , "Cual es el nombre de su pelicula favorita" , "Blanca nieves" ,'O',2);
insert into usuario values (0,"PedroB43","","Pedro43563@outlook.com", "2/9/1972", "098452746"
,"Pedro","","Herandez", "Couto" , "El nomrbe de mi cancion favorita" , "Hello" , 'M',2);


/*CREADO POR*/
insert into creadoPor values ((select idusuario from usuario where primernombre = "Fernanda"),
 (select idusuario from usuario where primernombre = "Felipe"),"11/5/2019");
insert into creadoPor values ((select idusuario from usuario where primernombre = "Pepe"),
	(select idusuario from usuario where primernombre = "Felipe"),"1/6/2019");
insert into creadoPor values ((select idusuario from usuario where primernombre = "Juan"),
	(select idusuario from usuario where primernombre = "Fernanda"),"17/7/2019");
insert into creadoPor values ((select idusuario from usuario where primernombre = "Antonio"),
	(select idusuario from usuario where primernombre = "Fernanda"),"18/5/2019");
insert into creadoPor values ((select idusuario from usuario where primernombre = "Pedro"),
	(select idusuario from usuario where primernombre = "Fernanda"),"21/5/2019");


	/*LINK*/
insert into link values ("http://maps.com",(select idusuario from usuario where primernombre = "Antonio"));
insert into link values ("http://maps2.com",(select idusuario from usuario where primernombre = "Pedro"));

	/*LUGAR*/
insert into lugar values (0,"Deposito piedras blancas", 3500, -34.882456, -56.194172,1,"Patio");
insert into lugar values (0,"Deposito de maldonado", 500, -34.948760, -54.924569,2,"Patio");
insert into lugar values (0,"Puerto de montevideo", 1200, -34.987460, -56.254790,1,"Puerto");
insert into lugar values (0,"Puerto de aguas profundas rocha", 2000, -34.658827, -54.152534,2,"Puerto");


	/*TRABAJA EN */
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Deposito de maldonado"),
	(select idusuario from usuario where primernombre = "Pepe"),"26/6/2019", "4/9/2019");
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
	(select idusuario from usuario where primernombre = "Pepe"),"26/6/2019", "");
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Deposito piedras blancas"),
	(select idusuario from usuario where primernombre = "Juan"),"13/6/2019", "");
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Puerto de montevideo"),
	(select idusuario from usuario where primernombre = "Juan"),"13/6/2019", "");
insert into trabajaen values (0,(select IDLugar from lugar where Nombre="Deposito de maldonado"),
	(select idusuario from usuario where primernombre = "Juan"),"15/6/2019", "17/6/2019");

	/*CONEXCION*/
	insert into conexion values (1,"2019-6-27 8:02","2019-6-27 18:06");
	insert into conexion values (1,"2019-6-28 23:02","2019-6-29 02:01");
	insert into conexion values (1,"2019-6-30 10:20","2019-6-30 16:06");
	insert into conexion values (2,"2019-7-1 8:04","2019-6-27 19:06");
	insert into conexion values (2,"2019-6-28 20:00","2019-6-28 22:00");
	insert into conexion values (3,"2019-6-13 7:04","2019-6-13 12:06");
	insert into conexion values (3,"2019-6-15 12:02","2019-6-15 18:01");
  insert into conexion values (3,"2019-6-18 10:17","2019-6-18 16:09");
	insert into conexion values (3,"2019-7-4 10:00","2019-7-4 18:00");
	insert into conexion values (3,"2019-7-8 10:00","2019-7-8 19:00");
  insert into conexion values (4,"2019-6-14 9:02","2019-6-14 18:29");
  insert into conexion values (4,"2019-6-15 10:02","2019-6-29 11:01");
  insert into conexion values (4,"2019-6-19 10:20","2019-6-30 20:06");
  insert into conexion values (4,"2019-6-16 10:20","2019-6-30 18:02");
	insert into conexion values (4,"2019-6-29 10:40","2019-6-29 14:15");
	insert into conexion values (4,"2019-7-3 8:45","2019-7-3 17:15");
  insert into conexion values (5,"2019-6-20 22:09","2019-6-21 02:01");
  insert into conexion values (5,"2019-6-22 10:20","2019-6-22 17:06");
	insert into conexion values (5,"2019-7-2 9:20","2019-7-2 17:06");

		/*ZONA*/
	insert into zona values ((select IDLugar from lugar where Nombre="Deposito piedras blancas"),
	0,"Zona A", 1500);
	insert into zona values ((select IDLugar from lugar where Nombre="Deposito piedras blancas"),
	0,"Zona B", 1500);
	insert into zona values ((select IDLugar from lugar where Nombre="Deposito piedras blancas"),
	0,"Zona C", 500);
	insert into zona values ((select IDLugar from lugar where Nombre="Deposito de maldonado"),
	0,"Zona A", 500);
	insert into zona values ((select IDLugar from lugar where Nombre="Puerto de montevideo"),
	0,"Zona A", 800);
	insert into zona values ((select IDLugar from lugar where Nombre="Puerto de montevideo"),
	0,"Zona B", 400);
	insert into zona values ((select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
	0,"Zona A", 200);
	insert into zona values ((select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
	0,"Zona B", 800);
	insert into zona values ((select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
	0,"Zona C", 1000);

	/*SUBZONA*/
	insert into subzona values ((select IDLugar from lugar where Nombre="Deposito piedras blancas"),
		(select IDZona from lugar,zona where lugar.nombre="Deposito piedras blancas"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona A"),0,"Zona A_1",1000);

	insert into subzona values ((select IDLugar from lugar where Nombre="Deposito piedras blancas"),
		(select IDZona from lugar,zona where lugar.nombre="Deposito piedras blancas"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona A"),0,"Zona A_2",500);

	insert into subzona values ((select IDLugar from lugar where Nombre="Deposito piedras blancas"),
		(select IDZona from lugar,zona where lugar.nombre="Deposito piedras blancas"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona B"),0,"Zona B_1",800);

	insert into subzona values ((select IDLugar from lugar where Nombre="Deposito piedras blancas"),
		(select IDZona from lugar,zona where lugar.nombre="Deposito piedras blancas"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona B"),0,"Zona B_2",700);

	insert into subzona values ((select IDLugar from lugar where Nombre="Deposito piedras blancas"),
		(select IDZona from lugar,zona where lugar.nombre="Deposito piedras blancas"
			and lugar.idlugar = zona.idlugar and zona.nombre = "Zona C"),0,"Zona C_1",500);

	insert into subzona values ((select IDLugar from lugar where Nombre="Deposito de maldonado"),
		(select IDZona from lugar,zona where lugar.nombre="Deposito de maldonado"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona A"),0,"Zona A_1",500);

	insert into subzona values ((select IDLugar from lugar where Nombre="Puerto de montevideo"),
		(select IDZona from lugar,zona where lugar.nombre="Puerto de montevideo"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona A"),0,"Zona A_1",300);

	insert into subzona values ((select IDLugar from lugar where Nombre="Puerto de montevideo"),
		(select IDZona from lugar,zona where lugar.nombre="Puerto de montevideo"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona A"),0,"Zona A_2",500);

  insert into subzona values ((select IDLugar from lugar where Nombre="Puerto de montevideo"),
	  (select IDZona from lugar,zona where lugar.nombre="Puerto de montevideo"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona B"),0,"Zona B_1",400);

	insert into subzona values ((select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
		(select IDZona from lugar,zona where lugar.nombre="Puerto de aguas profundas rocha"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona A"),0,"Zona A_1",200);

	insert into subzona values ((select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
		(select IDZona from lugar,zona where lugar.nombre="Puerto de aguas profundas rocha"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona B"),0,"Zona B_1",480);

	insert into subzona values ((select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
		(select IDZona from lugar,zona where lugar.nombre="Puerto de aguas profundas rocha"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona C"),0,"Zona C_1",500);

	insert into subzona values ((select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
		(select IDZona from lugar,zona where lugar.nombre="Puerto de aguas profundas rocha"
		and lugar.idlugar = zona.idlugar and zona.nombre = "Zona C"),0,"Zona C_2",500);

		/*VEHIUCLO*/
		insert into vehiculo values("1GH2J83LED0987547","Fiat","Cronos", "6ead26", "Auto", 2011, "Sevel"
		,(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"), "2019-6-27");
		insert into vehiculo values("1HGYN4HTEL8372649","Fiat","Toro", "#cecece", "Auto", 2015, "Sevel"
		,(select IDLugar from lugar where Nombre="Puerto de montevideo"), "2019-6-28");
		insert into vehiculo values("2GH2JJEBTE0987547","Chevrolet","Aveo", "c92222", "SUV", 2016, "Chevrolet UY"
		,(select IDLugar from lugar where Nombre="Puerto de montevideo"), "2019-7-1");
		insert into vehiculo values("1GH2HGRLED0988472","Chevrolet","Volt", "6ead26", "MiniVan", 2018, "Chevrolet UY"
		,(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"), "2019-6-26");


		/*vehiculoIngresa*/
		insert into vehiculoIngresa values ("1GH2J83LED0987547", "2019-4-11", "Precarga",(select idusuario from usuario where primernombre = "Fernanda"));
		insert into vehiculoIngresa values ("1GH2J83LED0987547", "2019-6-27", "Alta",(select idusuario from usuario where primernombre = "Pepe"));
		insert into vehiculoIngresa values ("1HGYN4HTEL8372649", "2019-4-11", "Precarga",(select idusuario from usuario where primernombre = "Fernanda"));
		insert into vehiculoIngresa values ("1HGYN4HTEL8372649", "2019-6-29", "Alta",(select idusuario from usuario where primernombre = "Juan"));
		insert into vehiculoIngresa values ("2GH2JJEBTE0987547", "2019-3-20", "Precarga",(select idusuario from usuario where primernombre = "Felipe"));
		insert into vehiculoIngresa values ("2GH2JJEBTE0987547", "2019-7-3", "Alta",(select idusuario from usuario where primernombre = "Juan"));
		insert into vehiculoIngresa values ("1GH2HGRLED0988472", "2019-3-20", "Precarga",(select idusuario from usuario where primernombre = "Felipe"));
		insert into vehiculoIngresa values ("1GH2HGRLED0988472", "2019-6-26", "Alta",(select idusuario from usuario where primernombre = "Fernanda"));
		insert into vehiculoIngresa values ("1GH2HGRLED0988472", "2019-7-25", "Baja",(select idusuario from usuario where primernombre = "Felipe"));

		/*informedanios*/
		insert into informedanios values ("0","Informe de ingreso","2019-6-28", "Parcial",
			"1GH2J83LED0987547",(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha")
		,(select idusuario from usuario where primernombre = "Pepe"));

		insert into informedanios values ("0","Luego del Granizo","2019-7-1", "Parcial",
			"1GH2J83LED0987547",(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha"),
		(select idusuario from usuario where primernombre = "Pepe"));

		insert into informedanios values ("0","Informe de ingreso","2019-7-2", "Parcial",
			"1GH2J83LED0987547",(select IDLugar from lugar where Nombre="Deposito de maldonado"),
		(select idusuario from usuario where primernombre = "Juan"));

		insert into informedanios values ("0","Informe de ingreso","2019-6-29", "Parcial",
			"1HGYN4HTEL8372649",(select IDLugar from lugar where Nombre="Puerto de montevideo")
		,(select idusuario from usuario where primernombre = "Juan"));

		insert into informedanios values ("0","Informe de ingreso","2019-7-4", "Parcial",
			"1HGYN4HTEL8372649",(select IDLugar from lugar where Nombre="Deposito piedras blancas")
		,(select idusuario from usuario where primernombre = "Juan"));

		insert into informedanios values ("0","Informe de ingreso","2019-7-3", "Parcial",
			"2GH2JJEBTE0987547",(select IDLugar from lugar where Nombre="Puerto de montevideo")
		,(select idusuario from usuario where primernombre = "Juan"));

		insert into informedanios values ("0","Informe de ingreso","2019-7-8", "Parcial",
			"2GH2JJEBTE0987547",(select IDLugar from lugar where Nombre="Deposito piedras blancas")
		,(select idusuario from usuario where primernombre = "Juan"));

		insert into informedanios values ("0","Informe de ingreso","2019-6-28", "Parcial",
			"1GH2HGRLED0988472",(select IDLugar from lugar where Nombre="Puerto de aguas profundas rocha")
		,(select idusuario from usuario where primernombre = "Pepe"));

		insert into informedanios values ("0","Informe de ingreso","2019-7-2", "Parcial",
			"1GH2HGRLED0988472",(select IDLugar from lugar where Nombre="Deposito de maldonado")
		,(select idusuario from usuario where primernombre = "Pepe"));

		insert into informedanios values ("0","Informe de ingreso","2019-7-4", "Parcial",
			"1GH2HGRLED0988472",(select IDLugar from lugar where Nombre="Deposito piedras blancas")
		,(select idusuario from usuario where primernombre = "Juan"));

		/*registrodanios*/
		insert into registrodanios values (1,0,"Rayon");
		insert into registrodanios values (2,0,"Roptura en la puerta");
		insert into registrodanios values (3,0,"No se ha encontrado el rayon");
		insert into registrodanios values (3,0,"La roptura de la puerta a aumentado");
		insert into registrodanios values (5,0,"Daño en la rueda");
		insert into registrodanios values (6,0,"Daño en el motor");
		insert into registrodanios values (7,0,"No se encontraron daños en el motor");
		insert into registrodanios values (9,0,"Agujero en el techo");
		insert into registrodanios values (10,0,"Creio el agujero");

			/*actualiza*/
		insert into actualiza values (3,3,1,1,"Anulacion");
		insert into actualiza values (3,4,2,2,"Correccion");
		insert into actualiza values (7,7,6,6,"Anulacion");
		insert into actualiza values (10,9,9,8,"Correccion");

		/*LA TABLA IMAGEN REGISTRO NO SE CARGA YA QUE NO SE PUEDE INGRESAR UNA imagen
		EN BYTE DIRECTAMENTE POR AQUI, HAY QUE USAR EL ODBC, POR ESO SE INGREZAN DESDE EL PROGRAMA*/


		/*Posicionado*/
			insert into posicionado values (4,7,10,"1GH2J83LED0987547","2019-6-27")
