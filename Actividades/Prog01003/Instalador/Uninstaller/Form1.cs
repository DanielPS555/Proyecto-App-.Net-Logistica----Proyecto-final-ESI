using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Uninstaller
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<int> UnKilledLines;

        private static void ForceDelete(string path)
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task uninst = new Task(() =>
            {
                try
                {
                    ForceDelete(ConexionLib.FachadaRegistro.RutaPrograma());
                } catch (Exception)
                {}
                ConexionLib.FachadaRegistro.EliminarConfiguracion();
                ConexionLib.FachadaRegistro.DesregistrarPrograma();
                ConexionLib.FachadaRegistro.DesregistrarDesinstalador();
            });
            uninst.Start();
            Timer t = new System.Windows.Forms.Timer();
            t.Interval = 5;
            UnKilledLines = new List<int>();
            for (int y = 0; y < pictureBox1.Image.Height; y++)
                UnKilledLines.Add(y);
            Random r = new Random();
            t.Tick += (a, b) =>
            {
                for (int i = 0; i < 12; i++)
                {
                    int idx = r.Next(UnKilledLines.Count);
                    var line = UnKilledLines[idx];
                    UnKilledLines.RemoveAt(idx);
                    if (!(pictureBox1.Image is Bitmap bmp))
                    {
                        pictureBox1.Image = new Bitmap(pictureBox1.Image);
                        bmp = (Bitmap)pictureBox1.Image;
                    }
                    for (int x = 0; x < pictureBox1.Image.Width; x++)
                        bmp.SetPixel(x, line, Color.Red);
                    pictureBox1.Image = bmp;
                    if (UnKilledLines.Count < 1)
                    {
                        t.Stop();
                        MessageBox.Show("Gracias por usar SLTA");
                        uninst.Wait();
                        this.Close();
                        break;
                    }
                }
            };
            t.Start();
        }
    }
    public static class Extends
    {
        public static string PathConcat(this string folder, params string[] subfolders)
        {
            var args = new string[subfolders.Length + 1];
            args[0] = folder;
            Array.Copy(subfolders, 0, args, 1, subfolders.Length);
            return System.IO.Path.Combine(args);
        }
    }
}
