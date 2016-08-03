namespace Demo
{
    partial class F跟踪
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
            this.do清除所有 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.out浏览器 = new System.Windows.Forms.WebBrowser();
            this.in显示模式 = new System.Windows.Forms.ComboBox();
            this.out以个体为中心 = new System.Windows.Forms.Panel();
            this.do设置中心号码 = new System.Windows.Forms.Button();
            this.in中心号码 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.out以个体为中心.SuspendLayout();
            this.SuspendLayout();
            // 
            // do清除所有
            // 
            this.do清除所有.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do清除所有.Location = new System.Drawing.Point(896, 19);
            this.do清除所有.Name = "do清除所有";
            this.do清除所有.Size = new System.Drawing.Size(120, 30);
            this.do清除所有.TabIndex = 16;
            this.do清除所有.Text = "清除所有";
            this.do清除所有.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "显示模式：";
            // 
            // out浏览器
            // 
            this.out浏览器.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out浏览器.Location = new System.Drawing.Point(20, 60);
            this.out浏览器.MinimumSize = new System.Drawing.Size(20, 20);
            this.out浏览器.Name = "out浏览器";
            this.out浏览器.Size = new System.Drawing.Size(996, 543);
            this.out浏览器.TabIndex = 10;
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
            this.in显示模式.TabIndex = 21;
            // 
            // out以个体为中心
            // 
            this.out以个体为中心.Controls.Add(this.do设置中心号码);
            this.out以个体为中心.Controls.Add(this.in中心号码);
            this.out以个体为中心.Controls.Add(this.label1);
            this.out以个体为中心.Location = new System.Drawing.Point(293, 10);
            this.out以个体为中心.Name = "out以个体为中心";
            this.out以个体为中心.Size = new System.Drawing.Size(400, 44);
            this.out以个体为中心.TabIndex = 22;
            // 
            // do设置中心号码
            // 
            this.do设置中心号码.Location = new System.Drawing.Point(249, 9);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "个体序号：";
            // 
            // F跟踪
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.out以个体为中心);
            this.Controls.Add(this.in显示模式);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.do清除所有);
            this.Controls.Add(this.out浏览器);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F跟踪";
            this.Size = new System.Drawing.Size(1030, 620);
            this.out以个体为中心.ResumeLayout(false);
            this.out以个体为中心.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button do清除所有;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser out浏览器;
        private System.Windows.Forms.ComboBox in显示模式;
        private System.Windows.Forms.Panel out以个体为中心;
        private System.Windows.Forms.TextBox in中心号码;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button do设置中心号码;
    }
}
