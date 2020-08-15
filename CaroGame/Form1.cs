using CaroGame.CaroManagement;
using CaroGame.Config;
using CaroGame.LANManagement;
using CaroGame.SoundManagement;
using System;
using System.Windows.Forms;

namespace CaroGame
{
    public partial class Form1 : Form
    {
        private CaroManager caroManager;
        private LANManager lanManager;
        private SoundManager soundManager;

        public Form1()
        {
            InitializeController();
            InitializeComponent();
            caroManager = new CaroManager(txtPlayer, pnlCaroBoard, lblTime);
            lanManager = new LANManager();
            soundManager = new SoundManager();
            if (CONST.IS_PLAY_MUSIC)
            {
                soundManager.IsLoop = true;
                soundManager.Volume = CONST.VOLUME_SIZE;
                soundManager.Play("./Sound/su-thanh-hoa.wav");
            }
            CaroManager.lanManager = lanManager;
            caroManager.NewGameEvent += CaroManager_NewGameEvent;
            caroManager.EndGameEvent += CaroManager_EndGameEvent;
            this.FormClosing += Form1_FormClosing;
            DrawGameModeForm(this, "Game Mode");
        }

        #region Event Handler
        #region Event Load And Save Game Handler
        private void ButLoadGameSetting_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButLoadGame_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButSaveGame_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButLoadBack_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Player Infomation Handler
        private void ButBack_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButColorPlayer2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButColorPlayer1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Common Setting Handler
        private void ButSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButSound_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButSizeBoard_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButNamePlayer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButTimer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButGameMode_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Caro Manager Handler
        private void CaroManager_EndGameEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CaroManager_NewGameEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Game Mode Handler
        private void ButModeAI_Click(object sender, EventArgs e)
        {
        }

        private void ButModeLan_Click(object sender, EventArgs e)
        {
        }

        private void ButTwoPlayer_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region Event Menu Tool Handler
        private void ToolItemAbout_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ToolItemSetting_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ToolItemQuick_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ToolItemNewGame_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Load Game Handler
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Main Handler
        private void ButUndo_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButRedo_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Chat Handler
        private void ButChat_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Time Handler
        private void ButSTimeOnOrOff_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Lan Handler
        private void ButGetIP_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButConnect_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            DialogResult result = MessageBox.Show("Are you sure?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                if (CONST.IS_ON_TIMER && CONST.GAME_MODE != "LAN") timer.Start();
            }
            else
            {
                if (!CONST.IS_LOAD_GAME) CONST.WriteCONST();
                CONST.WriteSaveGame();
            }
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CONST.IS_ON_TIMER && CONST.GAME_MODE != "LAN") timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int time = Int32.Parse(lblTime.Text);
            if (time > 0) lblTime.Text = (time - 1).ToString();
            else
            {
                System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
                timer.Stop();
                MessageBox.Show("The " + caroManager.PlayerList[1 - caroManager.Turn].NamePlayer + " win", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) caroManager.NewGameHandle(1 - caroManager.Turn);
            }
        }
        #endregion
    }
}
