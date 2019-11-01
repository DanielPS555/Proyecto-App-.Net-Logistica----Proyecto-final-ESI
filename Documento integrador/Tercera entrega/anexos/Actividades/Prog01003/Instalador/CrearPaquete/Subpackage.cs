using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CrearPaquete
{
    public class Subpackage
    {
        public string nombre;
        public string ruta;

        public Subpackage(string nombre, string ruta)
        {
            this.nombre = nombre;
            this.ruta = ruta;
        }

        public static string ConditionsFromPackages(List<Subpackage> spackages, out Dictionary<string, byte[]> files)
        {
            var conditions = new Dictionary<string, List<string>>();
            files = new Dictionary<string, byte[]>();
            foreach(Subpackage i in spackages)
            {
                var k = from x in System.IO.Directory.EnumerateFiles(i.ruta) where x.EndsWith(".exe") || x.EndsWith(".dll") select x.Split('\\').Last();
                foreach(var x in k.Where(z => !conditions.ContainsKey(z)))
                {
                    conditions[x] = new List<string>();
                    files[x] = File.ReadAllBytes(System.IO.Path.Combine(i.ruta, x));
                }
                foreach (var x in k)
                    conditions[x].Add(i.nombre);
            }
            files["Conditions.txt"] = Encoding.UTF8.GetBytes(string.Join("\r\n", (from x in conditions.Keys select x+ ":" + string.Join("|", conditions[x]))));
            return Encoding.UTF8.GetString(files["Conditions.txt"]);
        }

        public override string ToString()
        {
            return nombre + ": " + ruta;
        }
    }
}
