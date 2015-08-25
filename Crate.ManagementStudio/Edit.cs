using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Crate.ManagementStudio.Properties;

namespace Crate.ManagementStudio
{
    public partial class Edit : Form
    {
        public readonly Dictionary<string, string> Result = new Dictionary<string, string>();

        public Edit(Dictionary<string, string> items)
        {
            InitializeComponent();
            _items = items;

            GenerateForm();
        }

        private void GenerateForm()
        {
            int y = 20;
            foreach (var item in _items)
            {
                var tb = new TextBox
                {
                    Location = new Point(10, y),
                    Width = Width - 40,
                    Text = item.Value
                };

                var lb = new Label
                {
                    Location = new Point(10, tb.Location.Y - 15),
                    Text = item.Key + ":"
                };

                _textBoxes.Add(tb);

                Controls.Add(tb);
                Controls.Add(lb);

                if (item.Key == "Id")
                    tb.Enabled = false;

                y += 50;
            }

            const int btnWidth = 100;
            const int btnHeight = 30;
            int positionY = _textBoxes[_textBoxes.Count - 1].Location.Y + 30;

            var saveButton = new Button
            {
                Text = Resources.Edit_GenerateForm_Save,
                Location = new Point(Location.X + Width - btnWidth - 140, positionY),
                Size = new Size(btnWidth, btnHeight)
            };

            var discardButton = new Button
            {
                Text = Resources.Edit_GenerateForm_Discard,
                Location = new Point(Location.X + Width - btnWidth - 29, positionY),
                Size = new Size(btnWidth, btnHeight)
            };

            if (positionY + discardButton.Height < Height)
                Height = discardButton.Location.Y + discardButton.Height + 50;
            else
                Height = 800;

            Controls.Add(saveButton);
            Controls.Add(discardButton);

            saveButton.Click += SaveChangesButton_Click;
            discardButton.Click += DiscardChangesButton_Click;
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in _items)
            {
                Result.Add(item.Key, _textBoxes[i].Text);
                i++;
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DiscardChangesButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private readonly Dictionary<string, string> _items;
        private readonly List<TextBox> _textBoxes = new List<TextBox>();
    }
}
