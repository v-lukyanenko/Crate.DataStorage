namespace Crate.ManagementStudio
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SkipObjectsTbx = new System.Windows.Forms.TextBox();
            this.SelectObjectsTbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RefreshConnectionBtn = new System.Windows.Forms.Button();
            this.SelectObjectsBtn = new System.Windows.Forms.Button();
            this.ObjectsTbx = new System.Windows.Forms.ComboBox();
            this.ObjectsLbl = new System.Windows.Forms.Label();
            this.RepositoriesCbx = new System.Windows.Forms.ComboBox();
            this.RepositoryLbl = new System.Windows.Forms.Label();
            this.RightBtnContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectsGridView = new System.Windows.Forms.DataGridView();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ObjectsTab = new System.Windows.Forms.TabPage();
            this.PairsTab = new System.Windows.Forms.TabPage();
            this.PairsGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.RightBtnContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectsGridView)).BeginInit();
            this.TabControl.SuspendLayout();
            this.ObjectsTab.SuspendLayout();
            this.PairsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PairsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(910, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.connectToolStripMenuItem.Text = "Create Connection";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.SkipObjectsTbx);
            this.panel1.Controls.Add(this.SelectObjectsTbx);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.RefreshConnectionBtn);
            this.panel1.Controls.Add(this.SelectObjectsBtn);
            this.panel1.Controls.Add(this.ObjectsTbx);
            this.panel1.Controls.Add(this.ObjectsLbl);
            this.panel1.Controls.Add(this.RepositoriesCbx);
            this.panel1.Controls.Add(this.RepositoryLbl);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 39);
            this.panel1.TabIndex = 1;
            // 
            // SkipObjectsTbx
            // 
            this.SkipObjectsTbx.Enabled = false;
            this.SkipObjectsTbx.Location = new System.Drawing.Point(541, 9);
            this.SkipObjectsTbx.Name = "SkipObjectsTbx";
            this.SkipObjectsTbx.Size = new System.Drawing.Size(57, 20);
            this.SkipObjectsTbx.TabIndex = 9;
            this.SkipObjectsTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SkipObjectsTbx_KeyPress);
            // 
            // SelectObjectsTbx
            // 
            this.SelectObjectsTbx.Enabled = false;
            this.SelectObjectsTbx.Location = new System.Drawing.Point(439, 10);
            this.SelectObjectsTbx.Name = "SelectObjectsTbx";
            this.SelectObjectsTbx.Size = new System.Drawing.Size(57, 20);
            this.SelectObjectsTbx.TabIndex = 8;
            this.SelectObjectsTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectObjectsTbx_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Skip:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select top:";
            // 
            // RefreshConnectionBtn
            // 
            this.RefreshConnectionBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RefreshConnectionBtn.Location = new System.Drawing.Point(823, 6);
            this.RefreshConnectionBtn.Name = "RefreshConnectionBtn";
            this.RefreshConnectionBtn.Size = new System.Drawing.Size(75, 23);
            this.RefreshConnectionBtn.TabIndex = 5;
            this.RefreshConnectionBtn.Text = "Refresh";
            this.RefreshConnectionBtn.UseVisualStyleBackColor = true;
            this.RefreshConnectionBtn.Click += new System.EventHandler(this.RefreshConnectionBtn_Click);
            // 
            // SelectObjectsBtn
            // 
            this.SelectObjectsBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SelectObjectsBtn.Enabled = false;
            this.SelectObjectsBtn.Location = new System.Drawing.Point(604, 7);
            this.SelectObjectsBtn.Name = "SelectObjectsBtn";
            this.SelectObjectsBtn.Size = new System.Drawing.Size(75, 23);
            this.SelectObjectsBtn.TabIndex = 4;
            this.SelectObjectsBtn.Text = "Execute";
            this.SelectObjectsBtn.UseVisualStyleBackColor = true;
            this.SelectObjectsBtn.Click += new System.EventHandler(this.SelectObjectsBtn_Click);
            // 
            // ObjectsTbx
            // 
            this.ObjectsTbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjectsTbx.Enabled = false;
            this.ObjectsTbx.FormattingEnabled = true;
            this.ObjectsTbx.Location = new System.Drawing.Point(247, 9);
            this.ObjectsTbx.Name = "ObjectsTbx";
            this.ObjectsTbx.Size = new System.Drawing.Size(121, 21);
            this.ObjectsTbx.TabIndex = 3;
            // 
            // ObjectsLbl
            // 
            this.ObjectsLbl.AutoSize = true;
            this.ObjectsLbl.Location = new System.Drawing.Point(204, 12);
            this.ObjectsLbl.Name = "ObjectsLbl";
            this.ObjectsLbl.Size = new System.Drawing.Size(41, 13);
            this.ObjectsLbl.TabIndex = 2;
            this.ObjectsLbl.Text = "Object:";
            // 
            // RepositoriesCbx
            // 
            this.RepositoriesCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RepositoriesCbx.Enabled = false;
            this.RepositoriesCbx.FormattingEnabled = true;
            this.RepositoriesCbx.Location = new System.Drawing.Point(66, 9);
            this.RepositoriesCbx.Name = "RepositoriesCbx";
            this.RepositoriesCbx.Size = new System.Drawing.Size(121, 21);
            this.RepositoriesCbx.TabIndex = 1;
            this.RepositoriesCbx.SelectedIndexChanged += new System.EventHandler(this.RepositoriesTbx_SelectedIndexChanged);
            // 
            // RepositoryLbl
            // 
            this.RepositoryLbl.AutoSize = true;
            this.RepositoryLbl.Location = new System.Drawing.Point(3, 12);
            this.RepositoryLbl.Name = "RepositoryLbl";
            this.RepositoryLbl.Size = new System.Drawing.Size(60, 13);
            this.RepositoryLbl.TabIndex = 0;
            this.RepositoryLbl.Text = "Repository:";
            // 
            // RightBtnContextMenu
            // 
            this.RightBtnContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.RightBtnContextMenu.Name = "RightBtnContextMenu";
            this.RightBtnContextMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // ObjectsGridView
            // 
            this.ObjectsGridView.AllowUserToOrderColumns = true;
            this.ObjectsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectsGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.ObjectsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ObjectsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ObjectsGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.ObjectsGridView.Location = new System.Drawing.Point(-4, 0);
            this.ObjectsGridView.Name = "ObjectsGridView";
            this.ObjectsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ObjectsGridView.Size = new System.Drawing.Size(906, 388);
            this.ObjectsGridView.TabIndex = 3;
            this.ObjectsGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ObjectsGridView_CellBeginEdit);
            this.ObjectsGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ObjectsGridView_CellEndEdit);
            this.ObjectsGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ObjectsGridView_CellMouseUp);
            this.ObjectsGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.ObjectsGridView_UserDeletingRow);
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.ObjectsTab);
            this.TabControl.Controls.Add(this.PairsTab);
            this.TabControl.Location = new System.Drawing.Point(0, 65);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(910, 410);
            this.TabControl.TabIndex = 0;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // ObjectsTab
            // 
            this.ObjectsTab.Controls.Add(this.ObjectsGridView);
            this.ObjectsTab.Location = new System.Drawing.Point(4, 22);
            this.ObjectsTab.Name = "ObjectsTab";
            this.ObjectsTab.Size = new System.Drawing.Size(902, 384);
            this.ObjectsTab.TabIndex = 0;
            this.ObjectsTab.Text = "Objects";
            this.ObjectsTab.UseVisualStyleBackColor = true;
            // 
            // PairsTab
            // 
            this.PairsTab.Controls.Add(this.PairsGridView);
            this.PairsTab.Location = new System.Drawing.Point(4, 22);
            this.PairsTab.Name = "PairsTab";
            this.PairsTab.Size = new System.Drawing.Size(902, 384);
            this.PairsTab.TabIndex = 0;
            this.PairsTab.Text = "Pairs";
            this.PairsTab.UseVisualStyleBackColor = true;
            // 
            // PairsGridView
            // 
            this.PairsGridView.AllowUserToOrderColumns = true;
            this.PairsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PairsGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.PairsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PairsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PairsGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.PairsGridView.Location = new System.Drawing.Point(-2, -2);
            this.PairsGridView.Name = "PairsGridView";
            this.PairsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PairsGridView.Size = new System.Drawing.Size(906, 388);
            this.PairsGridView.TabIndex = 4;
            this.PairsGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.PairsGridView_CellBeginEdit);
            this.PairsGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.PairsGridView_CellEndEdit);
            this.PairsGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PairsGridView_CellMouseUp);
            this.PairsGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.PairsGridView_UserDeletingRow);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 475);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crate Management Studio";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.RightBtnContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ObjectsGridView)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ObjectsTab.ResumeLayout(false);
            this.PairsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PairsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.Label RepositoryLbl;
        private System.Windows.Forms.ComboBox RepositoriesCbx;
        private System.Windows.Forms.ComboBox ObjectsTbx;
        private System.Windows.Forms.Label ObjectsLbl;
        private System.Windows.Forms.Button SelectObjectsBtn;
        private System.Windows.Forms.Button RefreshConnectionBtn;
        private System.Windows.Forms.ContextMenuStrip RightBtnContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox SkipObjectsTbx;
        private System.Windows.Forms.TextBox SelectObjectsTbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ObjectsGridView;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage ObjectsTab;
        private System.Windows.Forms.TabPage PairsTab;
        private System.Windows.Forms.DataGridView PairsGridView;
    }
}

