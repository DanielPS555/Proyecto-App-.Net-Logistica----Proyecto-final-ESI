select l_sz.idlugar, l_sz.nombre, l_sz.capacidad from (select l.idlugar, sz.capacidad from lugar as sz
inner join incluye as p_sz on p_sz.menor=sz.idlugar
inner join lugar as z on p_sz.mayor=z.idlugar
inner join incluye as p_z on p_z.menor=z.idlugar
inner join lugar as l on p_z.mayor=l.idlugar
where sz.nombre="Zona A_2_mvd") as l
inner join incluye as z_of_l on l.idlugar=z_of_l.mayor
inner join incluye as sz_of_l on z_of_l.menor=sz_of_l.mayor
inner join lugar as l_sz on sz_of_l.menor=l_sz.idlugar
where l_sz.capacidad < l.capacidad
order by l_sz.capacidad desc
