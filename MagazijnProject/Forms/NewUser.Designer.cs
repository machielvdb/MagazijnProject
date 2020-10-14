namespace MagazijnProject
{
    partial class NieuweGebruiker
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbVoornaam = new System.Windows.Forms.TextBox();
            this.tbAchternaam = new System.Windows.Forms.TextBox();
            this.dtpIndienst = new System.Windows.Forms.DateTimePicker();
            this.cbToegang = new System.Windows.Forms.ComboBox();
            this.btnAanmaken = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voornaam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Achternaam:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Indiensttreding:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Toegang: ";
            // 
            // tbVoornaam
            // 
            this.tbVoornaam.Location = new System.Drawing.Point(93, 6);
            this.tbVoornaam.Name = "tbVoornaam";
            this.tbVoornaam.Size = new System.Drawing.Size(200, 20);
            this.tbVoornaam.TabIndex = 5;
            // 
            // tbAchternaam
            // 
            this.tbAchternaam.Location = new System.Drawing.Point(93, 30);
            this.tbAchternaam.Name = "tbAchternaam";
            this.tbAchternaam.Size = new System.Drawing.Size(200, 20);
            this.tbAchternaam.TabIndex = 6;
            // 
            // dtpIndienst
            // 
            this.dtpIndienst.Location = new System.Drawing.Point(93, 79);
            this.dtpIndienst.Name = "dtpIndienst";
            this.dtpIndienst.Size = new System.Drawing.Size(200, 20);
            this.dtpIndienst.TabIndex = 7;
            // 
            // cbToegang
            // 
            this.cbToegang.FormattingEnabled = true;
            this.cbToegang.Location = new System.Drawing.Point(93, 54);
            this.cbToegang.Name = "cbToegang";
            this.cbToegang.Size = new System.Drawing.Size(201, 21);
            this.cbToegang.Sorted = true;
            this.cbToegang.TabIndex = 8;
            // 
            // btnAanmaken
            // 
            this.btnAanmaken.Location = new System.Drawing.Point(15, 105);
            this.btnAanmaken.Name = "btnAanmaken";
            this.btnAanmaken.Size = new System.Drawing.Size(279, 23);
            this.btnAanmaken.TabIndex = 9;
            this.btnAanmaken.Text = "Aanmaken";
            this.btnAanmaken.UseVisualStyleBackColor = true;
            this.btnAanmaken.Click += new System.EventHandler(this.btnAanmaken_Click);
            // 
            // NieuweGebruiker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 136);
            this.Controls.Add(this.btnAanmaken);
            this.Controls.Add(this.cbToegang);
            this.Controls.Add(this.dtpIndienst);
            this.Controls.Add(this.tbAchternaam);
            this.Controls.Add(this.tbVoornaam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NieuweGebruiker";
            this.Text = "Nieuwe gebruiker";
            this.Load += new System.EventHandler(this.NieuweGebruiker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbVoornaam;
        private System.Windows.Forms.TextBox tbAchternaam;
        private System.Windows.Forms.DateTimePicker dtpIndienst;
        private System.Windows.Forms.ComboBox cbToegang;
        private System.Windows.Forms.Button btnAanmaken;
    }
}