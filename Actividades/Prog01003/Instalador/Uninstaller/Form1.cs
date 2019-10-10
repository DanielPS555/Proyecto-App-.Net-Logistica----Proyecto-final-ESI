using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private List<Point> UnKilledPoints;

        private void button1_Click(object sender, EventArgs e)
        {
            Task uninst = new Task(() =>
            {
                try
                {
                    ConexionLib.FachadaRegistro.EliminarConfiguracion();
                    System.IO.Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).PathConcat("Bit"), true);
                }
                catch { }
            });
            uninst.Start();
            Timer t = new System.Windows.Forms.Timer();
            t.Interval = 5;
            UnKilledPoints = new List<Point>();
            for (int x = 0; x < pictureBox1.Image.Width; x++)
                for (int y = 0; y < pictureBox1.Image.Height; y++)
                    UnKilledPoints.Add(new Point(x, y));
            Random r = new Random();
            t.Tick += (a,b) =>
            {
                for (int i = 0; i < 25; i++)
                {
                    int idx = r.Next(UnKilledPoints.Count);
                    var point = UnKilledPoints[idx];
                    UnKilledPoints.RemoveAt(idx);
                    if (!(pictureBox1.Image is Bitmap bmp))
                    {
                        pictureBox1.Image = new Bitmap(pictureBox1.Image);
                        bmp = (Bitmap)pictureBox1.Image;
                    }
                    bmp.SetPixel(point.X, point.Y, Color.Red);
                    pictureBox1.Image = bmp;
                    if (UnKilledPoints.Count < 1)
                    {
                        t.Stop();
                        MessageBox.Show("Gracias por usar SLTA");
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
