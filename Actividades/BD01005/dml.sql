truncate vehiculoingresa;
truncate actualiza;
truncate imagenregistro;
truncate registrodanios;
truncate informedanios;
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
	("diosito", "no", "mvolcan@aguadita.uy", TO_DATE("1/1/1962", "%d/%m/%Y"), "911", "Miguel", "Volcan", "Sanchez", "Miau?", "Miau", "M", (select idrol from rol where nombre="Administrador"));

INSERT INTO
	usuario (nombredeusuario, hash_contra, email, fechanac, telefono, primernombre, primerapellido, segundoapellido, preguntasecreta, respuestasecreta, sexo, rol)
VALUES
	("koutakun", "no", "darkfm@vera.com.uy", TO_DATE("03/05/2001", "%d/%m/%Y"), "0305", "Salvador", "Pardiñas", "Barros", "Miau?", "Miau", "M", (select idrol from rol where nombre="Operario"));

INSERT INTO
	lugar (nombre, geox, geoy, usuariocreador, capacidad, tipo)
VALUES
	("Puerto de Montevideo", -35, -32, (select IDUsuario from usuario where NombreDeUsuario = "diosito"), 3, "Puerto");

INSERT INTO
	lugar (nombre, geox, geoy, usuariocreador, capacidad, tipo)
VALUES
	("Patio de Rocha", -35, -20, (select IDUsuario from usuario where NombreDeUsuario = "diosito"), 500, "Patio");

INSERT INTO
	zona (nombre, idlugar, capacidad)
VALUES
	("Rambla portuaria", (select IDLugar from lugar where nombre="Puerto de Montevideo"), 3);

INSERT INTO
	subzona (nombre, idzona, idlugar, capacidad)
VALUES
	("SZ-A", (select IDZona from zona where nombre="Rambla portuaria"), (select IDLugar from zona where nombre="Rambla portuaria"), 3);

INSERT INTO
	zona (nombre, idlugar, capacidad)
VALUES
	("Zona La Paloma", (select IDLugar from lugar where nombre = "Patio de Rocha"), 500);
insert into
	subzona (nombre, idzona, idlugar, capacidad)
VALUES
	("Subzona Arachania", (select IDZona from zona where nombre="Zona La Paloma"), (select IDLugar from zona where nombre="Zona La Paloma"), 500);

insert into vehiculo (VIN, Marca, Modelo, Color, Tipo, Anio, ClienteNombre, PuertoArriba)
values ("AUTARDO123", "Ford", "Focus", 0, "Auto", 2010, "Menem jr", (select IDLugar from lugar where nombre="Puerto de Montevideo"));

insert into vehiculoingresa(VIN, fecha, tipoingreso, usuario)
values ("AUTARDO123", TO_DATE("3/2/1991", "%d/%m/%Y"), "Alta", (select IDUsuario from usuario where NombreDeUsuario = "diosito"));


insert into
	lote (fechapartida, desde, hacia, creadorid, prioridad)
values
	(TO_DATE("5/3/1991", "%d/%m/%Y"), (select IDLugar from lugar where nombre="Puerto de Montevideo"), (select IDLugar from lugar where nombre="Patio de Rocha"), (select IDUsuario from usuario where nombredeusuario="diosito"), "Alta");
insert into
	integra(vin, lote, fecha, invalidado)
values
	("AUTARDO123", (select IDLote from lote), current, "f");