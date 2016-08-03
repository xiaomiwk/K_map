
using 显示地图;

namespace 显示地图_示例
{
    partial class F主窗口
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F主窗口));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.do开始测距 = new System.Windows.Forms.Button();
            this.do多次圈选 = new System.Windows.Forms.Button();
            this.do图层操作 = new System.Windows.Forms.Button();
            this.do模拟轨迹 = new System.Windows.Forms.Button();
            this.do加载地图 = new System.Windows.Forms.Button();
            this.do添加覆盖物2 = new System.Windows.Forms.Button();
            this.do单次圈选 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.do区域检索_圈选 = new System.Windows.Forms.Button();
            this.in区域检索_城市 = new System.Windows.Forms.TextBox();
            this.do区域检索_城市 = new System.Windows.Forms.Button();
            this.in区域检索_关键字 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.do逆地址编码 = new System.Windows.Forms.Button();
            this.in逆地址编码_纬度 = new System.Windows.Forms.TextBox();
            this.in逆地址编码_经度 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.in地址编码_城市 = new System.Windows.Forms.TextBox();
            this.do地址编码 = new System.Windows.Forms.Button();
            this.in地址编码_地名 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.do查询路径_公交_地名 = new System.Windows.Forms.Button();
            this.in查询路径_到城市 = new System.Windows.Forms.TextBox();
            this.in查询路径_从城市 = new System.Windows.Forms.TextBox();
            this.in查询路径_地名_说明 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.in查询路径_地名_方式 = new System.Windows.Forms.ComboBox();
            this.in查询路径_到地名 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.do查询路径_驾车_地名 = new System.Windows.Forms.Button();
            this.in查询路径_从地名 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.do查询路径_公交_经纬度 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.in查询路径_经纬度_方式 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.in查询路径_经纬度_说明 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.in查询路径_到经纬度 = new System.Windows.Forms.TextBox();
            this.do查询路径_驾车_经纬度 = new System.Windows.Forms.Button();
            this.in查询路径_从经纬度 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.out纬度 = new System.Windows.Forms.Label();
            this.out经度 = new System.Windows.Forms.Label();
            this.out层级 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.do删除覆盖物 = new System.Windows.Forms.Button();
            this.do添加覆盖物 = new System.Windows.Forms.Button();
            this.do定位初始点 = new System.Windows.Forms.Button();
            this.out地图 = new 显示地图.F地图();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.out地图);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.do开始测距);
            this.splitContainer1.Panel2.Controls.Add(this.do多次圈选);
            this.splitContainer1.Panel2.Controls.Add(this.do图层操作);
            this.splitContainer1.Panel2.Controls.Add(this.do模拟轨迹);
            this.splitContainer1.Panel2.Controls.Add(this.do加载地图);
            this.splitContainer1.Panel2.Controls.Add(this.do添加覆盖物2);
            this.splitContainer1.Panel2.Controls.Add(this.do单次圈选);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.out纬度);
            this.splitContainer1.Panel2.Controls.Add(this.out经度);
            this.splitContainer1.Panel2.Controls.Add(this.out层级);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.do删除覆盖物);
            this.splitContainer1.Panel2.Controls.Add(this.do添加覆盖物);
            this.splitContainer1.Panel2.Controls.Add(this.do定位初始点);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 702);
            this.splitContainer1.SplitterDistance = 903;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // do开始测距
            // 
            this.do开始测距.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do开始测距.FlatAppearance.BorderSize = 0;
            this.do开始测距.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do开始测距.ForeColor = System.Drawing.Color.White;
            this.do开始测距.Location = new System.Drawing.Point(18, 121);
            this.do开始测距.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do开始测距.Name = "do开始测距";
            this.do开始测距.Size = new System.Drawing.Size(100, 28);
            this.do开始测距.TabIndex = 40;
            this.do开始测距.Text = "开始测距";
            this.do开始测距.UseVisualStyleBackColor = false;
            // 
            // do多次圈选
            // 
            this.do多次圈选.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do多次圈选.FlatAppearance.BorderSize = 0;
            this.do多次圈选.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do多次圈选.ForeColor = System.Drawing.Color.White;
            this.do多次圈选.Location = new System.Drawing.Point(124, 85);
            this.do多次圈选.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do多次圈选.Name = "do多次圈选";
            this.do多次圈选.Size = new System.Drawing.Size(100, 28);
            this.do多次圈选.TabIndex = 39;
            this.do多次圈选.Text = "多次圈选";
            this.do多次圈选.UseVisualStyleBackColor = false;
            // 
            // do图层操作
            // 
            this.do图层操作.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do图层操作.FlatAppearance.BorderSize = 0;
            this.do图层操作.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do图层操作.ForeColor = System.Drawing.Color.White;
            this.do图层操作.Location = new System.Drawing.Point(230, 13);
            this.do图层操作.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do图层操作.Name = "do图层操作";
            this.do图层操作.Size = new System.Drawing.Size(100, 28);
            this.do图层操作.TabIndex = 38;
            this.do图层操作.Text = "图层操作";
            this.do图层操作.UseVisualStyleBackColor = false;
            // 
            // do模拟轨迹
            // 
            this.do模拟轨迹.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do模拟轨迹.FlatAppearance.BorderSize = 0;
            this.do模拟轨迹.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do模拟轨迹.ForeColor = System.Drawing.Color.White;
            this.do模拟轨迹.Location = new System.Drawing.Point(230, 85);
            this.do模拟轨迹.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do模拟轨迹.Name = "do模拟轨迹";
            this.do模拟轨迹.Size = new System.Drawing.Size(100, 28);
            this.do模拟轨迹.TabIndex = 37;
            this.do模拟轨迹.Text = "模拟轨迹";
            this.do模拟轨迹.UseVisualStyleBackColor = false;
            // 
            // do加载地图
            // 
            this.do加载地图.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do加载地图.FlatAppearance.BorderSize = 0;
            this.do加载地图.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do加载地图.ForeColor = System.Drawing.Color.White;
            this.do加载地图.Location = new System.Drawing.Point(18, 13);
            this.do加载地图.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do加载地图.Name = "do加载地图";
            this.do加载地图.Size = new System.Drawing.Size(100, 28);
            this.do加载地图.TabIndex = 36;
            this.do加载地图.Text = "加载地图";
            this.do加载地图.UseVisualStyleBackColor = false;
            // 
            // do添加覆盖物2
            // 
            this.do添加覆盖物2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do添加覆盖物2.FlatAppearance.BorderSize = 0;
            this.do添加覆盖物2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do添加覆盖物2.ForeColor = System.Drawing.Color.White;
            this.do添加覆盖物2.Location = new System.Drawing.Point(124, 49);
            this.do添加覆盖物2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do添加覆盖物2.Name = "do添加覆盖物2";
            this.do添加覆盖物2.Size = new System.Drawing.Size(100, 28);
            this.do添加覆盖物2.TabIndex = 34;
            this.do添加覆盖物2.Text = "添加覆盖物2";
            this.do添加覆盖物2.UseVisualStyleBackColor = false;
            // 
            // do单次圈选
            // 
            this.do单次圈选.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do单次圈选.FlatAppearance.BorderSize = 0;
            this.do单次圈选.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do单次圈选.ForeColor = System.Drawing.Color.White;
            this.do单次圈选.Location = new System.Drawing.Point(18, 85);
            this.do单次圈选.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do单次圈选.Name = "do单次圈选";
            this.do单次圈选.Size = new System.Drawing.Size(100, 28);
            this.do单次圈选.TabIndex = 33;
            this.do单次圈选.Text = "单次圈选";
            this.do单次圈选.UseVisualStyleBackColor = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.ItemSize = new System.Drawing.Size(121, 25);
            this.tabControl2.Location = new System.Drawing.Point(18, 175);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(312, 143);
            this.tabControl2.TabIndex = 32;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.do区域检索_圈选);
            this.tabPage3.Controls.Add(this.in区域检索_城市);
            this.tabPage3.Controls.Add(this.do区域检索_城市);
            this.tabPage3.Controls.Add(this.in区域检索_关键字);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(304, 110);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "  区域检索  ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // do区域检索_圈选
            // 
            this.do区域检索_圈选.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do区域检索_圈选.FlatAppearance.BorderSize = 0;
            this.do区域检索_圈选.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do区域检索_圈选.ForeColor = System.Drawing.Color.White;
            this.do区域检索_圈选.Location = new System.Drawing.Point(188, 44);
            this.do区域检索_圈选.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do区域检索_圈选.Name = "do区域检索_圈选";
            this.do区域检索_圈选.Size = new System.Drawing.Size(100, 28);
            this.do区域检索_圈选.TabIndex = 40;
            this.do区域检索_圈选.Text = "圈选查询";
            this.do区域检索_圈选.UseVisualStyleBackColor = false;
            // 
            // in区域检索_城市
            // 
            this.in区域检索_城市.Location = new System.Drawing.Point(82, 14);
            this.in区域检索_城市.Name = "in区域检索_城市";
            this.in区域检索_城市.Size = new System.Drawing.Size(62, 23);
            this.in区域检索_城市.TabIndex = 38;
            // 
            // do区域检索_城市
            // 
            this.do区域检索_城市.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do区域检索_城市.FlatAppearance.BorderSize = 0;
            this.do区域检索_城市.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do区域检索_城市.ForeColor = System.Drawing.Color.White;
            this.do区域检索_城市.Location = new System.Drawing.Point(82, 44);
            this.do区域检索_城市.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do区域检索_城市.Name = "do区域检索_城市";
            this.do区域检索_城市.Size = new System.Drawing.Size(100, 28);
            this.do区域检索_城市.TabIndex = 37;
            this.do区域检索_城市.Text = "在城市中查询";
            this.do区域检索_城市.UseVisualStyleBackColor = false;
            // 
            // in区域检索_关键字
            // 
            this.in区域检索_关键字.Location = new System.Drawing.Point(150, 14);
            this.in区域检索_关键字.Name = "in区域检索_关键字";
            this.in区域检索_关键字.Size = new System.Drawing.Size(132, 23);
            this.in区域检索_关键字.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 35;
            this.label9.Text = "关键字: ";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.do逆地址编码);
            this.tabPage4.Controls.Add(this.in逆地址编码_纬度);
            this.tabPage4.Controls.Add(this.in逆地址编码_经度);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(304, 110);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "  逆地址编码  ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // do逆地址编码
            // 
            this.do逆地址编码.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do逆地址编码.FlatAppearance.BorderSize = 0;
            this.do逆地址编码.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do逆地址编码.ForeColor = System.Drawing.Color.White;
            this.do逆地址编码.Location = new System.Drawing.Point(81, 74);
            this.do逆地址编码.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do逆地址编码.Name = "do逆地址编码";
            this.do逆地址编码.Size = new System.Drawing.Size(100, 28);
            this.do逆地址编码.TabIndex = 34;
            this.do逆地址编码.Text = "查询";
            this.do逆地址编码.UseVisualStyleBackColor = false;
            // 
            // in逆地址编码_纬度
            // 
            this.in逆地址编码_纬度.Location = new System.Drawing.Point(81, 44);
            this.in逆地址编码_纬度.Name = "in逆地址编码_纬度";
            this.in逆地址编码_纬度.Size = new System.Drawing.Size(120, 23);
            this.in逆地址编码_纬度.TabIndex = 25;
            // 
            // in逆地址编码_经度
            // 
            this.in逆地址编码_经度.Location = new System.Drawing.Point(81, 14);
            this.in逆地址编码_经度.Name = "in逆地址编码_经度";
            this.in逆地址编码_经度.Size = new System.Drawing.Size(120, 23);
            this.in逆地址编码_经度.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "纬度: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "经度: ";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.in地址编码_城市);
            this.tabPage5.Controls.Add(this.do地址编码);
            this.tabPage5.Controls.Add(this.in地址编码_地名);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(304, 110);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "  地址编码  ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // in地址编码_城市
            // 
            this.in地址编码_城市.Location = new System.Drawing.Point(81, 14);
            this.in地址编码_城市.Name = "in地址编码_城市";
            this.in地址编码_城市.Size = new System.Drawing.Size(62, 23);
            this.in地址编码_城市.TabIndex = 41;
            // 
            // do地址编码
            // 
            this.do地址编码.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do地址编码.FlatAppearance.BorderSize = 0;
            this.do地址编码.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do地址编码.ForeColor = System.Drawing.Color.White;
            this.do地址编码.Location = new System.Drawing.Point(82, 44);
            this.do地址编码.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do地址编码.Name = "do地址编码";
            this.do地址编码.Size = new System.Drawing.Size(100, 28);
            this.do地址编码.TabIndex = 40;
            this.do地址编码.Text = "查询";
            this.do地址编码.UseVisualStyleBackColor = false;
            // 
            // in地址编码_地名
            // 
            this.in地址编码_地名.Location = new System.Drawing.Point(150, 14);
            this.in地址编码_地名.Name = "in地址编码_地名";
            this.in地址编码_地名.Size = new System.Drawing.Size(132, 23);
            this.in地址编码_地名.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "地址: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(121, 25);
            this.tabControl1.Location = new System.Drawing.Point(18, 324);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(312, 309);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.do查询路径_公交_地名);
            this.tabPage1.Controls.Add(this.in查询路径_到城市);
            this.tabPage1.Controls.Add(this.in查询路径_从城市);
            this.tabPage1.Controls.Add(this.in查询路径_地名_说明);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.in查询路径_地名_方式);
            this.tabPage1.Controls.Add(this.in查询路径_到地名);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.do查询路径_驾车_地名);
            this.tabPage1.Controls.Add(this.in查询路径_从地名);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(304, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  查询路线 - 地名  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // do查询路径_公交_地名
            // 
            this.do查询路径_公交_地名.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do查询路径_公交_地名.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do查询路径_公交_地名.FlatAppearance.BorderSize = 0;
            this.do查询路径_公交_地名.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询路径_公交_地名.ForeColor = System.Drawing.Color.White;
            this.do查询路径_公交_地名.Location = new System.Drawing.Point(188, 241);
            this.do查询路径_公交_地名.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do查询路径_公交_地名.Name = "do查询路径_公交_地名";
            this.do查询路径_公交_地名.Size = new System.Drawing.Size(100, 28);
            this.do查询路径_公交_地名.TabIndex = 49;
            this.do查询路径_公交_地名.Text = "公交";
            this.do查询路径_公交_地名.UseVisualStyleBackColor = false;
            // 
            // in查询路径_到城市
            // 
            this.in查询路径_到城市.Location = new System.Drawing.Point(82, 44);
            this.in查询路径_到城市.Name = "in查询路径_到城市";
            this.in查询路径_到城市.Size = new System.Drawing.Size(62, 23);
            this.in查询路径_到城市.TabIndex = 48;
            // 
            // in查询路径_从城市
            // 
            this.in查询路径_从城市.Location = new System.Drawing.Point(82, 15);
            this.in查询路径_从城市.Name = "in查询路径_从城市";
            this.in查询路径_从城市.Size = new System.Drawing.Size(62, 23);
            this.in查询路径_从城市.TabIndex = 47;
            // 
            // in查询路径_地名_说明
            // 
            this.in查询路径_地名_说明.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.in查询路径_地名_说明.Location = new System.Drawing.Point(82, 104);
            this.in查询路径_地名_说明.Multiline = true;
            this.in查询路径_地名_说明.Name = "in查询路径_地名_说明";
            this.in查询路径_地名_说明.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.in查询路径_地名_说明.Size = new System.Drawing.Size(200, 130);
            this.in查询路径_地名_说明.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 45;
            this.label6.Text = "说明: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 44;
            this.label5.Text = "方式: ";
            // 
            // in查询路径_地名_方式
            // 
            this.in查询路径_地名_方式.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in查询路径_地名_方式.FormattingEnabled = true;
            this.in查询路径_地名_方式.Items.AddRange(new object[] {
            "公交",
            "自驾",
            "步行"});
            this.in查询路径_地名_方式.Location = new System.Drawing.Point(82, 73);
            this.in查询路径_地名_方式.Name = "in查询路径_地名_方式";
            this.in查询路径_地名_方式.Size = new System.Drawing.Size(200, 25);
            this.in查询路径_地名_方式.TabIndex = 43;
            // 
            // in查询路径_到地名
            // 
            this.in查询路径_到地名.Location = new System.Drawing.Point(150, 44);
            this.in查询路径_到地名.Name = "in查询路径_到地名";
            this.in查询路径_到地名.Size = new System.Drawing.Size(132, 23);
            this.in查询路径_到地名.TabIndex = 42;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 17);
            this.label11.TabIndex = 41;
            this.label11.Text = "到: ";
            // 
            // do查询路径_驾车_地名
            // 
            this.do查询路径_驾车_地名.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do查询路径_驾车_地名.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do查询路径_驾车_地名.FlatAppearance.BorderSize = 0;
            this.do查询路径_驾车_地名.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询路径_驾车_地名.ForeColor = System.Drawing.Color.White;
            this.do查询路径_驾车_地名.Location = new System.Drawing.Point(82, 241);
            this.do查询路径_驾车_地名.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do查询路径_驾车_地名.Name = "do查询路径_驾车_地名";
            this.do查询路径_驾车_地名.Size = new System.Drawing.Size(100, 28);
            this.do查询路径_驾车_地名.TabIndex = 40;
            this.do查询路径_驾车_地名.Text = "驾车";
            this.do查询路径_驾车_地名.UseVisualStyleBackColor = false;
            // 
            // in查询路径_从地名
            // 
            this.in查询路径_从地名.Location = new System.Drawing.Point(150, 15);
            this.in查询路径_从地名.Name = "in查询路径_从地名";
            this.in查询路径_从地名.Size = new System.Drawing.Size(132, 23);
            this.in查询路径_从地名.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "从: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.do查询路径_公交_经纬度);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.in查询路径_经纬度_方式);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.in查询路径_经纬度_说明);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.in查询路径_到经纬度);
            this.tabPage2.Controls.Add(this.do查询路径_驾车_经纬度);
            this.tabPage2.Controls.Add(this.in查询路径_从经纬度);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(304, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "    经纬度    ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // do查询路径_公交_经纬度
            // 
            this.do查询路径_公交_经纬度.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do查询路径_公交_经纬度.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do查询路径_公交_经纬度.FlatAppearance.BorderSize = 0;
            this.do查询路径_公交_经纬度.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询路径_公交_经纬度.ForeColor = System.Drawing.Color.White;
            this.do查询路径_公交_经纬度.Location = new System.Drawing.Point(188, 241);
            this.do查询路径_公交_经纬度.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do查询路径_公交_经纬度.Name = "do查询路径_公交_经纬度";
            this.do查询路径_公交_经纬度.Size = new System.Drawing.Size(100, 28);
            this.do查询路径_公交_经纬度.TabIndex = 53;
            this.do查询路径_公交_经纬度.Text = "公交";
            this.do查询路径_公交_经纬度.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 17);
            this.label12.TabIndex = 52;
            this.label12.Text = "方式: ";
            // 
            // in查询路径_经纬度_方式
            // 
            this.in查询路径_经纬度_方式.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in查询路径_经纬度_方式.FormattingEnabled = true;
            this.in查询路径_经纬度_方式.Items.AddRange(new object[] {
            "公交",
            "自驾",
            "步行"});
            this.in查询路径_经纬度_方式.Location = new System.Drawing.Point(82, 73);
            this.in查询路径_经纬度_方式.Name = "in查询路径_经纬度_方式";
            this.in查询路径_经纬度_方式.Size = new System.Drawing.Size(200, 25);
            this.in查询路径_经纬度_方式.TabIndex = 51;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(36, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 17);
            this.label17.TabIndex = 50;
            this.label17.Text = "到: ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(36, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 17);
            this.label18.TabIndex = 49;
            this.label18.Text = "从: ";
            // 
            // in查询路径_经纬度_说明
            // 
            this.in查询路径_经纬度_说明.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.in查询路径_经纬度_说明.Location = new System.Drawing.Point(82, 104);
            this.in查询路径_经纬度_说明.Multiline = true;
            this.in查询路径_经纬度_说明.Name = "in查询路径_经纬度_说明";
            this.in查询路径_经纬度_说明.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.in查询路径_经纬度_说明.Size = new System.Drawing.Size(200, 130);
            this.in查询路径_经纬度_说明.TabIndex = 48;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 17);
            this.label16.TabIndex = 47;
            this.label16.Text = "说明: ";
            // 
            // in查询路径_到经纬度
            // 
            this.in查询路径_到经纬度.Location = new System.Drawing.Point(82, 44);
            this.in查询路径_到经纬度.Name = "in查询路径_到经纬度";
            this.in查询路径_到经纬度.Size = new System.Drawing.Size(130, 23);
            this.in查询路径_到经纬度.TabIndex = 42;
            // 
            // do查询路径_驾车_经纬度
            // 
            this.do查询路径_驾车_经纬度.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do查询路径_驾车_经纬度.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do查询路径_驾车_经纬度.FlatAppearance.BorderSize = 0;
            this.do查询路径_驾车_经纬度.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询路径_驾车_经纬度.ForeColor = System.Drawing.Color.White;
            this.do查询路径_驾车_经纬度.Location = new System.Drawing.Point(82, 241);
            this.do查询路径_驾车_经纬度.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do查询路径_驾车_经纬度.Name = "do查询路径_驾车_经纬度";
            this.do查询路径_驾车_经纬度.Size = new System.Drawing.Size(100, 28);
            this.do查询路径_驾车_经纬度.TabIndex = 39;
            this.do查询路径_驾车_经纬度.Text = "驾车";
            this.do查询路径_驾车_经纬度.UseVisualStyleBackColor = false;
            // 
            // in查询路径_从经纬度
            // 
            this.in查询路径_从经纬度.Location = new System.Drawing.Point(82, 15);
            this.in查询路径_从经纬度.Name = "in查询路径_从经纬度";
            this.in查询路径_从经纬度.Size = new System.Drawing.Size(130, 23);
            this.in查询路径_从经纬度.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(219, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 17);
            this.label13.TabIndex = 35;
            this.label13.Text = "经度,纬度 ";
            // 
            // out纬度
            // 
            this.out纬度.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.out纬度.AutoSize = true;
            this.out纬度.Location = new System.Drawing.Point(231, 676);
            this.out纬度.Name = "out纬度";
            this.out纬度.Size = new System.Drawing.Size(43, 17);
            this.out纬度.TabIndex = 24;
            this.out纬度.Text = "label6";
            // 
            // out经度
            // 
            this.out经度.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.out经度.AutoSize = true;
            this.out经度.Location = new System.Drawing.Point(61, 676);
            this.out经度.Name = "out经度";
            this.out经度.Size = new System.Drawing.Size(43, 17);
            this.out经度.TabIndex = 23;
            this.out经度.Text = "label5";
            // 
            // out层级
            // 
            this.out层级.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.out层级.AutoSize = true;
            this.out层级.Location = new System.Drawing.Point(61, 648);
            this.out层级.Name = "out层级";
            this.out层级.Size = new System.Drawing.Size(43, 17);
            this.out层级.TabIndex = 22;
            this.out层级.Text = "label4";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 676);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "纬度: ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 676);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "经度: ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 648);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "层级: ";
            // 
            // do删除覆盖物
            // 
            this.do删除覆盖物.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do删除覆盖物.FlatAppearance.BorderSize = 0;
            this.do删除覆盖物.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do删除覆盖物.ForeColor = System.Drawing.Color.White;
            this.do删除覆盖物.Location = new System.Drawing.Point(230, 49);
            this.do删除覆盖物.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do删除覆盖物.Name = "do删除覆盖物";
            this.do删除覆盖物.Size = new System.Drawing.Size(100, 28);
            this.do删除覆盖物.TabIndex = 15;
            this.do删除覆盖物.Text = "删除覆盖物";
            this.do删除覆盖物.UseVisualStyleBackColor = false;
            // 
            // do添加覆盖物
            // 
            this.do添加覆盖物.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do添加覆盖物.FlatAppearance.BorderSize = 0;
            this.do添加覆盖物.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do添加覆盖物.ForeColor = System.Drawing.Color.White;
            this.do添加覆盖物.Location = new System.Drawing.Point(18, 49);
            this.do添加覆盖物.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do添加覆盖物.Name = "do添加覆盖物";
            this.do添加覆盖物.Size = new System.Drawing.Size(100, 28);
            this.do添加覆盖物.TabIndex = 14;
            this.do添加覆盖物.Text = "添加覆盖物";
            this.do添加覆盖物.UseVisualStyleBackColor = false;
            // 
            // do定位初始点
            // 
            this.do定位初始点.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.do定位初始点.FlatAppearance.BorderSize = 0;
            this.do定位初始点.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do定位初始点.ForeColor = System.Drawing.Color.White;
            this.do定位初始点.Location = new System.Drawing.Point(124, 13);
            this.do定位初始点.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.do定位初始点.Name = "do定位初始点";
            this.do定位初始点.Size = new System.Drawing.Size(100, 28);
            this.do定位初始点.TabIndex = 16;
            this.do定位初始点.Text = "定位初始点";
            this.do定位初始点.UseVisualStyleBackColor = false;
            // 
            // out地图
            // 
            this.out地图.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out地图.Location = new System.Drawing.Point(0, 0);
            this.out地图.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.out地图.Name = "out地图";
            this.out地图.Size = new System.Drawing.Size(903, 702);
            this.out地图.TabIndex = 12;
            this.out地图.启用默认缩放控件 = true;
            this.out地图.当前地图源 = 显示地图.E地图源.无;
            this.out地图.当前层级 = 8;
            this.out地图.按钮文字颜色 = System.Drawing.Color.White;
            this.out地图.按钮背景颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            this.out地图.显示图片调试信息 = false;
            this.out地图.缩放控件位置 = new System.Drawing.Point(10, 10);
            // 
            // F主窗口
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 702);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "F主窗口";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "显示地图_示例";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button do定位初始点;
        private System.Windows.Forms.Button do删除覆盖物;
        private System.Windows.Forms.Button do添加覆盖物;
        private F地图 out地图;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label out纬度;
        private System.Windows.Forms.Label out经度;
        private System.Windows.Forms.Label out层级;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button do单次圈选;
        private System.Windows.Forms.TextBox in逆地址编码_纬度;
        private System.Windows.Forms.TextBox in逆地址编码_经度;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button do区域检索_城市;
        private System.Windows.Forms.TextBox in区域检索_关键字;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button do逆地址编码;
        private System.Windows.Forms.TextBox in查询路径_到地名;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button do查询路径_驾车_地名;
        private System.Windows.Forms.TextBox in查询路径_从地名;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox in查询路径_到经纬度;
        private System.Windows.Forms.Button do查询路径_驾车_经纬度;
        private System.Windows.Forms.TextBox in查询路径_从经纬度;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button do添加覆盖物2;
        private System.Windows.Forms.Button do加载地图;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button do地址编码;
        private System.Windows.Forms.TextBox in地址编码_地名;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox in查询路径_地名_方式;
        private System.Windows.Forms.TextBox in查询路径_地名_说明;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox in查询路径_经纬度_说明;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox in查询路径_到城市;
        private System.Windows.Forms.TextBox in查询路径_从城市;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox in查询路径_经纬度_方式;
        private System.Windows.Forms.Button do查询路径_公交_地名;
        private System.Windows.Forms.Button do查询路径_公交_经纬度;
        private System.Windows.Forms.TextBox in区域检索_城市;
        private System.Windows.Forms.TextBox in地址编码_城市;
        private System.Windows.Forms.Button do区域检索_圈选;
        private System.Windows.Forms.Button do模拟轨迹;
        private System.Windows.Forms.Button do图层操作;
        private System.Windows.Forms.Button do多次圈选;
        private System.Windows.Forms.Button do开始测距;
    }
}

