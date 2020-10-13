namespace MagazijnProject.Forms
{
    partial class NieuwWachtwoord
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
            this.tbNieuwWachtwoord = new System.Windows.Forms.TextBox();
            this.btnBevestig = new System.Windows.Forms.Button();
            this.tbBevestigWachtwoord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nieuw wachtwoord:";
            // 
            // tbNieuwWachtwoord
            // 
            this.tbNieuwWachtwoord.Location = new System.Drawing.Point(119, 6);
            this.tbNieuwWachtwoord.Name = "tbNieuwWachtwoord";
            this.tbNieuwWachtwoord.Size = new System.Drawing.Size(165, 20);
            this.tbNieuwWachtwoord.TabIndex = 1;
            this.tbNieuwWachtwoord.UseSystemPasswordChar = true;
            // 
            // btnBevestig
            // 
            this.btnBevestig.Location = new System.Drawing.Point(15, 60);
            this.btnBevestig.Name = "btnBevestig";
            this.btnBevestig.Size = new System.Drawing.Size(269, 23);
            this.btnBevestig.TabIndex = 2;
            this.btnBevestig.Text = "Bevestig";
            this.btnBevestig.UseVisualStyleBackColor = true;
            this.btnBevestig.Click += new System.EventHandler(this.btnBevestig_Click);
            // 
            // tbBevestigWachtwoord
            // 
            this.tbBevestigWachtwoord.Location = new System.Drawing.Point(119, 32);
            this.tbBevestigWachtwoord.Name = "tbBevestigWachtwoord";
            this.tbBevestigWachtwoord.Size = new System.Drawing.Size(165, 20);
            this.tbBevestigWachtwoord.TabIndex = 3;
            this.tbBevestigWachtwoord.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bevestig:";
            // 
            // NieuwWachtwoord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 95);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBevestigWachtwoord);
            this.Controls.Add(this.btnBevestig);
            this.Controls.Add(this.tbNieuwWachtwoord);
            this.Controls.Add(this.label1);
            this.Name = "NieuwWachtwoord";
            this.Text = "NieuwWachtwoord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNieuwWachtwoord;
        private System.Windows.Forms.Button btnBevestig;
        private System.Windows.Forms.TextBox tbBevestigWachtwoord;
        private System.Windows.Forms.Label label2;
    }
}