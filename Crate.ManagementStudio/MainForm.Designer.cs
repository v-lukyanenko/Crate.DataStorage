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
            this.label2 = new System.Windows.Forms.Label();
            this.RepositoriesTbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RightBtnContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectsGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.RightBtnContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectsGridView)).BeginInit();
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.RepositoriesTbx);
            this.panel1.Controls.Add(this.label1);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Object:";
            // 
            // RepositoriesTbx
            // 
            this.RepositoriesTbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RepositoriesTbx.Enabled = false;
            this.RepositoriesTbx.FormattingEnabled = true;
            this.RepositoriesTbx.Location = new System.Drawing.Point(66, 9);
            this.RepositoriesTbx.Name = "RepositoriesTbx";
            this.RepositoriesTbx.Size = new System.Drawing.Size(121, 21);
            this.RepositoriesTbx.TabIndex = 1;
            this.RepositoriesTbx.SelectedIndexChanged += new System.EventHandler(this.RepositoriesTbx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Repository:";
            // 
            // RightBtnContextMenu
            // 
            this.RightBtnContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.RightBtnContextMenu.Name = "RightBtnContextMenu";
            this.RightBtnContextMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
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
            this.ObjectsGridView.Location = new System.Drawing.Point(0, 70);
            this.ObjectsGridView.Name = "ObjectsGridView";
            this.ObjectsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ObjectsGridView.Size = new System.Drawing.Size(910, 406);
            this.ObjectsGridView.TabIndex = 3;
            this.ObjectsGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ObjectsGridView_CellBeginEdit);
            this.ObjectsGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ObjectsGridView_CellEndEdit);
            this.ObjectsGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.ObjectsGridView_UserDeletingRow);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 475);
            this.Controls.Add(this.ObjectsGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Crate Management Studio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.RightBtnContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ObjectsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RepositoriesTbx;
        private System.Windows.Forms.ComboBox ObjectsTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectObjectsBtn;
        private System.Windows.Forms.Button RefreshConnectionBtn;
        private System.Windows.Forms.ContextMenuStrip RightBtnContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox SkipObjectsTbx;
        private System.Windows.Forms.TextBox SelectObjectsTbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ObjectsGridView;
    }
}

