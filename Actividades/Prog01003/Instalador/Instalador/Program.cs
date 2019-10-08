using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instalador
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ConexionLib.FachadaRegistro.EstaRegistrado())
            {
                MessageBox.Show("SLTA ya está instalado, por favor elimínelo del sistema mediante Agregar y Eliminar Programas antes de ejecutar el instalador", "Versión previa de SLTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InstallerForm());
        }
    }
}
