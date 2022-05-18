namespace SEM.Desktop
{
    partial class MainForm
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
            this.runBtn = new System.Windows.Forms.Button();
            this.deviceCb = new System.Windows.Forms.ComboBox();
            this.deviceLb = new System.Windows.Forms.Label();
            this.cameraPb = new System.Windows.Forms.PictureBox();
            this.allowedAppsTb = new System.Windows.Forms.TextBox();
            this.logsTb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPb)).BeginInit();
            this.SuspendLayout();
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.runBtn.Location = new System.Drawing.Point(438, 30);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(105, 33);
            this.runBtn.TabIndex = 0;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // deviceCb
            // 
            this.deviceCb.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceCb.FormattingEnabled = true;
            this.deviceCb.Location = new System.Drawing.Point(136, 30);
            this.deviceCb.Name = "deviceCb";
            this.deviceCb.Size = new System.Drawing.Size(265, 33);
            this.deviceCb.TabIndex = 1;
            // 
            // deviceLb
            // 
            this.deviceLb.AutoSize = true;
            this.deviceLb.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceLb.Location = new System.Drawing.Point(42, 33);
            this.deviceLb.Name = "deviceLb";
            this.deviceLb.Size = new System.Drawing.Size(72, 25);
            this.deviceLb.TabIndex = 2;
            this.deviceLb.Text = "Device:";
            // 
            // cameraPb
            // 
            this.cameraPb.Location = new System.Drawing.Point(12, 103);
            this.cameraPb.Name = "cameraPb";
            this.cameraPb.Size = new System.Drawing.Size(531, 335);
            this.cameraPb.TabIndex = 3;
            this.cameraPb.TabStop = false;
            // 
            // allowedAppsTb
            // 
            this.allowedAppsTb.Enabled = false;
            this.allowedAppsTb.Location = new System.Drawing.Point(549, 30);
            this.allowedAppsTb.Multiline = true;
            this.allowedAppsTb.Name = "allowedAppsTb";
            this.allowedAppsTb.Size = new System.Drawing.Size(239, 149);
            this.allowedAppsTb.TabIndex = 4;
            this.allowedAppsTb.Text = "Allowed apps:";
            // 
            // logsTb
            // 
            this.logsTb.Enabled = false;
            this.logsTb.Location = new System.Drawing.Point(549, 185);
            this.logsTb.Multiline = true;
            this.logsTb.Name = "logsTb";
            this.logsTb.Size = new System.Drawing.Size(239, 253);
            this.logsTb.TabIndex = 5;
            this.logsTb.Text = "Logs:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logsTb);
            this.Controls.Add(this.allowedAppsTb);
            this.Controls.Add(this.cameraPb);
            this.Controls.Add(this.deviceLb);
            this.Controls.Add(this.deviceCb);
            this.Controls.Add(this.runBtn);
            this.Name = "MainForm";
            this.Text = "SEM Keeper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cameraPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button runBtn;
        private ComboBox deviceCb;
        private Label deviceLb;
        private PictureBox cameraPb;
        private TextBox allowedAppsTb;
        private TextBox logsTb;
    }
}