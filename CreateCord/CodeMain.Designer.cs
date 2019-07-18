namespace CreateCord
{
    partial class CodeMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvTables = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_choice = new System.Windows.Forms.Button();
            this.t_path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.表名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Json列 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Json格式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JsonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvTables);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(2, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 397);
            this.panel1.TabIndex = 12;
            // 
            // tvTables
            // 
            this.tvTables.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tvTables.Location = new System.Drawing.Point(0, 20);
            this.tvTables.Name = "tvTables";
            this.tvTables.Size = new System.Drawing.Size(200, 377);
            this.tvTables.TabIndex = 1;
            this.tvTables.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTables_AfterSelect_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 405);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_choice);
            this.groupBox2.Controls.Add(this.t_path);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(202, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 91);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生成策略";
            // 
            // b_choice
            // 
            this.b_choice.Location = new System.Drawing.Point(517, 43);
            this.b_choice.Name = "b_choice";
            this.b_choice.Size = new System.Drawing.Size(75, 23);
            this.b_choice.TabIndex = 10;
            this.b_choice.Text = "选择";
            this.b_choice.UseVisualStyleBackColor = true;
            this.b_choice.Click += new System.EventHandler(this.b_choice_Click);
            // 
            // t_path
            // 
            this.t_path.Location = new System.Drawing.Point(77, 43);
            this.t_path.Name = "t_path";
            this.t_path.ReadOnly = true;
            this.t_path.Size = new System.Drawing.Size(418, 21);
            this.t_path.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "保存路径：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(614, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "生成代码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.表名称,
            this.Json列,
            this.Json格式,
            this.JsonEdit});
            this.dgvColumns.Location = new System.Drawing.Point(210, 131);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowTemplate.Height = 23;
            this.dgvColumns.Size = new System.Drawing.Size(666, 300);
            this.dgvColumns.TabIndex = 14;
            this.dgvColumns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColumns_CellClick);
            // 
            // 表名称
            // 
            this.表名称.DataPropertyName = "表名称";
            this.表名称.HeaderText = "表名称";
            this.表名称.Name = "表名称";
            this.表名称.ReadOnly = true;
            this.表名称.Width = 170;
            // 
            // Json列
            // 
            this.Json列.DataPropertyName = "Json列";
            this.Json列.HeaderText = "Json列";
            this.Json列.Name = "Json列";
            this.Json列.ReadOnly = true;
            this.Json列.Width = 150;
            // 
            // Json格式
            // 
            this.Json格式.DataPropertyName = "Json格式";
            this.Json格式.HeaderText = "Json格式";
            this.Json格式.Name = "Json格式";
            this.Json格式.ReadOnly = true;
            this.Json格式.Width = 200;
            // 
            // JsonEdit
            // 
            this.JsonEdit.HeaderText = "Json编辑";
            this.JsonEdit.Name = "JsonEdit";
            this.JsonEdit.ReadOnly = true;
            this.JsonEdit.Text = "Json编辑";
            this.JsonEdit.UseColumnTextForButtonValue = true;
            // 
            // CodeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvColumns);
            this.Name = "CodeMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeMain";
            this.Load += new System.EventHandler(this.CodeMain_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvTables;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.Button b_choice;
        private System.Windows.Forms.TextBox t_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 表名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn Json列;
        private System.Windows.Forms.DataGridViewTextBoxColumn Json格式;
        private System.Windows.Forms.DataGridViewButtonColumn JsonEdit;
    }
}