using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLTA_KB
{
    public partial class Form1 : Form
    {
        private LiteDB.LiteDatabase db;
        private LiteDB.LiteCollection<Usuario> usuarios;
        private LiteDB.LiteCollection<Articulo> articulos;

        private void MakeTree()
        {
            ArticleList.Items.Clear();
            ArticleList.Items.AddRange(articulos.FindAll().ToArray());
        }

        public Form1()
        {
            db = new LiteDB.LiteDatabase("wiki.db");
            Console.WriteLine(db);
            usuarios = db.GetCollection<Usuario>("usuarios");
            Console.WriteLine(usuarios);
            usuarios.EnsureIndex(x => x.Nombre);
            usuarios.EnsureIndex(x => x.Id);
            usuarios.EnsureIndex(x => x.Public_key);
            Console.WriteLine(usuarios);
            articulos = db.GetCollection<Articulo>("articulos");
            articulos.EnsureIndex(x => x.id);
            Console.WriteLine(articulos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CspParameters cspParameters = new CspParameters
            {
                KeyContainerName = authorName.Text + "'s key"
            };
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(256, cspParameters);
            Usuario newUser = new Usuario()
            {
                Nombre = authorName.Text,
                Public_key = rsa.ToXmlString(false)
            };
            usuarios.Insert(newUser);
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "*.key|Key file"
            };
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                Stream file = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(file);
                sw.Write(rsa.ToXmlString(true));
                file.Flush();
                file.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "*.key|Key file"
            };
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Stream file = ofd.OpenFile();
                StreamReader sr = new StreamReader(file);
                string keyXml = sr.ReadToEnd();
                RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
                rSACryptoServiceProvider.FromXmlString(keyXml);
                string title = tituloArticulo.Text;
                string desc = contenidoArticulo.Text;
                var bytes = rSACryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(desc), false);
                Articulo art = new Articulo()
                {
                    usuario = (from u in usuarios.FindAll() where u.Public_key == keyXml select u).Single(),
                    data = bytes,
                    titulo = title
                };
                articulos.Insert(art);
                MakeTree();
            }
        }

        private void ArticleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Articulo art = ArticleList.SelectedItem as Articulo;
            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
            rSACryptoServiceProvider.FromXmlString(art.usuario.Public_key);
            var data = Encoding.UTF8.GetString(rSACryptoServiceProvider.Decrypt(art.data, false));
            contenidoArticulo.Text = data;
            tituloArticulo.Text = art.titulo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);
            MakeTree();
        }
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Public_key { get; set; }
    }

    public class Articulo
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public string titulo { get; set; }
        public byte[] data { get; set; }
        public override string ToString()
        {
            return $"@{usuario.Nombre}: {titulo}";
        }
    }

}
