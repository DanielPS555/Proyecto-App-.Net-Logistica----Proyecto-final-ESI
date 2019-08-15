select marca, count(*) from posicionado inner join
(select distinct menor as idlugar from incluye
start with mayor=(select idlugar from lugar where nombre="Deposito piedras blancas")
connect by prior menor=mayor) as sz
on posicionado.idlugar=sz.idlugar and posicionado.hasta is null
inner join vehiculo on vehiculo.idvehiculo=posicionado.idvehiculo
group by marca
