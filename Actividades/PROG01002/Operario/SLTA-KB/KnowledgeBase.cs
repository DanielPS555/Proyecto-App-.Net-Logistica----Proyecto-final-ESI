using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;

namespace SLTA_KB
{
    namespace KnowledgeBase
    {

        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Public_key { get; set; }

            public override string ToString()
            {
                return "@" + Nombre;
            }
        }

        public class Articulo
        {
            public int Id { get; set; }
            public Usuario Usuario { get; set; }
            public string Titulo { get; set; }
            public byte[] Data { get; set; }
            public byte[] Signature { get; set; }
            public override string ToString()
            {
                return $"@{Usuario.Nombre}: {Titulo}";
            }
        }
        public static class ManipulationFunctions
        {
            public static Usuario GenKey(string username)
            {
                CspParameters cspParameters = new CspParameters
                {
                    KeyContainerName = username + "'s key"
                };
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters);
                Usuario newUser = new Usuario()
                {
                    Nombre = username,
                    Public_key = rsa.ToXmlString(false)
                };
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Key file|*.key"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Stream file = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(file);
                    string keyXml = rsa.ToXmlString(true);
                    Console.WriteLine(keyXml);
                    sw.Write(keyXml);
                    sw.Flush();
                    file.Close();
                    return newUser;
                }
                else return null;
            }

            public static Usuario FindUser(string keyXml, LiteCollection<Usuario> usuarios) => usuarios.FindAll().Where(x => x.Public_key == keyXml).SingleOrDefault();

            public static Articulo MakeArticle(string tituloArticulo, string contenidoArticulo, RSACryptoServiceProvider cryptoProvider, Usuario usuario)
            {

                string title = tituloArticulo;
                string desc = contenidoArticulo;
                var bytes = Encoding.UTF8.GetBytes(desc);
                var signature = cryptoProvider.SignData(bytes, new SHA256CryptoServiceProvider());
                var newCrypto = new RSACryptoServiceProvider();
                newCrypto.FromXmlString(usuario.Public_key);
                if(!newCrypto.VerifyData(bytes, new SHA256CryptoServiceProvider(), signature))
                {
                    throw new InvalidOperationException("Could not verify after signing!");
                }
                Articulo art = new Articulo()
                {
                    Usuario = usuario,
                    Data = bytes,
                    Titulo = title,
                    Signature = signature
                };
                return art;
            }
        }

    }
}
