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
    }
}
