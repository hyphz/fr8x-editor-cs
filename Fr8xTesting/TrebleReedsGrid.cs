using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fr8xTesting
{
    public partial class TrebleReedsGrid : UserControl
    {
        public TrebleReedsGrid()
        {
            InitializeComponent();
        }

        private TrebleRegister _tr;

        private void LoadRegister()
        {
            dataGridView1.Rows.Clear();
            for (int x = 0; x < 10; x++)
            {
                var voice = _tr.GetTrebleVoice(x);
                dataGridView1.Rows.Add(Constants.reedFeet[x],
                    voice.Patch.Pc,
                    voice.Enabled,
                    voice.Cassotto,
                    voice.Volume);
            }
        }
        public void SetTrebleRegister(TrebleRegister tr)
        {
            _tr = tr;
            LoadRegister();
        }

       
    }
}
