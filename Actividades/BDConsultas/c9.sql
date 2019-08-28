select first 1 current year to day as fecha_actual,
v.vin, v.marca, v.modelo, v.color,
case
  when va.tipoingreso is null then "El vehiculo no ha llegado"
  when vb.tipoingreso is not null then "El vehiculo ha abandonado el sistema"
  when transporta.transporteid is null then "En espera en el puerto"
  when transporta.estado = "Proceso" then "en transito"
  when transporta.estado = "Fallo" then "Varado"
  when posicionado.idlugar is null then concat("En el lugar ", lugar.nombre)
  when posicionado.idlugar is not null then
	concat(concat(
		concat("En el lugar ", lugar.nombre), " posicionado en "),
		sz.nombre)
  else "Estado desconocido"
end as estado
 from vehiculo as v
left join vehiculoingresa as va
on va.idvehiculo=v.idvehiculo
and va.tipoingreso="Alta"
left join vehiculoingresa as vb
on vb.idvehiculo=v.idvehiculo
and vb.tipoingreso="Baja"
left join integra on integra.idvehiculo=v.idvehiculo
left join lote on integra.lote=lote.idlote
left join transporta
on lote.idlote=transporta.idlote
left join lugar on lote.destino=lugar.idlugar
left join posicionado on
posicionado.idlugar in (select unnamed_col_1 from
table(subzonas_en_lugar(lugar.idlugar)))
left join lugar as sz on posicionado.idlugar=sz.idlugar
where v.vin="1L0V36I113UWU1112"
order by transporta.fechahorallegadareal desc
