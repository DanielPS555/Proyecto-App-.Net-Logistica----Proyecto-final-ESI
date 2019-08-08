merge into actualiza as dst
	using (select ?::integer as vehiculo1, ?::integer as informe1,
		?::integer as registro1, ?::integer as vehiculo2,
		?::integer as informe2, ?::integer as registro2,
		?::varchar(15) as tipo from sysmaster:'informix'.sysdual
		) as src
	on dst.vehiculo1=src.vehiculo1
	and dst.informe1=src.informe1
	and dst.registro1=src.registro1
when not matched then insert
	(dst.vehiculo1, dst.informe1, dst.registro1,
	 dst.vehiculo2, dst.informe2, dst.registro2,
	 dst.tipo) values
	(src.vehiculo1, src.informe1, src.registro1,
	 src.vehiculo2, src.informe2, src.registro2,
	 src.tipo)
when matched then update set dst.tipo=src.tipo, dst.registro2=src.registro2,
	dst.informe2=src.informe2;
