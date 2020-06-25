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
            manager = new Manager(this, txtPlayer, pnlCaroBoard, caroConst);

            butTwoPlayer.Click += ButTwoPlayer_Click;
            butModeLan.Click += ButModeLan_Click;
            butRedo.Click += ButRedo_Click;
            butUndo.Click += ButUndo_Click;

            formGameMode.ShowDialog();
        }

        #region Event Handle
        private void ButModeLan_Click(object sender, EventArgs e)
        {
            caroConst.gameMode = "LAN";
            formGameMode.Close();
            manager.DrawCaroBoard(caroConst.numberOfRow, caroConst.numberOfColumn);
        }

        private void ButTwoPlayer_Click(object sender, EventArgs e)
        {
            formGameMode.Close();
            manager.DrawCaroBoard(caroConst.numberOfRow, caroConst.numberOfColumn);
        }

        private void ButUndo_Click(object sender, EventArgs e)
        {
            manager.UndoHandle();
        }

        private void ButRedo_Click(object sender, EventArgs e)
        {
            manager.RedoHandle();
        }
        #endregion
    }
}
