using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            butMode.Click += ButMode_Click;
            butModeLan.Click += ButModeLan_Click;
        }

        #region Event Handle
        private void ButModeLan_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButMode_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
