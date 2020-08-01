using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Caro.CaroManager;
using Caro.ConnectManager;
using Caro.SaveGame;
using Caro.Setting;
using DataTransmission;

namespace Caro
{
    public partial class Form1 : Form
    {
        private Manager manager;
        private SocketManager socketManager;
        private SoundManager soundManager;

        public Form1()
        {
            InitializeController();
            InitializeComponent();
            manager = new Manager(txtPlayer, pnlCaroBoard, lblTime);
            socketManager = new SocketManager();
            soundManager = new SoundManager();
            if (CONST.IS_PLAY_MUSIC)
            {
                soundManager.IsLoop = true;
                soundManager.Volume = CONST.VOLUME_SIZE;
                soundManager.Play("./Sound/su-thanh-hoa.wav");
            }
            Manager.socketManager = socketManager;
            manager.NewGameEvent += Manager_NewGameEvent;
            manager.EndGameEvent += Manager_EndGameEvent;
            this.FormClosing += Form1_FormClosing;
            DrawGameModeForm(this, "Game Mode");
        }

        private void ListenOtherPlayer()
        {
            MessageData message = new MessageData(0, 0, 0, "");
            while (true)
            {
                try
                {
                    socketManager.RECEIVE_TCP(ref message, SocketFlags.None);
                    if (message.odcode == 100)
                    {
                        CONST.NAME_PLAYER2 = message.data;
                        if (!CONST.IS_SERVER)
                        {
                            CONST.NUMBER_OF_ROW = message.X;
                            CONST.NUMBER_OF_COLUMN = message.Y;
                        }
                        else
                        {
                            message.data = CONST.NAME_PLAYER1;
                            socketManager.SEND_TCP(message, SocketFlags.None);
                            Data.AdjustMessage(ref message, 100, CONST.NUMBER_OF_ROW, CONST.NUMBER_OF_COLUMN, "");
                            socketManager.SEND_TCP(message, SocketFlags.None);
                        }
                    }
                    else if (message.odcode == 101) manager.LANMovePointHandle(message.X, message.Y);
                    else if (message.odcode == 112) CrossThread.PerformSafely<int>(manager.pnlCaroBoard, manager.NewGameHandle, manager.Turn);
                    else if (message.odcode == 120) rtbChat.Text += "Enemy: " + message.data + "\n";
                }
                catch { continue; }
            }
        }

        #region Event Handle
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
                if(!CONST.IS_LOAD_GAME) CONST.WriteCONST();
                CONST.WriteSaveGame();
            }
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CONST.IS_ON_TIMER && CONST.GAME_MODE != "LAN") timer.Start();
        }

        private void Manager_EndGameEvent(object sender, EventArgs e)
        {
            if (CONST.IS_ON_TIMER) timer.Stop();
            butUndo.Enabled = false;
            butRedo.Enabled = false;
        }

        private void Manager_NewGameEvent(object sender, EventArgs e)
        {
            DrawMainForm(this);
            if (CONST.IS_ON_TIMER && CONST.GAME_MODE != "LAN") timer.Start();
            butUndo.Enabled = true;
            butRedo.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int time = Int32.Parse(lblTime.Text);
            if (time > 0) lblTime.Text = (time - 1).ToString();
            else
            {
                System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
                timer.Stop();
                MessageBox.Show("The " + manager.PlayerList[1 - manager.Turn].NamePlayer + " win", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) manager.NewGameHandle(1 - manager.Turn);
            }
        }

        private void ButModeLan_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            Form parent = (Form)eventBut.Parent;
            if (parent.Text == "Game Mode")
            {
                CONST.GAME_MODE = "LAN";
                CONST.IS_LOAD_GAME = false;
                DrawPlayerForm(this, "Name Player", "LAN");
            }
            else
            {
                DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    CONST.GAME_MODE = "LAN";
                    settingForm.Close();
                    DrawPlayerForm(this, "Name Player", "LAN");
                }
            }
        }

        private void ButTwoPlayer_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            Form parent = (Form)eventBut.Parent;
            if (parent.Text == "Game Mode")
            {
                CONST.GAME_MODE = "TWO_PLAYER";
                CONST.IS_LOAD_GAME = false;
                DrawPlayerForm(this, "Name Player", "TWO_PLAYER");
            }
            else
            {
                DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    CONST.GAME_MODE = "TWO_PLAYER";
                    settingForm.Close();
                    DrawMainForm(this);
                    manager.NewGameHandle(0);
                    if (CONST.IS_ON_TIMER) timer.Start();
                }
            }
        }

        private void ButModeAI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chế độ này chưa được thiết lập\nChọn chế độ khác", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            Form parent = eventBut.Parent as Form;
            int index = eventBut.Text[0] - '0' - 1;
            SaveGameHelper.index = index;
            GameSave gameSave = CONST.saveData.GameSaveList[index];
            CONST.NAME_PLAYER1 = gameSave.PlayerName1;
            CONST.NAME_PLAYER2 = gameSave.PlayerName2;
            CONST.NUMBER_OF_COLUMN = gameSave.NumberOfColumn;
            CONST.NUMBER_OF_ROW = gameSave.NumberOfRow;
            manager.PlayerList[0].NamePlayer = CONST.NAME_PLAYER1;
            manager.PlayerList[1].NamePlayer = CONST.NAME_PLAYER2;
            manager.LoadSaveGame(gameSave.Turn, gameSave.CaroBoard);
            if ((int)parent.Tag == 1) parent.Close(); 
            DrawMainForm(this);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            int index = (int)eventBut.Tag;
            CONST.saveData.GameSaveList.RemoveAt(index - 1);
            DrawLoadGame(this);
        }

        private void ButLoadGame_Click(object sender, EventArgs e)
        {
            CONST.IS_LOAD_GAME = true;
            DrawLoadGame(this);
        }

        private void ButLoadGameSetting_Click(object sender, EventArgs e)
        {
            CONST.IS_LOAD_GAME = true;
            DrawLoadGame(settingForm);
        }

        private void ButSaveGame_Click(object sender, EventArgs e)
        {
            SaveGameHelper.caroBoard = manager.ConvertBoardToString();
            SaveGameHelper.turn = manager.Turn;
            SaveGameHelper.SaveCurrentGame();
            CONST.WriteSaveGame();
            settingForm.Close();
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
            Application.Exit();
        }

        private void ToolItemNewGame_Click(object sender, EventArgs e)
        {
            timer.Stop();
            DialogResult result = MessageBox.Show("Are you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK) manager.NewGameHandle(manager.Turn);
            else
            {
                if (CONST.IS_ON_TIMER && CONST.GAME_MODE != "LAN") timer.Start();
            }
        }

        private void ToolItemAbout_Click(object sender, EventArgs e)
        {
            timer.Stop();
            DrawAboutGame(settingForm);
            settingForm.ShowDialog();
        }

        private void ButSizeBoard_Click(object sender, EventArgs e)
        {
            DrawSizeSettingForm(settingForm);
        }

        private void ButNamePlayer_Click(object sender, EventArgs e)
        {
            DrawPlayerForm(settingForm, "Name Player Setting");
        }

        private void ButColorPlayer2_Click(object sender, EventArgs e)
        {
            ColorDialog playerColor = new ColorDialog();
            DialogResult result = playerColor.ShowDialog();
            if (result == DialogResult.OK)
            {
                string color = playerColor.Color.Name;
                if (color != "Black") butColorPlayer2.ForeColor = Color.Black;
                else butColorPlayer2.ForeColor = Color.White;
                butColorPlayer2.Text = playerColor.Color.Name;
                butColorPlayer2.BackColor = playerColor.Color;
            }
        }

        private void ButColorPlayer1_Click(object sender, EventArgs e)
        {
            ColorDialog playerColor = new ColorDialog();
            DialogResult result = playerColor.ShowDialog();
            if (result == DialogResult.OK)
            {
                string color = playerColor.Color.Name;
                if (color != "Black") butColorPlayer1.ForeColor = Color.Black;
                else butColorPlayer1.ForeColor = Color.White;
                butColorPlayer1.Text = playerColor.Color.Name;
                butColorPlayer1.BackColor = playerColor.Color;
            }
        }

        private void ButTimer_Click(object sender, EventArgs e)
        {
            DrawTimeSettingForm(settingForm);
        }

        private void ButGameMode_Click(object sender, EventArgs e)
        {
            DrawGameModeForm(settingForm, "Game Mode Setting");
        }

        private void ButSound_Click(object sender, EventArgs e)
        {
            DrawSoundSettingForm(settingForm);
        }

        private void ButSTimeOnOrOff_Click(object sender, EventArgs e)
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

        private void ButConnect_Click(object sender, EventArgs e)
        {
            string IP = txtName1Row.Text;
            string sPort = txtName2Column.Text;
            int port = -1;
            if (Int32.TryParse(sPort, out port))
            {
                if (SocketManager.CheckIP(IP) && (port > 0) && (port < 99999))
                {
                    CONST.IP = IP; CONST.PORT = port;
                node:
                    if (!socketManager.ConnectServer())
                    {
                        if (socketManager.CreateServer())
                        {
                            txtName1Row.ReadOnly = true;
                            txtName2Column.ReadOnly = true;
                            butConnect.Enabled = false;
                            butConnect.Text = "Success";
                            butConnect.BackColor = Color.Green;
                            butGetIP.Enabled = false;
                            butSave.Enabled = true;
                            CONST.IS_SERVER = true;
                            CONST.IS_TURN = true;
                            CONST.IS_LOCK = true;
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
                        CONST.IS_SERVER = false;
                        CONST.IS_TURN = false;
                        CONST.IS_LOCK = false;
                        Thread listenThread = new Thread(ListenOtherPlayer);
                        listenThread.IsBackground = true;
                        listenThread.Start();
                        socketManager.SEND_TCP(new MessageData(100, 0, 0, CONST.NAME_PLAYER1), SocketFlags.None);
                    }
                }
            }
            else MessageBox.Show("Wrong input", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            Form parent = (Form)eventBut.Parent;
            string temp = parent.Text;
            if (temp == "Name Player") DrawGameModeForm(this, "Game Mode");
            else if (temp == "Name Player Setting" || temp == "Time Setting" || temp == "Game Mode Setting" 
                || temp == "Size Setting" || temp == "Sound Setting")
                DrawSettingForm(settingForm);
            else if (temp == "LAN Connection") DrawPlayerForm(this, "Name Player", CONST.GAME_MODE);
        }

        private void ButLoadBack_Click(object sender, EventArgs e)
        {
            DrawGameModeForm(this, "Game Mode");
        }

        private void ButGetIP_Click(object sender, EventArgs e)
        {
            txtName1Row.Text = SocketManager.GetIPv4();
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            Form parent = eventBut.Parent as Form;
            string temp = parent.Text;
            if (temp == "Setting")
            {
                settingForm.Close();
                if (CONST.IS_ON_TIMER && CONST.GAME_MODE != "LAN") timer.Start();
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
                        lblTime.Text = CONST.TIME_TURN.ToString();
                    }
                }
                else
                {
                    CONST.IS_ON_TIMER = false;
                    lblTime.Text = "No Timer";
                }
                DrawSettingForm(settingForm);
            }
            else if (temp == "Size Setting")
            {
                int row = 0, column = 0;
                bool check1 = Int32.TryParse(txtName1Row.Text, out row);
                bool check2 = Int32.TryParse(txtName2Column.Text, out column);
                if (!check1 || !check2)
                {
                    MessageBox.Show("Must be enter integer", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = CONST.NUMBER_OF_ROW.ToString();
                    txtName2Column.Text = CONST.NUMBER_OF_COLUMN.ToString();
                }
                else if (row > 20 || row < 10 || column > 30 || column < 10)
                {
                    MessageBox.Show("Number of row is less than 20 and greater than 10\nNumber of column is less than 30 and greater than 10"
                        , "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = CONST.NUMBER_OF_ROW.ToString();
                    txtName2Column.Text = CONST.NUMBER_OF_COLUMN.ToString();
                }
                else
                {
                    DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        CONST.NUMBER_OF_ROW = row;
                        CONST.NUMBER_OF_COLUMN = column;
                        settingForm.Close();
                        manager.NewGameHandle(manager.Turn);
                    }
                }
            }
            else if (temp == "Name Player" && CONST.GAME_MODE == "TWO_PLAYER")
            {
                string namePlayer1 = txtName1Row.Text;
                string namePlayer2 = txtName2Column.Text;
                if (string.IsNullOrEmpty(namePlayer1) || string.IsNullOrEmpty(namePlayer2))
                {
                    MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = CONST.NAME_PLAYER1;
                    txtName2Column.Text = CONST.NAME_PLAYER2;
                }
                else if (namePlayer1 == namePlayer2 || butColorPlayer1.BackColor == butColorPlayer2.BackColor)
                {
                    MessageBox.Show("Wrong", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = CONST.NAME_PLAYER1;
                    txtName2Column.Text = CONST.NAME_PLAYER2;
                }
                else
                {
                    CONST.NAME_PLAYER1 = namePlayer1;
                    CONST.NAME_PLAYER2 = namePlayer2;
                    CONST.COLOR_PLAYER1 = butColorPlayer1.BackColor.Name;
                    CONST.COLOR_PLAYER2 = butColorPlayer2.BackColor.Name;
                    manager.NewGameHandle(0);
                    DrawMainForm(this);
                    if (CONST.IS_ON_TIMER) timer.Start();
                }
            }
            else if (temp == "Name Player" && CONST.GAME_MODE == "LAN")
            {
                string namePlayer = txtName1Row.Text;
                if (string.IsNullOrEmpty(namePlayer))
                {
                    MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = CONST.NAME_PLAYER1;
                }
                else
                {
                    CONST.NAME_PLAYER1 = namePlayer;
                    DrawLANForm(this);
                }
            }
            else if (temp == "Name Player Setting")
            {
                string namePlayer1 = txtName1Row.Text;
                string namePlayer2 = txtName2Column.Text;
                if (string.IsNullOrEmpty(namePlayer1) || string.IsNullOrEmpty(namePlayer2))
                {
                    MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = CONST.NAME_PLAYER1;
                    txtName2Column.Text = CONST.NAME_PLAYER2;
                }
                else if (namePlayer1 == namePlayer2)
                {
                    MessageBox.Show("Wrong", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName1Row.Text = CONST.NAME_PLAYER1;
                    txtName2Column.Text = CONST.NAME_PLAYER2;
                }
                else
                {
                    CONST.NAME_PLAYER1 = namePlayer1;
                    CONST.NAME_PLAYER2 = namePlayer2;
                    manager.PlayerList[0].NamePlayer = CONST.NAME_PLAYER1;
                    manager.PlayerList[1].NamePlayer = CONST.NAME_PLAYER2;
                    txtPlayer.Text = manager.PlayerList[manager.Turn].NamePlayer;
                    DrawSettingForm(settingForm);
                }
            }
            else if (temp == "LAN Connection")
            {
                DrawMainForm(this);
                manager.NewGameHandle(0);
            }
            else if(temp == "Sound Setting")
            {
                CONST.VOLUME_SIZE = (int)numSound.Value;
                soundManager.Volume = CONST.VOLUME_SIZE;
                if (CONST.VOLUME_SIZE == 0)
                {
                    CONST.IS_PLAY_MUSIC = false;
                    soundManager.Stop();
                }
                else
                {
                    CONST.IS_PLAY_MUSIC = true;
                    soundManager.IsLoop = true;
                    soundManager.Volume = CONST.VOLUME_SIZE;
                    soundManager.Play("./Sound/su-thanh-hoa.wav");
                }
                DrawSettingForm(settingForm);
            }
        }

        private void ButChat_Click(object sender, EventArgs e)
        {
            string data = txtChat.Text;
            rtbChat.Text += "You: " + data + "\n";
            txtChat.Text = "";
            MessageData message = new MessageData(120, 0, 0, data);
            socketManager.SEND_TCP(message, SocketFlags.None);
        }
        #endregion
    }
}
