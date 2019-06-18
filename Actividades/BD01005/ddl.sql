create table
	rol(
	idrol serial primary key,
	nombre varchar(25) unique
);
insert into rol(nombre) values("Operario");
insert into rol(nombre) values("Transportista");
insert into rol(nombre) values("Administrador");
CREATE
	table usuario(
	IDUsuario serial primary key,
	NombreDeUsuario varchar(20),
	Hash_Contra char(60) NOT null,
	/* La contrasenia será hasheada con bcrypt */ 
	Email varchar(255) NOT null,
	FechaNac date,
	Telefono varchar(15) NOT null,
	/* según E.164 los números telefónicos internacionales pueden ser de hasta 
	15 dígitos incluyendo el codigo país */
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
	foreign key(rol) references rol(idrol)
);

CREATE
	table lugar(
	IDLugar serial primary key,
	Nombre varchar(100) not null unique,
	Capacidad INTEGER NOT null CHECK (Capacidad > 0),
	GeoX FLOAT NOT null,
	GeoY FLOAT NOT null,
	UsuarioCreador integer NOT null references usuario(IDUsuario),
	Tipo varchar(6) NOT null check (Tipo IN ("Patio",
	"Puerto"))
);

CREATE
	table trabajaen(
	ID serial primary key,
	IDLugar integer not null,
	IDUsuario integer not null,
	FechaInicio date NOT null,
	FechaFin date,
	foreign key(IDLugar) references lugar(IDLugar),
	foreign key(IDUsuario) references usuario(IDUsuario)
);

CREATE
	table conexion(
	IDTrabajaEn integer,
	HoraIngreso datetime year to minute not null,
	HoraSalida datetime year to minute,
	foreign key(IDTrabajaEn) references trabajaen(ID),
	primary key(IDTrabajaEn, HoraIngreso)
);

CREATE
	table zona(
	IDLugar integer,
	IDZona serial,
	Nombre varchar(100) not null,
	Capacidad integer NOT null check(Capacidad > 0),
	foreign key(IDLugar) references lugar(IDLugar),
	primary key(IDLugar, IDZona)
	);
CREATE
	table subzona(
	IDLugar integer,
	IDZona integer,
	IDSub serial,
	Nombre varchar(50) not null,
	Capacidad integer NOT null check(Capacidad > 0),
	foreign key(IDLugar, IDZona) references zona(IDLugar, IDZona),
	primary key(IDLugar, IDZona, IDSub)
	);
CREATE
	table vehiculo( VIN char(17),
	Marca varchar(50) NOT null,
	Modelo varchar(50) NOT null,
	Color integer NOT null,
	/* representacion RGBA 8bits por canal corresponde a un integer 32bit */ 
	Tipo varchar(25) NOT null check(Tipo in ('Auto', 'MiniVan', 'SUV', 'Camion')),
	Anio integer NOT null check(Anio >= 1900 and Anio <= 10000),
	ClienteNombre varchar(50) NOT null,
	PuertoArriba integer NOT null,
	FechaArribo datetime year to day,
	primary key(VIN),
	foreign key(PuertoArriba) references lugar(IDLugar) );

create table vehiculoIngresa(
	VIN char(17),
	Fecha datetime year to day not null,
	TipoIngreso varchar(10) not null check (TipoIngreso in ('Precarga', 'Alta', 'Baja')),
	Usuario integer not null,
	primary key(VIN, Fecha),
	foreign key(VIN) references Vehiculo(VIN),
	foreign key(Usuario) references Usuario(IDUsuario)
);
CREATE
	table informedanios( ID serial primary key,
	Descripcion varchar(255) NOT null,
	Fecha datetime year to day NOT null,
	Tipo varchar(50) NOT null check (Tipo in ('Total', 'Parcial')),
	VIN char(17) NOT null,
	foreign key(VIN) references vehiculo(VIN) );
CREATE
	table registrodanios(
	informedanios integer not null,
	nroenlista integer not null check (nroenlista > 0),
	descripcion varchar(255) not null,
	foreign key(informedanios) references informedanios(ID),
	primary key(informedanios, nroenlista)
);
CREATE
	table imagenregistro (
	informe integer,
	nrolista integer,
	nroimagen serial,
	imagen BYTE NOT null,
	primary key(informe, nrolista, nroimagen),
	foreign key(informe, nrolista) references registrodanios(informedanios, nroenlista)
);
CREATE
	table actualiza (
	informe1 integer,
	registro1 integer,
	informe2 integer,
	registro2 integer,
	tipo varchar(15) NOT null check (tipo in ('Anulacion', 'Correccion')),
	foreign key(informe1, registro1) references registrodanios(informedanios, nroenlista),
	foreign key(informe2, registro2) references registrodanios(informedanios, nroenlista),
	primary key(informe1, registro1, informe2, registro2)
);
CREATE
	table posicionado (
	IDLugar integer,
	IDZona integer,
	IDSub integer,
	VIN char(17),
	desde datetime year to hour,
	hasta datetime year to hour,
	posicion integer NOT null check (posicion > 0),
	foreign key(VIN) references vehiculo(VIN),
	foreign key(IDLugar, IDZona, IDSub) references subzona(IDLugar, IDZona, IDSub),
	primary key(IDLugar, IDZona, IDSub, VIN, desde)
	);
CREATE
	table camion( VIN char(17),
	Marca varchar(50) NOT null,
	Modelo varchar(50) NOT null,
	Matricula char(7) NOT null,
	UsuarioIngresa integer NOT null,
	primary key(VIN),
	foreign key(UsuarioIngresa) references usuario(IDUsuario) );
CREATE
		table rampascamion( VIN char(17),
	RampaIt integer check (RampaIt > 0),
	CantCamiones integer NOT null check (CantCamiones > 0),
	CantAutos integer NOT null check (CantAutos > 0),
	CantSUV integer NOT null check(CantSUV > 0),
	CantMinivan integer NOT null check (CantMinivan > 0),
	primary key(VIN, RampaIt),
	foreign key(VIN) references camion(VIN) );
CREATE
	table conduce( 
	VIN char(17),
	Usuario integer,
	Desde date,
	Hasta date,
	foreign key(VIN) references camion(VIN),
	foreign key(Usuario) references usuario(IDUsuario),
	primary key(VIN, Usuario, Desde)
);
CREATE
	table lote( IDLote serial,
	FechaPartida date NOT null,
	Desde integer NOT null,
	Hacia integer NOT null,
	CreadorID integer NOT null,
	Prioridad varchar(10) NOT null check (Prioridad in ('Normal', 'Alta')),
	primary key(IDLote),
	foreign key(Desde) references lugar(IDLugar),
	foreign key(Hacia) references lugar(IDLugar),
	foreign key(CreadorID) references usuario(IDUsuario) );
CREATE
	table integra( VIN char(17),
	Lote integer,
	Fecha datetime year to minute,
	invalidado boolean not null,
	primary key(VIN, Lote, Fecha),
	foreign key(VIN) references vehiculo(VIN),
	foreign key(Lote) references lote(IDLote) );
CREATE
	table transporte(
	transporteID serial primary key,
	Usuario integer NOT NULL,
	FechaHoraSalida datetime year to minute not null,
	FechaHoraLlegada datetime year to minute not null,
	Estado varchar(10) NOT null check (Estado in ("En proceso", "Fallo", "Exitoso")),
	foreign key(Usuario) references usuario(IDUsuario)
	);
CREATE
	table transporta( transporteID integer,
	IDLote integer,
	primary key(transporteID, IDLote),
	foreign key(transporteID) references transporte(transporteID),
	foreign key(IDLote) references lote(IDLote) );
CREATE
	table posicionestransporte(
	transporteID integer,
	FechaHoraPosicion datetime year to second,
	PosX float not null,
	PosY float not null,
	precision float not null,
	primary key(transporteID,
	FechaHoraPosicion),
	foreign key(transporteID) references transporte(transporteID) );
