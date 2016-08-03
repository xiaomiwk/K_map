namespace 显示地图_逻辑图
{
    partial class UC窗体头
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
            this.do关闭 = new System.Windows.Forms.Button();
            this.do最大化 = new System.Windows.Forms.Button();
            this.do最小化 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // do关闭
            // 
            this.do关闭.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do关闭.FlatAppearance.BorderSize = 0;
            this.do关闭.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do关闭.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.do关闭.ForeColor = System.Drawing.Color.Silver;
            this.do关闭.Image = global::显示地图_逻辑图.Properties.Resources.关闭0;
            this.do关闭.Location = new System.Drawing.Point(353, 3);
            this.do关闭.Name = "do关闭";
            this.do关闭.Size = new System.Drawing.Size(21, 21);
            this.do关闭.TabIndex = 11;
            this.do关闭.UseVisualStyleBackColor = true;
            // 
            // do最大化
            // 
            this.do最大化.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do最大化.FlatAppearance.BorderSize = 0;
            this.do最大化.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do最大化.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.do最大化.ForeColor = System.Drawing.Color.Silver;
            this.do最大化.Image = global::显示地图_逻辑图.Properties.Resources.最大化0;
            this.do最大化.Location = new System.Drawing.Point(321, 3);
            this.do最大化.Name = "do最大化";
            this.do最大化.Size = new System.Drawing.Size(21, 21);
            this.do最大化.TabIndex = 12;
            this.do最大化.UseVisualStyleBackColor = true;
            // 
            // do最小化
            // 
            this.do最小化.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do最小化.FlatAppearance.BorderSize = 0;
            this.do最小化.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do最小化.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.do最小化.ForeColor = System.Drawing.Color.Silver;
            this.do最小化.Image = global::显示地图_逻辑图.Properties.Resources.最小化0;
            this.do最小化.Location = new System.Drawing.Point(288, 3);
            this.do最小化.Name = "do最小化";
            this.do最小化.Size = new System.Drawing.Size(21, 21);
            this.do最小化.TabIndex = 13;
            this.do最小化.UseVisualStyleBackColor = true;
            // 
            // UC窗体头
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.do最小化);
            this.Controls.Add(this.do最大化);
            this.Controls.Add(this.do关闭);
            this.Name = "UC窗体头";
            this.Size = new System.Drawing.Size(378, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button do关闭;
        private System.Windows.Forms.Button do最大化;
        private System.Windows.Forms.Button do最小化;
    }
}
