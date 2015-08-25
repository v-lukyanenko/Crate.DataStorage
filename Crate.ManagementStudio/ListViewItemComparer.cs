using System;
using System.Collections;
using System.Windows.Forms;

namespace Crate.ManagementStudio
{
    class ListViewItemComparer : IComparer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItemComparer"/> class.
        /// </summary>
        public ListViewItemComparer()
        {
            _col = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItemComparer"/> class.
        /// </summary>
        /// <param name="column">The column.</param>
        public ListViewItemComparer(int column)
        {
            _col = column;
        }

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero <paramref name="x" /> is less than <paramref name="y" />. Zero <paramref name="x" /> equals <paramref name="y" />. Greater than zero <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public int Compare(object x, object y)
        {
            return String.CompareOrdinal(((ListViewItem)x).SubItems[_col].Text, ((ListViewItem)y).SubItems[_col].Text);
        }

        private readonly int _col;
    }
}
