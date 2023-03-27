namespace Eğitim_Takip
{
    partial class SunucuAyarlari
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
            this.button1 = new System.Windows.Forms.Button();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.databaseText = new System.Windows.Forms.TextBox();
            this.serverText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(205, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Bağlan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("Arial", 8.25F);
            this.passwordText.Location = new System.Drawing.Point(115, 95);
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '●';
            this.passwordText.Size = new System.Drawing.Size(175, 20);
            this.passwordText.TabIndex = 3;
            // 
            // usernameText
            // 
            this.usernameText.Font = new System.Drawing.Font("Arial", 8.25F);
            this.usernameText.Location = new System.Drawing.Point(115, 68);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(175, 20);
            this.usernameText.TabIndex = 2;
            // 
            // databaseText
            // 
            this.databaseText.Font = new System.Drawing.Font("Arial", 8.25F);
            this.databaseText.Location = new System.Drawing.Point(115, 39);
            this.databaseText.Name = "databaseText";
            this.databaseText.Size = new System.Drawing.Size(175, 20);
            this.databaseText.TabIndex = 1;
            // 
            // serverText
            // 
            this.serverText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.serverText.Location = new System.Drawing.Point(115, 13);
            this.serverText.Name = "serverText";
            this.serverText.Size = new System.Drawing.Size(175, 20);
            this.serverText.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 156;
            this.label5.Text = "Sunucu Adresi:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(21, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 14);
            this.label6.TabIndex = 156;
            this.label6.Text = "Veritabanı Adı:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(30, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 14);
            this.label7.TabIndex = 156;
            this.label7.Text = "Kullanıcı Adı:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(72, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 14);
            this.label8.TabIndex = 156;
            this.label8.Text = "Şifre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.serverText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.databaseText);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.usernameText);
            this.groupBox1.Controls.Add(this.passwordText);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 164);
            this.groupBox1.TabIndex = 157;
            this.groupBox1.TabStop = false;
            // 
            // SunucuAyarlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 187);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SunucuAyarlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sunucu Ayarları";
            this.Load += new System.EventHandler(this.SunucuAyarlari_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox databaseText;
        private System.Windows.Forms.TextBox serverText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}