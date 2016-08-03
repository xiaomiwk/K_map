namespace 显示地图_逻辑图
{
    partial class F逻辑图
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F逻辑图));
            this.out地图 = new 显示地图_逻辑图.F拓扑图();
            this.do定位点 = new System.Windows.Forms.Button();
            this.do添加覆盖物 = new System.Windows.Forms.Button();
            this.do删除覆盖物 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // out地图
            // 
            this.out地图.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out地图.Location = new System.Drawing.Point(0, 0);
            this.out地图.Name = "out地图";
            this.out地图.Size = new System.Drawing.Size(1006, 615);
            this.out地图.TabIndex = 0;
            this.out地图.启用默认缩放控件 = true;
            this.out地图.当前层级 = 8;
            this.out地图.按钮文字颜色 = System.Drawing.Color.White;
            this.out地图.按钮背景颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.out地图.显示图片调试信息 = false;
            this.out地图.缩放控件位置 = new System.Drawing.Point(3, 5);
            // 
            // do定位点
            // 
            this.do定位点.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            this.do定位点.FlatAppearance.BorderSize = 0;
            this.do定位点.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do定位点.ForeColor = System.Drawing.Color.White;
            this.do定位点.Location = new System.Drawing.Point(98, 46);
            this.do定位点.Name = "do定位点";
            this.do定位点.Size = new System.Drawing.Size(100, 28);
            this.do定位点.TabIndex = 12;
            this.do定位点.Text = "定位点";
            this.do定位点.UseVisualStyleBackColor = false;
            // 
            // do添加覆盖物
            // 
            this.do添加覆盖物.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            this.do添加覆盖物.FlatAppearance.BorderSize = 0;
            this.do添加覆盖物.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do添加覆盖物.ForeColor = System.Drawing.Color.White;
            this.do添加覆盖物.Location = new System.Drawing.Point(204, 12);
            this.do添加覆盖物.Name = "do添加覆盖物";
            this.do添加覆盖物.Size = new System.Drawing.Size(100, 28);
            this.do添加覆盖物.TabIndex = 11;
            this.do添加覆盖物.Text = "添加覆盖物";
            this.do添加覆盖物.UseVisualStyleBackColor = false;
            // 
            // do删除覆盖物
            // 
            this.do删除覆盖物.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            this.do删除覆盖物.FlatAppearance.BorderSize = 0;
            this.do删除覆盖物.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do删除覆盖物.ForeColor = System.Drawing.Color.White;
            this.do删除覆盖物.Location = new System.Drawing.Point(98, 12);
            this.do删除覆盖物.Name = "do删除覆盖物";
            this.do删除覆盖物.Size = new System.Drawing.Size(100, 28);
            this.do删除覆盖物.TabIndex = 10;
            this.do删除覆盖物.Text = "删除覆盖物";
            this.do删除覆盖物.UseVisualStyleBackColor = false;
            // 
            // F逻辑图
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1006, 615);
            this.Controls.Add(this.do定位点);
            this.Controls.Add(this.do添加覆盖物);
            this.Controls.Add(this.do删除覆盖物);
            this.Controls.Add(this.out地图);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F逻辑图";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "逻辑图";
            this.ResumeLayout(false);

        }

        #endregion

        private F拓扑图 out地图;
        private System.Windows.Forms.Button do定位点;
        private System.Windows.Forms.Button do添加覆盖物;
        private System.Windows.Forms.Button do删除覆盖物;

    }
}

