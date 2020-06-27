using Caro.CaroManager;
using Caro.ConnectManager;
using Caro.Setting;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Caro
{
    public partial class Form1 : Form
    {
        private Manager manager;
        private SocketManager socketManager;

        public Form1()
        {
            InitializeComponent();
            manager = new Manager(txtPlayer, pnlCaroBoard, lblTime);
            socketManager = new SocketManager();
            Manager.socketManager = socketManager;
            manager.NewGameEvent += Manager_NewGameEvent;
            manager.EndGameEvent += Manager_EndGameEvent;
            this.FormClosing += Form1_FormClosing;
            DrawGameModeForm(this, "Game Mode");
        }

        #region Event Handle
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            DialogResult result = MessageBox.Show("Are you sure?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                if (CONST.IS_ON_TIMER) timer.Start();
            }
        }

        private void Manager_EndGameEvent(object sender, EventArgs e)
        {
            if (CONST.IS_ON_TIMER) timer.Stop();
        }

        private void Manager_NewGameEvent(object sender, EventArgs e)
        {
            DrawMainForm(this);
            if (CONST.IS_ON_TIMER) timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int time = Int32.Parse(lblTime.Text);
            if(time > 0) lblTime.Text = (time - 1).ToString();
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
            Button eventBut = (Button)sender;
            Form parent = (Form)eventBut.Parent;
            if(parent.Text == "Game Mode")
            {
                CONST.gameMode = "LAN";
                CONST.numberOfColumn = 10;
                CONST.numberOfRow = 10;
                DrawNamePlayerForm(this, "Name Player", "LAN");
            }
            else
            {
                DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(result == DialogResult.OK)
                {
                    CONST.gameMode = "LAN";
                    settingForm.Close();
                    DrawMainForm(this);
                    manager.NewGameHandle(0);
                    if (CONST.IS_ON_TIMER) timer.Start();
                }
            }
        }

        private void ButTwoPlayer_Click(object sender, EventArgs e)
        {
            Button eventBut = (Button)sender;
            Form parent = (Form)eventBut.Parent;
            if (parent.Text == "Game Mode")
            {
                CONST.gameMode = "TWO_PLAYER";
                CONST.numberOfColumn = 10;
                CONST.numberOfRow = 10;
                DrawNamePlayerForm(this, "Name Player", "TWO_PLAYER");
            }
            else
            {
                DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    CONST.gameMode = "TWO_PLAYER";
                    settingForm.Close();
                    DrawMainForm(this);
                    manager.NewGameHandle(0);
                    if (CONST.IS_ON_TIMER) timer.Start();
                }
            }
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
        }

        private void ButSizeBoard_Click(object sender, EventArgs e)
        {
            DrawSizeSettingForm(settingForm);
        }

        private void ButNamePlayer_Click(object sender, EventArgs e)
        {
            DrawNamePlayerForm(settingForm, "Name Player Setting");
        }

        private void ButTimer_Click(object sender, EventArgs e)
        {
            DrawTimeSettingForm(settingForm);
        }

        private void ButGameMode_Click(object sender, EventArgs e)
        {
            DrawGameModeForm(settingForm, "Game Mode Setting");
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

        private void ButConnect_Click(object sender, EventArgs e)
        {
            string IP = txtIP.Text;
            string sPort = txtPort.Text;
            int port = -1;
            if (Int32.TryParse(sPort, out port))
            {
                if(SocketManager.CheckIP(IP) && (port > 0) && (port < 99999))
                {
                    CONST.IP = IP; CONST.PORT = port;
                    node:
                    if (!socketManager.ConnectServer())
                    {
                        if (socketManager.CreateServer())
                        {
                            butConnect.Text = "Success";
                            butConnect.BackColor = Color.Green;
                            butSave.Enabled = true;
                            CONST.isServer = true;
                            CONST.IS_TURN = true;
                            CONST.IS_LOCK = true;
                            Thread listenThread = new Thread(() =>
                            {
                                int odcode = -1; string message = "";
                                while (true)
                                {
                                    try
                                    {
                                        socketManager.RECEIVE_TCP(ref odcode, ref message, SocketFlags.None);
                                        if(odcode == 100)
                                        {
                                            CONST.NAME_PLAYER2 = message;
                                            socketManager.SEND_TCP(EncapsulateData.CreateMessage(100, CONST.NAME_PLAYER1), SocketFlags.None);
                                        }
                                        else if(odcode == 101)
                                        {
                                            string[] XY = message.Split(' ');
                                            int X = Int32.Parse(XY[0]);
                                            int Y = Int32.Parse(XY[1]);
                                            manager.LANMovePointHandle(X, Y);
                                        }
                                    }
                                    catch { txtPlayer.Text = "123456"; continue; }
                                }
                            });
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
                        butConnect.Text = "Success";
                        butConnect.BackColor = Color.Green;
                        butSave.Enabled = true;
                        CONST.isServer = false;
                        CONST.IS_TURN = false;
                        CONST.IS_LOCK = false;
                        Thread listenThread = new Thread(() =>
                        {
                            int odcode = -1; string message = "";
                            while (true)
                            {
                                try
                                {
                                    socketManager.RECEIVE_TCP(ref odcode, ref message, SocketFlags.None);
                                    if (odcode == 100)
                                    {
                                        CONST.NAME_PLAYER2 = message;
                                    }
                                    else if (odcode == 101)
                                    {
                                        string[] XY = message.Split(' ');
                                        int X = Int32.Parse(XY[0]);
                                        int Y = Int32.Parse(XY[1]);
                                        manager.LANMovePointHandle(X, Y);
                                    }
                                }
                                catch { continue; }
                            }
                        });
                        listenThread.IsBackground = true;
                        listenThread.Start();
                        socketManager.SEND_TCP(EncapsulateData.CreateMessage(100, CONST.NAME_PLAYER1), SocketFlags.None);
                    }
                }
            }
            else MessageBox.Show("Wrong input", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            Button eventBut = (Button)sender;
            Form parent = (Form)eventBut.Parent;
            string temp = parent.Text;
            if (temp == "Name Player") DrawGameModeForm(this, "Game Mode");
            else if (temp == "LAN Connection") DrawNamePlayerForm(this, "Name Player", CONST.gameMode);
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            Button eventBut = (Button)sender;
            Form parent = (Form)eventBut.Parent;
            string temp = parent.Text;
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
            else if(temp == "Size Setting")
            {
                int row = 0, column = 0;
                bool check1 = Int32.TryParse(txtSSizeRow.Text, out row);
                bool check2 = Int32.TryParse(txtSSizeColumn.Text, out column);
                if (!check1 || !check2)
                {
                    MessageBox.Show("Must be enter integer", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSSizeRow.Text = CONST.numberOfRow.ToString();
                    txtSSizeColumn.Text = CONST.numberOfColumn.ToString();
                }
                else if(row > 20 || row < 5 || column > 30 || column < 5)
                {
                    MessageBox.Show("Number of row is less than 20 and greater than 5\nNumber of column is less than 30 and greater than 5"
                        , "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSSizeRow.Text = CONST.numberOfRow.ToString();
                    txtSSizeColumn.Text = CONST.numberOfColumn.ToString();
                }
                else
                {
                    DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if(result == DialogResult.OK)
                    {
                        CONST.numberOfRow = row;
                        CONST.numberOfColumn = column;
                        settingForm.Close();
                        manager.NewGameHandle(manager.Turn);
                    }
                }
            }
            else if(temp == "Name Player" && CONST.gameMode == "TWO_PLAYER")
            {
                string namePlayer1 = txtNamePlayer1.Text;
                string namePlayer2 = txtNamePlayer2.Text;
                if (string.IsNullOrEmpty(namePlayer1) || string.IsNullOrEmpty(namePlayer2))
                {
                    MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNamePlayer1.Text = CONST.NAME_PLAYER1;
                    txtNamePlayer2.Text = CONST.NAME_PLAYER2;
                }
                else if (namePlayer1 == namePlayer2)
                {
                    MessageBox.Show("Wrong", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNamePlayer1.Text = CONST.NAME_PLAYER1;
                    txtNamePlayer2.Text = CONST.NAME_PLAYER2;
                }
                else
                {
                    CONST.NAME_PLAYER1 = namePlayer1;
                    CONST.NAME_PLAYER2 = namePlayer2;
                    manager.NewGameHandle(0);
                    DrawMainForm(this);
                    if (CONST.IS_ON_TIMER) timer.Start();
                }
            }
            else if(temp == "Name Player" && CONST.gameMode == "LAN")
            {
                string namePlayer = txtNamePlayer1.Text;
                if (string.IsNullOrEmpty(namePlayer))
                {
                    MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNamePlayer1.Text = CONST.NAME_PLAYER1;
                }
                else
                {
                    CONST.NAME_PLAYER1 = namePlayer;
                    DrawLANForm(this);
                }
            }
            else if(temp == "Name Player Setting")
            {
                string namePlayer1 = txtNamePlayer1.Text;
                string namePlayer2 = txtNamePlayer2.Text;
                if (string.IsNullOrEmpty(namePlayer1) || string.IsNullOrEmpty(namePlayer2))
                {
                    MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNamePlayer1.Text = CONST.NAME_PLAYER1;
                    txtNamePlayer2.Text = CONST.NAME_PLAYER2;
                }
                else if(namePlayer1 == namePlayer2)
                {
                    MessageBox.Show("Wrong", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNamePlayer1.Text = CONST.NAME_PLAYER1;
                    txtNamePlayer2.Text = CONST.NAME_PLAYER2;
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
            else if(temp == "LAN Connection")
            {
                DrawMainForm(this);
                manager.NewGameHandle(0);
                if (CONST.IS_ON_TIMER) timer.Start();
            }
        }
        #endregion
    }
}
