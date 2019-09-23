update cliente set PIN='3321' where nombre='Sevel';

insert into comentarioUsuario values ((select idvehiculo from vehiculo where VIN like '1GH2J83%'), 1, current year to second, "Está sanito don!");