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
            this.btnWithBorder2 = new System.Windows.Forms.Button();
            this.btnNoBorder2 = new System.Windows.Forms.Button();
            this.btnAddFrame = new System.Windows.Forms.Button();
            this.btnClearFrame = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(86, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnWithBorder
            // 
            this.btnWithBorder.Location = new System.Drawing.Point(43, 219);
            this.btnWithBorder.Name = "btnWithBorder";
            this.btnWithBorder.Size = new System.Drawing.Size(75, 23);
            this.btnWithBorder.TabIndex = 0;
            this.btnWithBorder.Text = "测试带边框";
            this.btnWithBorder.UseVisualStyleBackColor = false;
            this.btnWithBorder.Click += new System.EventHandler(this.btnWithBorder_Click);
            // 
            // btnNoBorder
            // 
            this.btnNoBorder.Location = new System.Drawing.Point(124, 219);
            this.btnNoBorder.Name = "btnNoBorder";
            this.btnNoBorder.Size = new System.Drawing.Size(75, 23);
            this.btnNoBorder.TabIndex = 0;
            this.btnNoBorder.Text = "测试不带边框";
            this.btnNoBorder.UseVisualStyleBackColor = false;
            this.btnNoBorder.Click += new System.EventHandler(this.btnNoBorder_Click);
            // 
            // uiWinControl1
            // 
            this.uiWinControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.uiWinControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiWinControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.uiWinControl1.Location = new System.Drawing.Point(421, 0);
            this.uiWinControl1.Name = "uiWinControl1";
            this.uiWinControl1.Size = new System.Drawing.Size(280, 439);
            this.uiWinControl1.TabIndex = 1;
            this.uiWinControl1.Text = "uiWinControl1";
            this.uiWinControl1.Visible = false;
            // 
            // btnWithBorder2
            // 
            this.btnWithBorder2.Location = new System.Drawing.Point(43, 248);
            this.btnWithBorder2.Name = "btnWithBorder2";
            this.btnWithBorder2.Size = new System.Drawing.Size(75, 23);
            this.btnWithBorder2.TabIndex = 0;
            this.btnWithBorder2.Text = "测试带边框";
            this.btnWithBorder2.UseVisualStyleBackColor = false;
            this.btnWithBorder2.Click += new System.EventHandler(this.btnWithBorder2_Click);
            // 
            // btnNoBorder2
            // 
            this.btnNoBorder2.Location = new System.Drawing.Point(124, 248);
            this.btnNoBorder2.Name = "btnNoBorder2";
            this.btnNoBorder2.Size = new System.Drawing.Size(75, 23);
            this.btnNoBorder2.TabIndex = 0;
            this.btnNoBorder2.Text = "测试不带边框";
            this.btnNoBorder2.UseVisualStyleBackColor = false;
            this.btnNoBorder2.Click += new System.EventHandler(this.btnNoBorder2_Click);
            // 
            // btnAddFrame
            // 
            this.btnAddFrame.Location = new System.Drawing.Point(43, 277);
            this.btnAddFrame.Name = "btnAddFrame";
            this.btnAddFrame.Size = new System.Drawing.Size(75, 23);
            this.btnAddFrame.TabIndex = 2;
            this.btnAddFrame.Text = "添加帧";
            this.btnAddFrame.UseVisualStyleBackColor = false;
            this.btnAddFrame.Click += new System.EventHandler(this.btnAddFrame_Click);
            // 
            // btnClearFrame
            // 
            this.btnClearFrame.Location = new System.Drawing.Point(124, 277);
            this.btnClearFrame.Name = "btnClearFrame";
            this.btnClearFrame.Size = new System.Drawing.Size(75, 23);
            this.btnClearFrame.TabIndex = 2;
            this.btnClearFrame.Text = "清空帧";
            this.btnClearFrame.UseVisualStyleBackColor = false;
            this.btnClearFrame.Click += new System.EventHandler(this.btnClearFrame_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 323);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmDemo
            // 
            this.ClientSize = new System.Drawing.Size(701, 439);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnClearFrame);
            this.Controls.Add(this.btnAddFrame);
            this.Controls.Add(this.btnNoBorder2);
            this.Controls.Add(this.btnWithBorder2);
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
        private System.Windows.Forms.Button btnWithBorder2;
        private System.Windows.Forms.Button btnNoBorder2;
        public Windows.Forms.UIWinControl uiWinControl1;
        private System.Windows.Forms.Button btnAddFrame;
        private System.Windows.Forms.Button btnClearFrame;
        private System.Windows.Forms.Button button2;
    }
}

