ALTER table cliente add passphrase char(60);

insert into evento(id, datos, fechaAgregado) values(0,
'{"tipo": "modulo", "por": "admin", "autor": 1, "mensaje": "instalacion del sltawc"}'::json
, current year to second);
