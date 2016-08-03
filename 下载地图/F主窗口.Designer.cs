namespace 下载地图
{
    partial class F主窗口
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F主窗口));
            this.out容器 = new System.Windows.Forms.Panel();
            this.in省 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.out地图 = new GMap.NET.WindowsForms.GMapControl();
            this.in市 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.out进度 = new System.Windows.Forms.Label();
            this.do终止下载 = new System.Windows.Forms.Button();
            this.outZOOM = new System.Windows.Forms.Label();
            this.out经纬度 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.do开始下载 = new System.Windows.Forms.Button();
            this.in层级_结束 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.in层级_开始 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.in来源 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.out容器.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // out容器
            // 
            this.out容器.Controls.Add(this.in省);
            this.out容器.Controls.Add(this.label5);
            this.out容器.Controls.Add(this.label7);
            this.out容器.Controls.Add(this.out地图);
            this.out容器.Controls.Add(this.in市);
            this.out容器.Controls.Add(this.panel1);
            this.out容器.Controls.Add(this.label3);
            this.out容器.Controls.Add(this.in来源);
            this.out容器.Controls.Add(this.label1);
            this.out容器.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out容器.Location = new System.Drawing.Point(0, 0);
            this.out容器.Name = "out容器";
            this.out容器.Size = new System.Drawing.Size(922, 655);
            this.out容器.TabIndex = 0;
            // 
            // in省
            // 
            this.in省.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in省.FormattingEnabled = true;
            this.in省.Location = new System.Drawing.Point(97, 53);
            this.in省.Name = "in省";
            this.in省.Size = new System.Drawing.Size(234, 25);
            this.in省.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 17);
            this.label5.TabIndex = 38;
            this.label5.Text = "省:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(392, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(291, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "!! 暂时只开放面向谷歌地图的应用, 其他地图仅供研究";
            // 
            // out地图
            // 
            this.out地图.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out地图.Bearing = 0F;
            this.out地图.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.out地图.CanDragMap = true;
            this.out地图.EmptyTileColor = System.Drawing.Color.Navy;
            this.out地图.GrayScaleMode = false;
            this.out地图.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.out地图.LevelsKeepInMemmory = 5;
            this.out地图.Location = new System.Drawing.Point(19, 92);
            this.out地图.MarkersEnabled = true;
            this.out地图.MaxZoom = 2;
            this.out地图.MinZoom = 2;
            this.out地图.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.out地图.Name = "out地图";
            this.out地图.NegativeMode = false;
            this.out地图.PolygonsEnabled = true;
            this.out地图.RetryLoadTile = 0;
            this.out地图.RoutesEnabled = true;
            this.out地图.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.out地图.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.out地图.ShowTileGridLines = false;
            this.out地图.Size = new System.Drawing.Size(884, 439);
            this.out地图.TabIndex = 33;
            this.out地图.Zoom = 0D;
            // 
            // in市
            // 
            this.in市.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in市.FormattingEnabled = true;
            this.in市.Location = new System.Drawing.Point(435, 52);
            this.in市.Name = "in市";
            this.in市.Size = new System.Drawing.Size(234, 25);
            this.in市.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.out进度);
            this.panel1.Controls.Add(this.do终止下载);
            this.panel1.Controls.Add(this.outZOOM);
            this.panel1.Controls.Add(this.out经纬度);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.do开始下载);
            this.panel1.Controls.Add(this.in层级_结束);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.in层级_开始);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 110);
            this.panel1.TabIndex = 35;
            // 
            // out进度
            // 
            this.out进度.AutoSize = true;
            this.out进度.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.out进度.ForeColor = System.Drawing.Color.Gray;
            this.out进度.Location = new System.Drawing.Point(238, 86);
            this.out进度.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.out进度.Name = "out进度";
            this.out进度.Size = new System.Drawing.Size(26, 17);
            this.out进度.TabIndex = 30;
            this.out进度.Text = "0%";
            // 
            // do终止下载
            // 
            this.do终止下载.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.do终止下载.FlatAppearance.BorderSize = 0;
            this.do终止下载.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do终止下载.ForeColor = System.Drawing.Color.White;
            this.do终止下载.Location = new System.Drawing.Point(119, 81);
            this.do终止下载.Name = "do终止下载";
            this.do终止下载.Size = new System.Drawing.Size(100, 26);
            this.do终止下载.TabIndex = 29;
            this.do终止下载.Text = "终止下载";
            this.do终止下载.UseVisualStyleBackColor = false;
            // 
            // outZOOM
            // 
            this.outZOOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.outZOOM.AutoSize = true;
            this.outZOOM.Location = new System.Drawing.Point(341, 10);
            this.outZOOM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outZOOM.Name = "outZOOM";
            this.outZOOM.Size = new System.Drawing.Size(59, 17);
            this.outZOOM.TabIndex = 28;
            this.outZOOM.Text = "当前层级:";
            // 
            // out经纬度
            // 
            this.out经纬度.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.out经纬度.AutoSize = true;
            this.out经纬度.Location = new System.Drawing.Point(524, 10);
            this.out经纬度.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.out经纬度.Name = "out经纬度";
            this.out经纬度.Size = new System.Drawing.Size(47, 17);
            this.out经纬度.TabIndex = 27;
            this.out经纬度.Text = "经纬度:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(202, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "按住键盘\"ALT\"键, 拖动鼠标右键框选";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "选择:";
            // 
            // do开始下载
            // 
            this.do开始下载.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.do开始下载.FlatAppearance.BorderSize = 0;
            this.do开始下载.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do开始下载.ForeColor = System.Drawing.Color.White;
            this.do开始下载.Location = new System.Drawing.Point(7, 81);
            this.do开始下载.Name = "do开始下载";
            this.do开始下载.Size = new System.Drawing.Size(100, 26);
            this.do开始下载.TabIndex = 19;
            this.do开始下载.Text = "开始下载";
            this.do开始下载.UseVisualStyleBackColor = false;
            // 
            // in层级_结束
            // 
            this.in层级_结束.Location = new System.Drawing.Point(120, 43);
            this.in层级_结束.Name = "in层级_结束";
            this.in层级_结束.Size = new System.Drawing.Size(29, 23);
            this.in层级_结束.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "-";
            // 
            // in层级_开始
            // 
            this.in层级_开始.Location = new System.Drawing.Point(62, 43);
            this.in层级_开始.Name = "in层级_开始";
            this.in层级_开始.Size = new System.Drawing.Size(29, 23);
            this.in层级_开始.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "层级:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "市:";
            // 
            // in来源
            // 
            this.in来源.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in来源.FormattingEnabled = true;
            this.in来源.Location = new System.Drawing.Point(97, 12);
            this.in来源.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.in来源.Name = "in来源";
            this.in来源.Size = new System.Drawing.Size(234, 25);
            this.in来源.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "来源:";
            // 
            // F主窗口
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 655);
            this.Controls.Add(this.out容器);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F主窗口";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载地图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.out容器.ResumeLayout(false);
            this.out容器.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel out容器;
        private System.Windows.Forms.ComboBox in省;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private GMap.NET.WindowsForms.GMapControl out地图;
        private System.Windows.Forms.ComboBox in市;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label outZOOM;
        private System.Windows.Forms.Label out经纬度;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button do开始下载;
        private System.Windows.Forms.TextBox in层级_结束;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox in层级_开始;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox in来源;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label out进度;
        private System.Windows.Forms.Button do终止下载;

    }
}

