namespace CreateCord
{
    partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DBName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnIffrm = new System.Windows.Forms.Button();
            this.BtnTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DBName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Password);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.UId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Port);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ServerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 310);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新建连接";
            // 
            // DBName
            // 
            this.DBName.Location = new System.Drawing.Point(106, 140);
            this.DBName.Name = "DBName";
            this.DBName.Size = new System.Drawing.Size(164, 21);
            this.DBName.TabIndex = 9;
            this.DBName.Text = "postgres";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "数据库名称：";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(106, 249);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(164, 21);
            this.Password.TabIndex = 7;
            this.Password.Text = "postgres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码：";
            // 
            // UId
            // 
            this.UId.Location = new System.Drawing.Point(106, 197);
            this.UId.Name = "UId";
            this.UId.Size = new System.Drawing.Size(164, 21);
            this.UId.TabIndex = 5;
            this.UId.Text = "postgres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名：";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(106, 92);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(164, 21);
            this.Port.TabIndex = 3;
            this.Port.Text = "5432";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口号：";
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(106, 31);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(164, 21);
            this.ServerName.TabIndex = 1;
            this.ServerName.Text = "192.168.31.117";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "主机号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 7;
            // 
            // BtnIffrm
            // 
            this.BtnIffrm.Location = new System.Drawing.Point(218, 388);
            this.BtnIffrm.Name = "BtnIffrm";
            this.BtnIffrm.Size = new System.Drawing.Size(96, 35);
            this.BtnIffrm.TabIndex = 6;
            this.BtnIffrm.Text = "确认";
            this.BtnIffrm.UseVisualStyleBackColor = true;
            this.BtnIffrm.Click += new System.EventHandler(this.BtnIffrm_Click);
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(13, 388);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(85, 35);
            this.BtnTest.TabIndex = 5;
            this.BtnTest.Text = "测试连接";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 453);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnIffrm);
            this.Controls.Add(this.BtnTest);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置链接";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DBName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnIffrm;
        private System.Windows.Forms.Button BtnTest;
    }
}