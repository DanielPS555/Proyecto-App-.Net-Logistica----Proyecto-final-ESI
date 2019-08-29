select lugar.nombre, zona.nombre, count(*) as cant_subzonas
from lugar as lugar
inner join incluye as i_zonas on lugar.idlugar=i_zonas.mayor
inner join lugar as zona on i_zonas.menor=zona.idlugar
inner join incluye as i_subzonas on zona.idlugar=i_subzonas.mayor
group by lugar.nombre, zona.nombre
