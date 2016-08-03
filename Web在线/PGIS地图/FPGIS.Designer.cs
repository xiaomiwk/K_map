namespace Demo
{
    partial class FPGIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPGIS));
            this.out功能容器 = new System.Windows.Forms.TabControl();
            this.out区域操作 = new System.Windows.Forms.TabPage();
            this.out轨迹回放 = new System.Windows.Forms.TabPage();
            this.out跟踪 = new System.Windows.Forms.TabPage();
            this.out定位 = new System.Windows.Forms.TabPage();
            this.out地址查询 = new System.Windows.Forms.TabPage();
            this.out用户列表 = new System.Windows.Forms.ListBox();
            this.out功能容器.SuspendLayout();
            this.SuspendLayout();
            // 
            // out功能容器
            // 
            this.out功能容器.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out功能容器.Controls.Add(this.out地址查询);
            this.out功能容器.Controls.Add(this.out区域操作);
            this.out功能容器.Controls.Add(this.out轨迹回放);
            this.out功能容器.Controls.Add(this.out跟踪);
            this.out功能容器.Controls.Add(this.out定位);
            this.out功能容器.Location = new System.Drawing.Point(210, 19);
            this.out功能容器.Name = "out功能容器";
            this.out功能容器.SelectedIndex = 0;
            this.out功能容器.Size = new System.Drawing.Size(1042, 676);
            this.out功能容器.TabIndex = 0;
            // 
            // out区域操作
            // 
            this.out区域操作.Location = new System.Drawing.Point(4, 29);
            this.out区域操作.Name = "out区域操作";
            this.out区域操作.Padding = new System.Windows.Forms.Padding(3);
            this.out区域操作.Size = new System.Drawing.Size(1034, 643);
            this.out区域操作.TabIndex = 4;
            this.out区域操作.Text = "    区域操作    ";
            this.out区域操作.UseVisualStyleBackColor = true;
            // 
            // out轨迹回放
            // 
            this.out轨迹回放.Location = new System.Drawing.Point(4, 29);
            this.out轨迹回放.Name = "out轨迹回放";
            this.out轨迹回放.Padding = new System.Windows.Forms.Padding(3);
            this.out轨迹回放.Size = new System.Drawing.Size(1034, 643);
            this.out轨迹回放.TabIndex = 2;
            this.out轨迹回放.Text = "  轨迹回放  ";
            this.out轨迹回放.UseVisualStyleBackColor = true;
            // 
            // out跟踪
            // 
            this.out跟踪.Location = new System.Drawing.Point(4, 29);
            this.out跟踪.Name = "out跟踪";
            this.out跟踪.Padding = new System.Windows.Forms.Padding(3);
            this.out跟踪.Size = new System.Drawing.Size(1034, 643);
            this.out跟踪.TabIndex = 1;
            this.out跟踪.Text = "  跟踪  ";
            this.out跟踪.UseVisualStyleBackColor = true;
            // 
            // out定位
            // 
            this.out定位.Location = new System.Drawing.Point(4, 29);
            this.out定位.Name = "out定位";
            this.out定位.Padding = new System.Windows.Forms.Padding(3);
            this.out定位.Size = new System.Drawing.Size(1034, 643);
            this.out定位.TabIndex = 0;
            this.out定位.Text = "  定位  ";
            this.out定位.UseVisualStyleBackColor = true;
            // 
            // out地址查询
            // 
            this.out地址查询.Location = new System.Drawing.Point(4, 29);
            this.out地址查询.Name = "out地址查询";
            this.out地址查询.Padding = new System.Windows.Forms.Padding(3);
            this.out地址查询.Size = new System.Drawing.Size(1034, 643);
            this.out地址查询.TabIndex = 3;
            this.out地址查询.Text = "    地址查询    ";
            this.out地址查询.UseVisualStyleBackColor = true;
            // 
            // out用户列表
            // 
            this.out用户列表.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.out用户列表.FormattingEnabled = true;
            this.out用户列表.IntegralHeight = false;
            this.out用户列表.ItemHeight = 20;
            this.out用户列表.Items.AddRange(new object[] {
            "虚空",
            "龙鹰",
            "小黑",
            "卡尔"});
            this.out用户列表.Location = new System.Drawing.Point(13, 19);
            this.out用户列表.Name = "out用户列表";
            this.out用户列表.Size = new System.Drawing.Size(191, 675);
            this.out用户列表.TabIndex = 1;
            // 
            // FPGIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 702);
            this.Controls.Add(this.out用户列表);
            this.Controls.Add(this.out功能容器);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FPGIS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIS客户端 - PGIS地图Demo";
            this.out功能容器.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl out功能容器;
        private System.Windows.Forms.TabPage out定位;
        private System.Windows.Forms.TabPage out跟踪;
        private System.Windows.Forms.TabPage out轨迹回放;
        private System.Windows.Forms.ListBox out用户列表;
        private System.Windows.Forms.TabPage out地址查询;
        private System.Windows.Forms.TabPage out区域操作;
    }
}

