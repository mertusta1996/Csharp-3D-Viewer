namespace Csharp3DViewer.View
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TrackBar tbSensitivity;
        private System.Windows.Forms.Label lblSens;
        private System.Windows.Forms.Button Load_Model_Button;
        private System.Windows.Forms.Button Load_Texture_Button;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Panel pnlLoading;
        private System.Windows.Forms.ProgressBar pbLoading;
        private System.Windows.Forms.Label lblLoadingStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbSensitivity = new System.Windows.Forms.TrackBar();
            this.lblSens = new System.Windows.Forms.Label();
            this.Load_Model_Button = new System.Windows.Forms.Button();
            this.Load_Texture_Button = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.glControl1 = new OpenTK.GLControl();
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.lblLoadingStatus = new System.Windows.Forms.Label();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbSensitivity)).BeginInit();
            this.topPanel.SuspendLayout();
            this.pnlLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSensitivity
            // 
            this.tbSensitivity.Location = new System.Drawing.Point(494, 17);
            this.tbSensitivity.Maximum = 100;
            this.tbSensitivity.Minimum = 1;
            this.tbSensitivity.Name = "tbSensitivity";
            this.tbSensitivity.Size = new System.Drawing.Size(150, 56);
            this.tbSensitivity.TabIndex = 0;
            this.tbSensitivity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSensitivity.Value = 1;
            // 
            // lblSens
            // 
            this.lblSens.ForeColor = System.Drawing.Color.White;
            this.lblSens.Location = new System.Drawing.Point(328, 17);
            this.lblSens.Name = "lblSens";
            this.lblSens.Size = new System.Drawing.Size(170, 23);
            this.lblSens.TabIndex = 1;
            this.lblSens.Text = "Zoom/Pan Sensitivity :";
            // 
            // Load_Model_Button
            // 
            this.Load_Model_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Load_Model_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Load_Model_Button.FlatAppearance.BorderSize = 0;
            this.Load_Model_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load_Model_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load_Model_Button.ForeColor = System.Drawing.Color.White;
            this.Load_Model_Button.Location = new System.Drawing.Point(650, 15);
            this.Load_Model_Button.Name = "Load_Model_Button";
            this.Load_Model_Button.Size = new System.Drawing.Size(110, 30);
            this.Load_Model_Button.TabIndex = 2;
            this.Load_Model_Button.Text = "Load Model";
            this.Load_Model_Button.UseVisualStyleBackColor = false;
            this.Load_Model_Button.Click += new System.EventHandler(this.Load_Model_Button_Click);
            // 
            // Load_Texture_Button
            // 
            this.Load_Texture_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Load_Texture_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Load_Texture_Button.FlatAppearance.BorderSize = 0;
            this.Load_Texture_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load_Texture_Button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Load_Texture_Button.ForeColor = System.Drawing.Color.White;
            this.Load_Texture_Button.Location = new System.Drawing.Point(770, 15);
            this.Load_Texture_Button.Name = "Load_Texture_Button";
            this.Load_Texture_Button.Size = new System.Drawing.Size(110, 30);
            this.Load_Texture_Button.TabIndex = 3;
            this.Load_Texture_Button.Text = "Load Texture";
            this.Load_Texture_Button.UseVisualStyleBackColor = false;
            this.Load_Texture_Button.Click += new System.EventHandler(this.Load_Texture_Button_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.topPanel.Controls.Add(this.tbSensitivity);
            this.topPanel.Controls.Add(this.lblSens);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.Load_Model_Button);
            this.topPanel.Controls.Add(this.Load_Texture_Button);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 60);
            this.topPanel.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblTitle.Location = new System.Drawing.Point(18, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Csharp 3D Viewer";
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(0, 60);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(900, 540);
            this.glControl1.TabIndex = 1;
            this.glControl1.VSync = true;
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.GlControl1_Paint);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GlControl1_MouseDown);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GlControl1_MouseMove);
            this.glControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.GlControl1_MouseWheel);
            this.glControl1.Resize += new System.EventHandler(this.GlControl1_Resize);
            // 
            // pnlLoading
            // 
            this.pnlLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoading.Controls.Add(this.lblLoadingStatus);
            this.pnlLoading.Controls.Add(this.pbLoading);
            this.pnlLoading.Location = new System.Drawing.Point(300, 250);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(300, 100);
            this.pnlLoading.TabIndex = 0;
            this.pnlLoading.Visible = false;
            // 
            // lblLoadingStatus
            // 
            this.lblLoadingStatus.AutoSize = true;
            this.lblLoadingStatus.ForeColor = System.Drawing.Color.White;
            this.lblLoadingStatus.Location = new System.Drawing.Point(22, 20);
            this.lblLoadingStatus.Name = "lblLoadingStatus";
            this.lblLoadingStatus.Size = new System.Drawing.Size(119, 20);
            this.lblLoadingStatus.TabIndex = 0;
            this.lblLoadingStatus.Text = "Loading Model...";
            // 
            // pbLoading
            // 
            this.pbLoading.Location = new System.Drawing.Point(25, 50);
            this.pbLoading.MarqueeAnimationSpeed = 30;
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(250, 20);
            this.pbLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbLoading.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Csharp 3D Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.tbSensitivity)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.pnlLoading.ResumeLayout(false);
            this.pnlLoading.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}