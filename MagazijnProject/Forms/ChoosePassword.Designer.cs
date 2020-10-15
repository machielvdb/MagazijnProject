namespace MagazijnProject.Forms
{
    partial class ChoosePassword
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
            this.tbNew = new System.Windows.Forms.TextBox();
            this.tbConfirm = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Confirm:";
            // 
            // tbNew
            // 
            this.tbNew.Location = new System.Drawing.Point(102, 6);
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(200, 20);
            this.tbNew.TabIndex = 11;
            this.tbNew.UseSystemPasswordChar = true;
            // 
            // tbConfirm
            // 
            this.tbConfirm.Location = new System.Drawing.Point(102, 32);
            this.tbConfirm.Name = "tbConfirm";
            this.tbConfirm.Size = new System.Drawing.Size(200, 20);
            this.tbConfirm.TabIndex = 12;
            this.tbConfirm.UseSystemPasswordChar = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(15, 58);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(287, 23);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // ChoosePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 90);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tbConfirm);
            this.Controls.Add(this.tbNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChoosePassword";
            this.Text = "ChoosePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNew;
        private System.Windows.Forms.TextBox tbConfirm;
        private System.Windows.Forms.Button btnConfirm;
    }
}