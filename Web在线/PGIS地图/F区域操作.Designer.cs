namespace Demo
{
    partial class F区域操作
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
            this.do删除上一个区域 = new System.Windows.Forms.Button();
            this.in区域选择方法 = new System.Windows.Forms.ComboBox();
            this.do删除所有区域 = new System.Windows.Forms.Button();
            this.do查询区域内手机 = new System.Windows.Forms.Button();
            this.do呼叫区域内手机 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.out结果 = new System.Windows.Forms.TextBox();
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
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "区域选择方法：";
            // 
            // do删除上一个区域
            // 
            this.do删除上一个区域.Location = new System.Drawing.Point(504, 19);
            this.do删除上一个区域.Name = "do删除上一个区域";
            this.do删除上一个区域.Size = new System.Drawing.Size(120, 30);
            this.do删除上一个区域.TabIndex = 27;
            this.do删除上一个区域.Text = "删除上一个区域";
            this.do删除上一个区域.UseVisualStyleBackColor = true;
            // 
            // in区域选择方法
            // 
            this.in区域选择方法.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in区域选择方法.FormattingEnabled = true;
            this.in区域选择方法.Items.AddRange(new object[] {
            "不可用",
            "长方形，点击：起点（左上点） - 终点（右下点）",
            "圆形，点击：起点（直径一端） - 终点（直径另一端）",
            "圆形，点击：起点（圆心） - 终点（半径另一端）",
            "圆形，点击：点（圆心），半径1公里",
            "圆形，点击：点（圆心），半径2公里",
            "圆形，点击：点（圆心），半径3公里"});
            this.in区域选择方法.Location = new System.Drawing.Point(130, 21);
            this.in区域选择方法.Name = "in区域选择方法";
            this.in区域选择方法.Size = new System.Drawing.Size(368, 28);
            this.in区域选择方法.TabIndex = 28;
            // 
            // do删除所有区域
            // 
            this.do删除所有区域.Location = new System.Drawing.Point(630, 19);
            this.do删除所有区域.Name = "do删除所有区域";
            this.do删除所有区域.Size = new System.Drawing.Size(120, 30);
            this.do删除所有区域.TabIndex = 29;
            this.do删除所有区域.Text = "删除所有区域";
            this.do删除所有区域.UseVisualStyleBackColor = true;
            // 
            // do查询区域内手机
            // 
            this.do查询区域内手机.Location = new System.Drawing.Point(775, 19);
            this.do查询区域内手机.Name = "do查询区域内手机";
            this.do查询区域内手机.Size = new System.Drawing.Size(120, 30);
            this.do查询区域内手机.TabIndex = 33;
            this.do查询区域内手机.Text = "查询区域内手机";
            this.do查询区域内手机.UseVisualStyleBackColor = true;
            // 
            // do呼叫区域内手机
            // 
            this.do呼叫区域内手机.Location = new System.Drawing.Point(901, 19);
            this.do呼叫区域内手机.Name = "do呼叫区域内手机";
            this.do呼叫区域内手机.Size = new System.Drawing.Size(120, 30);
            this.do呼叫区域内手机.TabIndex = 35;
            this.do呼叫区域内手机.Text = "呼叫区域内手机";
            this.do呼叫区域内手机.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.label1.Location = new System.Drawing.Point(781, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "通知";
            // 
            // out结果
            // 
            this.out结果.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out结果.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out结果.Location = new System.Drawing.Point(785, 95);
            this.out结果.Multiline = true;
            this.out结果.Name = "out结果";
            this.out结果.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.out结果.Size = new System.Drawing.Size(245, 508);
            this.out结果.TabIndex = 38;
            // 
            // F区域操作
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.out结果);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.do呼叫区域内手机);
            this.Controls.Add(this.do查询区域内手机);
            this.Controls.Add(this.do删除所有区域);
            this.Controls.Add(this.in区域选择方法);
            this.Controls.Add(this.do删除上一个区域);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.out浏览器);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F区域操作";
            this.Size = new System.Drawing.Size(1030, 620);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser out浏览器;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button do删除上一个区域;
        private System.Windows.Forms.ComboBox in区域选择方法;
        private System.Windows.Forms.Button do删除所有区域;
        private System.Windows.Forms.Button do查询区域内手机;
        private System.Windows.Forms.Button do呼叫区域内手机;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox out结果;
    }
}
