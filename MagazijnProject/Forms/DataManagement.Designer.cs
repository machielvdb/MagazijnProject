namespace MagazijnProject.Forms
{
    partial class DataManagement
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
            this.btnPersoneel = new System.Windows.Forms.Button();
            this.btnLeveranciers = new System.Windows.Forms.Button();
            this.btnKlanten = new System.Windows.Forms.Button();
            this.btnProducten = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPersoneel
            // 
            this.btnPersoneel.Location = new System.Drawing.Point(12, 12);
            this.btnPersoneel.Name = "btnPersoneel";
            this.btnPersoneel.Size = new System.Drawing.Size(100, 23);
            this.btnPersoneel.TabIndex = 0;
            this.btnPersoneel.Text = "Personeel";
            this.btnPersoneel.UseVisualStyleBackColor = true;
            this.btnPersoneel.Click += new System.EventHandler(this.btnPersoneel_Click);
            // 
            // btnLeveranciers
            // 
            this.btnLeveranciers.Location = new System.Drawing.Point(12, 70);
            this.btnLeveranciers.Name = "btnLeveranciers";
            this.btnLeveranciers.Size = new System.Drawing.Size(100, 23);
            this.btnLeveranciers.TabIndex = 1;
            this.btnLeveranciers.Text = "Leveranciers";
            this.btnLeveranciers.UseVisualStyleBackColor = true;
            this.btnLeveranciers.Click += new System.EventHandler(this.btnLeveranciers_Click);
            // 
            // btnKlanten
            // 
            this.btnKlanten.Location = new System.Drawing.Point(12, 99);
            this.btnKlanten.Name = "btnKlanten";
            this.btnKlanten.Size = new System.Drawing.Size(100, 23);
            this.btnKlanten.TabIndex = 2;
            this.btnKlanten.Text = "Klanten";
            this.btnKlanten.UseVisualStyleBackColor = true;
            this.btnKlanten.Click += new System.EventHandler(this.btnKlanten_Click);
            // 
            // btnProducten
            // 
            this.btnProducten.Location = new System.Drawing.Point(12, 41);
            this.btnProducten.Name = "btnProducten";
            this.btnProducten.Size = new System.Drawing.Size(100, 23);
            this.btnProducten.TabIndex = 3;
            this.btnProducten.Text = "Producten";
            this.btnProducten.UseVisualStyleBackColor = true;
            this.btnProducten.Click += new System.EventHandler(this.btnProducten_Click);
            // 
            // Databeheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(129, 131);
            this.Controls.Add(this.btnProducten);
            this.Controls.Add(this.btnKlanten);
            this.Controls.Add(this.btnLeveranciers);
            this.Controls.Add(this.btnPersoneel);
            this.Name = "Databeheer";
            this.Text = "Databeheer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPersoneel;
        private System.Windows.Forms.Button btnLeveranciers;
        private System.Windows.Forms.Button btnKlanten;
        private System.Windows.Forms.Button btnProducten;
    }
}