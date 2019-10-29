using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrearPaquete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(listaPaquetes.Items.Count > 0)
            {
                fbd.SelectedPath = listaPaquetes.Items.Cast<Subpackage>().First().ruta;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                listaPaquetes.Items.Add(new Subpackage(pkgnameBox.Text, fbd.SelectedPath));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearCondiciones();
        }

        private Dictionary<String, byte[]> fileDict;

        private void CrearCondiciones()
        {
            conditions.Text = Subpackage.ConditionsFromPackages(listaPaquetes.Items.Cast<Subpackage>().ToList(), out fileDict);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrearCondiciones();
            using (MemoryStream ms = new MemoryStream())
            {
                using (System.IO.Compression.ZipArchive zipArchive = new System.IO.Compression.ZipArchive(ms, System.IO.Compression.ZipArchiveMode.Create, true))
                    foreach (var k in fileDict)
                    {
                        var entry = zipArchive.CreateEntry(k.Key);
                        using (Stream outfile = entry.Open())
                        {
                            outfile.Write(k.Value, 0, k.Value.Length);
                        }
                    }
                ms.Seek(0, SeekOrigin.Begin);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = ".zip";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = sfd.OpenFile())
                        ms.CopyTo(stream);
                }
            }; 
        }
    }
}
