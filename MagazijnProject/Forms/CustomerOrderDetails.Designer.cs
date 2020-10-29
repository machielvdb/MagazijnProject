namespace MagazijnProject.Forms
{
    partial class CustomerOrderDetails
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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.tbOrderID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDateCreated = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEmployee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbProducts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(13, 13);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer:";
            // 
            // tbCustomer
            // 
            this.tbCustomer.Enabled = false;
            this.tbCustomer.Location = new System.Drawing.Point(93, 10);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.Size = new System.Drawing.Size(151, 20);
            this.tbCustomer.TabIndex = 1;
            // 
            // tbOrderID
            // 
            this.tbOrderID.Enabled = false;
            this.tbOrderID.Location = new System.Drawing.Point(93, 36);
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.Size = new System.Drawing.Size(151, 20);
            this.tbOrderID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "OrderID:";
            // 
            // tbDateCreated
            // 
            this.tbDateCreated.Enabled = false;
            this.tbDateCreated.Location = new System.Drawing.Point(93, 88);
            this.tbDateCreated.Name = "tbDateCreated";
            this.tbDateCreated.Size = new System.Drawing.Size(151, 20);
            this.tbDateCreated.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Date created:";
            // 
            // tbEmployee
            // 
            this.tbEmployee.Enabled = false;
            this.tbEmployee.Location = new System.Drawing.Point(93, 62);
            this.tbEmployee.Name = "tbEmployee";
            this.tbEmployee.Size = new System.Drawing.Size(151, 20);
            this.tbEmployee.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Employee:";
            // 
            // lbProducts
            // 
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.Location = new System.Drawing.Point(16, 114);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(228, 238);
            this.lbProducts.TabIndex = 8;
            // 
            // CustomerOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 367);
            this.Controls.Add(this.lbProducts);
            this.Controls.Add(this.tbDateCreated);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbOrderID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Name = "CustomerOrderDetails";
            this.Text = "OrderDetails";
            this.Load += new System.EventHandler(this.CustomerOrderDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox tbCustomer;
        private System.Windows.Forms.TextBox tbOrderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDateCreated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbProducts;
    }
}