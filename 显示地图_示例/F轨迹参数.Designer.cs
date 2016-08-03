namespace 显示地图_示例
{
    partial class F轨迹参数
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F轨迹参数));
            this.do确定 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.in数量 = new System.Windows.Forms.ComboBox();
            this.in频率 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // do确定
            // 
            this.do确定.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do确定.FlatAppearance.BorderSize = 0;
            this.do确定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do确定.ForeColor = System.Drawing.Color.White;
            this.do确定.Location = new System.Drawing.Point(46, 210);
            this.do确定.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do确定.Name = "do确定";
            this.do确定.Size = new System.Drawing.Size(100, 28);
            this.do确定.TabIndex = 37;
            this.do确定.Text = "确定";
            this.do确定.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "数量";
            // 
            // in数量
            // 
            this.in数量.FormattingEnabled = true;
            this.in数量.Location = new System.Drawing.Point(46, 64);
            this.in数量.Name = "in数量";
            this.in数量.Size = new System.Drawing.Size(121, 25);
            this.in数量.TabIndex = 39;
            // 
            // in频率
            // 
            this.in频率.FormattingEnabled = true;
            this.in频率.Location = new System.Drawing.Point(46, 154);
            this.in频率.Name = "in频率";
            this.in频率.Size = new System.Drawing.Size(121, 25);
            this.in频率.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "频率 (单位: 秒/次)";
            // 
            // F轨迹参数
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(230, 276);
            this.Controls.Add(this.in频率);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.in数量);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.do确定);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "F轨迹参数";
            this.Text = "轨迹参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button do确定;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox in数量;
        private System.Windows.Forms.ComboBox in频率;
        private System.Windows.Forms.Label label2;
    }
}