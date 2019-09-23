using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLTA_KB
{
    public partial class ArticleForm : Form
    {
        public ArticleForm()
        {
            InitializeComponent();
        }

        public string Titulo
        {
            get
            {
                return this.titleBox.Text;
            }
        }
        public string Contenido
        {
            get
            {
                return this.contentBox.Text;
            }
        }
    }
}
