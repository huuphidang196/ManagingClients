
namespace ManagingClients
{
    partial class frmUserLoginForm
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
            this.txtNameLoginAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasswordAccount = new System.Windows.Forms.TextBox();
            this.btnLoginAccount = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreatNewAccount = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập :";
            // 
            // txtNameLoginAccount
            // 
            this.txtNameLoginAccount.Location = new System.Drawing.Point(123, 76);
            this.txtNameLoginAccount.Name = "txtNameLoginAccount";
            this.txtNameLoginAccount.Size = new System.Drawing.Size(282, 26);
            this.txtNameLoginAccount.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu :";
            // 
            // txtPasswordAccount
            // 
            this.txtPasswordAccount.Location = new System.Drawing.Point(123, 122);
            this.txtPasswordAccount.Name = "txtPasswordAccount";
            this.txtPasswordAccount.Size = new System.Drawing.Size(282, 26);
            this.txtPasswordAccount.TabIndex = 1;
            // 
            // btnLoginAccount
            // 
            this.btnLoginAccount.BackColor = System.Drawing.Color.LawnGreen;
            this.btnLoginAccount.Location = new System.Drawing.Point(139, 177);
            this.btnLoginAccount.Name = "btnLoginAccount";
            this.btnLoginAccount.Size = new System.Drawing.Size(109, 31);
            this.btnLoginAccount.TabIndex = 2;
            this.btnLoginAccount.Text = "Đăng Nhập";
            this.btnLoginAccount.UseVisualStyleBackColor = false;
            this.btnLoginAccount.Click += new System.EventHandler(this.btnLoginAccount_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCreatNewAccount);
            this.panel1.Controls.Add(this.btnLoginAccount);
            this.panel1.Controls.Add(this.txtPasswordAccount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNameLoginAccount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 268);
            this.panel1.TabIndex = 3;
            // 
            // btnCreatNewAccount
            // 
            this.btnCreatNewAccount.BackColor = System.Drawing.Color.Orange;
            this.btnCreatNewAccount.Location = new System.Drawing.Point(278, 177);
            this.btnCreatNewAccount.Name = "btnCreatNewAccount";
            this.btnCreatNewAccount.Size = new System.Drawing.Size(109, 31);
            this.btnCreatNewAccount.TabIndex = 3;
            this.btnCreatNewAccount.Text = "Tạo tài khoản";
            this.btnCreatNewAccount.UseVisualStyleBackColor = false;
            // 
            // frmUserLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(509, 268);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.frmUserLoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameLoginAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPasswordAccount;
        private System.Windows.Forms.Button btnLoginAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreatNewAccount;
    }
}