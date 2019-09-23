namespace SLTA_KB
{
    partial class UserList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userBox = new System.Windows.Forms.ListBox();
            this.okbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userBox
            // 
            this.userBox.FormattingEnabled = true;
            this.userBox.Location = new System.Drawing.Point(12, 12);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(402, 303);
            this.userBox.TabIndex = 0;
            // 
            // okbtn
            // 
            this.okbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okbtn.Location = new System.Drawing.Point(339, 322);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(75, 23);
            this.okbtn.TabIndex = 1;
            this.okbtn.Text = "OK";
            this.okbtn.UseVisualStyleBackColor = true;
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 357);
            this.Controls.Add(this.okbtn);
            this.Controls.Add(this.userBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UserList";
            this.Text = "UserList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox userBox;
        private System.Windows.Forms.Button okbtn;
    }
}