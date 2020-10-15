namespace MagazijnProject.Forms
{
    partial class ObjectManagementOverview
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
            this.lbObjects = new System.Windows.Forms.ListBox();
            this.Details = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbObjects
            // 
            this.lbObjects.FormattingEnabled = true;
            this.lbObjects.Location = new System.Drawing.Point(13, 13);
            this.lbObjects.Name = "lbObjects";
            this.lbObjects.Size = new System.Drawing.Size(213, 173);
            this.lbObjects.TabIndex = 0;
            // 
            // Details
            // 
            this.Details.Location = new System.Drawing.Point(232, 49);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(185, 30);
            this.Details.TabIndex = 11;
            this.Details.Text = "Details";
            this.Details.UseVisualStyleBackColor = true;
            this.Details.Click += new System.EventHandler(this.Details_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(232, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(185, 30);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // ObjectManagementOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 196);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.Details);
            this.Controls.Add(this.lbObjects);
            this.Name = "ObjectManagementOverview";
            this.Text = "ObjectManagementOverview";
            this.Load += new System.EventHandler(this.ObjectManagementOverview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbObjects;
        private System.Windows.Forms.Button Details;
        private System.Windows.Forms.Button btnNew;
    }
}