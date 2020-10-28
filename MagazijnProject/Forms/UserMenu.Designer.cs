namespace MagazijnProject.Forms
{
    partial class UserMenu
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
            this.btnManagement = new System.Windows.Forms.Button();
            this.btnShop = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnOverview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManagement
            // 
            this.btnManagement.Location = new System.Drawing.Point(12, 12);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(185, 23);
            this.btnManagement.TabIndex = 0;
            this.btnManagement.Text = "Management";
            this.btnManagement.UseVisualStyleBackColor = true;
            this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
            // 
            // btnShop
            // 
            this.btnShop.Location = new System.Drawing.Point(12, 41);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(185, 23);
            this.btnShop.TabIndex = 1;
            this.btnShop.Text = "Shop";
            this.btnShop.UseVisualStyleBackColor = true;
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Location = new System.Drawing.Point(12, 70);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(185, 23);
            this.btnWarehouse.TabIndex = 2;
            this.btnWarehouse.Text = "Warehouse";
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnOverview
            // 
            this.btnOverview.Location = new System.Drawing.Point(12, 99);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(185, 23);
            this.btnOverview.TabIndex = 3;
            this.btnOverview.Text = "Overview";
            this.btnOverview.UseVisualStyleBackColor = true;
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);
            // 
            // UserMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 130);
            this.Controls.Add(this.btnOverview);
            this.Controls.Add(this.btnWarehouse);
            this.Controls.Add(this.btnShop);
            this.Controls.Add(this.btnManagement);
            this.Name = "UserMenu";
            this.Text = "UserMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Button btnShop;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnOverview;
    }
}