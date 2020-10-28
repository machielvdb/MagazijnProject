namespace MagazijnProject.Forms
{
    partial class WarehouseMenu
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
            this.btnStock = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnSupplierOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(12, 12);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(185, 23);
            this.btnStock.TabIndex = 11;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Location = new System.Drawing.Point(12, 41);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(185, 23);
            this.btnSuppliers.TabIndex = 12;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.UseVisualStyleBackColor = true;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnSupplierOrders
            // 
            this.btnSupplierOrders.Location = new System.Drawing.Point(12, 70);
            this.btnSupplierOrders.Name = "btnSupplierOrders";
            this.btnSupplierOrders.Size = new System.Drawing.Size(185, 23);
            this.btnSupplierOrders.TabIndex = 13;
            this.btnSupplierOrders.Text = "Supplier Orders";
            this.btnSupplierOrders.UseVisualStyleBackColor = true;
            this.btnSupplierOrders.Click += new System.EventHandler(this.btnSupplierOrders_Click);
            // 
            // WarehouseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 102);
            this.Controls.Add(this.btnSupplierOrders);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnSuppliers);
            this.Name = "WarehouseMenu";
            this.Text = "WarehouseMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnSupplierOrders;
    }
}