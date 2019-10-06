using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Instalador
{
    public partial class InstallerForm : Form
    {
        public InstallerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.Environment.OSVersion.Version.Major < 6 || (System.Environment.OSVersion.Version.Major == 6 && System.Environment.OSVersion.Version.Minor < 2))
            {
                MessageBox.Show("El SLTA sólo tiene funcionamiento verificado en Windows 7 y Windows 10, no aseguramos que funcione correctamente en otras versiones del sistema", "Sistema antigüo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\ODBC\\ODBCINST.INI"))
            {
                if (!rk.GetSubKeyNames().Contains("IBM INFORMIX ODBC DRIVER (64-bit)"))
                {
                    MessageBox.Show("Debe instalar el driver 64 bits de Informix para ODBC antes de instalar el SLTA", "Falta driver de ODBC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full"))
            {
                if (!rk.GetValueNames().Contains("Release") || (rk.GetValue("Release") as int?) < 461808)
                {
                    MessageBox.Show("Debe instalar .NET Framework 4.7.2 o mayor antes de instalar el SLTA", "Falta .NET Framework actualizado", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = keyBox.Text;
            BitMath.Matrix[] mats;
            try
            {
                mats = BitMath.Matrix.FromBase64(x);
            } catch (Exception _e)
            {
                MessageBox.Show("Clave inválida");
                return;
            }
            foreach (BitMath.Matrix m in mats)
            {
                Console.WriteLine(m);
            }
            var M1Mat = mats[0] * mats[1];
            var M2Mat = mats[2] * mats[3];
            var ExpectedM1 = new BitMath.Matrix(new Fractions.Fraction[][] { new Fractions.Fraction[] { 2, 19, 19 }, new Fractions.Fraction[] { 9, 18, 11 }, new Fractions.Fraction[] { 20, 11, 22 } });
            var ExpectedM2 = new BitMath.Matrix(new Fractions.Fraction[][] { new Fractions.Fraction[] { 19, 20 }, new Fractions.Fraction[] { 12, 1 } });
            if (M1Mat != ExpectedM1 || M2Mat != ExpectedM2)
            {
                MessageBox.Show("La clave ingresada es inválida!", "Clave errónea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                verifyButton.BackColor = Color.Green;
                packageBox.Visible = true;
                appLbl.Visible = true;
                installBtn.Visible = true;
            }
        }

        private void installBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(@"El sistema se instalará en C:\Program Files\Bit\SLTA, continuar?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            System.IO.Directory.CreateDirectory(@"C:\Program Files\Bit\SLTA");
            byte[] packageBytes = Properties.Resources.Paquetes;
            string[] conditions;
            using (var packageStream = new System.IO.MemoryStream(packageBytes))
            {
                using (var zipArchive = new System.IO.Compression.ZipArchive(packageStream))
                {
                    var conditionsEntry = zipArchive.GetEntry("Conditions.txt");
                    using (var condition_stream = conditionsEntry.Open())
                    {
                        using (var streamReader = new System.IO.StreamReader(condition_stream))
                        {
                            conditions = streamReader.ReadToEnd().Split('\n');
                        }
                    }
                    conditions = conditions.Where(file =>
                    {
                        var parts = file.Split(':');
                        var appliesFor = parts[1].Contains('|') ? parts[1].Split('|') : new string[]{ parts[1] };
                        bool v = appliesFor.Any(f => packageBox.CheckedItems.Cast<string>().Any(i => i.Trim() == f.Trim()));
                        Console.Write(string.Join(", ", appliesFor));
                        Console.Write(" is in ");
                        Console.Write(string.Join(", ", packageBox.CheckedItems.Cast<string>()));
                        Console.Write(": ");
                        Console.WriteLine(v);
                        return v;
                    }).ToArray();
                    progressBar1.Visible = true;
                    progressBar1.Maximum = conditions.Length;
                    progressBar1.Value = 0;
                    foreach (var file in conditions)
                    {
                        var fileName = file.Split(':')[0];
                        var fileEntry = zipArchive.GetEntry(fileName);
                        var fileStream = fileEntry.Open();
                        var outputStream = new System.IO.FileStream(@"C:\Program Files\Bit\SLTA\" + fileName, System.IO.FileMode.Create);
                        var copyPromise = fileStream.CopyToAsync(outputStream);
                        copyPromise.Wait();
                        progressBar1.Value += 1;
                        Console.WriteLine(fileName);
                    }
                    MessageBox.Show("Instalado con éxito!");
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
