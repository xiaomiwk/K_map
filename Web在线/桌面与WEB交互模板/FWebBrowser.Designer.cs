namespace Demo
{
    partial class FWebBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FWebBrowser));
            this.out浏览器 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.in传入参数 = new System.Windows.Forms.TextBox();
            this.do执行客户端动作 = new System.Windows.Forms.Button();
            this.do传入JSON = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // out浏览器
            // 
            this.out浏览器.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out浏览器.Location = new System.Drawing.Point(10, 69);
            this.out浏览器.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.out浏览器.MinimumSize = new System.Drawing.Size(16, 19);
            this.out浏览器.Name = "out浏览器";
            this.out浏览器.Size = new System.Drawing.Size(771, 585);
            this.out浏览器.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "传入参数：";
            // 
            // in传入参数
            // 
            this.in传入参数.Location = new System.Drawing.Point(93, 22);
            this.in传入参数.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.in传入参数.Name = "in传入参数";
            this.in传入参数.Size = new System.Drawing.Size(179, 26);
            this.in传入参数.TabIndex = 13;
            // 
            // do执行客户端动作
            // 
            this.do执行客户端动作.Location = new System.Drawing.Point(276, 20);
            this.do执行客户端动作.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.do执行客户端动作.Name = "do执行客户端动作";
            this.do执行客户端动作.Size = new System.Drawing.Size(120, 30);
            this.do执行客户端动作.TabIndex = 17;
            this.do执行客户端动作.Text = "执行客户端动作";
            this.do执行客户端动作.UseVisualStyleBackColor = true;
            // 
            // do传入JSON
            // 
            this.do传入JSON.Location = new System.Drawing.Point(400, 20);
            this.do传入JSON.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.do传入JSON.Name = "do传入JSON";
            this.do传入JSON.Size = new System.Drawing.Size(120, 30);
            this.do传入JSON.TabIndex = 18;
            this.do传入JSON.Text = "传入JSON";
            this.do传入JSON.UseVisualStyleBackColor = true;
            // 
            // FWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 665);
            this.Controls.Add(this.do传入JSON);
            this.Controls.Add(this.do执行客户端动作);
            this.Controls.Add(this.in传入参数);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.out浏览器);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FWebBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F桌面与WEB交互";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser out浏览器;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox in传入参数;
        private System.Windows.Forms.Button do执行客户端动作;
        private System.Windows.Forms.Button do传入JSON;
    }
}