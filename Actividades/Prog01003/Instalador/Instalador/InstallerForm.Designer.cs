namespace Instalador
{
    partial class InstallerForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallerForm));
            this.packageBox = new System.Windows.Forms.CheckedListBox();
            this.appLbl = new System.Windows.Forms.Label();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.keyLbl = new System.Windows.Forms.Label();
            this.verifyButton = new System.Windows.Forms.Button();
            this.installBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.smCheck = new System.Windows.Forms.CheckBox();
            this.InstallList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // packageBox
            // 
            this.packageBox.BackColor = System.Drawing.Color.White;
            this.packageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.packageBox.Enabled = false;
            this.packageBox.Font = new System.Drawing.Font("Segoe UI", 13.25F);
            this.packageBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.packageBox.FormattingEnabled = true;
            this.packageBox.Items.AddRange(new object[] {
            "Administrador",
            "Operario",
            "Transportista"});
            this.packageBox.Location = new System.Drawing.Point(22, 339);
            this.packageBox.Name = "packageBox";
            this.packageBox.Size = new System.Drawing.Size(177, 78);
            this.packageBox.TabIndex = 0;
            // 
            // appLbl
            // 
            this.appLbl.AutoSize = true;
            this.appLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.appLbl.Location = new System.Drawing.Point(17, 311);
            this.appLbl.Name = "appLbl";
            this.appLbl.Size = new System.Drawing.Size(383, 25);
            this.appLbl.TabIndex = 1;
            this.appLbl.Text = "Seleccione los aplicativos que desea instalar";
            this.appLbl.Visible = false;
            // 
            // keyBox
            // 
            this.keyBox.BackColor = System.Drawing.Color.White;
            this.keyBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.keyBox.Location = new System.Drawing.Point(19, 164);
            this.keyBox.Multiline = true;
            this.keyBox.Name = "keyBox";
            this.keyBox.ReadOnly = true;
            this.keyBox.Size = new System.Drawing.Size(470, 93);
            this.keyBox.TabIndex = 2;
            // 
            // keyLbl
            // 
            this.keyLbl.AutoSize = true;
            this.keyLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.keyLbl.Location = new System.Drawing.Point(17, 136);
            this.keyLbl.Name = "keyLbl";
            this.keyLbl.Size = new System.Drawing.Size(231, 25);
            this.keyLbl.TabIndex = 3;
            this.keyLbl.Text = "Clave de usuario del SLTA:";
            // 
            // verifyButton
            // 
            this.verifyButton.BackColor = System.Drawing.Color.White;
            this.verifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(212)))));
            this.verifyButton.Location = new System.Drawing.Point(202, 263);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(176, 34);
            this.verifyButton.TabIndex = 4;
            this.verifyButton.Text = "Verificar";
            this.verifyButton.UseVisualStyleBackColor = false;
            this.verifyButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // installBtn
            // 
            this.installBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(212)))));
            this.installBtn.Enabled = false;
            this.installBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installBtn.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installBtn.ForeColor = System.Drawing.Color.White;
            this.installBtn.Location = new System.Drawing.Point(11, 423);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(237, 50);
            this.installBtn.TabIndex = 5;
            this.installBtn.Text = "Instalar";
            this.installBtn.UseVisualStyleBackColor = false;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 479);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(831, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // smCheck
            // 
            this.smCheck.AutoSize = true;
            this.smCheck.Enabled = false;
            this.smCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smCheck.Location = new System.Drawing.Point(254, 447);
            this.smCheck.Name = "smCheck";
            this.smCheck.Size = new System.Drawing.Size(207, 25);
            this.smCheck.TabIndex = 8;
            this.smCheck.Text = "Agregar al menu de inicio";
            this.smCheck.UseVisualStyleBackColor = true;
            // 
            // InstallList
            // 
            this.InstallList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.InstallList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstallList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.InstallList.FormattingEnabled = true;
            this.InstallList.ItemHeight = 21;
            this.InstallList.Location = new System.Drawing.Point(522, 8);
            this.InstallList.Name = "InstallList";
            this.InstallList.Size = new System.Drawing.Size(321, 464);
            this.InstallList.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(212)))));
            this.button1.Location = new System.Drawing.Point(20, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Ingresar clave";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.label1.Location = new System.Drawing.Point(154, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Instalacion del sistema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.label2.Location = new System.Drawing.Point(155, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 30);
            this.label2.TabIndex = 12;
            this.label2.Text = "STLA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label3.Location = new System.Drawing.Point(384, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ingrese la clave";
            // 
            // InstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(855, 514);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InstallList);
            this.Controls.Add(this.smCheck);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.installBtn);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.keyLbl);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.appLbl);
            this.Controls.Add(this.packageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InstallerForm";
            this.Text = "Instalador del SLTA";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox packageBox;
        private System.Windows.Forms.Label appLbl;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Label keyLbl;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button installBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox smCheck;
        private System.Windows.Forms.ListBox InstallList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}

