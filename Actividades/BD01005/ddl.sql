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
	15 dígitos incluyendo el codigo país */ PrimerNombre varchar(50) NOT null,
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
	CreadorID integer NOT null,
	Tipo varchar(10) NOT null,
    check (Tipo IN ("Patio",
	"Puerto")),
	foreign key(CreadorID) references usuario(IDUsuario),
	UNIQUE(Nombre) );
CREATE
	table trabajaen(
	LogID_TE serial primary key,
	Lugar integer not null,
	Usuario integer not null,
	Desde date NOT null,
	Hasta date,
	foreign key(Lugar) references lugar(IDLugar),
	foreign key(Usuario) references usuario(IDUsuario) );
CREATE
	table usuarioingresa(
	ID_TE serial primary key,
	FechaHoraInicio datetime year to minute,
	FechaHoraFin datetime year to minute,
	foreign key(ID_TE) references trabajaen(LogID_TE)
	);
CREATE
	table zona(
	IDZona serial primary key,
	Lugar integer,
	Nombre varchar(100),
	Capacidad integer NOT null,
	foreign key(Lugar) references lugar(IDLugar) );
CREATE
	table subzona(
	IDSub serial primary key,
	Zona integer not null,
	Nombre varchar(50) not null,
	Capacidad integer NOT null,
	foreign key(Zona) references zona(IDZona) );
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
	UsuarioIngresa integer NOT null,
	PuertoArriba integer NOT null,
	primary key(VIN),
	foreign key(UsuarioIngresa) references usuario(IDUsuario),
	foreign key(PuertoArriba) references lugar(IDLugar) );
CREATE
	table informedanios( ID serial primary key,
	Descripcion varchar(255) NOT null,
	Fecha datetime year to day NOT null,
	Tipo varchar(50) NOT null,
	VehiculoSobre char(17) NOT null,
	foreign key(VehiculoSobre) references vehiculo(VIN) );
CREATE
	table registrodanios(
	rd serial primary key,
	informedanios integer not null,
	nroenlista integer not null,
	descripcion varchar(255) not null,
	foreign key(informedanios) references informedanios(ID) );
CREATE
	table imagenregistro (
	rdid integer,
	imgit integer,
	imagen BYTE NOT null,
	primary key(rdid, imgit),
	foreign key(rdid) references registrodanios(rd) );
CREATE
	table actualiza ( rdanterior integer,
	rdnuevo integer,
	tipo varchar(50) NOT null,
	foreign key(rdanterior) references registrodanios(rd),
	foreign key(rdnuevo) references registrodanios(rd),
	primary key(rdanterior, rdnuevo)
);
CREATE
	table posicionado (
	poslog serial primary key,
	VIN char(17) not null,
	subzona integer not null,
	desde datetime year to hour not null,
	hasta datetime year to hour,
	posicion integer NOT null,
	foreign key(VIN) references vehiculo(VIN),
	foreign key(subzona) references subzona(IDSub) );
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
	IDConduce serial primary key,
	VIN char(17) not null,
	Usuario integer not null,
	Desde date not null,
	Hasta date NOT null,
	foreign key(VIN) references camion(VIN),
	foreign key(Usuario) references usuario(IDUsuario) );
CREATE
	table lote( IDLote serial,
	FechaPartida date NOT null,
	Destino integer NOT null,
	CreadorID integer NOT null,
	Prioridad varchar(10) NOT null,
	primary key(IDLote),
	foreign key(Destino) references lugar(IDLugar),
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
