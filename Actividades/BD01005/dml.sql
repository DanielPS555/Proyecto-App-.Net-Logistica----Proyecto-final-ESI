truncate actualiza;
truncate imagenregistro;
truncate registrodanios;
truncate informedanios;
truncate usuarioingresa;
truncate trabajaen;
truncate conduce;
truncate rampascamion;
truncate camion;
truncate posicionestransporte;
truncate transporta;
truncate transporte;
truncate posicionado;
truncate integra;
truncate lote;
truncate vehiculo;
truncate subzona;
truncate zona;
truncate lugar;
truncate usuario;

INSERT INTO
	usuario (nombredeusuario, hash_contra, email, fechanac, telefono, primernombre, primerapellido, segundoapellido, preguntasecreta, respuestasecreta, sexo, rol)
VALUES
	("diosito", "no", "mvolcan@aguadita.uy", TO_DATE("1/1/1962", "%d/%m/%Y"), "911", "Miguel", "Volcan", "Sanchez", "Miau?", "Miau", "M", (select idrol from rol where nombre="Admin"));

INSERT INTO
	usuario (nombredeusuario, hash_contra, email, fechanac, telefono, primernombre, primerapellido, segundoapellido, preguntasecreta, respuestasecreta, sexo, rol)
VALUES
	("koutakun", "no", "darkfm@vera.com.uy", TO_DATE("03/05/2001", "%d/%m/%Y"), "0305", "Salvador", "Pardiñas", "Barros", "Miau?", "Miau", "M", (select idrol from rol where nombre="Operario"));

INSERT INTO
	lugar (nombre, geox, geoy, creadorid, capacidad, tipo)
VALUES
	("Puerto de Montevideo", -35, -32, (select IDUsuario from usuario where NombreDeUsuario = "diosito"), 3, "Puerto");

INSERT INTO
	lugar (nombre, geox, geoy, creadorid, capacidad, tipo)
VALUES
	("Patio de Rocha", -35, -20, (select IDUsuario from usuario where NombreDeUsuario = "diosito"), 500, "Patio");

INSERT INTO
	zona (nombre, lugar, capacidad)
VALUES
	("Rambla portuaria", (select IDLugar from lugar where nombre="Puerto de Montevideo"), 3);

INSERT INTO
	subzona (nombre, idzona, idlugar, capacidad)
VALUES
	("SZ-A", (select IDZona from zona where nombre="Rambla portuaria"), (select IDLugar from zona where nombre="Rambla portuaria"), 3);

INSERT INTO
	zona (nombre, lugar, capacidad)
VALUES
	("Zona 1", (select IDLugar from lugar where nombre = "Patio de Rocha"), 500);
insert into
	subzona (nombre, idzona, idlugar, capacidad)
VALUES
	("El cuarto con la mano de Peron", (select IDZona from zona where nombre="La casa de Menem"), 500);

insert into vehiculo (VIN, Marca, Modelo, Color, Tipo, Anio, FueraDeSistema, ClienteNombre, UsuarioIngresa, PuertoArriba)
values ("AUTARDO123", "Ford", "Focus", 0, "Auto", 2010, "f", "Menem jr", (select IDUsuario from usuario where NombreDeUsuario = "fluffycat"), (select IDLugar from lugar where nombre="La loma del orto"));


insert into
	lote (fechapartida, destino, creadorid, prioridad)
values
	(TO_DATE("5/3/1991", "%d/%m/%Y"), (select IDLugar from lugar where nombre="La loma del orto"), (select IDUsuario from usuario where nombredeusuario="fluffycat"), "Alta");
insert into
	camion (vin, marca, modelo, matricula, usuarioingresa)
values
	("A", "GM", "Camion", "ATR1995", (select IDUsuario from usuario where NombreDeUsuario = "fluffycat"));
insert into
	conduce(vin, usuario, desde, hasta)
values
	("A", (select IDUsuario from usuario where NombreDeUsuario = "fluffycat"), TO_DATE("3/1/1989", "%d/%m/%Y"), TO_DATE("9/5/2010", "%d/%m/%Y"));
insert into
	integra(vin, lote)
values
	("AUTARDO123", (select IDLote from lote));