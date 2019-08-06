/* parametros: vehiculoid, vehiculoid,vehiculoid*/
select * from (select first 1 origen as idlugar, "Llegada al pais" as salida, (select fecha::date from vehiculoIngresa
where idvehiculo=? and tipoingreso="Alta") as llegada
 from integra inner join lote on integra.lote=lote.idlote
where idvehiculo=?
order by integra.fecha)
union all
(select destino as idlugar, fechahorasalida::char(18) as salida, fechahorallegadareal::date as llegada
 from integra inner join lote on integra.lote=lote.idlote
inner join transporta on transporta.idlote=lote.idlote
inner join transporte on transporta.transporteid=transporte.transporteid
where idvehiculo=? and invalidado='f')
order by llegada

