namespace Demo
{
    partial class F地址查询
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
            this.out浏览器 = new System.Windows.Forms.WebBrowser();
            this.label4 = new System.Windows.Forms.Label();
            this.in关键词 = new System.Windows.Forms.TextBox();
            this.do查询 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.out结果 = new System.Windows.Forms.TextBox();
            this.out返回页数 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // out浏览器
            // 
            this.out浏览器.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out浏览器.Location = new System.Drawing.Point(20, 60);
            this.out浏览器.MinimumSize = new System.Drawing.Size(20, 20);
            this.out浏览器.Name = "out浏览器";
            this.out浏览器.Size = new System.Drawing.Size(755, 543);
            this.out浏览器.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "关键词：";
            // 
            // in关键词
            // 
            this.in关键词.Location = new System.Drawing.Point(88, 21);
            this.in关键词.Name = "in关键词";
            this.in关键词.Size = new System.Drawing.Size(359, 26);
            this.in关键词.TabIndex = 25;
            // 
            // do查询
            // 
            this.do查询.Location = new System.Drawing.Point(453, 19);
            this.do查询.Name = "do查询";
            this.do查询.Size = new System.Drawing.Size(120, 30);
            this.do查询.TabIndex = 27;
            this.do查询.Text = "查询";
            this.do查询.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.label1.Location = new System.Drawing.Point(777, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 28;
            this.label1.Text = "查询结果";
            // 
            // out结果
            // 
            this.out结果.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out结果.Location = new System.Drawing.Point(782, 95);
            this.out结果.Multiline = true;
            this.out结果.Name = "out结果";
            this.out结果.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.out结果.Size = new System.Drawing.Size(245, 508);
            this.out结果.TabIndex = 29;
            // 
            // out返回页数
            // 
            this.out返回页数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.out返回页数.AutoSize = true;
            this.out返回页数.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.out返回页数.Location = new System.Drawing.Point(857, 60);
            this.out返回页数.Name = "out返回页数";
            this.out返回页数.Size = new System.Drawing.Size(147, 19);
            this.out返回页数.TabIndex = 30;
            this.out返回页数.Text = "共5页，当前仅显示一页";
            // 
            // F地址查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.out返回页数);
            this.Controls.Add(this.out结果);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.do查询);
            this.Controls.Add(this.in关键词);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.out浏览器);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F地址查询";
            this.Size = new System.Drawing.Size(1030, 620);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser out浏览器;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox in关键词;
        private System.Windows.Forms.Button do查询;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox out结果;
        private System.Windows.Forms.Label out返回页数;
    }
}
