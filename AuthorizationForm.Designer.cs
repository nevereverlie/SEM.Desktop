namespace SEM.Desktop
{
    partial class AuthorizationForm
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
            this.loginBtn = new System.Windows.Forms.Button();
            this.loginLb = new System.Windows.Forms.Label();
            this.loginTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.errorLb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginBtn.Location = new System.Drawing.Point(130, 219);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(100, 46);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.Text = "Sign In";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // loginLb
            // 
            this.loginLb.AutoSize = true;
            this.loginLb.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginLb.Location = new System.Drawing.Point(12, 43);
            this.loginLb.Name = "loginLb";
            this.loginLb.Size = new System.Drawing.Size(63, 25);
            this.loginLb.TabIndex = 1;
            this.loginLb.Text = "Login:";
            // 
            // loginTb
            // 
            this.loginTb.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginTb.Location = new System.Drawing.Point(120, 40);
            this.loginTb.Name = "loginTb";
            this.loginTb.Size = new System.Drawing.Size(229, 32);
            this.loginTb.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password:";
            // 
            // passwordTb
            // 
            this.passwordTb.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTb.Location = new System.Drawing.Point(120, 137);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.PasswordChar = '*';
            this.passwordTb.Size = new System.Drawing.Size(229, 32);
            this.passwordTb.TabIndex = 4;
            // 
            // errorLb
            // 
            this.errorLb.AutoSize = true;
            this.errorLb.ForeColor = System.Drawing.Color.Red;
            this.errorLb.Location = new System.Drawing.Point(12, 188);
            this.errorLb.Name = "errorLb";
            this.errorLb.Size = new System.Drawing.Size(97, 15);
            this.errorLb.TabIndex = 5;
            this.errorLb.Text = "Sample error text";
            this.errorLb.Visible = false;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 296);
            this.Controls.Add(this.errorLb);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginTb);
            this.Controls.Add(this.loginLb);
            this.Controls.Add(this.loginBtn);
            this.Name = "AuthorizationForm";
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button loginBtn;
        private Label loginLb;
        private TextBox loginTb;
        private Label label1;
        private TextBox passwordTb;
        private Label errorLb;
    }
}