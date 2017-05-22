namespace keshe_Ruangong
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_denglu = new System.Windows.Forms.Button();
            this.denglu = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_zhuce = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.denglu)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_denglu
            // 
            this.bt_denglu.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt_denglu.ForeColor = System.Drawing.Color.White;
            this.bt_denglu.Location = new System.Drawing.Point(84, 208);
            this.bt_denglu.Name = "bt_denglu";
            this.bt_denglu.Size = new System.Drawing.Size(75, 23);
            this.bt_denglu.TabIndex = 13;
            this.bt_denglu.Text = "登录";
            this.bt_denglu.UseVisualStyleBackColor = false;
            this.bt_denglu.Click += new System.EventHandler(this.bt_denglu_Click);
            // 
            // denglu
            // 
            this.denglu.BackColor = System.Drawing.Color.Transparent;
            this.denglu.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.denglu.ErrorImage = null;
            this.denglu.Location = new System.Drawing.Point(122, 41);
            this.denglu.Name = "denglu";
            this.denglu.Size = new System.Drawing.Size(100, 50);
            this.denglu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.denglu.TabIndex = 12;
            this.denglu.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(111, 152);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(168, 21);
            this.textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 21);
            this.textBox1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "账号：";
            // 
            // bt_zhuce
            // 
            this.bt_zhuce.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt_zhuce.ForeColor = System.Drawing.Color.White;
            this.bt_zhuce.Location = new System.Drawing.Point(186, 208);
            this.bt_zhuce.Name = "bt_zhuce";
            this.bt_zhuce.Size = new System.Drawing.Size(75, 23);
            this.bt_zhuce.TabIndex = 14;
            this.bt_zhuce.Text = "注册";
            this.bt_zhuce.UseVisualStyleBackColor = false;
            this.bt_zhuce.Click += new System.EventHandler(this.bt_zhuce_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 272);
            this.Controls.Add(this.bt_zhuce);
            this.Controls.Add(this.bt_denglu);
            this.Controls.Add(this.denglu);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "weblog";
            ((System.ComponentModel.ISupportInitialize)(this.denglu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_denglu;
        private System.Windows.Forms.PictureBox denglu;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_zhuce;
    }
}

