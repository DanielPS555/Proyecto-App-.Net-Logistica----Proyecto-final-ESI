insert into evento(id, datos, fechaAgregado) values(0,
'{"tipo": "comentario", "por": "admin", "autor": 1, "idvehiculo": 1, "mensaje": "Está en la zona"}'::json
, current year to second);

insert into evento(idvehiculodatos, fechaAgregado) values(0,
'{"tipo": "comentario", "por": "cliente", "autor": 1, "idvehiculo": 1, "mensaje": "Grasia don!"}'::json
, current year to second);