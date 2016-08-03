namespace 显示地图
{
    partial class FDemo切换
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
            this.do切换 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // do切换
            // 
            this.do切换.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do切换.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do切换.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.do切换.ForeColor = System.Drawing.Color.White;
            this.do切换.Location = new System.Drawing.Point(0, 0);
            this.do切换.Margin = new System.Windows.Forms.Padding(0);
            this.do切换.Name = "do切换";
            this.do切换.Size = new System.Drawing.Size(35, 25);
            this.do切换.TabIndex = 33;
            this.do切换.Text = ">";
            this.do切换.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.do切换.UseVisualStyleBackColor = false;
            // 
            // FDemo切换
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.do切换);
            this.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.Name = "FDemo切换";
            this.Size = new System.Drawing.Size(35, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button do切换;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
