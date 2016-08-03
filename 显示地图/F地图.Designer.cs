namespace 显示地图
{
    partial class F地图
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
            this.out地图控件 = new GMap.NET.WindowsForms.GMapControl();
            this.do缩放 = new 显示地图.FDemo缩放();
            this.SuspendLayout();
            // 
            // out地图控件
            // 
            this.out地图控件.Bearing = 0F;
            this.out地图控件.CanDragMap = true;
            this.out地图控件.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out地图控件.EmptyTileColor = System.Drawing.Color.Navy;
            this.out地图控件.GrayScaleMode = false;
            this.out地图控件.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.out地图控件.LevelsKeepInMemmory = 5;
            this.out地图控件.Location = new System.Drawing.Point(0, 0);
            this.out地图控件.MarkersEnabled = true;
            this.out地图控件.MaxZoom = 18;
            this.out地图控件.MinZoom = 8;
            this.out地图控件.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.out地图控件.Name = "out地图控件";
            this.out地图控件.NegativeMode = false;
            this.out地图控件.PolygonsEnabled = true;
            this.out地图控件.RetryLoadTile = 0;
            this.out地图控件.RoutesEnabled = true;
            this.out地图控件.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.out地图控件.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.out地图控件.ShowTileGridLines = false;
            this.out地图控件.Size = new System.Drawing.Size(782, 539);
            this.out地图控件.TabIndex = 4;
            this.out地图控件.Zoom = 11D;
            // 
            // do缩放
            // 
            this.do缩放.BackColor = System.Drawing.Color.White;
            this.do缩放.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.do缩放.Location = new System.Drawing.Point(3, 5);
            this.do缩放.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.do缩放.Name = "do缩放";
            this.do缩放.Size = new System.Drawing.Size(36, 161);
            this.do缩放.TabIndex = 5;
            this.do缩放.按钮文字颜色 = System.Drawing.Color.White;
            this.do缩放.按钮背景颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(115)))), ((int)(((byte)(136)))));
            // 
            // F地图
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.do缩放);
            this.Controls.Add(this.out地图控件);
            this.Name = "F地图";
            this.Size = new System.Drawing.Size(782, 539);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl out地图控件;
        private FDemo缩放 do缩放;
    }
}
