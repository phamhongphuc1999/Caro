using System;
using System.Drawing;
using System.Windows.Forms;
using CaroGame.Configuration;
using CaroGame.Presentation;
using CaroGame.Presentation.CustomPanel;
using CaroGame.SaveGameManagement;

namespace CaroGame.Presentaion
{
    partial class MainForm
    {
        public Timer timer;
        public RichTextBox rtbChat, rtbAbout;
        public Panel pnlChat, pnlCaroBoard;
        public Button butUndo, butRedo;
        public Button butSaveGame;
        public Button butConnect, butGetIP, butChat;
        public TextBox txtChat, txtPlayer;
        public Label lblTime;
        public PlayerPanel playerPanel;
        public SizePanel sizePanel;
        public OverviewPanel overviewPanel;
        public GameModePanel gameModePanel;
        public CustomMenu mainMenu;

        #region Windows Form Designer generated code
        #region Initialize Controller

        private void InitializeController()
        {
            #region LAN Mode
            butConnect = new Button()
            {
                Size = new Size(360, 35),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(120, 205)
            };
            butGetIP = new Button()
            {
                Text = "Get IP",
                Size = new Size(80, 35),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(490, 85)
            };
            butConnect.Click += ButConnect_Click;
            butGetIP.Click += ButGetIP_Click;
            #endregion

            #region Main Game
            pnlCaroBoard = new Panel()
            {
                Location = new Point(1, 70)
            };
            butUndo = new Button()
            {
                Text = "Undo",
                Size = new Size(120, 30),
            };
            butRedo = new Button()
            {
                Text = "Redo",
                Size = new Size(120, 30)
            };
            txtPlayer = new TextBox()
            {
                Width = 240,
                ReadOnly = true
            };
            lblTime = new Label()
            {
                Size = new Size(90, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 35)
            };
            mainMenu = new CustomMenu
            {
                Name = "mainMenu",
                Text = "Menu",
                GripMargin = new Padding(2, 2, 0, 2),
                ImageScalingSize = new Size(24, 24),
                Location = new Point(0, 0),
                TabIndex = 0
            };
            mainMenu.toolItemAbout.Click += ToolItemAbout_Click;
            mainMenu.toolItemSetting.Click += ToolItemSetting_Click;
            mainMenu.toolItemQuick.Click += ToolItemQuick_Click;
            mainMenu.toolItemNewGame.Click += ToolItemNewGame_Click;
            butRedo.Click += ButRedo_Click;
            butUndo.Click += ButUndo_Click;
            #endregion

            #region CHAT Form In LAN Mode
            pnlChat = new Panel();
            txtChat = new TextBox()
            {
                Multiline = true,
                Size = new Size(330, 50),
            };
            butChat = new Button()
            {
                Text = "Send",
                Size = new Size(70, 50)
            };
            rtbChat = new RichTextBox();
            butChat.Click += ButChat_Click;
            #endregion

            butSaveGame = new Button()
            {
                Text = "Save Game",
                Size = new Size(110, 40),
                Location = new Point(485, 0)
            };
            butSaveGame.Click += ButSaveGame_Click;

            playerPanel = new PlayerPanel()
            {
                Location = new Point(0, 0)
            };
            playerPanel.routePnl.cancelActionBut.Click += PlayerPanel_CancelActionBut_Click;
            playerPanel.routePnl.nextActionBut.Click += PlayerPanel_NextActionBut_Click;
            sizePanel = new SizePanel()
            {
                Location = new Point(0, 0)
            };
            overviewPanel = new OverviewPanel()
            {
                Location = new Point(0, 0)
            };
            overviewPanel.butNewGame.Click += ButNewGame_Click;
            overviewPanel.butGuide.Click += ButGuide_Click;
            gameModePanel = new GameModePanel()
            {
                Location = new Point(0, 0)
            };
            gameModePanel.butTwoPlayer.Click += ButTwoPlayer_Click;
            gameModePanel.butModeLan.Click += ButModeLan_Click;
            gameModePanel.butModeAI.Click += ButModeAI_Click;
            gameModePanel.routePanel.cancelActionBut.Click += ButCancel_Click;
            gameModePanel.butLoadGame.Click += ButLoadGame_Click;

            rtbAbout = new RichTextBox()
            {
                Name = "rtbAbout",
                Text = "\n\n" +
                "          Devepoler: Phạm Hồng Phúc\n" +
                "          Country: Việt Nam\n" +
                "          Game: Caro Game\n" +
                "          Version: v1",
                Size = new Size(400, 250),
                Location = new Point(0, 0),
                Enabled = false
            };
            timer = new Timer()
            {
                Interval = Config.INTERVAL * 1000
            };
            timer.Tick += Timer_Tick;
        }
        #endregion

        #region Draw Form
        private void DrawOverviewForm(Form overviewForm, string formText)
        {
            DrawCommonForm(ref overviewForm, formText);
            overviewForm.Controls.Add(overviewPanel);
        }

        private void DrawGameModeForm(Form gameModeForm, string formText)
        {
            DrawCommonForm(ref gameModeForm, formText);
            gameModeForm.Controls.Add(gameModePanel);
        }

        private void DrawPlayerForm(Form playerForm, string formText, string gameMode = "")
        {
            DrawCommonForm(ref playerForm, Config.NAME.PLAYER);
            playerForm.Controls.Add(playerPanel);
        }

        private void DrawLANForm(Form LANForm)
        {
            //butNext.Enabled = false;
            butConnect.Text = "Connect";
            butConnect.BackColor = Color.White;
            butConnect.Enabled = true;
            butGetIP.Enabled = true;
            //txtName2Column.ReadOnly = false;
            //txtName1Row.ReadOnly = false;
            //txtName1Row.Text = "";
            //lblName1Row.Text = "IP";
            //lblName2Column.Text = "Port";
            //butCancel.Location = new Point(370, 280);
            DrawCommonForm(ref LANForm, Config.NAME.LAN_CONNECTION);
            //LANForm.Controls.Add(lblName1Row);
            //LANForm.Controls.Add(lblName2Column);
            //LANForm.Controls.Add(txtName1Row);
            //LANForm.Controls.Add(txtName2Column);
            //LANForm.Controls.Add(butNext);
            LANForm.Controls.Add(butConnect);
            //LANForm.Controls.Add(butCancel);
            LANForm.Controls.Add(butGetIP);
        }

        private void DrawMainForm(Form mainForm)
        {
            int width = Config.NUMBER_OF_COLUMN * Config.CHESS_SIZE.Width;
            int height = Config.NUMBER_OF_ROW * Config.CHESS_SIZE.Height;
            pnlCaroBoard.Size = new Size(width, height);
            DrawCommonForm(ref mainForm, Config.NAME.CARO, width, height);
            txtPlayer.Location = new Point(pnlCaroBoard.Width - 240, 0);
            butUndo.Location = new Point(pnlCaroBoard.Width - 120, 30);
            butRedo.Location = new Point(pnlCaroBoard.Width - 240, 30);
            mainForm.AutoSize = true;
            if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN)
            {
                pnlChat.Size = new Size(400, pnlCaroBoard.Height + 70);
                pnlChat.Location = new Point(pnlCaroBoard.Width, 0);
                txtChat.Location = new Point(0, pnlChat.Height - 50);
                butChat.Location = new Point(330, pnlChat.Height - 50);
                rtbChat.Size = new Size(400, pnlChat.Height - 50);
                rtbChat.Location = new Point(0, 0);
                pnlChat.Controls.Add(txtChat);
                pnlChat.Controls.Add(butChat);
                pnlChat.Controls.Add(rtbChat);
                mainForm.Controls.Add(pnlChat);
            }
            mainForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainForm.Controls.Add(pnlCaroBoard);
            mainForm.Controls.Add(txtPlayer);
            mainForm.Controls.Add(butRedo);
            mainForm.Controls.Add(butUndo);
            mainForm.Controls.Add(lblTime);
            mainForm.Controls.Add(mainMenu);
            mainForm.MainMenuStrip = mainMenu;
        }

        private void DrawLoadGame(Form loadForm)
        {
            int Y = 40, count = 1;
            loadForm.Controls.Clear();
            if (SaveGameHelper.saveData.GameSaveList.Count == 0)
            {
                Label info = new Label()
                {
                    Text = "Nothing To Load",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(200, 30),
                    Location = new Point(120, Y)
                };
                Y += 60;
                loadForm.Controls.Add(info);
            }
            else
            {
                foreach (GameSaveData item in SaveGameHelper.saveData.GameSaveList)
                {
                    string butText = count.ToString() + "." + item.PlayerName1 + " vs " + item.PlayerName2 + "; row: "
                        + item.NumberOfRow + "/ column: " + item.NumberOfColumn;
                    Button button = new Button()
                    {
                        Text = butText,
                        Size = new Size(200, 40),
                        Location = new Point(70, Y)
                    };
                    Button buttonDelete = new Button()
                    {
                        Tag = count,
                        Text = "X",
                        Size = new Size(40, 40),
                        Location = new Point(270, Y)
                    };
                    button.Click += Button_Click;
                    buttonDelete.Click += ButtonDelete_Click;
                    loadForm.Controls.Add(button);
                    loadForm.Controls.Add(buttonDelete);
                    Y += 60; count++;
                }
            }
            DrawCommonForm(ref loadForm, Config.NAME.LOAD_GAME, 400, Y + 110, false);
            //butCancel.Location = new Point(170, Y + 30);
            //loadForm.Controls.Add(butCancel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aboutForm"></param>
        private void DrawAboutGame(Form aboutForm)
        {
            DrawCommonForm(ref aboutForm, Config.NAME.ABOUT, 400, 250);
            aboutForm.Icon = new Icon("../../../Resources/Image/about.ico");
            aboutForm.Controls.Add(rtbAbout);
        }
        #endregion
        #endregion
    }
}
