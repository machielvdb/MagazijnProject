namespace MagazijnProject.Forms
{
    partial class GebruikerMenu
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
            this.btnDatabeheer = new System.Windows.Forms.Button();
            this.btnOverzicht = new System.Windows.Forms.Button();
            this.Bestellingen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDatabeheer
            // 
            this.btnDatabeheer.Location = new System.Drawing.Point(12, 12);
            this.btnDatabeheer.Name = "btnDatabeheer";
            this.btnDatabeheer.Size = new System.Drawing.Size(171, 23);
            this.btnDatabeheer.TabIndex = 0;
            this.btnDatabeheer.Text = "Databeheer";
            this.btnDatabeheer.UseVisualStyleBackColor = true;
            this.btnDatabeheer.Click += new System.EventHandler(this.btnDatabeheer_Click);
            // 
            // btnOverzicht
            // 
            this.btnOverzicht.Location = new System.Drawing.Point(12, 41);
            this.btnOverzicht.Name = "btnOverzicht";
            this.btnOverzicht.Size = new System.Drawing.Size(171, 23);
            this.btnOverzicht.TabIndex = 1;
            this.btnOverzicht.Text = "Overzicht";
            this.btnOverzicht.UseVisualStyleBackColor = true;
            // 
            // Bestellingen
            // 
            this.Bestellingen.Location = new System.Drawing.Point(12, 70);
            this.Bestellingen.Name = "Bestellingen";
            this.Bestellingen.Size = new System.Drawing.Size(171, 23);
            this.Bestellingen.TabIndex = 2;
            this.Bestellingen.Text = "Bestelling";
            this.Bestellingen.UseVisualStyleBackColor = true;
            // 
            // GebruikerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 105);
            this.Controls.Add(this.Bestellingen);
            this.Controls.Add(this.btnOverzicht);
            this.Controls.Add(this.btnDatabeheer);
            this.Name = "GebruikerMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDatabeheer;
        private System.Windows.Forms.Button btnOverzicht;
        private System.Windows.Forms.Button Bestellingen;
    }
}