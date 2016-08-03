namespace 显示地图_逻辑图
{
    partial class F逻辑图2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.out容器 = new System.Windows.Forms.Panel();
            this.uC窗体头1 = new 显示地图_逻辑图.UC窗体头();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.out容器);
            this.panel1.Controls.Add(this.uC窗体头1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 651);
            this.panel1.TabIndex = 0;
            // 
            // out容器
            // 
            this.out容器.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out容器.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.out容器.Location = new System.Drawing.Point(19, 41);
            this.out容器.Name = "out容器";
            this.out容器.Size = new System.Drawing.Size(979, 589);
            this.out容器.TabIndex = 1;
            // 
            // uC窗体头1
            // 
            this.uC窗体头1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uC窗体头1.BackColor = System.Drawing.Color.White;
            this.uC窗体头1.Location = new System.Drawing.Point(142, 3);
            this.uC窗体头1.Name = "uC窗体头1";
            this.uC窗体头1.Size = new System.Drawing.Size(875, 32);
            this.uC窗体头1.TabIndex = 0;
            this.uC窗体头1.显示最大化按钮 = true;
            this.uC窗体头1.显示最小化按钮 = true;
            // 
            // FDemo逻辑图2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1022, 653);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1050);
            this.Name = "FDemo逻辑图2";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FDemo逻辑图2";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UC窗体头 uC窗体头1;
        private System.Windows.Forms.Panel out容器;
    }
}