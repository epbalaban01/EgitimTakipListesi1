﻿namespace Eğitim_Takip
{
    partial class EgitimDuzenle
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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.comboboxSaat = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxZoomLink = new System.Windows.Forms.TextBox();
            this.textboxZoomSifre = new System.Windows.Forms.TextBox();
            this.textboxZoomID = new System.Windows.Forms.TextBox();
            this.textboxEgitimAdi = new System.Windows.Forms.TextBox();
            this.textboxEgitimZamani = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(78, 250);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(32, 17);
            this.checkBox2.TabIndex = 176;
            this.checkBox2.Text = "1";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 250);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(32, 17);
            this.checkBox1.TabIndex = 177;
            this.checkBox1.Text = "0";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guncelle.Location = new System.Drawing.Point(198, 212);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(100, 42);
            this.btn_guncelle.TabIndex = 7;
            this.btn_guncelle.Text = "Güncelle";
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(32, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 0;
            this.label6.Visible = false;
            // 
            // lblid
            // 
            this.lblid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblid.ForeColor = System.Drawing.Color.Black;
            this.lblid.Location = new System.Drawing.Point(34, 191);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(74, 26);
            this.lblid.TabIndex = 173;
            this.lblid.Text = "-";
            this.lblid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblid.Visible = false;
            // 
            // comboboxSaat
            // 
            this.comboboxSaat.FormattingEnabled = true;
            this.comboboxSaat.Items.AddRange(new object[] {
            "09:30",
            "10:00",
            "10:30",
            "14:00",
            "20:00"});
            this.comboboxSaat.Location = new System.Drawing.Point(154, 174);
            this.comboboxSaat.Name = "comboboxSaat";
            this.comboboxSaat.Size = new System.Drawing.Size(177, 21);
            this.comboboxSaat.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(34, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 15);
            this.label10.TabIndex = 167;
            this.label10.Text = "Saat:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(34, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 168;
            this.label5.Text = "Zoom Link:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(34, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 169;
            this.label4.Text = "Zoom Şifre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(34, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 170;
            this.label3.Text = "Zoom ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 171;
            this.label2.Text = "Eğitim Zamanı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 172;
            this.label1.Text = "Eğitim Adı:";
            // 
            // textboxZoomLink
            // 
            this.textboxZoomLink.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxZoomLink.Location = new System.Drawing.Point(154, 144);
            this.textboxZoomLink.Name = "textboxZoomLink";
            this.textboxZoomLink.Size = new System.Drawing.Size(177, 21);
            this.textboxZoomLink.TabIndex = 5;
            // 
            // textboxZoomSifre
            // 
            this.textboxZoomSifre.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxZoomSifre.Location = new System.Drawing.Point(154, 113);
            this.textboxZoomSifre.Name = "textboxZoomSifre";
            this.textboxZoomSifre.Size = new System.Drawing.Size(177, 21);
            this.textboxZoomSifre.TabIndex = 4;
            // 
            // textboxZoomID
            // 
            this.textboxZoomID.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxZoomID.Location = new System.Drawing.Point(154, 82);
            this.textboxZoomID.Name = "textboxZoomID";
            this.textboxZoomID.Size = new System.Drawing.Size(177, 21);
            this.textboxZoomID.TabIndex = 3;
            // 
            // textboxEgitimAdi
            // 
            this.textboxEgitimAdi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxEgitimAdi.Location = new System.Drawing.Point(154, 20);
            this.textboxEgitimAdi.Name = "textboxEgitimAdi";
            this.textboxEgitimAdi.Size = new System.Drawing.Size(177, 21);
            this.textboxEgitimAdi.TabIndex = 1;
            // 
            // textboxEgitimZamani
            // 
            this.textboxEgitimZamani.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxEgitimZamani.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.textboxEgitimZamani.Location = new System.Drawing.Point(154, 49);
            this.textboxEgitimZamani.Name = "textboxEgitimZamani";
            this.textboxEgitimZamani.Size = new System.Drawing.Size(177, 21);
            this.textboxEgitimZamani.TabIndex = 2;
            this.textboxEgitimZamani.Value = new System.DateTime(2022, 9, 1, 23, 2, 56, 0);
            // 
            // EgitimDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 286);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_guncelle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.comboboxSaat);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxZoomLink);
            this.Controls.Add(this.textboxZoomSifre);
            this.Controls.Add(this.textboxZoomID);
            this.Controls.Add(this.textboxEgitimAdi);
            this.Controls.Add(this.textboxEgitimZamani);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EgitimDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eğitim Düzenle";
            this.Load += new System.EventHandler(this.EgitimDuzenle_Load);
            this.Shown += new System.EventHandler(this.EgitimDuzenle_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_guncelle;
        internal System.Windows.Forms.TextBox label6;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.ComboBox comboboxSaat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxZoomLink;
        private System.Windows.Forms.TextBox textboxZoomSifre;
        private System.Windows.Forms.TextBox textboxZoomID;
        private System.Windows.Forms.TextBox textboxEgitimAdi;
        private System.Windows.Forms.DateTimePicker textboxEgitimZamani;
    }
}