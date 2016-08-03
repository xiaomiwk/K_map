namespace Demo
{
    partial class F轨迹回放
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
            this.label4 = new System.Windows.Forms.Label();
            this.in用户列表 = new System.Windows.Forms.DataGridView();
            this.outId列 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.out姓名列 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.out颜色列 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.in开始时间 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.in结束时间 = new System.Windows.Forms.DateTimePicker();
            this.do开始生成 = new System.Windows.Forms.Button();
            this.out用户列表 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.in用户列表)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label4.Location = new System.Drawing.Point(54, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "1. 选择用户";
            // 
            // in用户列表
            // 
            this.in用户列表.AllowUserToAddRows = false;
            this.in用户列表.AllowUserToDeleteRows = false;
            this.in用户列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.in用户列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.in用户列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.outId列,
            this.out姓名列,
            this.out颜色列,
            this.Column3});
            this.in用户列表.Location = new System.Drawing.Point(156, 87);
            this.in用户列表.Name = "in用户列表";
            this.in用户列表.RowTemplate.Height = 28;
            this.in用户列表.Size = new System.Drawing.Size(755, 234);
            this.in用户列表.TabIndex = 22;
            // 
            // outId列
            // 
            this.outId列.DataPropertyName = "Id";
            this.outId列.HeaderText = "序号";
            this.outId列.Name = "outId列";
            this.outId列.ReadOnly = true;
            this.outId列.Width = 200;
            // 
            // out姓名列
            // 
            this.out姓名列.DataPropertyName = "姓名";
            this.out姓名列.HeaderText = "姓名";
            this.out姓名列.Name = "out姓名列";
            this.out姓名列.ReadOnly = true;
            this.out姓名列.Width = 200;
            // 
            // out颜色列
            // 
            this.out颜色列.DataPropertyName = "颜色";
            this.out颜色列.HeaderText = "颜色";
            this.out颜色列.Name = "out颜色列";
            this.out颜色列.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.Text = "删除";
            this.Column3.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(54, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "2. 选择时间";
            // 
            // in开始时间
            // 
            this.in开始时间.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.in开始时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in开始时间.Location = new System.Drawing.Point(156, 393);
            this.in开始时间.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.in开始时间.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.in开始时间.Name = "in开始时间";
            this.in开始时间.Size = new System.Drawing.Size(211, 23);
            this.in开始时间.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "开始时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "结束时间：";
            // 
            // in结束时间
            // 
            this.in结束时间.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.in结束时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in结束时间.Location = new System.Drawing.Point(515, 393);
            this.in结束时间.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.in结束时间.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.in结束时间.Name = "in结束时间";
            this.in结束时间.Size = new System.Drawing.Size(211, 23);
            this.in结束时间.TabIndex = 27;
            // 
            // do开始生成
            // 
            this.do开始生成.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.do开始生成.FlatAppearance.BorderSize = 0;
            this.do开始生成.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do开始生成.ForeColor = System.Drawing.Color.White;
            this.do开始生成.Location = new System.Drawing.Point(811, 492);
            this.do开始生成.Name = "do开始生成";
            this.do开始生成.Size = new System.Drawing.Size(100, 26);
            this.do开始生成.TabIndex = 30;
            this.do开始生成.Text = "开始生成";
            this.do开始生成.UseVisualStyleBackColor = false;
            // 
            // out用户列表
            // 
            this.out用户列表.FormattingEnabled = true;
            this.out用户列表.IntegralHeight = false;
            this.out用户列表.ItemHeight = 17;
            this.out用户列表.Items.AddRange(new object[] {
            "虚空",
            "龙鹰",
            "小黑",
            "卡尔"});
            this.out用户列表.Location = new System.Drawing.Point(57, 87);
            this.out用户列表.Name = "out用户列表";
            this.out用户列表.Size = new System.Drawing.Size(91, 234);
            this.out用户列表.TabIndex = 31;
            // 
            // F轨迹回放
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.out用户列表);
            this.Controls.Add(this.do开始生成);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.in结束时间);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.in开始时间);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.in用户列表);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F轨迹回放";
            this.Size = new System.Drawing.Size(1030, 620);
            ((System.ComponentModel.ISupportInitialize)(this.in用户列表)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView in用户列表;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker in开始时间;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker in结束时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn outId列;
        private System.Windows.Forms.DataGridViewTextBoxColumn out姓名列;
        private System.Windows.Forms.DataGridViewComboBoxColumn out颜色列;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.Button do开始生成;
        private System.Windows.Forms.ListBox out用户列表;
    }
}
