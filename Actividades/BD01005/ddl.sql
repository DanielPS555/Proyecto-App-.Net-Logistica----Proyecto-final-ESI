CREATE table
	usuario(
	IDUsuario serial primary key,
	NombreDeUsuario varchar(20) not null unique,
	Hash_Contra char(60) not null,
	/* La contrasenia ser hasheada con bcrypt */
	Email varchar(255) NOT null,
	FechaNac date,
	Telefono varchar(15) NOT null,
	/* segn E.164 los nmeros telefnicos internacionales pueden ser de hasta
	15 dgitos incluyendo el codigo pas */
	PrimerNombre varchar(50) NOT null,
	PrimerApellido varchar(50) NOT null,
	PreguntaSecreta varchar(50) NOT null,
	RespuestaSecreta varchar(50) NOT null,
	Creador integer,
	FechaCreacion date not null,
	Sexo char(1) NOT null,
	Rol char(1) not null,
	CHECK (Rol in ('A', 'O', 'T')),
	CHECK (Sexo IN ('M',
	'F',
	'O')),
	foreign key(Creador) references Usuario(IDUsuario)
);

CREATE table
	cliente(
		RUT varchar(12) unique not null,
		Nombre varchar(100) not null,
		IDCliente serial primary key,
		fechaRegistro datetime year to day not null,
		invalido boolean not null
);

CREATE table
	lugar(
	IDLugar serial primary key,
	Nombre varchar(100) not null,
	Capacidad INTEGER NOT null CHECK (Capacidad > 0),
	GeoX FLOAT NOT null,
	GeoY FLOAT NOT null,
	UsuarioCreador integer NOT null references usuario(IDUsuario),
	Tipo varchar(6) NOT null check (Tipo IN
 		    	         ("Patio","Puerto","Establecimiento", 'Zona', 'Subzona'))
);

create table
	incluye(
	menor integer primary key,
	mayor integer,
	foreign key(menor) references lugar(idlugar),
	foreign key(mayor) references lugar(idlugar)
);
create table
       perteneceA(
	IDLugar integer primary key references Lugar(IDLugar),
	ClienteID integer references Cliente(IDCliente)
);

CREATE table
	trabajaen(
	ID serial primary key,
	IDLugar integer not null,
	IDUsuario integer not null,
	FechaInicio date NOT null,
	FechaFin date,
	foreign key(IDLugar) references lugar(IDLugar) ON DELETE CASCADE,
	foreign key(IDUsuario) references usuario(IDUsuario) ON DELETE CASCADE
);

CREATE table
	conexion(
	IDTrabajaEn integer,
	HoraIngreso datetime year to second not null,
	HoraSalida datetime year to second,
	foreign key(IDTrabajaEn) references trabajaen(ID) ON DELETE CASCADE,
	primary key(IDTrabajaEn, HoraIngreso)
);

CREATE table
	vehiculo(
	IDVehiculo serial primary key,
	VIN char(17) unique,
	Marca varchar(50),
	Modelo varchar(50),
	Color char(6), /* representación ineficiente; 6char = 6hex = 16^6 = 2^24 < 2^32 = int (4char) < 6char */
	/* representacion del color por hexadecimal*/
	Tipo varchar(7) NOT null check(Tipo in ('Auto', 'MiniVan', 'SUV', 'Camion', 'Van')),
	Anio integer check(Anio >= 1900 and Anio <= 10000),
	Cliente Integer NOT null,
	FechaArribo datetime year to day,
	foreign key(Cliente) references Cliente(IDCliente) ON DELETE CASCADE
);

create table
	vehiculoIngresa(
	IDVehiculo integer,
	Fecha datetime year to day,
	TipoIngreso varchar(10) not null check (TipoIngreso in ('Precarga', 'Alta', 'Baja')),
	Usuario integer,
	primary key(IDVehiculo, Usuario, Fecha),
	foreign key(IDVehiculo) references Vehiculo(IDVehiculo) ON DELETE CASCADE,
	foreign key(Usuario) references Usuario(IDUsuario) ON DELETE CASCADE
);
CREATE table
	informedanios(
	ID serial,
	Descripcion varchar(255) NOT null,
	Fecha datetime year to minute NOT null,
	Tipo varchar(50) NOT null check (Tipo in ('Total', 'Parcial')),
	IDVehiculo integer NOT null,
	idlugar integer NOT null,
	idusuario integer NOT null,
	primary key(ID, IDVehiculo),
	foreign key(idusuario) references usuario(IDUsuario) ON DELETE CASCADE,
	foreign key(IDVehiculo) references vehiculo(IDVehiculo) ON DELETE CASCADE,
 	foreign key(idlugar) references lugar(idlugar) ON DELETE CASCADE
);

CREATE table
	registrodanios(
	idvehiculo integer not null,
	informedanios integer not null,
	idregistro serial,
	descripcion varchar(255) not null,
	foreign key(informedanios, idvehiculo) references informedanios(ID, IDVehiculo) ON DELETE CASCADE,
	primary key(idvehiculo, informedanios, idregistro)
);
CREATE table
	imagenregistro (
	vehiculo integer,
	informe integer,
	nrolista integer,
	nroimagen serial,
	imagen BYTE NOT null,
	primary key(vehiculo, informe, nrolista, nroimagen),
	foreign key(vehiculo, informe, nrolista) references registrodanios(idvehiculo, informedanios, idregistro) ON DELETE CASCADE
);
CREATE table
	actualiza (
	vehiculo1 integer,
	informe1 integer,
	registro1 integer,
	vehiculo2 integer,
	informe2 integer,
	registro2 integer,
	tipo varchar(15) NOT null check (tipo in ('Anulacion', 'Correccion')),
	CHECK (vehiculo1=vehiculo2),
	foreign key(vehiculo1, informe1, registro1) references registrodanios(idvehiculo, informedanios, idregistro) ON DELETE CASCADE,
	foreign key(vehiculo2, informe2, registro2) references registrodanios(idvehiculo, informedanios, idregistro) ON DELETE CASCADE,
	primary key(vehiculo1, informe1, registro1, vehiculo2, informe2, registro2)
);
CREATE table
	posicionado (
	IDLugar integer,
	IDVehiculo integer,
	desde datetime year to second,
	hasta datetime year to second,
	posicion integer NOT null check (posicion > 0),
	IDUsuario integer,
	foreign key(IDVehiculo) references vehiculo(IDVehiculo) ON DELETE CASCADE,
	foreign key(IDLugar) references lugar(IDLugar) ON DELETE CASCADE,
	foreign key(IDUsuario) references usuario(IDUsuario) ON DELETE CASCADE,
	primary key(IDLugar, IDVehiculo, desde)
	);
CREATE table
	camion(
	IDCamion serial primary key,
	VIN char(17) unique,
	Marca varchar(50) NOT null,
	Modelo varchar(50) NOT null,
	Matricula char(7) NOT null,
	Creador integer NOT null,
	FechaCreacion date not null,
	foreign key(Creador) references usuario(IDUsuario) ON DELETE CASCADE
);

CREATE table
	rampascamion(
	IDCamion integer references camion(IDCamion),
	RampaIt integer check (RampaIt > 0),
	CantCamiones integer NOT null check (CantCamiones > -1),
	CantAutos integer NOT null check (CantAutos > -1),
	CantSUV integer NOT null check(CantSUV > -1),
	CantVan integer NOT null check(CantVan > -1),
	CantMinivan integer NOT null check (CantMinivan > -1),
	primary key(IDCamion, RampaIt)
);
CREATE table
	conduce(
	Camion integer,
	Usuario integer,
	Desde date,
	Hasta date,
	foreign key(Camion) references camion(IDCamion) ON DELETE CASCADE,
	foreign key(Usuario) references usuario(IDUsuario) ON DELETE CASCADE,
	primary key(Camion, Usuario, Desde)
);
CREATE table
	lote(
	IDLote serial,
	nombre varchar(20) unique,
	Origen integer NOT null,
	Destino integer NOT null,
	CreadorID integer NOT null,
	FechaCreacion datetime year to day not null,
	Prioridad varchar(10) NOT null check (Prioridad in ('Normal', 'Alta')),
	Estado varchar(10) not null check (Estado in ('Abierto', 'Cerrado', 'Eliminado')),
	primary key(IDLote),
	foreign key(Origen) references lugar(IDLugar) ON DELETE CASCADE,
	foreign key(Destino) references lugar(IDLugar) ON DELETE CASCADE,
	foreign key(CreadorID) references usuario(IDUsuario) ON DELETE CASCADE);

CREATE table
	integra(
	IDVehiculo integer,
	Lote integer,
	Fecha datetime year to minute,
	invalidado boolean not null,
	IDUsuario integer not null,
	primary key(IDVehiculo, Lote, Fecha),
	foreign key(IDVehiculo) references vehiculo(IDVehiculo) ON DELETE CASCADE,
	foreign key(Lote) references lote(IDLote) ON DELETE CASCADE,
	foreign key(IDUsuario) references usuario(IDUsuario) ON DELETE CASCADE );

CREATE table
	transporte(
	transporteID serial primary key,
	Usuario integer NOT NULL,
	FechaHoraCreacion datetime year to minute not null,
	FechaHoraSalida datetime year to minute not null,
	FechaHoraLlegadaEstm datetime year to minute not null,
	FechaHoraLlegadaReal datetime year to minute,
	Estado varchar(10) NOT null check (Estado in ("Proceso", "Fallo", "Exitoso")),
	foreign key(Usuario) references usuario(IDUsuario) ON DELETE CASCADE
	);
CREATE table
	transporta( transporteID integer,
	IDLote integer,
	primary key(transporteID, IDLote),
	foreign key(transporteID) references transporte(transporteID) ON DELETE CASCADE,
	foreign key(IDLote) references lote(IDLote) ON DELETE CASCADE );

create table
	link(
    link varchar(255) primary key,
    transportista integer not null,
	foreign key(transportista) references usuario(idusuario) ON DELETE CASCADE
);
