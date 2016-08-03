namespace Demo
{
    partial class F轨迹回放_地图显示
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.in播放速度 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.out当前时间 = new System.Windows.Forms.Label();
            this.do播放 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.out播放进度 = new System.Windows.Forms.TrackBar();
            this.do关闭 = new System.Windows.Forms.Button();
            this.out以个体为中心 = new System.Windows.Forms.Panel();
            this.do设置中心号码 = new System.Windows.Forms.Button();
            this.in中心号码 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.in显示模式 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.out浏览器 = new System.Windows.Forms.WebBrowser();
            this.do暂停 = new System.Windows.Forms.Button();
            this.do停止 = new System.Windows.Forms.Button();
            this.in定时器 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.out播放进度)).BeginInit();
            this.out以个体为中心.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "播放速度：";
            // 
            // in播放速度
            // 
            this.in播放速度.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in播放速度.FormattingEnabled = true;
            this.in播放速度.Location = new System.Drawing.Point(390, 60);
            this.in播放速度.Name = "in播放速度";
            this.in播放速度.Size = new System.Drawing.Size(144, 28);
            this.in播放速度.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "当前时间：";
            // 
            // out当前时间
            // 
            this.out当前时间.AutoSize = true;
            this.out当前时间.Location = new System.Drawing.Point(648, 63);
            this.out当前时间.Name = "out当前时间";
            this.out当前时间.Size = new System.Drawing.Size(173, 20);
            this.out当前时间.TabIndex = 32;
            this.out当前时间.Text = "XX月XX日 XX时XX分XX秒";
            // 
            // do播放
            // 
            this.do播放.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do播放.Location = new System.Drawing.Point(897, 59);
            this.do播放.Name = "do播放";
            this.do播放.Size = new System.Drawing.Size(120, 30);
            this.do播放.TabIndex = 33;
            this.do播放.Text = "播放";
            this.do播放.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "播放进度：";
            // 
            // out播放进度
            // 
            this.out播放进度.BackColor = System.Drawing.Color.White;
            this.out播放进度.Location = new System.Drawing.Point(94, 64);
            this.out播放进度.Name = "out播放进度";
            this.out播放进度.Size = new System.Drawing.Size(189, 45);
            this.out播放进度.TabIndex = 35;
            // 
            // do关闭
            // 
            this.do关闭.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do关闭.BackColor = System.Drawing.Color.White;
            this.do关闭.FlatAppearance.BorderSize = 0;
            this.do关闭.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do关闭.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.do关闭.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.do关闭.Location = new System.Drawing.Point(990, 0);
            this.do关闭.Name = "do关闭";
            this.do关闭.Size = new System.Drawing.Size(40, 25);
            this.do关闭.TabIndex = 36;
            this.do关闭.Text = "X";
            this.do关闭.UseVisualStyleBackColor = false;
            // 
            // out以个体为中心
            // 
            this.out以个体为中心.Controls.Add(this.do设置中心号码);
            this.out以个体为中心.Controls.Add(this.in中心号码);
            this.out以个体为中心.Controls.Add(this.label5);
            this.out以个体为中心.Location = new System.Drawing.Point(293, 10);
            this.out以个体为中心.Name = "out以个体为中心";
            this.out以个体为中心.Size = new System.Drawing.Size(400, 44);
            this.out以个体为中心.TabIndex = 39;
            // 
            // do设置中心号码
            // 
            this.do设置中心号码.Location = new System.Drawing.Point(247, 9);
            this.do设置中心号码.Name = "do设置中心号码";
            this.do设置中心号码.Size = new System.Drawing.Size(120, 30);
            this.do设置中心号码.TabIndex = 26;
            this.do设置中心号码.Text = "设置";
            this.do设置中心号码.UseVisualStyleBackColor = true;
            // 
            // in中心号码
            // 
            this.in中心号码.Location = new System.Drawing.Point(97, 11);
            this.in中心号码.Name = "in中心号码";
            this.in中心号码.Size = new System.Drawing.Size(144, 26);
            this.in中心号码.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "个体序号：";
            // 
            // in显示模式
            // 
            this.in显示模式.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in显示模式.FormattingEnabled = true;
            this.in显示模式.Items.AddRange(new object[] {
            "手动",
            "以个体为中心",
            "群体"});
            this.in显示模式.Location = new System.Drawing.Point(102, 19);
            this.in显示模式.Name = "in显示模式";
            this.in显示模式.Size = new System.Drawing.Size(174, 28);
            this.in显示模式.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "显示模式：";
            // 
            // out浏览器
            // 
            this.out浏览器.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out浏览器.Location = new System.Drawing.Point(21, 106);
            this.out浏览器.MinimumSize = new System.Drawing.Size(20, 20);
            this.out浏览器.Name = "out浏览器";
            this.out浏览器.Size = new System.Drawing.Size(996, 496);
            this.out浏览器.TabIndex = 40;
            // 
            // do暂停
            // 
            this.do暂停.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do暂停.Location = new System.Drawing.Point(848, 59);
            this.do暂停.Name = "do暂停";
            this.do暂停.Size = new System.Drawing.Size(80, 30);
            this.do暂停.TabIndex = 41;
            this.do暂停.Text = "暂停";
            this.do暂停.UseVisualStyleBackColor = true;
            // 
            // do停止
            // 
            this.do停止.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do停止.Location = new System.Drawing.Point(937, 59);
            this.do停止.Name = "do停止";
            this.do停止.Size = new System.Drawing.Size(80, 30);
            this.do停止.TabIndex = 42;
            this.do停止.Text = "停止";
            this.do停止.UseVisualStyleBackColor = true;
            // 
            // F轨迹回放_地图显示
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.do播放);
            this.Controls.Add(this.do停止);
            this.Controls.Add(this.do暂停);
            this.Controls.Add(this.out浏览器);
            this.Controls.Add(this.out以个体为中心);
            this.Controls.Add(this.in显示模式);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.do关闭);
            this.Controls.Add(this.out播放进度);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.out当前时间);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.in播放速度);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F轨迹回放_地图显示";
            this.Size = new System.Drawing.Size(1030, 620);
            ((System.ComponentModel.ISupportInitialize)(this.out播放进度)).EndInit();
            this.out以个体为中心.ResumeLayout(false);
            this.out以个体为中心.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox in播放速度;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label out当前时间;
        private System.Windows.Forms.Button do播放;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar out播放进度;
        private System.Windows.Forms.Button do关闭;
        private System.Windows.Forms.Panel out以个体为中心;
        private System.Windows.Forms.Button do设置中心号码;
        private System.Windows.Forms.TextBox in中心号码;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox in显示模式;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.WebBrowser out浏览器;
        private System.Windows.Forms.Button do暂停;
        private System.Windows.Forms.Button do停止;
        private System.Windows.Forms.Timer in定时器;
    }
}
