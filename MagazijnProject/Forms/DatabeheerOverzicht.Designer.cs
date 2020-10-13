namespace MagazijnProject.Forms
{
    partial class DatabeheerOverzicht
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
            this.btnVerwijder = new System.Windows.Forms.Button();
            this.btnWijzig = new System.Windows.Forms.Button();
            this.btnNieuw = new System.Windows.Forms.Button();
            this.lbObjecten = new System.Windows.Forms.ListBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnVerwijder
            // 
            this.btnVerwijder.Location = new System.Drawing.Point(246, 70);
            this.btnVerwijder.Name = "btnVerwijder";
            this.btnVerwijder.Size = new System.Drawing.Size(120, 23);
            this.btnVerwijder.TabIndex = 13;
            this.btnVerwijder.Text = "Verwijder";
            this.btnVerwijder.UseVisualStyleBackColor = true;
            // 
            // btnWijzig
            // 
            this.btnWijzig.Location = new System.Drawing.Point(246, 41);
            this.btnWijzig.Name = "btnWijzig";
            this.btnWijzig.Size = new System.Drawing.Size(120, 23);
            this.btnWijzig.TabIndex = 12;
            this.btnWijzig.Text = "Wijzig";
            this.btnWijzig.UseVisualStyleBackColor = true;
            // 
            // btnNieuw
            // 
            this.btnNieuw.Location = new System.Drawing.Point(246, 12);
            this.btnNieuw.Name = "btnNieuw";
            this.btnNieuw.Size = new System.Drawing.Size(120, 23);
            this.btnNieuw.TabIndex = 11;
            this.btnNieuw.Text = "Nieuw";
            this.btnNieuw.UseVisualStyleBackColor = true;
            this.btnNieuw.Click += new System.EventHandler(this.btnNieuw_Click);
            // 
            // lbObjecten
            // 
            this.lbObjecten.FormattingEnabled = true;
            this.lbObjecten.Location = new System.Drawing.Point(12, 12);
            this.lbObjecten.Name = "lbObjecten";
            this.lbObjecten.Size = new System.Drawing.Size(228, 160);
            this.lbObjecten.TabIndex = 10;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(246, 119);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(120, 23);
            this.btnFilter.TabIndex = 15;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(246, 98);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(120, 20);
            this.tbFilter.TabIndex = 14;
            // 
            // DatabeheerOverzicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 177);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.btnVerwijder);
            this.Controls.Add(this.btnWijzig);
            this.Controls.Add(this.btnNieuw);
            this.Controls.Add(this.lbObjecten);
            this.Name = "DatabeheerOverzicht";
            this.Text = "DatabeheerOverzicht";
            this.Load += new System.EventHandler(this.DatabeheerOverzicht_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerwijder;
        private System.Windows.Forms.Button btnWijzig;
        private System.Windows.Forms.Button btnNieuw;
        private System.Windows.Forms.ListBox lbObjecten;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox tbFilter;
    }
}