namespace MagazijnProject.Forms
{
    partial class OrderOverview
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
            this.lblObject = new System.Windows.Forms.Label();
            this.cbObject = new System.Windows.Forms.ComboBox();
            this.lbOrders = new System.Windows.Forms.ListBox();
            this.btnDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblObject
            // 
            this.lblObject.AutoSize = true;
            this.lblObject.Location = new System.Drawing.Point(12, 9);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(35, 13);
            this.lblObject.TabIndex = 0;
            this.lblObject.Text = "label1";
            // 
            // cbObject
            // 
            this.cbObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbObject.FormattingEnabled = true;
            this.cbObject.Location = new System.Drawing.Point(66, 6);
            this.cbObject.Name = "cbObject";
            this.cbObject.Size = new System.Drawing.Size(166, 21);
            this.cbObject.TabIndex = 1;
            this.cbObject.SelectedIndexChanged += new System.EventHandler(this.cbObject_SelectedIndexChanged);
            // 
            // lbOrders
            // 
            this.lbOrders.FormattingEnabled = true;
            this.lbOrders.Location = new System.Drawing.Point(12, 33);
            this.lbOrders.Name = "lbOrders";
            this.lbOrders.Size = new System.Drawing.Size(220, 173);
            this.lbOrders.TabIndex = 2;
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(12, 212);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(220, 23);
            this.btnDetails.TabIndex = 3;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // OrderOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 241);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lbOrders);
            this.Controls.Add(this.cbObject);
            this.Controls.Add(this.lblObject);
            this.Name = "OrderOverview";
            this.Text = "OrderOverview";
            this.Load += new System.EventHandler(this.OrderOverview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.ComboBox cbObject;
        private System.Windows.Forms.ListBox lbOrders;
        private System.Windows.Forms.Button btnDetails;
    }
}