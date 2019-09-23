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
    public partial class UserList : Form
    {
        public UserList(LiteDB.LiteCollection<KnowledgeBase.Usuario> usuarios)
        {
            InitializeComponent();
            foreach (var u in usuarios.FindAll())
            {
                userBox.Items.Add(u);
            }
        }

        public KnowledgeBase.Usuario SelectedUser => (KnowledgeBase.Usuario)userBox.SelectedItem;
    }
}
