using Caro.CaroManager;
using Caro.Setting;
using System;
using System.Reflection;
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

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK) timer.Start();
            else e.Cancel = true;
        }

        private void Manager_EndGameEvent(object sender, EventArgs e)
        {
            if (CONST.IS_ON_TIMER) timer.Stop();
        }

        private void Manager_NewGameEvent(object sender, EventArgs e)
        {
            if (CONST.IS_ON_TIMER) timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
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
            if(CONST.IS_ON_TIMER) timer.Start();
        }

        private void ButTwoPlayer_Click(object sender, EventArgs e)
        {
            CONST.gameMode = "TWO_PLAYER";
            CONST.numberOfColumn = 10;
            CONST.numberOfRow = 10;
            DrawMainForm(this, CONST.numberOfRow, CONST.numberOfColumn);
            manager.NewGameHandle(0);
            if (CONST.IS_ON_TIMER) timer.Start();
        }

        private void ButUndo_Click(object sender, EventArgs e)
        {
            manager.UndoHandle();
        }

        private void ButRedo_Click(object sender, EventArgs e)
        {
            manager.RedoHandle();
        }

        private void ToolItemSetting_Click(object sender, EventArgs e)
        {
            timer.Stop();
            DrawSettingForm(settingForm);
            settingForm.ShowDialog();
        }

        private void ToolItemQuick_Click(object sender, EventArgs e)
        {
        }

        private void ToolItemNewGame_Click(object sender, EventArgs e)
        {
        }

        private void ButSizeBoard_Click(object sender, EventArgs e)
        {
        }

        private void ButNamePlayer_Click(object sender, EventArgs e)
        {
        }

        private void ButTimer_Click(object sender, EventArgs e)
        {
            DrawTimeSettingForm(settingForm);
        }

        private void ButGameMode_Click(object sender, EventArgs e)
        {
        }

        private void ButSTimeOnOrOff_Click(object sender, EventArgs e)
        {
            Button eventBut = (Button)sender;
            if(eventBut.Text == "Off Timer")
            {
                eventBut.Text = "On Timer";
                txtSTimeTurn.Enabled = false;
                txtSTimeInterval.Enabled = false;
            }
            else
            {
                eventBut.Text = "Off Timer";
                txtSTimeTurn.Enabled = true;
                txtSTimeInterval.Enabled = true;
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            string temp = settingForm.Text;
            if (temp == "Setting")
            {
                settingForm.Close();
                if (CONST.IS_ON_TIMER) timer.Start();
            }
            else if (temp == "Time Setting")
            {
                if (butSTimeOnOrOff.Text == "Off Timer")
                {
                    int timeTurn = 0, interval = 0;
                    bool check1 = Int32.TryParse(txtSTimeTurn.Text, out timeTurn);
                    bool check2 = Int32.TryParse(txtSTimeInterval.Text, out interval);
                    if (!check1 || !check2)
                    {
                        MessageBox.Show("Must be enter integer", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSTimeTurn.Text = CONST.TIME_TURN.ToString();
                        txtSTimeInterval.Text = CONST.INTERVAL.ToString();
                    }
                    else
                    {
                        CONST.IS_ON_TIMER = true;
                        CONST.TIME_TURN = timeTurn;
                        CONST.INTERVAL = interval;
                    }
                }
                else CONST.IS_ON_TIMER = false;
                DrawSettingForm(settingForm);
            }
        }
        #endregion
    }
}
