using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Crate.Core.DataContext;

namespace Crate.ManagementStudio
{
    public partial class CreateConnection : Form
    {
        public Connection CurrentConnection { get; set; }

        public CreateConnection()
        {
            InitializeComponent();
            SourceTypesInit();

            AuthenticationTypesInit();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SourceTypesInit()
        {
            SourceTypeCb.DataSource = new BindingSource(SourceTypes(), null);
            SourceTypeCb.DisplayMember = "Value";
            SourceTypeCb.ValueMember = "Key";

            SourceTypeCb.SelectedIndex = 1;

            SqlServerConnectionPnl.Show();
            FilePnl.Hide();
            MySqlConnectionPnl.Hide();
        }

        private void AuthenticationTypesInit()
        {
            AuthanticationCbx.DataSource = new BindingSource(AuthenticationTypes(), null);
            SourceTypeCb.DisplayMember = "Value";
            SourceTypeCb.ValueMember = "Key";

            AuthanticationCbx.SelectedIndex = 0;
        }

        private static Dictionary<int, string> SourceTypes()
        {
            return new Dictionary<int, string>
            {
                {1, "File"}, 
                {2, "Sql Server"}, 
                {3, "MySql"}
            };
        }

        private static Dictionary<int, string> AuthenticationTypes()
        {
            return new Dictionary<int, string>
            {
                {1, "Windows Authentication"}, 
                {2, "Sql Server Authentication"}
            };
        }

        private void SourceTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = ((KeyValuePair<int, string>) SourceTypeCb.SelectedItem);

            switch (selectedItem.Key)
            {
                case 1:
                    FilePnl.Show();
                    SqlServerConnectionPnl.Hide();
                    MySqlConnectionPnl.Hide();
                    break;

                case 2:
                    SqlServerConnectionPnl.Show();
                    FilePnl.Hide();
                    MySqlConnectionPnl.Hide();
                    break;

                case 3:
                    MySqlConnectionPnl.Show();
                    SqlServerConnectionPnl.Hide();
                    FilePnl.Hide();
                    break;
            }
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            var selectedItem = ((KeyValuePair<int, string>)SourceTypeCb.SelectedItem);

            var sourceType = selectedItem.Key;

            switch (selectedItem.Key)
            {
                case 1:
                    FileConnection(sourceType);
                    break;

                case 2:
                    SqlServerConnection(sourceType);
                    break;

                case 3:
                    MySqlServerConnection(sourceType);
                    break;
            }

            Close();
            DialogResult = DialogResult.OK;
        }

        private void FileConnection(int sourceType)
        {
            CurrentConnection = new Connection
            {
                SourceType = (SourceType)sourceType,
                ConnectionString = FilePathTbx.Text
            };
        }

        private void SqlServerConnection(int sourceType)
        {
            var integratedSecurity = AuthanticationCbx.SelectedIndex == 0 ? "true" : "false";

            var connectionString = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security={2};",
                ServerNameTbx.Text, InitialCatalogTbx.Text, integratedSecurity);

            CurrentConnection = new Connection
            {
                SourceType = (SourceType)sourceType,
                ConnectionString = connectionString
            };
        }

        private void MySqlServerConnection(int sourceType)
        {
            var connectionString = string.Format(@"Datasource={0};Database={1};port={2};username={3};password={4};",
                MySqlDataSourceTbx.Text, 
                MySqlDatabaseTbx.Text,
                MySqlPortTbx.Text,
                MySqlUserNameTbx.Text,
                MySqlPasswordTbx.Text);

            CurrentConnection = new Connection
            {
                SourceType = (SourceType)sourceType,
                ConnectionString = connectionString
            };
        }

        private void OpenDirectoryBtn_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            FilePathTbx.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
