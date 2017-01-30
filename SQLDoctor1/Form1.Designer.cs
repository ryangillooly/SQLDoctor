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
            this.components = new System.ComponentModel.Container();
            this.parseServerNamesButton = new System.Windows.Forms.Button();
            this.progressListBox = new System.Windows.Forms.ListBox();
            this.clearResults_Button = new System.Windows.Forms.Button();
            this.unvalSQLInst_ListBox = new System.Windows.Forms.ListBox();
            this.failedToConnectLabel = new System.Windows.Forms.Label();
            this.Results = new System.Windows.Forms.TabPage();
            this.Checks = new System.Windows.Forms.TabPage();
            this.runSQLChecks_Button = new System.Windows.Forms.Button();
            this.sqlChecks_CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.Instances = new System.Windows.Forms.TabPage();
            this.removeInstance_Button = new System.Windows.Forms.Button();
            this.moveToSQLChecks_Button = new System.Windows.Forms.Button();
            this.valSQLInst_ListBox = new System.Windows.Forms.ListBox();
            this.Servers = new System.Windows.Forms.TabPage();
            this.serverNameList = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inventoryDataSet = new SQLDoctor1.InventoryDataSet();
            this.instancesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.instancesTableAdapter = new SQLDoctor1.InventoryDataSetTableAdapters.InstancesTableAdapter();
            this.Instance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Results.SuspendLayout();
            this.Checks.SuspendLayout();
            this.Instances.SuspendLayout();
            this.Servers.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instancesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // parseServerNamesButton
            // 
            this.parseServerNamesButton.Location = new System.Drawing.Point(0, 264);
            this.parseServerNamesButton.Name = "parseServerNamesButton";
            this.parseServerNamesButton.Size = new System.Drawing.Size(293, 44);
            this.parseServerNamesButton.TabIndex = 4;
            this.parseServerNamesButton.Text = "Parse Server Names";
            this.parseServerNamesButton.UseVisualStyleBackColor = true;
            this.parseServerNamesButton.Click += new System.EventHandler(this.parseServerNames_Button_Click);
            // 
            // progressListBox
            // 
            this.progressListBox.FormattingEnabled = true;
            this.progressListBox.Location = new System.Drawing.Point(349, 44);
            this.progressListBox.Name = "progressListBox";
            this.progressListBox.Size = new System.Drawing.Size(618, 537);
            this.progressListBox.TabIndex = 5;
            // 
            // clearResults_Button
            // 
            this.clearResults_Button.Location = new System.Drawing.Point(349, 586);
            this.clearResults_Button.Name = "clearResults_Button";
            this.clearResults_Button.Size = new System.Drawing.Size(260, 43);
            this.clearResults_Button.TabIndex = 6;
            this.clearResults_Button.Text = "Clear Results";
            this.clearResults_Button.UseVisualStyleBackColor = true;
            this.clearResults_Button.Click += new System.EventHandler(this.clearResults_Button_Click);
            // 
            // unvalSQLInst_ListBox
            // 
            this.unvalSQLInst_ListBox.FormattingEnabled = true;
            this.unvalSQLInst_ListBox.Location = new System.Drawing.Point(0, 399);
            this.unvalSQLInst_ListBox.Name = "unvalSQLInst_ListBox";
            this.unvalSQLInst_ListBox.Size = new System.Drawing.Size(293, 186);
            this.unvalSQLInst_ListBox.TabIndex = 7;
            // 
            // failedToConnectLabel
            // 
            this.failedToConnectLabel.AutoSize = true;
            this.failedToConnectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.failedToConnectLabel.ForeColor = System.Drawing.Color.Red;
            this.failedToConnectLabel.Location = new System.Drawing.Point(82, 378);
            this.failedToConnectLabel.Name = "failedToConnectLabel";
            this.failedToConnectLabel.Size = new System.Drawing.Size(118, 17);
            this.failedToConnectLabel.TabIndex = 8;
            this.failedToConnectLabel.Text = "Failed to Connect";
            // 
            // Results
            // 
            this.Results.Controls.Add(this.dataGridView1);
            this.Results.Location = new System.Drawing.Point(4, 22);
            this.Results.Name = "Results";
            this.Results.Padding = new System.Windows.Forms.Padding(3);
            this.Results.Size = new System.Drawing.Size(296, 585);
            this.Results.TabIndex = 3;
            this.Results.Text = "Results";
            this.Results.UseVisualStyleBackColor = true;
            // 
            // Checks
            // 
            this.Checks.Controls.Add(this.runSQLChecks_Button);
            this.Checks.Controls.Add(this.sqlChecks_CheckedListBox);
            this.Checks.Location = new System.Drawing.Point(4, 22);
            this.Checks.Name = "Checks";
            this.Checks.Padding = new System.Windows.Forms.Padding(3);
            this.Checks.Size = new System.Drawing.Size(296, 585);
            this.Checks.TabIndex = 2;
            this.Checks.Text = "Tasks";
            this.Checks.UseVisualStyleBackColor = true;
            // 
            // runSQLChecks_Button
            // 
            this.runSQLChecks_Button.Location = new System.Drawing.Point(27, 301);
            this.runSQLChecks_Button.Name = "runSQLChecks_Button";
            this.runSQLChecks_Button.Size = new System.Drawing.Size(231, 88);
            this.runSQLChecks_Button.TabIndex = 7;
            this.runSQLChecks_Button.Text = "Run SQL Checks";
            this.runSQLChecks_Button.UseVisualStyleBackColor = true;
            this.runSQLChecks_Button.Click += new System.EventHandler(this.runSQLChecks_Button_Click);
            // 
            // sqlChecks_CheckedListBox
            // 
            this.sqlChecks_CheckedListBox.FormattingEnabled = true;
            this.sqlChecks_CheckedListBox.Items.AddRange(new object[] {
            "Full SQL Health Check",
            "SQL Server Version Query"});
            this.sqlChecks_CheckedListBox.Location = new System.Drawing.Point(0, 2);
            this.sqlChecks_CheckedListBox.Name = "sqlChecks_CheckedListBox";
            this.sqlChecks_CheckedListBox.Size = new System.Drawing.Size(296, 244);
            this.sqlChecks_CheckedListBox.TabIndex = 0;
            // 
            // Instances
            // 
            this.Instances.Controls.Add(this.removeInstance_Button);
            this.Instances.Controls.Add(this.moveToSQLChecks_Button);
            this.Instances.Controls.Add(this.failedToConnectLabel);
            this.Instances.Controls.Add(this.valSQLInst_ListBox);
            this.Instances.Controls.Add(this.unvalSQLInst_ListBox);
            this.Instances.Location = new System.Drawing.Point(4, 22);
            this.Instances.Name = "Instances";
            this.Instances.Padding = new System.Windows.Forms.Padding(3);
            this.Instances.Size = new System.Drawing.Size(296, 585);
            this.Instances.TabIndex = 1;
            this.Instances.Text = "Instances";
            this.Instances.UseVisualStyleBackColor = true;
            // 
            // removeInstance_Button
            // 
            this.removeInstance_Button.Location = new System.Drawing.Point(28, 308);
            this.removeInstance_Button.Name = "removeInstance_Button";
            this.removeInstance_Button.Size = new System.Drawing.Size(102, 40);
            this.removeInstance_Button.TabIndex = 7;
            this.removeInstance_Button.Text = "Remove";
            this.removeInstance_Button.UseVisualStyleBackColor = true;
            this.removeInstance_Button.Click += new System.EventHandler(this.removeInstance_Button_Click);
            // 
            // moveToSQLChecks_Button
            // 
            this.moveToSQLChecks_Button.Location = new System.Drawing.Point(172, 308);
            this.moveToSQLChecks_Button.Name = "moveToSQLChecks_Button";
            this.moveToSQLChecks_Button.Size = new System.Drawing.Size(118, 40);
            this.moveToSQLChecks_Button.TabIndex = 9;
            this.moveToSQLChecks_Button.Text = "Move to SQL Checks";
            this.moveToSQLChecks_Button.UseVisualStyleBackColor = true;
            this.moveToSQLChecks_Button.Click += new System.EventHandler(this.moveToSQLChecks_Button_Click);
            // 
            // valSQLInst_ListBox
            // 
            this.valSQLInst_ListBox.DisplayMember = "SQLInstance";
            this.valSQLInst_ListBox.FormattingEnabled = true;
            this.valSQLInst_ListBox.Location = new System.Drawing.Point(0, 0);
            this.valSQLInst_ListBox.Name = "valSQLInst_ListBox";
            this.valSQLInst_ListBox.Size = new System.Drawing.Size(293, 290);
            this.valSQLInst_ListBox.TabIndex = 0;
            // 
            // Servers
            // 
            this.Servers.Controls.Add(this.parseServerNamesButton);
            this.Servers.Controls.Add(this.serverNameList);
            this.Servers.Location = new System.Drawing.Point(4, 22);
            this.Servers.Name = "Servers";
            this.Servers.Padding = new System.Windows.Forms.Padding(3);
            this.Servers.Size = new System.Drawing.Size(296, 585);
            this.Servers.TabIndex = 0;
            this.Servers.Text = "Servers";
            this.Servers.UseVisualStyleBackColor = true;
            // 
            // serverNameList
            // 
            this.serverNameList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverNameList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverNameList.DetectUrls = false;
            this.serverNameList.EnableAutoDragDrop = true;
            this.serverNameList.ForeColor = System.Drawing.SystemColors.MenuText;
            this.serverNameList.Location = new System.Drawing.Point(0, 0);
            this.serverNameList.Name = "serverNameList";
            this.serverNameList.Size = new System.Drawing.Size(293, 258);
            this.serverNameList.TabIndex = 0;
            this.serverNameList.Text = "localhost";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Servers);
            this.tabControl1.Controls.Add(this.Instances);
            this.tabControl1.Controls.Add(this.Checks);
            this.tabControl1.Controls.Add(this.Results);
            this.tabControl1.Location = new System.Drawing.Point(12, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(304, 611);
            this.tabControl1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Instance,
            this.Score});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(296, 288);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // inventoryDataSet
            // 
            this.inventoryDataSet.DataSetName = "InventoryDataSet";
            this.inventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // instancesBindingSource
            // 
            this.instancesBindingSource.DataMember = "Instances";
            this.instancesBindingSource.DataSource = this.inventoryDataSet;
            // 
            // instancesTableAdapter
            // 
            this.instancesTableAdapter.ClearBeforeFill = true;
            // 
            // Instance
            // 
            this.Instance.HeaderText = "Instance";
            this.Instance.Name = "Instance";
            this.Instance.ReadOnly = true;
            // 
            // Score
            // 
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(987, 646);
            this.Controls.Add(this.clearResults_Button);
            this.Controls.Add(this.progressListBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Results.ResumeLayout(false);
            this.Checks.ResumeLayout(false);
            this.Instances.ResumeLayout(false);
            this.Instances.PerformLayout();
            this.Servers.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instancesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button parseServerNamesButton;
        private System.Windows.Forms.ListBox progressListBox;
        private System.Windows.Forms.Button clearResults_Button;
        private System.Windows.Forms.ListBox unvalSQLInst_ListBox;
        private System.Windows.Forms.Label failedToConnectLabel;
        private System.Windows.Forms.TabPage Results;
        private System.Windows.Forms.TabPage Checks;
        private System.Windows.Forms.CheckedListBox sqlChecks_CheckedListBox;
        private System.Windows.Forms.TabPage Instances;
        private System.Windows.Forms.ListBox valSQLInst_ListBox;
        private System.Windows.Forms.TabPage Servers;
        private System.Windows.Forms.RichTextBox serverNameList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button moveToSQLChecks_Button;
        private System.Windows.Forms.Button runSQLChecks_Button;
        private System.Windows.Forms.Button removeInstance_Button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private InventoryDataSet inventoryDataSet;
        private System.Windows.Forms.BindingSource instancesBindingSource;
        private InventoryDataSetTableAdapters.InstancesTableAdapter instancesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
    }
}

