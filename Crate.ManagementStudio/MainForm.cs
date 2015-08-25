using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Crate.Core.DataContext;
using Crate.Core.Repositories;
using Crate.ManagementStudio.Properties;

namespace Crate.ManagementStudio
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            RefreshConnectionBtn.Enabled = false;
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var connection = new CreateConnection())
            {
                var result = connection.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _currentConnection = connection.CurrentConnection;
                    CreateConnection();
                }
            }
        }

        private void CreateConnection()
        {
            _dc = CreateDataContext(_currentConnection);

            if (!_dc.CheckConnection())
            {
                MessageBox.Show(Resources.MainForm_CreateConnectionFailed);
                return;
            }

            var repositories = _dc.GetRepositories().ToArray();
            RepositoriesTbx.Enabled = true;
            RepositoriesTbx.Items.Clear();
            RepositoriesTbx.Items.AddRange(repositories);

            if (RepositoriesTbx.Items.Count > 0)
            {
                RepositoriesTbx.SelectedIndex = 0;

                var objects = _dc.GetObjects((string)RepositoriesTbx.SelectedItem).ToArray();
                ObjectsTbx.Enabled = true;
                ObjectsTbx.Items.Clear();
                ObjectsTbx.Items.AddRange(objects);

                if (ObjectsTbx.Items.Count > 0)
                {
                    ObjectsTbx.SelectedIndex = 0;
                    SelectObjectsBtn.Enabled = true;

                    SelectObjectsTbx.Enabled = true;
                    SkipObjectsTbx.Enabled = true;

                    SelectObjectsTbx.Text = "100";
                    SkipObjectsTbx.Text = "0";
                }
            }

            RefreshConnectionBtn.Enabled = true;
        }

        private static IDataContext CreateDataContext(Connection currentConnection)
        {
            IDataContext dc = null;

            switch (currentConnection.SourceType)
            {
                case SourceType.File:
                    dc = new FileContext(currentConnection.Options);
                    break;

                case SourceType.SqlServer:
                    dc = new SqlServerContext(currentConnection.Options);
                    break;

                case SourceType.MySql:
                    dc = new MySqlContext(currentConnection.Options);
                    break;
            }

            return dc;
        }

        private void RepositoriesTbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            var objects = _dc.GetObjects((string)RepositoriesTbx.SelectedItem).ToArray();
            ObjectsTbx.Items.Clear();
            ObjectsTbx.Items.AddRange(objects);

            if (ObjectsTbx.Items.Count > 0)
            {
                ObjectsTbx.SelectedIndex = 0;
                ObjectsTbx.Enabled = true;
                SelectObjectsBtn.Enabled = true;
            }
            else
            {
                ObjectsTbx.Enabled = false;
                SelectObjectsBtn.Enabled = false;
            }
        }

        private List<Dictionary<string, object>> _objects;
        private List<string> _titles;

        private void SelectObjectsBtn_Click(object sender, EventArgs e)
        {
            ClearOldData();

            int take;
            int skip;
           
            var takeIsParced = int.TryParse(SelectObjectsTbx.Text, out take);
            var skipIsParced = int.TryParse(SkipObjectsTbx.Text, out skip);

            if (!takeIsParced)
            {
                SelectObjectsTbx.Text = "100";
                take = 100;
            }

            if (!skipIsParced)
            {
                SkipObjectsTbx.Text = "0";
                skip = 0;
            }

            _objects = GetObjects().Skip(skip).Take(take).ToList();

            if (_objects.Count == 0)
                return;

            _titles = _objects[0].Select(c => c.Key).ToList();

            //Add titles
            foreach (var title in _titles)
                ObjectsGridView.Columns.Add(title, title);

            //Add rows
            foreach (object[] row in _objects.Select(item => item.Select(c => c.Value.ToString()).ToArray()))
                ObjectsGridView.Rows.Add(row);

            ObjectsGridView.Columns[0].Visible = false;
        }

        private IEnumerable<Dictionary<string, object>> GetObjects()
        {
            var repository = (string)RepositoriesTbx.SelectedItem;
            var objectType = (string)ObjectsTbx.SelectedItem;
            return _dc.Select(repository, objectType);
        }

        private void ClearOldData()
        {
            ObjectsGridView.Columns.Clear();
            ObjectsGridView.Rows.Clear();
        }

        private void RefreshConnectionBtn_Click(object sender, EventArgs e)
        {
            if (_currentConnection == new Connection())
                return;

            CreateConnection();
        }

        private IDataContext _dc;
        private Connection _currentConnection = new Connection();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resources.MainForm_DeleteItemQuestion, Resources.MainForm_DeleteItem, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
               
            }
        }

        private void ObjectsListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RightBtnContextMenu.Show(Cursor.Position);
            }
        }

        private void SelectObjectsTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = DigitsOnly(e);
        }

        private void SkipObjectsTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = DigitsOnly(e);
        }

        private static bool DigitsOnly(KeyPressEventArgs e)
        {
            return (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void ObjectsGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ObjectsGridView.Tag = ObjectsGridView.CurrentCell.Value;
        }

        private void ObjectsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (ObjectsGridView.Tag != ObjectsGridView.CurrentCell.Value)
            {
                var editableItems = new Dictionary<string, string>();

                var row = ObjectsGridView.Rows[e.RowIndex];

                foreach (var title in _titles)
                {
                    var value = row.Cells[title].Value.ToString();
                    editableItems.Add(title, value);
                }

                var rep = new Repository(RepositoriesTbx.SelectedItem.ToString());
                rep.UpdateFromDictionary(editableItems);
                _dc.SubmitChanges(rep);
            }
        }

        private void ObjectsGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = ObjectsGridView.Rows[e.Row.Index];
            var id = row.Cells["Id"].Value.ToString();

            var rep = new Repository(RepositoriesTbx.SelectedItem.ToString());
            rep.Remove(Guid.Parse(id));
            _dc.SubmitChanges(rep);
        }
    }
}

