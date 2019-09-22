namespace SLTA_KB
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
            this.contenidoArticulo = new System.Windows.Forms.RichTextBox();
            this.authorName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tituloArticulo = new System.Windows.Forms.TextBox();
            this.ArticleList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // contenidoArticulo
            // 
            this.contenidoArticulo.Location = new System.Drawing.Point(12, 12);
            this.contenidoArticulo.Name = "contenidoArticulo";
            this.contenidoArticulo.Size = new System.Drawing.Size(503, 426);
            this.contenidoArticulo.TabIndex = 0;
            this.contenidoArticulo.Text = "";
            // 
            // authorName
            // 
            this.authorName.Location = new System.Drawing.Point(521, 12);
            this.authorName.Name = "authorName";
            this.authorName.Size = new System.Drawing.Size(107, 20);
            this.authorName.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(521, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Crear autor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(521, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Agregar artículo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tituloArticulo
            // 
            this.tituloArticulo.Location = new System.Drawing.Point(521, 108);
            this.tituloArticulo.Name = "tituloArticulo";
            this.tituloArticulo.Size = new System.Drawing.Size(154, 20);
            this.tituloArticulo.TabIndex = 4;
            // 
            // ArticleList
            // 
            this.ArticleList.FormattingEnabled = true;
            this.ArticleList.Location = new System.Drawing.Point(521, 168);
            this.ArticleList.Name = "ArticleList";
            this.ArticleList.Size = new System.Drawing.Size(267, 264);
            this.ArticleList.TabIndex = 5;
            this.ArticleList.SelectedIndexChanged += new System.EventHandler(this.ArticleList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 450);
            this.Controls.Add(this.ArticleList);
            this.Controls.Add(this.tituloArticulo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.authorName);
            this.Controls.Add(this.contenidoArticulo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox contenidoArticulo;
        private System.Windows.Forms.TextBox authorName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tituloArticulo;
        private System.Windows.Forms.ListBox ArticleList;
    }
}

