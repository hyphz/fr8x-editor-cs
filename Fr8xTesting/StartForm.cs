using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using BKSystem.IO;

namespace Fr8xTesting
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog {Filter = "Roland FR-8X set files (*.st8)|*.st8"};
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SetData x = new SetData(ofd.FileName);
                x.WriteToFile("test.st8");

            }
        }
    }
}
