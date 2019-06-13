create table
	rol(
	idrol serial primary key,
	nombre varchar(100) unique
);
insert into rol(nombre) values("OpTrans");
insert into rol(nombre) values("OpPatio");
insert into rol(nombre) values("OpPuerto");
insert into rol(nombre) values("Admin");
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
	foreign key(rol) references rol(idrol));
CREATE
	table lugar(
	IDLugar serial primary key,
	Nombre varchar(100),
	Capacidad INTEGER NOT null,
	GeoX FLOAT NOT null,
	GeoY FLOAT NOT null,
	UsuarioCreador integer NOT null,
	Tipo varchar(10) NOT null,
    check (Tipo IN ("Patio",
	"Puerto")),
	foreign key(UsuarioCreador) references usuario(IDUsuario),
	UNIQUE(Nombre) );
CREATE
	table trabajaen(
	ID serial primary key,
	IDLugar integer not null,
	IDUsuario integer not null,
	FechaInicio date NOT null,
	FechaFin date,
	foreign key(IDLugar) references lugar(IDLugar),
	foreign key(IDUsuario) references usuario(IDUsuario) );
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
	Capacidad integer NOT null,
	foreign key(IDLugar) references lugar(IDLugar),
	primary key(IDLugar, IDZona)
	);
CREATE
	table subzona(
	IDLugar integer,
	IDZona integer,
	IDSub serial,
	Nombre varchar(50) not null,
	Capacidad integer NOT null,
	foreign key(IDLugar, IDZona) references zona(IDLugar, IDZona),
	primary key(IDLugar, IDZona, IDSub)
	);
CREATE
	table vehiculo( VIN char(17),
	Marca varchar(50) NOT null,
	Modelo varchar(50) NOT null,
	Color integer NOT null,
	/* representacion RGBA 8bits por canal corresponde a un integer 32bit */ 
	Tipo varchar(25) NOT null,
	Anio integer NOT null,
	FueraDeSistema boolean NOT null,
	ClienteNombre varchar(50) NOT null,
	PuertoArriba integer NOT null,
	FechaArribo datetime year to day,
	primary key(VIN),
	foreign key(PuertoArriba) references lugar(IDLugar) );
create table vehiculoIngresa(
	VIN char(17),
	Usuario integer,
	TipoIngreso varchar(10) not null check (TipoIngreso in ('Precarga', 'Arribo')),
	Fecha datetime year to day not null,
	primary key(VIN, Usuario),
	foreign key(VIN) references Vehiculo(VIN),
	foreign key(Usuario) references Usuario(IDUsuario)
);
CREATE
	table informedanios( ID serial primary key,
	Descripcion varchar(255) NOT null,
	Fecha datetime year to day NOT null,
	Tipo varchar(50) NOT null,
	VIN char(17) NOT null,
	foreign key(VIN) references vehiculo(VIN) );
CREATE
	table registrodanios(
	informedanios integer not null,
	nroenlista integer not null,
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
	tipo varchar(10) NOT null check (tipo in ('Total', 'Parcial')),
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
	posicion integer NOT null,
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
	RampaIt integer,
	CantCamiones integer NOT null,
	CantAutos integer NOT null,
	CantSUV integer NOT null,
	CantMinivan integer NOT null,
	primary key(VIN,
	RampaIt),
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
	Prioridad varchar(10) NOT null,
	primary key(IDLote),
	foreign key(Desde) references lugar(IDLugar),
	foreign key(Hacia) references lugar(IDLugar),
	foreign key(CreadorID) references usuario(IDUsuario) );
CREATE
	table integra( VIN char(17),
	Lote integer,
	primary key(VIN,
	Lote),
	foreign key(VIN) references vehiculo(VIN),
	foreign key(Lote) references lote(IDLote) );
CREATE
	table transporte(
	transporteID serial primary key,
	Usuario integer NOT NULL,
	FechaHoraSalida datetime year to minute not null,
	FechaHoraLlegada datetime year to minute not null,
	Estado varchar(10) NOT null,
	foreign key(Usuario) references usuario(IDUsuario)
	);
CREATE
	table transporta( transporteID integer,
	IDLote integer,
	primary key(transporteID, IDLote),
	foreign key(transporteID) references transporte(transporteID),
	foreign key(IDLote) references lote(IDLote) );
CREATE
	table posicionestransporte( transporteID integer,
	FechaHoraPosicion datetime year to second,
	PosX float,
	PosY float,
	precision float,
	primary key(transporteID,
	FechaHoraPosicion),
	foreign key(transporteID) references transporte(transporteID) );
