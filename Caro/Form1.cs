using Caro.CaroManager;
using Caro.Setting;
using System;
using System.Windows.Forms;

namespace Caro
{
    public partial class Form1 : Form
    {
        private static CONST caroConst;
        private Manager manager;

        public Form1()
        {
            InitializeComponent();
            caroConst = new CONST();
            DrawMainForm(caroConst.numberOfRow, caroConst.numberOfColumn);
            manager = new Manager(this, pnlCaroBoard, caroConst);
            butMode.Click += ButMode_Click;
            butModeLan.Click += ButModeLan_Click;
            formGameMode.ShowDialog();
        }

        #region Event Handle
        private void ButModeLan_Click(object sender, EventArgs e)
        {
            caroConst.gameMode = "LAN";
            formGameMode.Close();
            manager.DrawCaroBoard(caroConst.numberOfRow, caroConst.numberOfColumn);
        }

        private void ButMode_Click(object sender, EventArgs e)
        {
            formGameMode.Close();
            manager.DrawCaroBoard(caroConst.numberOfRow, caroConst.numberOfColumn);
        }
        #endregion
    }
}
