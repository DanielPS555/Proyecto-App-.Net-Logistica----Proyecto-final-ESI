create table
	rol(
	idrol serial primary key,
	nombre varchar(25) unique
);

CREATE table
	usuario(
	IDUsuario serial primary key,
	NombreDeUsuario varchar(20),
	Hash_Contra char(60) NOT null,
	/* La contrasenia ser hasheada con bcrypt */
	Email varchar(255) NOT null,
	FechaNac date,
	Telefono varchar(15) NOT null,
	/* segn E.164 los nmeros telefnicos internacionales pueden ser de hasta
	15 dgitos incluyendo el codigo pas */
	PrimerNombre varchar(50) NOT null,
	SegundoNombre varchar(50),
	PrimerApellido varchar(50) NOT null,
	SegundoApellido varchar(50),
	PreguntaSecreta varchar(50) NOT null,
	RespuestaSecreta varchar(50) NOT null,
	Sexo char(1) NOT null,
	rol integer not null,
	CHECK (Sexo IN ('M',
	'F',
	'O')),
	UNIQUE(NombreDeUsuario),
	foreign key(rol) references rol(idrol) ON DELETE CASCADE
);

CREATE table
	creadoPor(
		creado integer NOT null,
		creador integer NOT null,
		fechaCreacion date NOT null,
		primary key(creado),
		foreign key(creado) references usuario(IDUsuario) ON DELETE CASCADE,
		foreign key(creador) references usuario(IDUsuario) ON DELETE CASCADE
);

CREATE table
	cliente(
		RUT varchar(12) unique not null,
		Nombre varchar(100) not null,
		IDCliente serial primary key,
		fechaRegistro datetime year to day not null
);

CREATE table
	lugar(
	IDLugar serial primary key,
	Nombre varchar(100) not null unique,
	Capacidad INTEGER NOT null CHECK (Capacidad > 0),
	GeoX FLOAT NOT null,
	GeoY FLOAT NOT null,
	UsuarioCreador integer NOT null references usuario(IDUsuario),
/*	Duenio integer,*/

	Tipo varchar(6) NOT null check (Tipo IN
	     		    	         ("Patio","Puerto","Establecimiento"))
/*        foreign key(Duenio) references Cliente(RUT)*/
);
/*alter table lugar
add constraint check ((Tipo<>"Establecimiento" and Duenio is null) or
    	       	      (Tipo ="Establecimiento" and Duenio is not null)) constraint duenio_null;*/

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
	zona(
	IDLugar integer,
	IDZona serial,
	Nombre varchar(100) not null,
	Capacidad integer NOT null check(Capacidad > 0),
	foreign key(IDLugar) references lugar(IDLugar) ON DELETE CASCADE,
	primary key(IDLugar, IDZona)
	);
CREATE table
	subzona(
	IDLugar integer,
	IDZona integer,
	IDSub serial,
	Nombre varchar(50) not null,
	Capacidad integer NOT null check(Capacidad > 0),
	foreign key(IDLugar, IDZona) references zona(IDLugar, IDZona) ON DELETE CASCADE,
	primary key(IDLugar, IDZona, IDSub)
	);
CREATE table
	vehiculo( VIN char(17),
	Marca varchar(50),
	Modelo varchar(50),
	Color char(6), /* representación ineficiente; 6char = 6hex = 16^6 = 2^24 < 2^32 = int (4char) < 6char */
	/* representacion del color por hexadecimal*/
	Tipo varchar(7) NOT null check(Tipo in ('Auto', 'MiniVan', 'SUV', 'Camion', 'Van')),
	Anio integer check(Anio >= 1900 and Anio <= 10000),
	Cliente Integer NOT null,
	PuertoArriba integer,
	FechaArribo datetime year to day,
	primary key(VIN),
	foreign key(PuertoArriba) references lugar(IDLugar) ON DELETE CASCADE, /* ¿ por que on delete cascade si no usamos delete ? */
	foreign key(Cliente) references Cliente(IDCliente) ON DELETE CASCADE);

create table
	vehiculoIngresa(
	VIN char(17),
	Fecha datetime year to day not null,
	TipoIngreso varchar(10) not null check (TipoIngreso in ('Precarga', 'Alta', 'Baja')),
	Usuario integer not null,
	primary key(VIN, Fecha),
	foreign key(VIN) references Vehiculo(VIN) ON DELETE CASCADE,
	foreign key(Usuario) references Usuario(IDUsuario) ON DELETE CASCADE
);
CREATE table
	informedanios( ID serial primary key,
	Descripcion varchar(255) NOT null,
	Fecha datetime year to day NOT null,
	Tipo varchar(50) NOT null check (Tipo in ('Total', 'Parcial')),
	VIN char(17) NOT null,
	idlugar integer NOT null,
	idusuario integer NOT null,
	foreign key(idusuario) references usuario(IDUsuario) ON DELETE CASCADE,
	foreign key(VIN) references vehiculo(VIN) ON DELETE CASCADE,
 	foreign key(idlugar) references lugar(idlugar) ON DELETE CASCADE );

CREATE table
	registrodanios(
	informedanios integer not null,
	nroenlista serial,
	descripcion varchar(255) not null,
	foreign key(informedanios) references informedanios(ID) ON DELETE CASCADE,
	primary key(informedanios, nroenlista)
);
CREATE table
	imagenregistro (
	informe integer,
	nrolista integer,
	nroimagen serial,
	imagen BYTE NOT null,
	primary key(informe, nrolista, nroimagen),
	foreign key(informe, nrolista) references registrodanios(informedanios, nroenlista) ON DELETE CASCADE
);
CREATE table
	actualiza (
	informe1 integer,
	registro1 integer,
	informe2 integer,
	registro2 integer,
	tipo varchar(15) NOT null check (tipo in ('Anulacion', 'Correccion')),
	foreign key(informe1, registro1) references registrodanios(informedanios, nroenlista) ON DELETE CASCADE,
	foreign key(informe2, registro2) references registrodanios(informedanios, nroenlista) ON DELETE CASCADE,
	primary key(informe1, registro1, informe2, registro2)
);
CREATE table
	posicionado (
	IDLugar integer,
	IDZona integer,
	IDSub integer,
	VIN char(17),
	desde datetime year to second,
	hasta datetime year to second,
	posicion integer NOT null check (posicion > 0),
	IDUsuario integer NOT null,
	foreign key(VIN) references vehiculo(VIN) ON DELETE CASCADE,
	foreign key(IDLugar, IDZona, IDSub) references subzona(IDLugar, IDZona, IDSub) ON DELETE CASCADE,
	foreign key (IDUsuario) references usuario(IDUsuario) ON DELETE CASCADE,
	primary key(IDLugar, IDZona, IDSub, VIN, desde)
	);
CREATE table
	camion( VIN char(17),
	Marca varchar(50) NOT null,
	Modelo varchar(50) NOT null,
	Matricula char(7) NOT null,
	UsuarioIngresa integer NOT null,
	primary key(VIN),
	foreign key(UsuarioIngresa) references usuario(IDUsuario) ON DELETE CASCADE );

CREATE table
	rampascamion( VIN char(17),
	RampaIt integer check (RampaIt > 0),
	CantCamiones integer NOT null check (CantCamiones > -1),
	CantAutos integer NOT null check (CantAutos > -1),
	CantSUV integer NOT null check(CantSUV > -1),
	CantVan integer NOT null check(CantVan > -1),
	CantMinivan integer NOT null check (CantMinivan > -1),
	primary key(VIN, RampaIt),
	foreign key(VIN) references camion(VIN) ON DELETE CASCADE);

CREATE table
	conduce(
	VIN char(17),
	Usuario integer,
	Desde date,
	Hasta date,
	foreign key(VIN) references camion(VIN) ON DELETE CASCADE,
	foreign key(Usuario) references usuario(IDUsuario) ON DELETE CASCADE,
	primary key(VIN, Usuario, Desde)
);
CREATE table
	lote( IDLote serial,
	nombre varchar(20) unique,
	Desde integer NOT null,
	Hacia integer NOT null,
	CreadorID integer NOT null,
	FechaCreacion datetime year to day not null,
	Prioridad varchar(10) NOT null check (Prioridad in ('Normal', 'Alta')),
	Estado varchar(10) not null check (Estado in ('Abierto', 'Cerrado')),
	primary key(IDLote),
	foreign key(Desde) references lugar(IDLugar) ON DELETE CASCADE,
	foreign key(Hacia) references lugar(IDLugar) ON DELETE CASCADE,
	foreign key(CreadorID) references usuario(IDUsuario) ON DELETE CASCADE);

CREATE table
	integra( VIN char(17),
	Lote integer,
	Fecha datetime year to minute,
	invalidado boolean not null,
	IDUsuario integer not null,
	primary key(VIN, Lote, Fecha),
	foreign key(VIN) references vehiculo(VIN) ON DELETE CASCADE,
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
    link varchar(255) not null,
    transportista integer primary key,
	foreign key(transportista) references usuario(idusuario) ON DELETE CASCADE
);
