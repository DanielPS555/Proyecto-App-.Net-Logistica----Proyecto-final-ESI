namespace CrearPaquete
{
    partial class Form1
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
            this.listaPaquetes = new System.Windows.Forms.ListBox();
            this.pkgnameBox = new System.Windows.Forms.TextBox();
            this.Agregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.conditions = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // listaPaquetes
            // 
            this.listaPaquetes.FormattingEnabled = true;
            this.listaPaquetes.Location = new System.Drawing.Point(12, 12);
            this.listaPaquetes.Name = "listaPaquetes";
            this.listaPaquetes.Size = new System.Drawing.Size(776, 56);
            this.listaPaquetes.TabIndex = 0;
            // 
            // pkgnameBox
            // 
            this.pkgnameBox.Location = new System.Drawing.Point(12, 74);
            this.pkgnameBox.Name = "pkgnameBox";
            this.pkgnameBox.Size = new System.Drawing.Size(623, 20);
            this.pkgnameBox.TabIndex = 1;
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(641, 72);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(147, 23);
            this.Agregar.TabIndex = 2;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(292, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Generar Conditions.txt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(310, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(478, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Generar zip";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // conditions
            // 
            this.conditions.Location = new System.Drawing.Point(12, 129);
            this.conditions.Name = "conditions";
            this.conditions.ReadOnly = true;
            this.conditions.Size = new System.Drawing.Size(776, 309);
            this.conditions.TabIndex = 5;
            this.conditions.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.conditions);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.pkgnameBox);
            this.Controls.Add(this.listaPaquetes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listaPaquetes;
        private System.Windows.Forms.TextBox pkgnameBox;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox conditions;
    }
}

