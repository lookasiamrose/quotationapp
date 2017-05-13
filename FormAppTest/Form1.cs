using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace FormAppTest
{
    public partial class Form1 : Form
    {
        private Model model;
        private String[] urlsBOM;

        public Form1()
        {
            InitializeComponent();

            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = dataGridView1.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dataGridView1, true, null);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           /* model = new Model();
            model.setBOMsFromPath(urlsBOM);
            model.showAllBOMs();
            String[][] firstBOM = model.getFirstBOM();

            var rowCount = firstBOM.GetLength(0);
            var rowLength = firstBOM[0].GetLength(0);

            for (int i = 0; i < rowLength; i++) dataGridView1.Columns.Add(new DataGridViewColumn());

            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                var row = new DataGridViewRow();

                for (int columnIndex = 0; columnIndex < rowLength; ++columnIndex)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = firstBOM[rowIndex][columnIndex]
                    });
                }
                rows.Add(row);
            }
            dataGridView1.Rows.AddRange(rows.ToArray());*/
            BomInit firstBOMView = new BomInit();
            firstBOMView.Show();

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            urlsBOM = (String[]) e.Data.GetData(DataFormats.FileDrop, false);
            if(sender is Panel)
            {
                for(int i=0;i<urlsBOM.Length;i++)
                {
                    Label l = new Label();
                    Console.WriteLine(urlsBOM[i]);
                    l.Text = urlsBOM[i];
                    (sender as Panel).Controls.Add(l);
                }
            }
        }
    }
}
