-- PFD.01: Caminos entre Lugares a través de Medios
create table
       Camino(
	EnMedio integer,
	IDCamino serial,
	Nombre varchar(90) unique,
        foreign key(EnMedio) references medioTransporte(IDMedio) ON DELETE CASCADE,
	primary key(EnMedio, IDCamino)
); -- Ruta 8, Panamericana, Linea Aerea UY-AR43, El triangulo de las bermudas, las vias de AFE, etc.

create table
       ConexionEntre(
	EnMedio integer,
	IDCamino1 integer,
	IDCamino2 integer,
	foreign key(EnMedio, IDCamino1) references Camino(EnMedio, IDCamino),
	foreign key(EnMedio, IDCamino2) references Camino(EnMedio, IDCamino)
); -- Ruta 8 con Ruta 9, Panamericana con General Paz, etc

create table
       SalidaA(
	IDLugar integer,
	IDMedio integer,
	IDCamino integer,
	foreign key (IDLugar) references Lugar(IDLugar),
	foreign key (IDMedio, IDCamino) references Camino(EnMedio, IDCamino),
	primary key (IDLugar, IDMedio, IDCamino)
); -- Puerto de montevideo con rio de la plata, Puerto de montevideo con Rambla Portuaria

-- Consultas propuestas

-- Suponiendo que Medio 1 = ruta, y existen Ruta 8 -> Ruta9,Ruta10, Ruta9->Ruta 11, Ruta10->Ruta12
select * from ConexionEntre
	start with EnMedio=1 and IDCamino1=8
	connect by nocycle prior IDCamino2=IDCamino1;
