namespace SQLDoctor1
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Servers = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Instances = new System.Windows.Forms.TabPage();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.Checks = new System.Windows.Forms.TabPage();
            this.sqlCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.Results = new System.Windows.Forms.TabPage();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Servers.SuspendLayout();
            this.Instances.SuspendLayout();
            this.Checks.SuspendLayout();
            this.Results.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Servers);
            this.tabControl1.Controls.Add(this.Instances);
            this.tabControl1.Controls.Add(this.Checks);
            this.tabControl1.Controls.Add(this.Results);
            this.tabControl1.Location = new System.Drawing.Point(12, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(304, 278);
            this.tabControl1.TabIndex = 0;
            // 
            // Servers
            // 
            this.Servers.Controls.Add(this.richTextBox1);
            this.Servers.Location = new System.Drawing.Point(4, 22);
            this.Servers.Name = "Servers";
            this.Servers.Padding = new System.Windows.Forms.Padding(3);
            this.Servers.Size = new System.Drawing.Size(296, 252);
            this.Servers.TabIndex = 0;
            this.Servers.Text = "Servers";
            this.Servers.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(296, 252);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "localhost";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Instances
            // 
            this.Instances.Controls.Add(this.listBox3);
            this.Instances.Location = new System.Drawing.Point(4, 22);
            this.Instances.Name = "Instances";
            this.Instances.Padding = new System.Windows.Forms.Padding(3);
            this.Instances.Size = new System.Drawing.Size(296, 252);
            this.Instances.TabIndex = 1;
            this.Instances.Text = "Instances";
            this.Instances.UseVisualStyleBackColor = true;
            // 
            // listBox3
            // 
            this.listBox3.DisplayMember = "SQLInstance";
            this.listBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(3, 3);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(290, 246);
            this.listBox3.TabIndex = 0;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // Checks
            // 
            this.Checks.Controls.Add(this.sqlCheckedListBox);
            this.Checks.Location = new System.Drawing.Point(4, 22);
            this.Checks.Name = "Checks";
            this.Checks.Padding = new System.Windows.Forms.Padding(3);
            this.Checks.Size = new System.Drawing.Size(296, 252);
            this.Checks.TabIndex = 2;
            this.Checks.Text = "Checks";
            this.Checks.UseVisualStyleBackColor = true;
            // 
            // sqlCheckedListBox
            // 
            this.sqlCheckedListBox.FormattingEnabled = true;
            this.sqlCheckedListBox.Items.AddRange(new object[] {
            "Full SQL Health Check",
            "SQL Server Version Query"});
            this.sqlCheckedListBox.Location = new System.Drawing.Point(0, 2);
            this.sqlCheckedListBox.Name = "sqlCheckedListBox";
            this.sqlCheckedListBox.Size = new System.Drawing.Size(296, 244);
            this.sqlCheckedListBox.TabIndex = 0;
            this.sqlCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.sqlCheckedListBox_SelectedIndexChanged);
            // 
            // Results
            // 
            this.Results.Controls.Add(this.listBox4);
            this.Results.Location = new System.Drawing.Point(4, 22);
            this.Results.Name = "Results";
            this.Results.Padding = new System.Windows.Forms.Padding(3);
            this.Results.Size = new System.Drawing.Size(296, 252);
            this.Results.TabIndex = 3;
            this.Results.Text = "Results";
            this.Results.UseVisualStyleBackColor = true;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(0, 0);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(300, 407);
            this.listBox4.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(304, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "Parse Server Names";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(349, 44);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(618, 407);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 43);
            this.button2.TabIndex = 6;
            this.button2.Text = "Clear Results";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(20, 414);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(304, 251);
            this.listBox2.TabIndex = 7;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(108, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Failed to Connect";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(979, 690);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Servers.ResumeLayout(false);
            this.Instances.ResumeLayout(false);
            this.Checks.ResumeLayout(false);
            this.Results.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Servers;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage Instances;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.TabPage Checks;
        private System.Windows.Forms.TabPage Results;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox sqlCheckedListBox;
    }
}

