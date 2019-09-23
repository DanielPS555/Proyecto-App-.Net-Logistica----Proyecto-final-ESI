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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        public string Username {
            get {
                return username.Text;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(username.TextLength > 3)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
