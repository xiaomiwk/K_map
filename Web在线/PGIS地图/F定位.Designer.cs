namespace Demo
{
    partial class F定位
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
            this.out浏览器 = new System.Windows.Forms.WebBrowser();
            this.in显示模式 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.in显示模式.Location = new System.Drawing.Point(102, 19);
            this.in显示模式.Name = "in显示模式";
            this.in显示模式.Size = new System.Drawing.Size(174, 28);
            this.in显示模式.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "显示模式：";
            // 
            // F定位
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.in显示模式);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.do清除所有);
            this.Controls.Add(this.out浏览器);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F定位";
            this.Size = new System.Drawing.Size(1030, 620);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button do清除所有;
        private System.Windows.Forms.WebBrowser out浏览器;
        private System.Windows.Forms.ComboBox in显示模式;
        private System.Windows.Forms.Label label4;
    }
}
