namespace 显示地图
{
    partial class FDemo缩放
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
            this.do放大 = new System.Windows.Forms.Button();
            this.out进度条 = new System.Windows.Forms.TrackBar();
            this.do缩小 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.out进度条)).BeginInit();
            this.SuspendLayout();
            // 
            // do放大
            // 
            this.do放大.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do放大.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do放大.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.do放大.ForeColor = System.Drawing.Color.White;
            this.do放大.Location = new System.Drawing.Point(0, 0);
            this.do放大.Margin = new System.Windows.Forms.Padding(0);
            this.do放大.Name = "do放大";
            this.do放大.Size = new System.Drawing.Size(36, 25);
            this.do放大.TabIndex = 30;
            this.do放大.Text = "+";
            this.do放大.UseVisualStyleBackColor = false;
            // 
            // out进度条
            // 
            this.out进度条.Location = new System.Drawing.Point(3, 25);
            this.out进度条.Margin = new System.Windows.Forms.Padding(0);
            this.out进度条.Name = "out进度条";
            this.out进度条.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.out进度条.Size = new System.Drawing.Size(45, 111);
            this.out进度条.TabIndex = 32;
            // 
            // do缩小
            // 
            this.do缩小.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do缩小.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do缩小.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.do缩小.ForeColor = System.Drawing.Color.White;
            this.do缩小.Location = new System.Drawing.Point(0, 136);
            this.do缩小.Margin = new System.Windows.Forms.Padding(0);
            this.do缩小.Name = "do缩小";
            this.do缩小.Size = new System.Drawing.Size(36, 25);
            this.do缩小.TabIndex = 31;
            this.do缩小.Text = "-";
            this.do缩小.UseVisualStyleBackColor = false;
            // 
            // FDemo缩放
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.do放大);
            this.Controls.Add(this.out进度条);
            this.Controls.Add(this.do缩小);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FDemo缩放";
            this.Size = new System.Drawing.Size(36, 161);
            ((System.ComponentModel.ISupportInitialize)(this.out进度条)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button do放大;
        private System.Windows.Forms.TrackBar out进度条;
        private System.Windows.Forms.Button do缩小;
    }
}
