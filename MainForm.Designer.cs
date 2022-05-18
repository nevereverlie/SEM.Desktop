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
            this.runBtn.Location = new System.Drawing.Point(524, 40);
            this.runBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(120, 44);
            this.runBtn.TabIndex = 0;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // deviceCb
            // 
            this.deviceCb.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceCb.FormattingEnabled = true;
            this.deviceCb.Location = new System.Drawing.Point(179, 44);
            this.deviceCb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deviceCb.Name = "deviceCb";
            this.deviceCb.Size = new System.Drawing.Size(302, 39);
            this.deviceCb.TabIndex = 1;
            // 
            // deviceLb
            // 
            this.deviceLb.AutoSize = true;
            this.deviceLb.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceLb.Location = new System.Drawing.Point(70, 44);
            this.deviceLb.Name = "deviceLb";
            this.deviceLb.Size = new System.Drawing.Size(91, 32);
            this.deviceLb.TabIndex = 2;
            this.deviceLb.Text = "Device:";
            // 
            // cameraPb
            // 
            this.cameraPb.Location = new System.Drawing.Point(14, 137);
            this.cameraPb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cameraPb.Name = "cameraPb";
            this.cameraPb.Size = new System.Drawing.Size(719, 447);
            this.cameraPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraPb.TabIndex = 3;
            this.cameraPb.TabStop = false;
            // 
            // allowedAppsTb
            // 
            this.allowedAppsTb.Location = new System.Drawing.Point(760, 40);
            this.allowedAppsTb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.allowedAppsTb.Multiline = true;
            this.allowedAppsTb.Name = "allowedAppsTb";
            this.allowedAppsTb.ReadOnly = true;
            this.allowedAppsTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.allowedAppsTb.Size = new System.Drawing.Size(273, 197);
            this.allowedAppsTb.TabIndex = 4;
            this.allowedAppsTb.Text = "Allowed apps:";
            // 
            // logsTb
            // 
            this.logsTb.Location = new System.Drawing.Point(760, 245);
            this.logsTb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logsTb.Multiline = true;
            this.logsTb.Name = "logsTb";
            this.logsTb.ReadOnly = true;
            this.logsTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logsTb.Size = new System.Drawing.Size(273, 336);
            this.logsTb.TabIndex = 5;
            this.logsTb.Text = "Logs:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 601);
            this.Controls.Add(this.logsTb);
            this.Controls.Add(this.allowedAppsTb);
            this.Controls.Add(this.cameraPb);
            this.Controls.Add(this.deviceLb);
            this.Controls.Add(this.deviceCb);
            this.Controls.Add(this.runBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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