namespace FolderComments
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
            this.text = new System.Windows.Forms.TextBox();
            this.保存 = new System.Windows.Forms.Button();
            this.取消 = new System.Windows.Forms.Button();
            this.清空 = new System.Windows.Forms.Button();
            this.cbReg = new System.Windows.Forms.CheckBox();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dt3 = new System.Windows.Forms.DateTimePicker();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPath = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.AcceptsReturn = true;
            this.text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text.Location = new System.Drawing.Point(12, 12);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(333, 149);
            this.text.TabIndex = 0;
            this.text.Text = "请勾选/取消勾选下方“添加右键菜单”方框，\r\n或直接将要编辑备注的文件夹拖到本程序图标上\r\n";
            this.text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_KeyPress);
            this.text.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_KeyUp);
            // 
            // 保存
            // 
            this.保存.Location = new System.Drawing.Point(17, 167);
            this.保存.Name = "保存";
            this.保存.Size = new System.Drawing.Size(104, 23);
            this.保存.TabIndex = 1;
            this.保存.Text = "保存(Enter)";
            this.保存.UseVisualStyleBackColor = true;
            this.保存.Click += new System.EventHandler(this.保存_Click);
            // 
            // 取消
            // 
            this.取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.取消.Location = new System.Drawing.Point(125, 167);
            this.取消.Name = "取消";
            this.取消.Size = new System.Drawing.Size(104, 23);
            this.取消.TabIndex = 2;
            this.取消.Text = "取消(Esc)";
            this.取消.UseVisualStyleBackColor = true;
            this.取消.Click += new System.EventHandler(this.取消_Click);
            // 
            // 清空
            // 
            this.清空.Location = new System.Drawing.Point(235, 167);
            this.清空.Name = "清空";
            this.清空.Size = new System.Drawing.Size(104, 23);
            this.清空.TabIndex = 3;
            this.清空.Text = "清空(Alt+&C)";
            this.清空.UseVisualStyleBackColor = true;
            this.清空.Click += new System.EventHandler(this.清空_Click);
            // 
            // cbReg
            // 
            this.cbReg.AutoSize = true;
            this.cbReg.Location = new System.Drawing.Point(18, 319);
            this.cbReg.Name = "cbReg";
            this.cbReg.Size = new System.Drawing.Size(284, 19);
            this.cbReg.TabIndex = 9;
            this.cbReg.Text = "为本工具添加右键菜单“文件夹备注”";
            this.cbReg.UseVisualStyleBackColor = true;
            this.cbReg.CheckedChanged += new System.EventHandler(this.cbReg_CheckedChanged);
            // 
            // dt1
            // 
            this.dt1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt1.Location = new System.Drawing.Point(123, 201);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(205, 25);
            this.dt1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "创建日期";
            // 
            // dt3
            // 
            this.dt3.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dt3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt3.Location = new System.Drawing.Point(123, 263);
            this.dt3.Name = "dt3";
            this.dt3.Size = new System.Drawing.Size(205, 25);
            this.dt3.TabIndex = 7;
            // 
            // dt2
            // 
            this.dt2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt2.Location = new System.Drawing.Point(123, 232);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(205, 25);
            this.dt2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "上次访问日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "修改日期";
            // 
            // cbPath
            // 
            this.cbPath.AutoSize = true;
            this.cbPath.Location = new System.Drawing.Point(18, 294);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(211, 19);
            this.cbPath.TabIndex = 11;
            this.cbPath.Text = "将该文件夹添加到用户PATH";
            this.cbPath.UseVisualStyleBackColor = true;
            this.cbPath.CheckedChanged += new System.EventHandler(this.cbPath_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.保存;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.取消;
            this.ClientSize = new System.Drawing.Size(357, 345);
            this.Controls.Add(this.cbPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt3);
            this.Controls.Add(this.dt2);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.cbReg);
            this.Controls.Add(this.清空);
            this.Controls.Add(this.取消);
            this.Controls.Add(this.保存);
            this.Controls.Add(this.text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件夹备注 By x7890";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.Button 保存;
        private System.Windows.Forms.Button 取消;
        private System.Windows.Forms.Button 清空;
        private System.Windows.Forms.CheckBox cbReg;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt3;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbPath;
    }
}

