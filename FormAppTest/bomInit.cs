using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppTest
{
    public partial class BomInit : Form
    {
        public BomInit()
        {
            InitializeComponent();
        }
        public BomInit(String[][] bomArg)
        {
            InitializeComponent();
            gridInit();

            List<DataGridViewRow> rows = getDataGridRowsFromBOM(bomArg);
            for (int i = 0; i < rows.ElementAt(0).Cells.Count; i++) bomViewGrid.Columns.Add(new DataGridViewColumn());
            bomViewGrid.Rows.AddRange(rows.ToArray());
        }
        private void gridInit()
        {
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = bomViewGrid.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(bomViewGrid, true, null);
            }
        }
        private List<DataGridViewRow> getDataGridRowsFromBOM(String[][] bomArg)
        {
            var rowCount = bomArg.GetLength(0);
            var rowLength = bomArg[0].GetLength(0);

            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                var row = new DataGridViewRow();

                for (int columnIndex = 0; columnIndex < rowLength; ++columnIndex)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = bomArg[rowIndex][columnIndex]
                    });
                }
                rows.Add(row);
            }
            return rows;
        }

        private void bomViewGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView)
            {
                if (e.RowIndex != -1) //check if not the header
                {
                    if ((sender as DataGridView).CurrentCell != null && (sender as DataGridView).CurrentCell.Value != null) //check if the cell exists
                        MessageBox.Show((sender as DataGridView).CurrentCell.Value.ToString());
                }
            }
        }

        private void BomInit_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Perform double click on the header to choose the 'group by' entity", "Step 1", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void BomInit_Load(object sender, EventArgs e)
        {
            /*
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
             */
        }
    }
}
