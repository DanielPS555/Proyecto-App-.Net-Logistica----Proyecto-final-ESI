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
            this.packageBox = new System.Windows.Forms.CheckedListBox();
            this.appLbl = new System.Windows.Forms.Label();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.keyLbl = new System.Windows.Forms.Label();
            this.verifyButton = new System.Windows.Forms.Button();
            this.installBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.exit = new System.Windows.Forms.Button();
            this.smCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // packageBox
            // 
            this.packageBox.BackColor = System.Drawing.Color.LightCoral;
            this.packageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.packageBox.ForeColor = System.Drawing.Color.Blue;
            this.packageBox.FormattingEnabled = true;
            this.packageBox.Items.AddRange(new object[] {
            "Administrador",
            "Operario",
            "Transportista"});
            this.packageBox.Location = new System.Drawing.Point(568, 12);
            this.packageBox.Name = "packageBox";
            this.packageBox.Size = new System.Drawing.Size(102, 47);
            this.packageBox.TabIndex = 0;
            this.packageBox.Visible = false;
            // 
            // appLbl
            // 
            this.appLbl.AutoSize = true;
            this.appLbl.ForeColor = System.Drawing.Color.Blue;
            this.appLbl.Location = new System.Drawing.Point(344, 12);
            this.appLbl.Name = "appLbl";
            this.appLbl.Size = new System.Drawing.Size(218, 13);
            this.appLbl.TabIndex = 1;
            this.appLbl.Text = "Seleccione los aplicativos que desea instalar";
            this.appLbl.Visible = false;
            // 
            // keyBox
            // 
            this.keyBox.BackColor = System.Drawing.Color.LightCoral;
            this.keyBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyBox.ForeColor = System.Drawing.Color.Blue;
            this.keyBox.Location = new System.Drawing.Point(162, 10);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(176, 20);
            this.keyBox.TabIndex = 2;
            // 
            // keyLbl
            // 
            this.keyLbl.AutoSize = true;
            this.keyLbl.ForeColor = System.Drawing.Color.Blue;
            this.keyLbl.Location = new System.Drawing.Point(12, 12);
            this.keyLbl.Name = "keyLbl";
            this.keyLbl.Size = new System.Drawing.Size(136, 13);
            this.keyLbl.TabIndex = 3;
            this.keyLbl.Text = "Clave de usuario del SLTA:";
            // 
            // verifyButton
            // 
            this.verifyButton.BackColor = System.Drawing.Color.LightCoral;
            this.verifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyButton.ForeColor = System.Drawing.Color.Blue;
            this.verifyButton.Location = new System.Drawing.Point(162, 36);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(176, 34);
            this.verifyButton.TabIndex = 4;
            this.verifyButton.Text = "Verificar";
            this.verifyButton.UseVisualStyleBackColor = false;
            this.verifyButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // installBtn
            // 
            this.installBtn.BackColor = System.Drawing.Color.LightCoral;
            this.installBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installBtn.Location = new System.Drawing.Point(568, 65);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(102, 24);
            this.installBtn.TabIndex = 5;
            this.installBtn.Text = "Instalar";
            this.installBtn.UseVisualStyleBackColor = false;
            this.installBtn.Visible = false;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 95);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(658, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // exit
            // 
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.exit.Location = new System.Drawing.Point(765, 7);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(23, 23);
            this.exit.TabIndex = 7;
            this.exit.Text = "x";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // smCheck
            // 
            this.smCheck.AutoSize = true;
            this.smCheck.Location = new System.Drawing.Point(417, 70);
            this.smCheck.Name = "smCheck";
            this.smCheck.Size = new System.Drawing.Size(145, 17);
            this.smCheck.TabIndex = 8;
            this.smCheck.Text = "Agregar al menu de inicio";
            this.smCheck.UseVisualStyleBackColor = true;
            this.smCheck.Visible = false;
            // 
            // InstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.smCheck);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.installBtn);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.keyLbl);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.appLbl);
            this.Controls.Add(this.packageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InstallerForm";
            this.Text = "Instalador del SLTA";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.CheckBox smCheck;
    }
}

