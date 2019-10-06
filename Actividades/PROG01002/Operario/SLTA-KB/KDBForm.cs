using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLTA_KB
{
    public partial class KDBForm : Form
    {
        private LiteDB.LiteDatabase litedb = null;
        private LiteDB.LiteCollection<KnowledgeBase.Usuario> usuarios = null;
        private LiteDB.LiteCollection<KnowledgeBase.Articulo> articulos = null;

        public KDBForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserForm uform = new UserForm();
            if(uform.ShowDialog() == DialogResult.OK)
            {
                KnowledgeBase.Usuario usuario = KnowledgeBase.ManipulationFunctions.GenKey(uform.Username);
                if(!(usuario is null))
                {
                    usuarios.Insert(usuario);
                }
                MessageBox.Show("Usuario agregado con éxito, por favor conéctese usando su clave privada");
            }
        }

        private KnowledgeBase.Usuario currentUser = null;
        private RSACryptoServiceProvider cryptoProvider = null;

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Claves|*.key";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Stream k = ofd.OpenFile();
                StreamReader kr = new StreamReader(k);
                string keyXml = kr.ReadToEnd();
                RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
                rSACryptoServiceProvider.FromXmlString(keyXml);
                keyXml = rSACryptoServiceProvider.ToXmlString(false);
                KnowledgeBase.Usuario uActual = KnowledgeBase.ManipulationFunctions.FindUser(keyXml, usuarios);
                if (uActual != null)
                {
                    MessageBox.Show("Se conectó como el usuario " + uActual.Nombre);
                    currentUser = uActual;
                    cryptoProvider = rSACryptoServiceProvider;
                    loadArticles();
                    toolStrip1.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se encontró un usuario con una clave pública equivalente");
                    toolStrip1.Visible = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(currentUser is null)
            {
                MessageBox.Show("Debe loggearse primero");
                return;
            }
            ArticleForm af = new ArticleForm();
            if(af.ShowDialog() == DialogResult.OK)
            {
                var art = KnowledgeBase.ManipulationFunctions.MakeArticle(af.Titulo, af.Contenido, cryptoProvider, currentUser);
                articulos.Insert(art);
                loadArticles();
            }
        }

        private void loadArticles()
        {
            articleList.Items.Clear();
            articleList.Items.AddRange(articulos.FindAll().ToArray());
        }

        private void articleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            KnowledgeBase.Articulo art = (KnowledgeBase.Articulo)articleList.SelectedItem;
            RSACryptoServiceProvider rcsp = new RSACryptoServiceProvider();
            rcsp.FromXmlString(art.Usuario.Public_key);
            if(!rcsp.VerifyData(art.Data, new SHA256CryptoServiceProvider(), art.Signature))
            {
                MessageBox.Show("La firma del artículo no concide con la firma de su autor! Hay una posibilidad de que haya una brecha de seguridad");
                return;
            }
            articleBox.Text = Encoding.UTF8.GetString(art.Data);
            StyleUp(articleBox);
        }

        private void StyleUp(RichTextBox articleBox)
        {
            var headersPos = Enumerable.Range(0, articleBox.Text.Length).Where(x => articleBox.Text[x] == '#').ToArray();
            articleBox.Font = new Font(FontFamily.GenericSansSerif, 8);
            foreach(var k in headersPos)
            {
                var endLine = articleBox.Text.IndexOf('\n', k + 1);
                articleBox.SelectionStart = k + 1;
                articleBox.SelectionLength = endLine - (k + 1);
                articleBox.SelectionFont = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
            }
            var boldPos = new Regex(@"\*(.*)\*").Matches(articleBox.Text);
            foreach(var match in boldPos.Cast<Match>())
            {
                articleBox.SelectionStart = match.Index;
                articleBox.SelectionLength = match.Length;
                articleBox.SelectionFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            }
            var italicPos = new Regex(@"_(.*)_").Matches(articleBox.Text);
            foreach(var match in italicPos.Cast<Match>())
            {
                articleBox.SelectionStart = match.Index;
                articleBox.SelectionLength = match.Length;
                articleBox.SelectionFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Italic);
            }
            var codePos = new Regex(@"startCodeBlock").Matches(articleBox.Text);
            foreach(var match in codePos.Cast<Match>())
            {
                var endPos = articleBox.Text.IndexOf("endCodeBlock", match.Index);
                articleBox.SelectionStart = match.Index;
                articleBox.SelectionLength = endPos - match.Index + "endCodeBlock".Length;
                articleBox.SelectionFont = new Font(FontFamily.GenericMonospace, 8);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Public key|*.pub"
            };
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                Stream oStream = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(oStream);
                sw.WriteLine(cryptoProvider.ToXmlString(false));
                sw.Flush();
                oStream.Close();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Public key|*.pub"
            };
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Stream iStream = ofd.OpenFile();
                StreamReader sr = new StreamReader(iStream);
                var pkey = sr.ReadToEnd().Trim();
                iStream.Close();
                UserList ul = new UserList(usuarios);
                if(ul.ShowDialog() == DialogResult.OK)
                {
                    if(ul.SelectedUser != null)
                    {
                        var upkey = ul.SelectedUser.Public_key.Trim();
                        if(upkey == pkey)
                        {
                            MessageBox.Show("La clave pública es válida!");
                            return;
                        }
                    }
                    MessageBox.Show("La clave pública es inválida, puede haberse equivocado de usuario o puede haber una brecha de seguridad.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Wiki database|*.db";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                litedb = new LiteDB.LiteDatabase(ofd.FileName);
                usuarios = litedb.GetCollection<KnowledgeBase.Usuario>("usuarios");
                usuarios.EnsureIndex(x => x.Id);
                usuarios.EnsureIndex(x => x.Nombre);
                usuarios.EnsureIndex(x => x.Public_key);
                articulos = litedb.GetCollection<KnowledgeBase.Articulo>("articulos");
                articulos.EnsureIndex(x => x.Id);
                articulos.EnsureIndex(x => x.Signature);
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e) => new MakeKey().ShowDialog();
    }
}
