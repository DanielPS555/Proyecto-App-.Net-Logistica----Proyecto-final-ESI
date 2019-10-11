using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionLib;

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
            OSCheck();
            IfxCheck();
            DotnetCheck();
        }

        private void DotnetCheck()
        {
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full"))
            {
                if (!rk.GetValueNames().Contains("Release") || (rk.GetValue("Release") as int?) < 394271)
                {
                    MessageBox.Show("Debe instalar .NET Framework 4.6 o mayor antes de instalar el SLTA", "Falta .NET Framework actualizado", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
        }

        private void IfxCheck()
        {
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\ODBC\\ODBCINST.INI"))
            {
                if (!rk.GetSubKeyNames().Contains("IBM INFORMIX ODBC DRIVER (64-bit)"))
                {
                    MessageBox.Show("Debe instalar el driver 64 bits de Informix para ODBC antes de instalar el SLTA", "Falta driver de ODBC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
        }

        private static void OSCheck()
        {
            Console.WriteLine(System.Environment.OSVersion.Version);
            if (System.Environment.OSVersion.Version.Major < 6 || (System.Environment.OSVersion.Version.Major == 6 && System.Environment.OSVersion.Version.Minor < 2))
            {
                MessageBox.Show("El SLTA sólo tiene funcionamiento verificado en Windows 8 y Windows 10, no aseguramos que funcione correctamente en otras versiones del sistema", "Sistema antigüo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = keyBox.Text;
            BitMath.Matrix[] mats;
            try
            {
                mats = BitMath.Matrix.FromBase64(x);
            }
            catch (Exception)
            {
                MessageBox.Show("Clave inválida");
                return;
            }
            foreach (BitMath.Matrix m in mats)
            {
                Console.WriteLine(m);
            }
            if (!MatrixVerification(mats))
            {
                MessageBox.Show("La clave ingresada es inválida!", "Clave errónea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Clave ingrezada";
                verifyButton.Enabled = false;
                button1.Enabled = false;
                packageBox.Enabled = true;
                appLbl.Enabled = true;
                installBtn.Enabled = true;
                smCheck.Enabled = true;
            }
        }

        private static bool MatrixVerification(BitMath.Matrix[] mats)
        {
            var M1Mat = mats[0] * mats[1];
            var M2Mat = mats[2] * mats[3];
            var ExpectedM1 = new BitMath.Matrix(new Fractions.Fraction[][] { new Fractions.Fraction[] { 2, 19, 19 }, new Fractions.Fraction[] { 9, 18, 11 }, new Fractions.Fraction[] { 20, 11, 22 } });
            var ExpectedM2 = new BitMath.Matrix(new Fractions.Fraction[][] { new Fractions.Fraction[] { 19, 20 }, new Fractions.Fraction[] { 12, 1 } });
            return ExpectedM1 == M1Mat && ExpectedM2 == M2Mat;
        }

        private void installBtn_Click(object sender, EventArgs e)
        {
            if (packageBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe selecionar un elemento a insltalar");
                return;
            }
            string InstallPath = GetInstallPath();
            if (!ConexionLib.FachadaRegistro.RegistrarPrograma(InstallPath))
            {
                MessageBox.Show("No se pudo registrar el programa, asegúrese de tener permisos de administrador");
            }
            if (MessageBox.Show($"El sistema se instalará en {InstallPath}, continuar?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            System.IO.Directory.CreateDirectory(InstallPath);
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
                        var appliesFor = parts[1].Contains('|') ? parts[1].Split('|') : new string[] { parts[1] };
                        bool v = appliesFor.Any(f => packageBox.CheckedItems.Cast<string>().Any(i => i.Trim() == f.Trim()));
                        return v;
                    }).ToArray();
                    progressBar1.Visible = true;
                    progressBar1.Maximum = conditions.Length;
                    progressBar1.Value = 0;
                    InstallList.Visible = true;
                    foreach (var file in conditions)
                    {
                        var fileName = file.Split(':')[0];
                        var fileEntry = zipArchive.GetEntry(fileName);
                        var fileStream = fileEntry.Open();
                        string path = System.IO.Path.Combine(InstallPath, fileName);
                        var outputStream = new System.IO.FileStream(path, System.IO.FileMode.Create);
                        using (var copyPromise = fileStream.CopyToAsync(outputStream))
                            copyPromise.Wait();
                        progressBar1.Value += 1;
                        InstallList.Items.Add(path);
                    }
                    var uninstallerPath = System.IO.Path.Combine(InstallPath, "Uninstall.exe");
                    var uninstallerBytes = Properties.Resources.Uninstaller;
                    var uninstStream = new System.IO.FileStream(uninstallerPath, System.IO.FileMode.Create);
                    using (var copyPromise = uninstStream.WriteAsync(uninstallerBytes, 0, uninstallerBytes.Length))
                        copyPromise.Wait();
                    try
                    {
                        FachadaRegistro.RegistrarDesinstalador(uninstallerPath);
                    } catch(Exception e_)
                    {
                        MessageBox.Show(e_.ToString());
                    }
                    if (smCheck.Checked)
                    {
                        var smPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
                        smPath = System.IO.Path.Combine(smPath, "Programs", "SLTA");
                        System.IO.Directory.CreateDirectory(smPath);
                        Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
                        dynamic wsh_shell = Activator.CreateInstance(t);
                        try
                        {
                            foreach (var executable in conditions.Where(x => x.Split(':')[0].EndsWith(".exe")))
                            {
                                CreateLink(InstallPath, smPath, wsh_shell, executable);
                            }
                        }
                        finally
                        {
                            Marshal.FinalReleaseComObject(wsh_shell);
                        }
                    }
                    if (MessageBox.Show("Instalado con éxito! ¿Desea abrir la configuración de red?", "Configuración de red", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        new ConfigurarRed(null).ShowDialog();
                    }
                }
            }
        }

        private void CreateLink(string InstallPath, string smPath, dynamic shell, string f)
        {
            var iconPath = System.IO.Path.Combine(smPath, f.Split(':')[0].Split('.')[0]) + ".lnk";
            var app = System.IO.Path.Combine(InstallPath, f.Split(':')[0]);
            var lnk = shell.CreateShortcut(iconPath);
            try
            {
                lnk.TargetPath = app;
                lnk.IconLocation = app;
                lnk.Save();
                InstallList.Items.Add(iconPath);
            }
            finally
            {
                Marshal.FinalReleaseComObject(lnk);
            }
        }

        private static string GetInstallPath()
        {
            var PFilesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var InstallPath = System.IO.Path.Combine(PFilesDirectory, "Bit", "SLTA");
            return InstallPath;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                var sr = new System.IO.StreamReader(open.FileName);
                var texto = sr.ReadToEnd();
                keyBox.Text = texto;
                sr.Close();
            }

        }


    }
}
