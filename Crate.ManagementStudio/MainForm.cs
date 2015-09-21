using System;
using System.Collections.Generic;
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
            CreateConnectionShowDialog();
        }

        private void CreateConnectionShowDialog()
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

            var repositories = _dc.GetRepositories().ToArray();
            RepositoriesCbx.Enabled = true;
            RepositoriesCbx.Items.Clear();
            RepositoriesCbx.Items.AddRange(repositories);

            if (RepositoriesCbx.Items.Count > 0)
            {
                RepositoriesCbx.SelectedIndex = 0;

                var objects = _dc.GetObjects((string)RepositoriesCbx.SelectedItem).ToArray();
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
                    dc = new FileContext(currentConnection.ConnectionString, "Test");
                    break;

                case SourceType.SqlServer:
                    dc = new SqlServerContext(currentConnection.ConnectionString, "Test");
                    break;

                case SourceType.MySql:
                    dc = new MySqlContext(currentConnection.ConnectionString, "Test");
                    break;
            }

            return dc;
        }

        private void RepositoriesTbx_SelectedIndexChanged(object sender, EventArgs e)
        {

            var isObjectsTabSelected = TabControl.SelectedIndex == 0;

            if (isObjectsTabSelected)
            {
                var objects = _dc.GetObjects((string)RepositoriesCbx.SelectedItem).ToArray();
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
        }

        private void SelectObjectsBtn_Click(object sender, EventArgs e)
        {
            _currentObject = (string)ObjectsTbx.SelectedItem;
            _currentRepository = (string)RepositoriesCbx.SelectedItem;

            if (TabControl.SelectedIndex == 0)
                ExecuteObjects();
            else
                ExecutePairs();
        }

        private void ExecutePairs()
        {
            PairsGridView.Columns.Clear();

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

            var pairs = _dc.Pairs.GetAllFromCrate((string)RepositoriesCbx.SelectedItem).Skip(skip).Take(take).ToList();

            if (pairs.Count == 0)
                return;

            PairsGridView.Columns.Add("Key", "Key");
            PairsGridView.Columns.Add("Value", "Value");

            var index = 0;
            //Add rows
            foreach (var array in pairs.Select(row => new List<object> { row.Key, row.Value }))
            {
                PairsGridView.Rows.Add(array.ToArray());

                var testRow = PairsGridView.Rows[index];
                testRow.Cells[0].ReadOnly = true;

                index++;
            }
        }

        private void ExecuteObjects()
        {
            ClearOldObjectsData();

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

            var currentObject = _dc.GetObjectStructure(_currentObject, (string)RepositoriesCbx.SelectedItem);
            _titles = currentObject.Select(c => c.Key).ToList();

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
            var repository = (string)RepositoriesCbx.SelectedItem;
            var objectType = _currentObject;
            return _dc.Select(repository, objectType);
        }

        private void ClearOldObjectsData()
        {
            ObjectsGridView.Columns.Clear();
            ObjectsGridView.Rows.Clear();
        }

        private void RefreshConnectionBtn_Click(object sender, EventArgs e)
        {
            if (_currentConnection == new Connection())
                return;

            SelectObjectsTbx.Text = "100";
            SkipObjectsTbx.Text = "0";
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

                var newObject = new Dictionary<string, string>();
                var update = true;

                foreach (var title in _titles)
                {
                    var cellValue = row.Cells[title].Value;

                    //Create a new object
                    if (row.Cells["Id"].Value == null)
                    {
                        update = false;

                        if (title == "Id")
                            newObject[title] = Guid.NewGuid().ToString();
                        else
                        {
                            newObject[title] = cellValue == null ? string.Empty : cellValue.ToString();
                        }

                        if (cellValue != null)
                        {
                            var value = cellValue.ToString();
                            editableItems.Add(title, value);
                        }
                    }
                    //Update the old one
                    else
                    {
                        var value = cellValue.ToString();
                        editableItems.Add(title, value);
                    }
                }

                var rep = new Repository(_currentRepository);

                if (update)
                {
                    if (_dc.CheckDataTypes(editableItems, _currentObject, _currentRepository))
                    {
                        ObjectsGridView.CurrentCell.ErrorText = "";
                        rep.UpdateFromDictionary(editableItems, _currentObject);
                        _dc.SubmitChanges(rep);
                    }
                    else
                    {
                        ObjectsGridView.CurrentCell.ErrorText = "Wrong data type! Changes cannot be saved!";
                    }
                }
                else
                {
                    if (_dc.CheckDataTypes(editableItems, _currentObject, _currentRepository))
                    {
                        var validation = newObject.Any(c => c.Value == string.Empty);
                        if (!validation)
                        {
                            rep.AddFromDictionary(newObject, _currentObject);
                            _dc.SubmitChanges(rep);
                        }
                    }
                    else
                    {
                        ObjectsGridView.CurrentCell.ErrorText = "Wrong data type! Changes cannot be saved!";
                    }
                }
            }
        }

        private void ObjectsGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteObjectRow(e.Row.Index);
        }

        private void DeleteObjectRow(int rowIndex)
        {
            var row = ObjectsGridView.Rows[rowIndex];

            var idRow = row.Cells["Id"].Value;

            if (idRow == null)
                return;

            var id = idRow.ToString();

            var rep = new Repository(_currentRepository);
            rep.Remove(Guid.Parse(id));
            _dc.SubmitChanges(rep);
        }

        private void ObjectsGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1)
                    return;

                ObjectsGridView.Rows[e.RowIndex].Selected = true;
                _rowIndex = e.RowIndex;
                ObjectsGridView.CurrentCell = ObjectsGridView.Rows[e.RowIndex].Cells[1];

                if (ObjectsGridView.Rows.Count - 1 != _rowIndex)
                    RightBtnContextMenu.Show(Cursor.Position);
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dc.Pairs == null || _dc == null)
                return;

            var isObjectsTabSelected = TabControl.SelectedIndex == 0;
            ObjectsTbx.Enabled = isObjectsTabSelected;
            ObjectsLbl.Enabled = isObjectsTabSelected;

            RepositoryLbl.Text = isObjectsTabSelected ? "Repository:" : "Crate:";

            if (!isObjectsTabSelected)
            {
                var crates = _dc.Pairs.GetCrates();
                RepositoriesCbx.Items.Clear();

                foreach (var crate in crates)
                    RepositoriesCbx.Items.Add(crate);
            }
            else
            {
                var repositories = _dc.GetRepositories().ToArray();
                RepositoriesCbx.Items.Clear();
                RepositoriesCbx.Items.AddRange(repositories);
            }

            if (RepositoriesCbx.Items.Count > 0)
                RepositoriesCbx.SelectedIndex = 0;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            CreateConnectionShowDialog();
        }

        private void PairsGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            PairsGridView.Tag = PairsGridView.CurrentCell.Value;
        }

        private void PairsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (PairsGridView.Tag != PairsGridView.CurrentCell.Value)
            {
                var row = PairsGridView.Rows[e.RowIndex];

                if (row.Cells["Key"].Value != null && row.Cells["Value"].Value != null)
                {
                    var key = row.Cells["Key"].Value.ToString();
                    var value = row.Cells["Value"].Value.ToString();

                    if (PairsGridView.Tag != null && _dc.Pairs.IfExists(key))
                        _dc.Pairs.Update(key, value);
                    else
                    {
                        if (!_dc.Pairs.IfExists(key))
                        {
                            _dc.Pairs.Add(key, value);
                            row.Cells["Key"].ReadOnly = true;

                            row.Cells["Key"].Style.BackColor = Color.White;
                            row.Cells["Key"].Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            row.Cells["Key"].Style.BackColor = Color.OrangeRed;
                            row.Cells["Key"].Style.ForeColor = Color.White;
                        }
                    }
                }
            }
        }

        private void PairsGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            RemovePair(e.Row.Index);
        }

        private void RemovePair(int key)
        {
            var row = PairsGridView.Rows[key];
            var keyValue = row.Cells["Key"].Value.ToString();
            _dc.Pairs.Remove(keyValue);
        }

        private void PairsGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1)
                    return;

                PairsGridView.Rows[e.RowIndex].Selected = true;
                _rowIndex = e.RowIndex;
                PairsGridView.CurrentCell = PairsGridView.Rows[e.RowIndex].Cells[1];

                if (PairsGridView.Rows.Count - 1 != _rowIndex)
                    RightBtnContextMenu.Show(Cursor.Position);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isObjectsTabSelected = TabControl.SelectedIndex == 0;

            var dialogResult = MessageBox.Show(Resources.MainForm_DeleteItemQuestion, Resources.MainForm_DeleteItem,
                    MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (isObjectsTabSelected)
                {
                    DeleteObjectRow(_rowIndex);
                    ObjectsGridView.Rows.RemoveAt(_rowIndex);
                }
                else
                {
                    var row = PairsGridView.Rows[_rowIndex];
                    var keyRow = row.Cells["Key"].Value.ToString();

                    _dc.Pairs.Remove(keyRow);
                    PairsGridView.Rows.RemoveAt(_rowIndex);
                }
            }
        }

        private IDataContext _dc;
        private Connection _currentConnection = new Connection();
        private List<Dictionary<string, object>> _objects;
        private List<string> _titles;
        private int _rowIndex;
        private string _currentObject;
        private string _currentRepository;
    }
}

