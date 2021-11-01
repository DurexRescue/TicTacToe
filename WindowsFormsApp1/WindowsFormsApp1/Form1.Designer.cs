namespace WindowsFormsApp1
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chessBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.reset = new System.Windows.Forms.Button();
            this.computer_Start = new System.Windows.Forms.Button();
            this.computer_First = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chessBoard
            // 
            this.chessBoard.Location = new System.Drawing.Point(12, 12);
            this.chessBoard.Name = "chessBoard";
            this.chessBoard.Size = new System.Drawing.Size(450, 450);
            this.chessBoard.TabIndex = 0;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(230, 467);
            this.reset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(94, 31);
            this.reset.TabIndex = 1;
            this.reset.Text = "重新开始";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // computer_Start
            // 
            this.computer_Start.Location = new System.Drawing.Point(12, 467);
            this.computer_Start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.computer_Start.Name = "computer_Start";
            this.computer_Start.Size = new System.Drawing.Size(94, 31);
            this.computer_Start.TabIndex = 2;
            this.computer_Start.Text = "电脑开始";
            this.computer_Start.UseVisualStyleBackColor = true;
            this.computer_Start.Click += new System.EventHandler(this.computer_Start_Click);
            // 
            // computer_First
            // 
            this.computer_First.Location = new System.Drawing.Point(110, 467);
            this.computer_First.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.computer_First.Name = "computer_First";
            this.computer_First.Size = new System.Drawing.Size(115, 31);
            this.computer_First.TabIndex = 3;
            this.computer_First.Text = "人机对战之电脑先手";
            this.computer_First.UseVisualStyleBackColor = true;
            this.computer_First.Click += new System.EventHandler(this.computer_First_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 510);
            this.Controls.Add(this.computer_First);
            this.Controls.Add(this.computer_Start);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.chessBoard);
            this.Name = "Form1";
            this.Text = "井字棋";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel chessBoard;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button computer_Start;
        private System.Windows.Forms.Button computer_First;
    }
}

