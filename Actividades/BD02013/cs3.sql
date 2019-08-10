/* Parametros:
ID del vehiculo
ID del informe a actualizar
ID del registro a actualizar
ID del vehiculo POR RNE DEBE SER = PRIMER ID
ID del informe que actualiza
ID del registro que actualiza
tipo de actualizacion */
insert into actualiza(vehiculo1, informe1, registro1,
		      vehiculo2, informe2, registro2, tipo)
values (?,?,?,?,?,?,?);
