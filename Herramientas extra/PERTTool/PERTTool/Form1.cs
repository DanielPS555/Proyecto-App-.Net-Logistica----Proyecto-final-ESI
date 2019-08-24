using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PERTTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            nombreBox.BackColor = Color.Red;
            Refresh();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            graphTool1.Weight = (int)numericUpDown1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (nombreBox.Text.Trim().Length < 1 || graphTool1.graph.Nodes.Where(x => x.Name == nombreBox.Text.Trim()).Count() > 0)
                nombreBox.BackColor = Color.Red;
            else
                nombreBox.BackColor = Color.White;
            graphTool1.Activity = nombreBox.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            graphTool1.Path = textBox2.Text;
            graphTool1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var i in graphTool1.Paths())
            {
                listBox1.Items.Add(i);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click izquierdo: Agregar un nodo con el nombre del primer textbox\nClick derecho: Seleccionar un nodo\nPresionar rueda: crear camino entre 2 nodos con nombre y peso definidos por el primer textbox y el numeric respectivamente\nF: Eliminar nodo (y sus caminos relacionados)\n[WSAD]: Mover el area visible, o mover un nodo si hay uno seleccionado\n-: Zoom out\n+: Zoom in", "Ayuda");
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                Stream os = sfd.OpenFile();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(os, graphTool1.graph);
            }
        }

        private void cargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Stream os = ofd.OpenFile();
                BinaryFormatter formatter = new BinaryFormatter();
                graphTool1.graph = (Graph)formatter.Deserialize(os);
                graphTool1.Invalidate();
            }
        }
    }
}
