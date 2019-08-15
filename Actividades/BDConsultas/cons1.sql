select posicionado.desde, lugar.nombre, vehiculo.VIN, vehiculo.marca, vehiculo.modelo,
vehiculo.anio, vehiculo.color
from (select distinct menor from incluye
start with mayor=(select idlugar from lugar where nombre="Deposito piedras blancas")
connect by prior menor=mayor)
inner join lugar on lugar.idlugar=menor and lugar.tipo="Subzona"
inner join posicionado on posicionado.idlugar=lugar.idlugar and posicionado.hasta is null
inner join vehiculo on posicionado.idvehiculo=vehiculo.idvehiculo
order by posicionado.desde, lugar.nombre
