namespace Microsoft.Demo
{
    partial class FrmDemo
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnWithBorder = new System.Windows.Forms.Button();
            this.btnNoBorder = new System.Windows.Forms.Button();
            this.uiWinControl1 = new Microsoft.Windows.Forms.UIWinControl();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnWithBorder
            // 
            this.btnWithBorder.Location = new System.Drawing.Point(43, 219);
            this.btnWithBorder.Name = "btnWithBorder";
            this.btnWithBorder.Size = new System.Drawing.Size(75, 23);
            this.btnWithBorder.TabIndex = 0;
            this.btnWithBorder.Text = "测试带边框";
            this.btnWithBorder.UseVisualStyleBackColor = true;
            this.btnWithBorder.Click += new System.EventHandler(this.btnWithBorder_Click);
            // 
            // btnNoBorder
            // 
            this.btnNoBorder.Location = new System.Drawing.Point(124, 219);
            this.btnNoBorder.Name = "btnNoBorder";
            this.btnNoBorder.Size = new System.Drawing.Size(75, 23);
            this.btnNoBorder.TabIndex = 0;
            this.btnNoBorder.Text = "测试不带边框";
            this.btnNoBorder.UseVisualStyleBackColor = true;
            this.btnNoBorder.Click += new System.EventHandler(this.btnNoBorder_Click);
            // 
            // uiWinControl1
            // 
            this.uiWinControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiWinControl1.Location = new System.Drawing.Point(421, 0);
            this.uiWinControl1.Name = "uiWinControl1";
            this.uiWinControl1.Size = new System.Drawing.Size(280, 439);
            this.uiWinControl1.TabIndex = 1;
            this.uiWinControl1.Text = "uiWinControl1";
            this.uiWinControl1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(463, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "测试带边框";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(544, 346);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "测试不带边框";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(57, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FrmDemo
            // 
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(701, 439);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.uiWinControl1);
            this.Controls.Add(this.btnNoBorder);
            this.Controls.Add(this.btnWithBorder);
            this.Name = "FrmDemo";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnWithBorder;
        private System.Windows.Forms.Button btnNoBorder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        public Windows.Forms.UIWinControl uiWinControl1;
        private System.Windows.Forms.Button button4;
    }
}

