using Caro.CaroManager;
using Caro.Setting;
using System;
using System.Windows.Forms;

namespace Caro
{
    public partial class Form1 : Form
    {
        private Manager manager;

        public Form1()
        {
            InitializeComponent();
            manager = new Manager(txtPlayer, pnlCaroBoard, lblTime);
            manager.NewGameEvent += Manager_NewGameEvent;
            manager.EndGameEvent += Manager_EndGameEvent;
            this.FormClosing += Form1_FormClosing;
            DrawGameModeForm(this);
        }

        #region Event Handle
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel) e.Cancel = true;
        }

        private void Manager_EndGameEvent(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void Manager_NewGameEvent(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            int time = Int32.Parse(lblTime.Text);
            if(time > 0) lblTime.Text = (time - 1).ToString();
            else
            {
                Timer timer = (Timer)sender;
                timer.Stop();
                MessageBox.Show("The " + manager.PlayerList[1 - manager.Turn].NamePlayer + " win", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) manager.NewGameHandle(1 - manager.Turn);
            }
        }

        private void ButModeLan_Click(object sender, EventArgs e)
        {
            CONST.gameMode = "LAN";
            CONST.numberOfColumn = 10;
            CONST.numberOfRow = 10;
            DrawMainForm(this, CONST.numberOfRow, CONST.numberOfColumn);
            manager.NewGameHandle(0);
            timer.Start();
        }

        private void ButTwoPlayer_Click(object sender, EventArgs e)
        {
            CONST.gameMode = "TWO_PLAYER";
            CONST.numberOfColumn = 10;
            CONST.numberOfRow = 10;
            DrawMainForm(this, CONST.numberOfRow, CONST.numberOfColumn);
            manager.NewGameHandle(0);
            timer.Start();
        }

        private void ButUndo_Click(object sender, EventArgs e)
        {
            manager.UndoHandle();
        }

        private void ButRedo_Click(object sender, EventArgs e)
        {
            manager.RedoHandle();
        }

        private void ToolItemSetting_Click(object sender, System.EventArgs e)
        {
            DrawSettingForm(settingForm);
            settingForm.ShowDialog();
        }

        private void ToolItemQuick_Click(object sender, System.EventArgs e)
        {
        }

        private void ToolItemNewGame_Click(object sender, System.EventArgs e)
        {
        }

        private void ButSizeBoard_Click(object sender, System.EventArgs e)
        {
        }

        private void ButNamePlayer_Click(object sender, System.EventArgs e)
        {
        }

        private void ButTimer_Click(object sender, System.EventArgs e)
        {
        }

        private void ButGameMode_Click(object sender, System.EventArgs e)
        {
        }

        private void ButSave_Click(object sender, System.EventArgs e)
        {
        }
        #endregion
    }
}
