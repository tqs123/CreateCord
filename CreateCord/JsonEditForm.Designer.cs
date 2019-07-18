namespace CreateCord
{
    partial class JsonEditForm
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
            this.rtb_jsonedit = new System.Windows.Forms.RichTextBox();
            this.b_ok = new System.Windows.Forms.Button();
            this.b_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb_jsonedit
            // 
            this.rtb_jsonedit.Location = new System.Drawing.Point(31, 12);
            this.rtb_jsonedit.Name = "rtb_jsonedit";
            this.rtb_jsonedit.Size = new System.Drawing.Size(836, 446);
            this.rtb_jsonedit.TabIndex = 0;
            this.rtb_jsonedit.Text = "";
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(685, 484);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 1;
            this.b_ok.Text = "确定";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_close
            // 
            this.b_close.Location = new System.Drawing.Point(792, 484);
            this.b_close.Name = "b_close";
            this.b_close.Size = new System.Drawing.Size(75, 23);
            this.b_close.TabIndex = 2;
            this.b_close.Text = "取消";
            this.b_close.UseVisualStyleBackColor = true;
            this.b_close.Click += new System.EventHandler(this.b_close_Click);
            // 
            // JsonEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 519);
            this.Controls.Add(this.b_close);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.rtb_jsonedit);
            this.Name = "JsonEditForm";
            this.Text = "JsonEditForm";
            this.Load += new System.EventHandler(this.JsonEditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_jsonedit;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_close;
    }
}