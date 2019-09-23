CREATE table comentarioCliente(
	idvehiculo integer,
	idcliente integer,
	fecha datetime year to second default current year to second,
	comentario varchar(255) not null,
	foreign key (idvehiculo) references vehiculo(idvehiculo),
	foreign key (idcliente) references cliente(idcliente),
	primary key(idvehiculo, idcliente, fecha)
);

CREATE table comentarioUsuario (
	idvehiculo integer,
	idusuario integer,
	fecha datetime year to second default current year to second,
	comentario varchar(255) not null,
	foreign key (idvehiculo) references vehiculo(idvehiculo),
	foreign key (idusuario) references usuario(idusuario),
	primary key(idvehiculo, idusuario, fecha)
);

ALTER table cliente add PIN char(4);