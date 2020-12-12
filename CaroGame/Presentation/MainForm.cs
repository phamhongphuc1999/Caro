// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using CaroGame.Configuration;
using CaroGame.LANManagement;
using CaroGame.Presentation;
using CaroGame.SaveGameManagement;
using DataTransmission;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Presentaion
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeController();
            InitializeComponent();
            caroManager.NewGameEvent += CaroManager_NewGameEvent;
            caroManager.EndGameEvent += CaroManager_EndGameEvent;
            this.FormClosing += Form1_FormClosing;
            DrawOverviewForm(this, Config.NAME.OVERVIEW);
        }

        /// <summary>
        /// Listen response or request from other payer in LAN GAME MODE
        /// </summary>
        private void ListenOtherPlayer()
        {
            MessageData message = new MessageData(0, 0, 0, "");
            while (true)
            {
                try
                {
                    lanManager.RECEIVE_TCP(ref message, SocketFlags.None);
                    if (message.odcode == 100)
                    {
                        Config.NAME_PLAYER2 = message.data;
                        if (!Config.IS_SERVER)
                        {
                            Config.NUMBER_OF_ROW = message.X;
                            Config.NUMBER_OF_COLUMN = message.Y;
                        }
                        else
                        {
                            message.data = Config.NAME_PLAYER1;
                            lanManager.SEND_TCP(message, SocketFlags.None);
                            Data.AdjustMessage(ref message, 100, Config.NUMBER_OF_ROW, Config.NUMBER_OF_COLUMN, "");
                            lanManager.SEND_TCP(message, SocketFlags.None);
                        }
                    }
                    else if (message.odcode == 101) caroManager.LANMovePointHandle(message.X, message.Y);
                    else if (message.odcode == 112) CrossThread.PerformSafely<int>(caroManager.pnlCaroBoard, caroManager.NewGameHandle, caroManager.Turn);
                    else if (message.odcode == 120) rtbChat.Text += "Enemy: " + message.data + "\n";
                }
                catch { continue; }
            }
        }

        #region Event Handler
        #region Event Load And Save Game Handler
        private void ButLoadGame_Click(object sender, EventArgs e)
        {
            string prevForm = Config.caroFlow.Peek();
            if (prevForm == Config.NAME.GAME_MODE) DrawLoadGame(this);
            else DrawLoadGame(settingForm);
            Config.IS_LOAD_GAME = true;
        }

        private void ButSaveGame_Click(object sender, EventArgs e)
        {
            SaveGameHelper.caroBoard = caroManager.ConvertBoardToString();
            SaveGameHelper.turn = caroManager.Turn;
            SaveGameHelper.SaveCurrentGame();
            SaveGameHelper.SaveGameToFile();
            settingForm.Close();
        }
        #endregion

        #region Event Player Infomation Handler
        private void ButCancel_Click(object sender, EventArgs e)
        {
            string currentFrom = Config.caroFlow.Pop();
            string prevForm = Config.caroFlow.Peek();
            if (currentFrom == Config.NAME.PLAYER) DrawGameModeForm(this, Config.NAME.GAME_MODE);
            else if (currentFrom == Config.NAME.SETTING) settingForm.Close();
            else if (currentFrom == Config.NAME.LAN_CONNECTION) DrawPlayerForm(this, Config.NAME.PLAYER, Config.GAME_MODE.CurrentGameMode);
            else if (currentFrom == Config.NAME.LOAD_GAME && prevForm == Config.NAME.GAME_MODE) DrawGameModeForm(this, Config.NAME.GAME_MODE);
            else DrawSettingForm(settingForm);
        }
        #endregion

        #region Event Common Setting Handler
        private void ButSave_Click(object sender, EventArgs e)
        {
            string currentForm = Config.caroFlow.Peek();
            if (currentForm == Config.NAME.SETTING)
            {
                settingForm.Close();
                if (Config.IS_ON_TIMER && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) timer.Start();
            }
            else if (currentForm == Config.NAME.TIME_SETTING)
            {
                if (butStatusTime.Text == "Off Timer")
                {
                    int timeTurn = 0, interval = 0;
                    bool check1 = Int32.TryParse(txtSTimeTurn.Text, out timeTurn);
                    bool check2 = Int32.TryParse(txtSTimeInterval.Text, out interval);
                    if (!check1 || !check2)
                    {
                        MessageBox.Show("Must be enter integer", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSTimeTurn.Text = Config.TIME_TURN.ToString();
                        txtSTimeInterval.Text = Config.INTERVAL.ToString();
                        return;
                    }
                    if (timeTurn <= 0 || timeTurn < interval || timeTurn > 30)
                    {
                        MessageBox.Show("time turn is the integer within 0 and 30 and less than interval", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSTimeTurn.Text = Config.TIME_TURN.ToString();
                        txtSTimeInterval.Text = Config.INTERVAL.ToString();
                        return;
                    }
                    Config.IS_ON_TIMER = true;
                    Config.TIME_TURN = timeTurn;
                    Config.INTERVAL = interval;
                    lblTime.Text = Config.TIME_TURN.ToString();
                }
                else
                {
                    Config.IS_ON_TIMER = false;
                    lblTime.Text = "No Timer";
                }
                DrawSettingForm(settingForm);
            }
            else if (currentForm == Config.NAME.SIZE_SETTING)
            {
                int row = 0, column = 0;
                bool check1 = Int32.TryParse(txtName1Row.Text, out row);
                bool check2 = Int32.TryParse(txtName2Column.Text, out column);
                if (!check1 || !check2)
                {
                    MessageBox.Show("Must be enter integer", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = Config.NUMBER_OF_ROW.ToString();
                    txtName2Column.Text = Config.NUMBER_OF_COLUMN.ToString();
                    return;
                }
                if (row > 20 || row < 10 || column > 30 || column < 10)
                {
                    MessageBox.Show("Number of row is less than 20 and greater than 10\nNumber of column is less than 30 and greater than 10"
                        , "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = Config.NUMBER_OF_ROW.ToString();
                    txtName2Column.Text = Config.NUMBER_OF_COLUMN.ToString();
                    return;
                }
                DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    Config.NUMBER_OF_ROW = row;
                    Config.NUMBER_OF_COLUMN = column;
                    settingForm.Close();
                    caroManager.NewGameHandle(caroManager.Turn);
                }
            }
            else if (currentForm == Config.NAME.PLAYER && Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.TWO_PLAYER)
            {
                string namePlayer1 = txtName1Row.Text;
                string namePlayer2 = txtName2Column.Text;
                if (string.IsNullOrEmpty(namePlayer1) || string.IsNullOrEmpty(namePlayer2))
                {
                    MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = Config.NAME_PLAYER1;
                    txtName2Column.Text = Config.NAME_PLAYER2;
                    return;
                }
                if (namePlayer1 == namePlayer2)
                {
                    MessageBox.Show("Wrong", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = Config.NAME_PLAYER1;
                    txtName2Column.Text = Config.NAME_PLAYER2;
                    return;
                }
                Config.NAME_PLAYER1 = namePlayer1;
                Config.NAME_PLAYER2 = namePlayer2;
                caroManager.NewGameHandle(0);
                if (Config.IS_ON_TIMER) timer.Start();
            }
            else if (currentForm == Config.NAME.PLAYER && Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN)
            {
                string namePlayer = txtName1Row.Text;
                if (string.IsNullOrEmpty(namePlayer))
                {
                    MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = Config.NAME_PLAYER1;
                    return;
                }
                Config.NAME_PLAYER1 = namePlayer;
                DrawLANForm(this);
            }
            else if (currentForm == Config.NAME.PLAYER_SETTING)
            {
                string namePlayer1 = txtName1Row.Text;
                string namePlayer2 = txtName2Column.Text;
                if (string.IsNullOrEmpty(namePlayer1) || string.IsNullOrEmpty(namePlayer2))
                {
                    MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = Config.NAME_PLAYER1;
                    txtName2Column.Text = Config.NAME_PLAYER2;
                    return;
                }
                if (namePlayer1 == namePlayer2)
                {
                    MessageBox.Show("Wrong", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = Config.NAME_PLAYER1;
                    txtName2Column.Text = Config.NAME_PLAYER2;
                    return;
                }
                Config.NAME_PLAYER1 = namePlayer1;
                Config.NAME_PLAYER2 = namePlayer2;
                caroManager.PlayerList[0].NamePlayer = Config.NAME_PLAYER1;
                caroManager.PlayerList[1].NamePlayer = Config.NAME_PLAYER2;
                txtPlayer.Text = caroManager.PlayerList[caroManager.Turn].NamePlayer;
                DrawSettingForm(settingForm);
            }
            else if (currentForm == Config.NAME.LAN_CONNECTION) caroManager.NewGameHandle(0);
            else if (currentForm == Config.NAME.SOUND_SETTING)
            {
                Config.VOLUME_SIZE = (int)numSound.Value;
                soundManager.Volume = Config.VOLUME_SIZE;
                if (Config.VOLUME_SIZE == 0)
                {
                    Config.IS_PLAY_MUSIC = false;
                    soundManager.Stop();
                }
                else
                {
                    Config.IS_PLAY_MUSIC = true;
                    soundManager.IsLoop = true;
                    soundManager.Volume = Config.VOLUME_SIZE;
                    soundManager.Play("su-thanh-hoa.wav");
                }
                DrawSettingForm(settingForm);
            }
        }

        private void ButSound_Click(object sender, EventArgs e)
        {
            DrawSoundSettingForm(settingForm);
        }

        private void ButSizeBoard_Click(object sender, EventArgs e)
        {
            DrawSizeSettingForm(settingForm);
        }

        private void ButNamePlayer_Click(object sender, EventArgs e)
        {
            DrawPlayerForm(settingForm, Config.NAME.PLAYER_SETTING);
        }

        private void ButTimer_Click(object sender, EventArgs e)
        {
            DrawTimeSettingForm(settingForm);
        }

        private void ButGameMode_Click(object sender, EventArgs e)
        {
            DrawGameModeForm(settingForm, Config.NAME.GAME_MODE_SETTING);
        }
        #endregion

        #region Event Caro Manager Handler
        private void CaroManager_EndGameEvent(object sender, EventArgs e)
        {
            if (Config.IS_ON_TIMER) timer.Stop();
            butUndo.Enabled = false;
            butRedo.Enabled = false;
        }

        private void CaroManager_NewGameEvent(object sender, EventArgs e)
        {
            DrawMainForm(this);
            if (Config.IS_ON_TIMER && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) timer.Start();
            butUndo.Enabled = true;
            butRedo.Enabled = true;
        }
        #endregion

        #region Event Game Mode Handler
        private void ButModeAI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chế độ này chưa được thiết lập\nChọn chế độ khác", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void ButModeLan_Click(object sender, EventArgs e)
        {
            string prevForm = Config.caroFlow.Peek();
            if (prevForm == Config.NAME.GAME_MODE)
            {
                Config.GAME_MODE.CurrentGameMode = Config.GAME_MODE.LAN;
                Config.IS_LOAD_GAME = false;
                DrawPlayerForm(this, Config.NAME.PLAYER, Config.GAME_MODE.LAN);
            }
            else if(prevForm == Config.NAME.GAME_MODE_SETTING)
            {
                DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    Config.GAME_MODE.CurrentGameMode = Config.GAME_MODE.LAN;
                    settingForm.Close();
                    DrawPlayerForm(this, Config.NAME.PLAYER, Config.GAME_MODE.LAN);
                }
            }
        }

        private void ButTwoPlayer_Click(object sender, EventArgs e)
        {
            string prevForm = Config.caroFlow.Peek();
            if (prevForm == Config.NAME.GAME_MODE)
            {
                Config.GAME_MODE.CurrentGameMode = Config.GAME_MODE.TWO_PLAYER;
                Config.IS_LOAD_GAME = false;
                DrawPlayerForm(this, Config.NAME.PLAYER, Config.GAME_MODE.TWO_PLAYER);
            }
            else if(prevForm == Config.NAME.GAME_MODE_SETTING)
            {
                DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    Config.GAME_MODE.CurrentGameMode = Config.GAME_MODE.TWO_PLAYER;
                    settingForm.Close();
                    DrawMainForm(this);
                    caroManager.NewGameHandle(0);
                    if (Config.IS_ON_TIMER) timer.Start();
                }
            }
        }
        #endregion

        #region Event Menu Tool Handler
        private void ToolItemAbout_Click(object sender, EventArgs e)
        {
            timer.Stop();
            DrawAboutGame(settingForm);
            settingForm.ShowDialog();
        }

        private void ToolItemSetting_Click(object sender, EventArgs e)
        {
            timer.Stop();
            DrawSettingForm(settingForm);
            settingForm.ShowDialog();
        }

        private void ToolItemQuick_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolItemNewGame_Click(object sender, EventArgs e)
        {
            timer.Stop();
            DialogResult result = MessageBox.Show("Are you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK) caroManager.NewGameHandle(caroManager.Turn);
            else
            {
                if (Config.IS_ON_TIMER && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) timer.Start();
            }
        }
        #endregion

        #region Event Load Game Handler
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            int index = (int)eventBut.Tag;
            SaveGameHelper.saveData.GameSaveList.RemoveAt(index - 1);
            DrawLoadGame(this);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            Config.caroFlow.Pop();
            string prevForm = Config.caroFlow.Peek();
            Form parent = eventBut.Parent as Form;
            int index = eventBut.Text[0] - '0' - 1;
            SaveGameHelper.index = index;
            GameSaveData gameSave = SaveGameHelper.saveData.GameSaveList[index];
            Config.NAME_PLAYER1 = gameSave.PlayerName1;
            Config.NAME_PLAYER2 = gameSave.PlayerName2;
            Config.NUMBER_OF_COLUMN = gameSave.NumberOfColumn;
            Config.NUMBER_OF_ROW = gameSave.NumberOfRow;
            caroManager.PlayerList[0].NamePlayer = Config.NAME_PLAYER1;
            caroManager.PlayerList[1].NamePlayer = Config.NAME_PLAYER2;
            caroManager.LoadSaveGame(gameSave.Turn, gameSave.CaroBoard);
            if (prevForm == Config.NAME.SETTING) parent.Close();
            DrawMainForm(this);
        }
        #endregion

        #region Event Overview Handler
        private void ButGuide_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "chức năng chưa có");
        }

        private void ButNewGame_Click(object sender, EventArgs e)
        {
            DrawGameModeForm(this, Config.NAME.GAME_MODE);
        }
        #endregion

        #region Event Main Handler
        private void ButUndo_Click(object sender, EventArgs e)
        {
            caroManager.UndoHandle();
        }

        private void ButRedo_Click(object sender, EventArgs e)
        {
            caroManager.RedoHandle();
        }
        #endregion

        #region Event Chat Handler
        private void ButChat_Click(object sender, EventArgs e)
        {
            string data = txtChat.Text;
            rtbChat.Text += "You: " + data + "\n";
            txtChat.Text = "";
            MessageData message = new MessageData(120, 0, 0, data);
            lanManager.SEND_TCP(message, SocketFlags.None);
        }
        #endregion

        #region Event Time Handler
        private void ButStatusTime_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            if (eventBut.Text == "Off Timer")
            {
                eventBut.Text = "On Timer";
                txtSTimeTurn.Enabled = false;
                txtSTimeInterval.Enabled = false;
                lblSTimeTurn.Enabled = false;
                lblSTimeInterval.Enabled = false;
            }
            else
            {
                eventBut.Text = "Off Timer";
                txtSTimeTurn.Enabled = true;
                txtSTimeInterval.Enabled = true;
                lblSTimeTurn.Enabled = true;
                lblSTimeInterval.Enabled = true;
            }
        }
        #endregion

        #region Event Lan Handler
        private void ButGetIP_Click(object sender, EventArgs e)
        {
            txtName1Row.Text = LANManager.GetIPv4();
        }

        private void ButConnect_Click(object sender, EventArgs e)
        {
            string IP = txtName1Row.Text;
            string sPort = txtName2Column.Text;
            int port = -1;
            if (Int32.TryParse(sPort, out port))
            {
                if (LANManager.CheckIP(IP) && (port > 0) && (port < 99999))
                {
                    Config.IP = IP; Config.PORT = port;
                node:
                    if (!lanManager.ConnectServer())
                    {
                        if (lanManager.CreateServer())
                        {
                            txtName1Row.ReadOnly = true;
                            txtName2Column.ReadOnly = true;
                            butConnect.Enabled = false;
                            butConnect.Text = "Success";
                            butConnect.BackColor = Color.Green;
                            butGetIP.Enabled = false;
                            butSave.Enabled = true;
                            Config.IS_SERVER = true;
                            Config.IS_TURN = true;
                            Config.IS_LOCK = true;
                            Thread listenThread = new Thread(ListenOtherPlayer);
                            listenThread.IsBackground = true;
                            listenThread.Start();
                        }
                        else
                        {
                            butConnect.Text = "Failure";
                            butConnect.BackColor = Color.Red;
                            DialogResult result = MessageBox.Show("The connection is fall", "WRONG", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            if (result == DialogResult.Retry) goto node;
                        }
                    }
                    else
                    {
                        txtName1Row.ReadOnly = true;
                        txtName2Column.ReadOnly = true;
                        butConnect.Enabled = false;
                        butConnect.Text = "Success";
                        butConnect.BackColor = Color.Green;
                        butGetIP.Enabled = false;
                        butSave.Enabled = true;
                        Config.IS_SERVER = false;
                        Config.IS_TURN = false;
                        Config.IS_LOCK = false;
                        Thread listenThread = new Thread(ListenOtherPlayer);
                        listenThread.IsBackground = true;
                        listenThread.Start();
                        lanManager.SEND_TCP(new MessageData(100, 0, 0, Config.NAME_PLAYER1), SocketFlags.None);
                    }
                }
            }
            else MessageBox.Show("Wrong input", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            DialogResult result = MessageBox.Show("Do you want to exit this game?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                if (Config.IS_ON_TIMER && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) timer.Start();
            }
            else
            {
                if (!Config.IS_LOAD_GAME) Config.SaveConfiguration();
                SaveGameHelper.SaveGameToFile();
            }
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Config.IS_ON_TIMER && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) timer.Start();
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
