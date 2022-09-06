
namespace Server.Forms
{
    partial class FromRecovery
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPasswords = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewClients = new System.Windows.Forms.ListView();
            this.listViewPasswords = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPasswords = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkUrl = new System.Windows.Forms.CheckBox();
            this.chkPassword = new System.Windows.Forms.CheckBox();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPasswords.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPasswords);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(0, 21);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 540);
            this.tabControl.TabIndex = 1;
            // 
            // tabPasswords
            // 
            this.tabPasswords.Controls.Add(this.tableLayoutPanel1);
            this.tabPasswords.Location = new System.Drawing.Point(4, 22);
            this.tabPasswords.Margin = new System.Windows.Forms.Padding(4);
            this.tabPasswords.Name = "tabPasswords";
            this.tabPasswords.Padding = new System.Windows.Forms.Padding(4);
            this.tabPasswords.Size = new System.Drawing.Size(976, 514);
            this.tabPasswords.TabIndex = 0;
            this.tabPasswords.Text = "Passwords";
            this.tabPasswords.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.listViewClients, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewPasswords, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(968, 506);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // listViewClients
            // 
            this.listViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewClients.FullRowSelect = true;
            this.listViewClients.HideSelection = false;
            this.listViewClients.Location = new System.Drawing.Point(4, 4);
            this.listViewClients.Margin = new System.Windows.Forms.Padding(4);
            this.listViewClients.MultiSelect = false;
            this.listViewClients.Name = "listViewClients";
            this.listViewClients.Size = new System.Drawing.Size(282, 498);
            this.listViewClients.TabIndex = 1;
            this.listViewClients.UseCompatibleStateImageBehavior = false;
            this.listViewClients.View = System.Windows.Forms.View.List;
            this.listViewClients.SelectedIndexChanged += new System.EventHandler(this.listViewClients_SelectedIndexChanged);
            // 
            // listViewPasswords
            // 
            this.listViewPasswords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderPasswords,
            this.columnHeaderUrl,
            this.columnHeaderTarget});
            this.listViewPasswords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPasswords.GridLines = true;
            this.listViewPasswords.HideSelection = false;
            this.listViewPasswords.LabelEdit = true;
            this.listViewPasswords.Location = new System.Drawing.Point(294, 4);
            this.listViewPasswords.Margin = new System.Windows.Forms.Padding(4);
            this.listViewPasswords.MultiSelect = false;
            this.listViewPasswords.Name = "listViewPasswords";
            this.listViewPasswords.Size = new System.Drawing.Size(670, 498);
            this.listViewPasswords.TabIndex = 0;
            this.listViewPasswords.UseCompatibleStateImageBehavior = false;
            this.listViewPasswords.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 150;
            // 
            // columnHeaderPasswords
            // 
            this.columnHeaderPasswords.Text = "Password";
            this.columnHeaderPasswords.Width = 150;
            // 
            // columnHeaderUrl
            // 
            this.columnHeaderUrl.Text = "Url";
            this.columnHeaderUrl.Width = 300;
            // 
            // columnHeaderTarget
            // 
            this.columnHeaderTarget.Text = "Target";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Search : ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(461, 21);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(109, 17);
            this.chkAll.TabIndex = 12;
            this.chkAll.Text = "Seach in all client";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // chkUrl
            // 
            this.chkUrl.AutoSize = true;
            this.chkUrl.Checked = true;
            this.chkUrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUrl.Location = new System.Drawing.Point(832, 20);
            this.chkUrl.Name = "chkUrl";
            this.chkUrl.Size = new System.Drawing.Size(39, 17);
            this.chkUrl.TabIndex = 9;
            this.chkUrl.Text = "Url";
            this.chkUrl.UseVisualStyleBackColor = true;
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.Location = new System.Drawing.Point(713, 20);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new System.Drawing.Size(72, 17);
            this.chkPassword.TabIndex = 10;
            this.chkPassword.Text = "Password";
            this.chkPassword.UseVisualStyleBackColor = true;
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Location = new System.Drawing.Point(616, 21);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(54, 17);
            this.chkName.TabIndex = 11;
            this.chkName.Text = "Name";
            this.chkName.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(897, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 20);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(240, 19);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(188, 20);
            this.txtsearch.TabIndex = 14;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // FromRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkUrl);
            this.Controls.Add(this.chkPassword);
            this.Controls.Add(this.chkName);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tabControl);
            this.Name = "FromRecovery";
            this.Text = "FromRecovery";
            this.tabControl.ResumeLayout(false);
            this.tabPasswords.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPasswords;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listViewClients;
        private System.Windows.Forms.ListView listViewPasswords;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderPasswords;
        private System.Windows.Forms.ColumnHeader columnHeaderUrl;
        private System.Windows.Forms.ColumnHeader columnHeaderTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkUrl;
        private System.Windows.Forms.CheckBox chkPassword;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtsearch;
    }
}