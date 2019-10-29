using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                fbd.SelectedPath
            }

        }
    }
}
