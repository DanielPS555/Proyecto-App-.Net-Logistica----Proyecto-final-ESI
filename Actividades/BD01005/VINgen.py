import random

def VINSink():
    while True:
        tr = random.randint(1,5)
        vin = [random.choice("ABCDEFGHIJKLMNOPQRSTUVWXYZ") for i in range(0,tr)] + [random.choice("0123456789") for i in range(0,17-tr)]
        random.shuffle(vin)
        vin = "".join(vin)
        yield vin

def ImportSink(vs):
    while True:
        v = next(vs)
        yield "insert into vehiculo(VIN, Tipo, Cliente) values ('" + v + "', 'Auto', 1);"
        yield "insert into vehiculoIngresa(IDVehiculo, Fecha, TipoIngreso, Usuario) values ((select IDVehiculo from vehiculo where vin='" + v + "'), current year to day, 'Precarga', 1);"

IS = ImportSink(VINSink())
for i in range(0, 10):
    print(next(IS))
    print(next(IS))
