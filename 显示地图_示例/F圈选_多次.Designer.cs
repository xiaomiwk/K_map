namespace 显示地图_示例
{
    partial class F圈选_多次
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.do多边形 = new System.Windows.Forms.Button();
            this.do关闭 = new System.Windows.Forms.Button();
            this.do圆形 = new System.Windows.Forms.Button();
            this.do矩形 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.do保存 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.do取消 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.do取消);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.do保存);
            this.panel1.Controls.Add(this.do多边形);
            this.panel1.Controls.Add(this.do关闭);
            this.panel1.Controls.Add(this.do圆形);
            this.panel1.Controls.Add(this.do矩形);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 48);
            this.panel1.TabIndex = 0;
            // 
            // do多边形
            // 
            this.do多边形.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do多边形.FlatAppearance.BorderSize = 0;
            this.do多边形.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do多边形.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.do多边形.ForeColor = System.Drawing.Color.White;
            this.do多边形.Location = new System.Drawing.Point(159, 11);
            this.do多边形.Margin = new System.Windows.Forms.Padding(0);
            this.do多边形.Name = "do多边形";
            this.do多边形.Size = new System.Drawing.Size(65, 26);
            this.do多边形.TabIndex = 34;
            this.do多边形.Text = "多边形";
            this.toolTip1.SetToolTip(this.do多边形, "单击鼠标右键选择顶点, 右键双击选择最后一个点");
            this.do多边形.UseVisualStyleBackColor = false;
            // 
            // do关闭
            // 
            this.do关闭.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do关闭.BackColor = System.Drawing.Color.White;
            this.do关闭.FlatAppearance.BorderSize = 0;
            this.do关闭.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do关闭.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.do关闭.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do关闭.Location = new System.Drawing.Point(390, 2);
            this.do关闭.Margin = new System.Windows.Forms.Padding(0);
            this.do关闭.Name = "do关闭";
            this.do关闭.Size = new System.Drawing.Size(25, 25);
            this.do关闭.TabIndex = 33;
            this.do关闭.Text = "X";
            this.do关闭.UseVisualStyleBackColor = false;
            // 
            // do圆形
            // 
            this.do圆形.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do圆形.FlatAppearance.BorderSize = 0;
            this.do圆形.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do圆形.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.do圆形.ForeColor = System.Drawing.Color.White;
            this.do圆形.Location = new System.Drawing.Point(86, 11);
            this.do圆形.Margin = new System.Windows.Forms.Padding(0);
            this.do圆形.Name = "do圆形";
            this.do圆形.Size = new System.Drawing.Size(65, 26);
            this.do圆形.TabIndex = 32;
            this.do圆形.Text = "圆形";
            this.toolTip1.SetToolTip(this.do圆形, "按下鼠标右键不放, 拖动, 选择完毕后释放鼠标右键");
            this.do圆形.UseVisualStyleBackColor = false;
            // 
            // do矩形
            // 
            this.do矩形.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do矩形.FlatAppearance.BorderSize = 0;
            this.do矩形.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do矩形.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.do矩形.ForeColor = System.Drawing.Color.White;
            this.do矩形.Location = new System.Drawing.Point(12, 11);
            this.do矩形.Margin = new System.Windows.Forms.Padding(0);
            this.do矩形.Name = "do矩形";
            this.do矩形.Size = new System.Drawing.Size(65, 26);
            this.do矩形.TabIndex = 31;
            this.do矩形.Text = "矩形";
            this.toolTip1.SetToolTip(this.do矩形, "按下鼠标右键不放, 拖动, 选择完毕后释放鼠标右键");
            this.do矩形.UseVisualStyleBackColor = false;
            // 
            // do保存
            // 
            this.do保存.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.do保存.FlatAppearance.BorderSize = 0;
            this.do保存.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do保存.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.do保存.ForeColor = System.Drawing.Color.White;
            this.do保存.Location = new System.Drawing.Point(249, 11);
            this.do保存.Margin = new System.Windows.Forms.Padding(0);
            this.do保存.Name = "do保存";
            this.do保存.Size = new System.Drawing.Size(65, 26);
            this.do保存.TabIndex = 35;
            this.do保存.Text = "保存";
            this.do保存.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(236, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 17);
            this.label1.TabIndex = 36;
            // 
            // do取消
            // 
            this.do取消.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.do取消.FlatAppearance.BorderSize = 0;
            this.do取消.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do取消.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.do取消.ForeColor = System.Drawing.Color.White;
            this.do取消.Location = new System.Drawing.Point(323, 11);
            this.do取消.Margin = new System.Windows.Forms.Padding(0);
            this.do取消.Name = "do取消";
            this.do取消.Size = new System.Drawing.Size(65, 26);
            this.do取消.TabIndex = 37;
            this.do取消.Text = "取消";
            this.do取消.UseVisualStyleBackColor = false;
            // 
            // F多次圈选
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "F多次圈选";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(419, 50);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button do矩形;
        private System.Windows.Forms.Button do关闭;
        private System.Windows.Forms.Button do圆形;
        private System.Windows.Forms.Button do多边形;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button do保存;
        private System.Windows.Forms.Button do取消;
    }
}
