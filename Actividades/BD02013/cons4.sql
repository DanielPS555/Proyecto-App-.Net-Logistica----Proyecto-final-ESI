select transporte.transporteid, usuario as transportista,
max(fechahorallegadaestm) as maximafechaesperada
from transporte
inner join transporta on transporta.transporteid=transporte.transporteid
group by transporte.transporteid, usuario