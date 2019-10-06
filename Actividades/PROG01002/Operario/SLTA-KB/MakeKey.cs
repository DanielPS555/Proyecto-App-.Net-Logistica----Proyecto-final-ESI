using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;

namespace SLTA_KB
{
    public partial class MakeKey : Form
    {
        public MakeKey()
        {
            InitializeComponent();
        }

        private void MakeKey_Load(object sender, EventArgs e)
        {
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            decimal[][] dec = new decimal[3][];

            dec[0] = new decimal[3] { a1.Value, a2.Value, a3.Value };
            dec[1] = new decimal[3] { a4.Value, a5.Value, a6.Value };
            dec[2] = new decimal[3] { a7.Value, a8.Value, a9.Value };
            Matrix<double> A = Matrix<double>.Build.Dense(3,3, (x,y) => (double)dec[x][y]);
            Vector<double> ES1 = Vector<double>.Build.Dense(new double[] // primer sistema de ecuaciones para despejar B
            {
                2,9,20
            });
            Vector<double> ES2 = Vector<double>.Build.Dense(new double[] // segundo sistema de ecuaciones para despejar B
            {
                18,19,11
            });
            Vector<double> ES3 = Vector<double>.Build.Dense(new double[] // tercer sistema de ecuaciones para despejar B
            {
                19,11,22
            });
            var X1 = A.Solve(ES1);
            var X2 = A.Solve(ES2);
            var X3 = A.Solve(ES3);
            var _B = Matrix<double>.Build.DenseOfColumnVectors(X1, X2, X3);
            var B = new decimal[3, 3];
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++) B[x, y] = (decimal)_B[x, y];
            b1.Value = B[0, 0];
            b2.Value = B[0, 1];
            b3.Value = B[0, 2];
            b4.Value = B[1, 0];
            b5.Value = B[1, 1];
            b6.Value = B[1, 2];
            b7.Value = B[2, 0];
            b8.Value = B[2, 1];
            b9.Value = B[2, 2];
        }
    }
}
