namespace Crate.ManagementStudio
{
    partial class CreateConnection
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
            this.label1 = new System.Windows.Forms.Label();
            this.SourceTypeCb = new System.Windows.Forms.ComboBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SqlServerConnectionPnl = new System.Windows.Forms.Panel();
            this.InitialCatalogTbx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RememberPasswordChbx = new System.Windows.Forms.CheckBox();
            this.PasswordTbx = new System.Windows.Forms.TextBox();
            this.LoginTbx = new System.Windows.Forms.TextBox();
            this.AuthanticationCbx = new System.Windows.Forms.ComboBox();
            this.ServerNameTbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FilePnl = new System.Windows.Forms.Panel();
            this.OpenDirectoryBtn = new System.Windows.Forms.Button();
            this.FilePathTbx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.MySqlConnectionPnl = new System.Windows.Forms.Panel();
            this.MySqlPasswordTbx = new System.Windows.Forms.TextBox();
            this.MySqlUserNameTbx = new System.Windows.Forms.TextBox();
            this.MySqlPortTbx = new System.Windows.Forms.TextBox();
            this.MySqlDatabaseTbx = new System.Windows.Forms.TextBox();
            this.MySqlDataSourceTbx = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SqlServerConnectionPnl.SuspendLayout();
            this.FilePnl.SuspendLayout();
            this.MySqlConnectionPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source type:";
            // 
            // SourceTypeCb
            // 
            this.SourceTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceTypeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SourceTypeCb.FormattingEnabled = true;
            this.SourceTypeCb.Location = new System.Drawing.Point(112, 6);
            this.SourceTypeCb.Name = "SourceTypeCb";
            this.SourceTypeCb.Size = new System.Drawing.Size(324, 28);
            this.SourceTypeCb.TabIndex = 2;
            this.SourceTypeCb.SelectedIndexChanged += new System.EventHandler(this.SourceTypeCb_SelectedIndexChanged);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ConnectBtn.Location = new System.Drawing.Point(255, 221);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(88, 39);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Cancel.Location = new System.Drawing.Point(349, 221);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 39);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // SqlServerConnectionPnl
            // 
            this.SqlServerConnectionPnl.Controls.Add(this.InitialCatalogTbx);
            this.SqlServerConnectionPnl.Controls.Add(this.label6);
            this.SqlServerConnectionPnl.Controls.Add(this.RememberPasswordChbx);
            this.SqlServerConnectionPnl.Controls.Add(this.PasswordTbx);
            this.SqlServerConnectionPnl.Controls.Add(this.LoginTbx);
            this.SqlServerConnectionPnl.Controls.Add(this.AuthanticationCbx);
            this.SqlServerConnectionPnl.Controls.Add(this.ServerNameTbx);
            this.SqlServerConnectionPnl.Controls.Add(this.label5);
            this.SqlServerConnectionPnl.Controls.Add(this.label4);
            this.SqlServerConnectionPnl.Controls.Add(this.label3);
            this.SqlServerConnectionPnl.Controls.Add(this.label2);
            this.SqlServerConnectionPnl.Location = new System.Drawing.Point(1, 44);
            this.SqlServerConnectionPnl.Name = "SqlServerConnectionPnl";
            this.SqlServerConnectionPnl.Size = new System.Drawing.Size(447, 171);
            this.SqlServerConnectionPnl.TabIndex = 6;
            // 
            // InitialCatalogTbx
            // 
            this.InitialCatalogTbx.Location = new System.Drawing.Point(111, 38);
            this.InitialCatalogTbx.Name = "InitialCatalogTbx";
            this.InitialCatalogTbx.Size = new System.Drawing.Size(324, 20);
            this.InitialCatalogTbx.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(7, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Initial catalog:";
            // 
            // RememberPasswordChbx
            // 
            this.RememberPasswordChbx.AutoSize = true;
            this.RememberPasswordChbx.Location = new System.Drawing.Point(126, 143);
            this.RememberPasswordChbx.Name = "RememberPasswordChbx";
            this.RememberPasswordChbx.Size = new System.Drawing.Size(125, 17);
            this.RememberPasswordChbx.TabIndex = 8;
            this.RememberPasswordChbx.Text = "Remember password";
            this.RememberPasswordChbx.UseVisualStyleBackColor = true;
            // 
            // PasswordTbx
            // 
            this.PasswordTbx.Enabled = false;
            this.PasswordTbx.Location = new System.Drawing.Point(126, 117);
            this.PasswordTbx.Name = "PasswordTbx";
            this.PasswordTbx.Size = new System.Drawing.Size(309, 20);
            this.PasswordTbx.TabIndex = 7;
            // 
            // LoginTbx
            // 
            this.LoginTbx.Enabled = false;
            this.LoginTbx.Location = new System.Drawing.Point(126, 91);
            this.LoginTbx.Name = "LoginTbx";
            this.LoginTbx.Size = new System.Drawing.Size(309, 20);
            this.LoginTbx.TabIndex = 6;
            // 
            // AuthanticationCbx
            // 
            this.AuthanticationCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AuthanticationCbx.FormattingEnabled = true;
            this.AuthanticationCbx.Location = new System.Drawing.Point(112, 64);
            this.AuthanticationCbx.Name = "AuthanticationCbx";
            this.AuthanticationCbx.Size = new System.Drawing.Size(324, 21);
            this.AuthanticationCbx.TabIndex = 5;
            // 
            // ServerNameTbx
            // 
            this.ServerNameTbx.Location = new System.Drawing.Point(111, 12);
            this.ServerNameTbx.Name = "ServerNameTbx";
            this.ServerNameTbx.Size = new System.Drawing.Size(324, 20);
            this.ServerNameTbx.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(19, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(19, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Login:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(7, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Authentication:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server name:";
            // 
            // FilePnl
            // 
            this.FilePnl.Controls.Add(this.OpenDirectoryBtn);
            this.FilePnl.Controls.Add(this.FilePathTbx);
            this.FilePnl.Controls.Add(this.label7);
            this.FilePnl.Location = new System.Drawing.Point(1, 44);
            this.FilePnl.Name = "FilePnl";
            this.FilePnl.Size = new System.Drawing.Size(447, 171);
            this.FilePnl.TabIndex = 11;
            // 
            // OpenDirectoryBtn
            // 
            this.OpenDirectoryBtn.Location = new System.Drawing.Point(372, 57);
            this.OpenDirectoryBtn.Name = "OpenDirectoryBtn";
            this.OpenDirectoryBtn.Size = new System.Drawing.Size(63, 23);
            this.OpenDirectoryBtn.TabIndex = 2;
            this.OpenDirectoryBtn.Text = "Open";
            this.OpenDirectoryBtn.UseVisualStyleBackColor = true;
            this.OpenDirectoryBtn.Click += new System.EventHandler(this.OpenDirectoryBtn_Click);
            // 
            // FilePathTbx
            // 
            this.FilePathTbx.Location = new System.Drawing.Point(10, 59);
            this.FilePathTbx.Name = "FilePathTbx";
            this.FilePathTbx.Size = new System.Drawing.Size(356, 20);
            this.FilePathTbx.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(7, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Directory path:";
            // 
            // MySqlConnectionPnl
            // 
            this.MySqlConnectionPnl.Controls.Add(this.MySqlPasswordTbx);
            this.MySqlConnectionPnl.Controls.Add(this.MySqlUserNameTbx);
            this.MySqlConnectionPnl.Controls.Add(this.MySqlPortTbx);
            this.MySqlConnectionPnl.Controls.Add(this.MySqlDatabaseTbx);
            this.MySqlConnectionPnl.Controls.Add(this.MySqlDataSourceTbx);
            this.MySqlConnectionPnl.Controls.Add(this.label12);
            this.MySqlConnectionPnl.Controls.Add(this.label11);
            this.MySqlConnectionPnl.Controls.Add(this.label10);
            this.MySqlConnectionPnl.Controls.Add(this.label9);
            this.MySqlConnectionPnl.Controls.Add(this.label8);
            this.MySqlConnectionPnl.Location = new System.Drawing.Point(1, 44);
            this.MySqlConnectionPnl.Name = "MySqlConnectionPnl";
            this.MySqlConnectionPnl.Size = new System.Drawing.Size(447, 171);
            this.MySqlConnectionPnl.TabIndex = 3;
            // 
            // MySqlPasswordTbx
            // 
            this.MySqlPasswordTbx.Location = new System.Drawing.Point(78, 114);
            this.MySqlPasswordTbx.Name = "MySqlPasswordTbx";
            this.MySqlPasswordTbx.Size = new System.Drawing.Size(357, 20);
            this.MySqlPasswordTbx.TabIndex = 9;
            // 
            // MySqlUserNameTbx
            // 
            this.MySqlUserNameTbx.Location = new System.Drawing.Point(78, 88);
            this.MySqlUserNameTbx.Name = "MySqlUserNameTbx";
            this.MySqlUserNameTbx.Size = new System.Drawing.Size(357, 20);
            this.MySqlUserNameTbx.TabIndex = 8;
            // 
            // MySqlPortTbx
            // 
            this.MySqlPortTbx.Location = new System.Drawing.Point(78, 62);
            this.MySqlPortTbx.Name = "MySqlPortTbx";
            this.MySqlPortTbx.Size = new System.Drawing.Size(357, 20);
            this.MySqlPortTbx.TabIndex = 7;
            // 
            // MySqlDatabaseTbx
            // 
            this.MySqlDatabaseTbx.Location = new System.Drawing.Point(78, 36);
            this.MySqlDatabaseTbx.Name = "MySqlDatabaseTbx";
            this.MySqlDatabaseTbx.Size = new System.Drawing.Size(357, 20);
            this.MySqlDatabaseTbx.TabIndex = 6;
            // 
            // MySqlDataSourceTbx
            // 
            this.MySqlDataSourceTbx.Location = new System.Drawing.Point(78, 10);
            this.MySqlDataSourceTbx.Name = "MySqlDataSourceTbx";
            this.MySqlDataSourceTbx.Size = new System.Drawing.Size(357, 20);
            this.MySqlDataSourceTbx.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Password:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "User name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Port:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Database:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Datasource:";
            // 
            // CreateConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 266);
            this.Controls.Add(this.MySqlConnectionPnl);
            this.Controls.Add(this.FilePnl);
            this.Controls.Add(this.SqlServerConnectionPnl);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.SourceTypeCb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Connection";
            this.SqlServerConnectionPnl.ResumeLayout(false);
            this.SqlServerConnectionPnl.PerformLayout();
            this.FilePnl.ResumeLayout(false);
            this.FilePnl.PerformLayout();
            this.MySqlConnectionPnl.ResumeLayout(false);
            this.MySqlConnectionPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SourceTypeCb;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Panel SqlServerConnectionPnl;
        private System.Windows.Forms.TextBox PasswordTbx;
        private System.Windows.Forms.TextBox LoginTbx;
        private System.Windows.Forms.ComboBox AuthanticationCbx;
        private System.Windows.Forms.TextBox ServerNameTbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox RememberPasswordChbx;
        private System.Windows.Forms.TextBox InitialCatalogTbx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel FilePnl;
        private System.Windows.Forms.TextBox FilePathTbx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button OpenDirectoryBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel MySqlConnectionPnl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox MySqlPasswordTbx;
        private System.Windows.Forms.TextBox MySqlUserNameTbx;
        private System.Windows.Forms.TextBox MySqlPortTbx;
        private System.Windows.Forms.TextBox MySqlDatabaseTbx;
        private System.Windows.Forms.TextBox MySqlDataSourceTbx;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}