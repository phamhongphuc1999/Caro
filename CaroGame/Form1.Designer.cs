using System.Drawing;
using System.Windows.Forms;
using System;
using CaroGame.Config;
using CaroGame.SaveGameManagement;

namespace CaroGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Timer timer;
        private Form settingForm;
        private MenuStrip mainMenu;
        private NumericUpDown numSound;
        private RichTextBox rtbChat, rtbAbout;
        private Panel pnlCaroBoard, pnlChat;
        private Button butColorPlayer1, butColorPlayer2;
        private Button butTwoPlayer, butModeLan, butModeAI, butUndo, butRedo, butLoadBack;
        private Button butGameMode, butTimer, butNamePlayer, butSizeBoard, butSound, butSave, butChat;
        private Button butSTimeOnOrOff, butConnect, butBack, butGetIP, butLoadGame, butLoadGameSetting, butSaveGame;
        private ToolStripMenuItem toolItemMain, toolItemNewGame, toolItemQuick, toolItemSetting, toolItemAbout;
        private TextBox txtPlayer, txtSTimeTurn, txtSTimeInterval, txtName1Row, txtName2Column, txtChat;
        private Label lblTime, lblSTimeTurn, lblSTimeInterval, lblName1Row, lblName2Column, lblSSound, lblOr;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        #region Initialize Controller
        private void CreateMainMenu()
        {
            toolItemSetting = new ToolStripMenuItem()
            {
                Name = "Setting",
                Text = "Setting"
            };

            toolItemNewGame = new ToolStripMenuItem()
            {
                Name = "NewGame",
                Text = "New Game"
            };

            toolItemQuick = new ToolStripMenuItem()
            {
                Name = "Quick",
                Text = "Quick Game"
            };

            toolItemAbout = new ToolStripMenuItem()
            {
                Name = "About",
                Text = "About"
            };

            toolItemMain = new ToolStripMenuItem()
            {
                Name = "Main",
                Text = "Menu"
            };
            toolItemMain.DropDownItems.AddRange(new ToolStripItem[]
            {
                toolItemNewGame,
                toolItemSetting,
                toolItemQuick,
                toolItemAbout
            });
            toolItemNewGame.Click += ToolItemNewGame_Click;
            toolItemQuick.Click += ToolItemQuick_Click;
            toolItemSetting.Click += ToolItemSetting_Click;
            toolItemAbout.Click += ToolItemAbout_Click;

            mainMenu = new MenuStrip()
            {
                Name = "mainMenu",
                Text = "Menu",
                GripMargin = new Padding(2, 2, 0, 2),
                ImageScalingSize = new Size(24, 24),
                Location = new Point(0, 0),
                TabIndex = 0
            };

            mainMenu.Items.AddRange(new ToolStripItem[]
            {
                toolItemMain
            });
        }

        private void InitializeController()
        {
            #region Game Mode
            butTwoPlayer = new Button()
            {
                Text = "Two Player",
                Size = new Size(100, 40),
                Location = new Point(25, 40)
            };
            butModeLan = new Button()
            {
                Text = "LAN Mode",
                Size = new Size(100, 40),
                Location = new Point(150, 40)
            };
            butModeAI = new Button()
            {
                Name = "butModeAI",
                Text = "One Player",
                Size = new Size(100, 40),
                Location = new Point(275, 40)
            };
            lblOr = new Label()
            {
                Name = "lblOr",
                Text = "OR",
                Size = new Size(60, 20),
                Location = new Point(180, 100)
            };
            butTwoPlayer.Click += ButTwoPlayer_Click;
            butModeLan.Click += ButModeLan_Click;
            butModeAI.Click += ButModeAI_Click;
            #endregion

            #region Player Infomation
            lblName1Row = new Label()
            {
                Size = new Size(50, 30),
                Location = new Point(20, 43)
            };
            lblName2Column = new Label()
            {
                Size = new Size(50, 30),
                Location = new Point(20, 93)
            };
            txtName1Row = new TextBox()
            {
                Width = 220,
                Location = new Point(80, 40)
            };
            txtName2Column = new TextBox()
            {
                Width = 220,
                Location = new Point(80, 90)
            };
            butColorPlayer1 = new Button()
            {
                Text = "Red",
                Size = new Size(80, 20),
                Location = new Point(302, 40),
                BackColor = Color.Red
            };
            butColorPlayer2 = new Button()
            {
                Text = "Green",
                Size = new Size(80, 20),
                Location = new Point(302, 90),
                BackColor = Color.Green
            };
            butBack = new Button()
            {
                Text = "Back",
                Size = new Size(80, 30),
                Location = new Point(170, 200)
            };
            butColorPlayer1.Click += ButColorPlayer1_Click;
            butColorPlayer2.Click += ButColorPlayer2_Click;
            butBack.Click += ButBack_Click;
            #endregion

            #region LAN Mode
            butConnect = new Button()
            {
                Size = new Size(220, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(80, 110)
            };
            butGetIP = new Button()
            {
                Text = "Get IP",
                Size = new Size(70, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(310, 30)
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
                Size = new Size(60, 20)
            };
            butRedo = new Button()
            {
                Text = "Redo",
                Size = new Size(60, 20)
            };
            txtPlayer = new TextBox()
            {
                Size = new Size(180, 20),
                ReadOnly = true
            };
            lblTime = new Label()
            {
                Size = new Size(50, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 30)
            };
            CreateMainMenu();
            butRedo.Click += ButRedo_Click;
            butUndo.Click += ButUndo_Click;
            #endregion

            #region CHAT Form in LAN Mode
            pnlChat = new Panel();
            txtChat = new TextBox()
            {
                Multiline = true,
                Size = new Size(260, 40),
            };
            butChat = new Button()
            {
                Text = "Send",
                Size = new Size(40, 40)
            };
            rtbChat = new RichTextBox();
            butChat.Click += ButChat_Click;
            #endregion

            #region Common Setting
            butGameMode = new Button()
            {
                Text = "Game Mode",
                Size = new Size(80, 40),
                Location = new Point(50, 45)
            };
            butTimer = new Button()
            {
                Text = "Time",
                Size = new Size(80, 40),
                Location = new Point(160, 45)
            };
            butNamePlayer = new Button()
            {
                Text = "Player",
                Size = new Size(80, 40),
                Location = new Point(270, 45)
            };
            butSizeBoard = new Button()
            {
                Text = "Size Board",
                Size = new Size(80, 40),
                Location = new Point(50, 95)
            };
            butSound = new Button()
            {
                Text = "Sound",
                Size = new Size(80, 40),
                Location = new Point(160, 95)
            };
            butSave = new Button()
            {
                Text = "Save Change",
                Size = new Size(80, 30),
                Location = new Point(270, 200)
            };
            butGameMode.Click += ButGameMode_Click;
            butTimer.Click += ButTimer_Click;
            butNamePlayer.Click += ButNamePlayer_Click;
            butSizeBoard.Click += ButSizeBoard_Click;
            butSound.Click += ButSound_Click;
            butSave.Click += ButSave_Click;
            #endregion

            #region Time Setting
            lblSTimeTurn = new Label()
            {
                Text = "Time Turn",
                Enabled = CONST.IS_ON_TIMER ? true : false,
                Size = new Size(60, 30),
                Location = new Point(20, 30)
            };

            lblSTimeInterval = new Label()
            {
                Text = "Interval",
                Enabled = CONST.IS_ON_TIMER ? true : false,
                Size = new Size(60, 30),
                Location = new Point(20, 80)
            };

            txtSTimeTurn = new TextBox()
            {
                Text = CONST.TIME_TURN.ToString(),
                Enabled = CONST.IS_ON_TIMER ? true : false,
                Width = 220,
                Location = new Point(80, 30)
            };

            txtSTimeInterval = new TextBox()
            {
                Text = CONST.INTERVAL.ToString(),
                Enabled = CONST.IS_ON_TIMER ? true : false,
                Width = 220,
                Location = new Point(80, 80)
            };

            butSTimeOnOrOff = new Button()
            {
                Text = CONST.IS_ON_TIMER ? "Off Timer" : "On Timer",
                Size = new Size(80, 30),
                Location = new Point(70, 200)
            };
            butSTimeOnOrOff.Click += ButSTimeOnOrOff_Click;
            #endregion

            #region Sound Setting
            lblSSound = new Label()
            {
                Text = "Volume",
                Size = new Size(60, 30),
                Location = new Point(20, 90)
            };
            numSound = new NumericUpDown()
            {
                Size = new Size(220, 20),
                Location = new Point(80, 90),
                Value = new decimal(CONST.VOLUME_SIZE),
                Maximum = new decimal(100),
                Minimum = new decimal(0),
                ThousandsSeparator = true
            };
            #endregion

            #region Load And Save Game
            butLoadGame = new Button()
            {
                Text = "Load Game",
                Size = new Size(120, 40),
                Location = new Point(140, 140)
            };
            butSaveGame = new Button()
            {
                Text = "Save Game",
                Size = new Size(73, 20),
                Location = new Point(327, 0)
            };
            butLoadGameSetting = new Button()
            {
                Text = "Load Game",
                Size = new Size(73, 20),
                Location = new Point(254, 0)
            };
            butLoadBack = new Button()
            {
                Text = "Back",
                Size = new Size(80, 30)
            };
            butLoadBack.Click += ButLoadBack_Click;
            butSaveGame.Click += ButSaveGame_Click;
            butLoadGame.Click += ButLoadGame_Click;
            butLoadGameSetting.Click += ButLoadGameSetting_Click;
            #endregion

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

            this.Icon = new Icon("./Image/caro.ico");
            settingForm = new Form()
            {
                Tag = 1,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };
            settingForm.FormClosing += SettingForm_FormClosing;
            timer = new Timer()
            {
                Interval = CONST.INTERVAL * 1000
            };
            timer.Tick += Timer_Tick;
        }
        #endregion

        #region Draw Form
        private void DrawCommonForm(ref Form form, string formText, int width = 400, int height = 250)
        {
            form.Controls.Clear();
            form.Text = formText;
            form.AutoScaleDimensions = new SizeF(9F, 20F);
            form.ClientSize = new Size(width, height);
        }

        private void DrawGameModeForm(Form gameModeForm, string formText)
        {
            DrawCommonForm(ref gameModeForm, formText);
            gameModeForm.Controls.Add(butTwoPlayer);
            gameModeForm.Controls.Add(butModeLan);
            gameModeForm.Controls.Add(butModeAI);
            if (formText == "Game Mode Setting") gameModeForm.Controls.Add(butBack);
            else
            {
                gameModeForm.Controls.Add(butLoadGame);
                gameModeForm.Controls.Add(lblOr);
            }
        }

        private void DrawPlayerForm(Form playerForm, string formText, string gameMode = "")
        {
            DrawCommonForm(ref playerForm, formText);
            txtName1Row.Text = CONST.NAME_PLAYER1;
            txtName2Column.Text = CONST.NAME_PLAYER2;
            if (gameMode == "LAN") lblName1Row.Text = "Player";
            else
            {
                lblName1Row.Text = "Player 1";
                lblName2Column.Text = "Player 2";
                playerForm.Controls.Add(lblName2Column);
                playerForm.Controls.Add(txtName2Column);
                playerForm.Controls.Add(butColorPlayer2);

            }
            playerForm.Controls.Add(lblName1Row);
            playerForm.Controls.Add(txtName1Row);
            playerForm.Controls.Add(butColorPlayer1);
            playerForm.Controls.Add(butBack);
            playerForm.Controls.Add(butSave);
            if (formText == "Player") butSave.Text = "Next";
            else if (formText == "Player Setting") butSave.Text = "Save Change";
            butSave.Enabled = true;
        }

        private void DrawLANForm(Form LANForm)
        {
            butSave.Text = "Next";
            butSave.Enabled = false;
            butConnect.Text = "Connect";
            butConnect.BackColor = Color.White;
            butConnect.Enabled = true;
            butGetIP.Enabled = true;
            txtName2Column.ReadOnly = false;
            txtName1Row.ReadOnly = false;
            txtName1Row.Text = "";
            lblName1Row.Text = "IP";
            lblName2Column.Text = "Port";
            DrawCommonForm(ref LANForm, "LAN Connection");
            LANForm.Controls.Add(lblName1Row);
            LANForm.Controls.Add(lblName2Column);
            LANForm.Controls.Add(txtName1Row);
            LANForm.Controls.Add(txtName2Column);
            LANForm.Controls.Add(butSave);
            LANForm.Controls.Add(butConnect);
            LANForm.Controls.Add(butBack);
            LANForm.Controls.Add(butGetIP);
        }

        private void DrawMainForm(Form mainForm)
        {
            int width = CONST.NUMBER_OF_COLUMN * CONST.CHESS_SIZE.Width;
            int height = CONST.NUMBER_OF_ROW * CONST.CHESS_SIZE.Height;
            DrawCommonForm(ref mainForm, "Caro", width, height);
            txtPlayer.Location = new Point(pnlCaroBoard.Width - 180, 0);
            butUndo.Location = new Point(pnlCaroBoard.Width - 60, 30);
            butRedo.Location = new Point(pnlCaroBoard.Width - 120, 30);
            mainForm.AutoSize = true;
            if (CONST.GAME_MODE == "LAN")
            {
                pnlChat.Size = new Size(300, pnlCaroBoard.Height + 70);
                pnlChat.Location = new Point(pnlCaroBoard.Width, 0);
                txtChat.Location = new Point(0, pnlChat.Height - 40);
                butChat.Location = new Point(260, pnlChat.Height - 40);
                rtbChat.Size = new Size(300, pnlChat.Height - 40);
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
        }

        private void DrawSettingForm(Form settingForm)
        {
            DrawCommonForm(ref settingForm, "Setting");
            settingForm.Icon = new Icon("./Image/setting.ico");
            settingForm.Controls.Add(butGameMode);
            settingForm.Controls.Add(butTimer);
            settingForm.Controls.Add(butNamePlayer);
            settingForm.Controls.Add(butSizeBoard);
            settingForm.Controls.Add(butSound);
            settingForm.Controls.Add(butSave);
            settingForm.Controls.Add(butSaveGame);
            settingForm.Controls.Add(butLoadGameSetting);
            butSave.Text = "Save Change";
            if (CONST.GAME_MODE == "TWO_PLAYER") butTimer.Enabled = true;
            else if (CONST.GAME_MODE == "LAN") butTimer.Enabled = false;
        }

        private void DrawTimeSettingForm(Form timeSettingForm)
        {
            DrawCommonForm(ref timeSettingForm, "Time Setting");
            timeSettingForm.Controls.Add(lblSTimeTurn);
            timeSettingForm.Controls.Add(lblSTimeInterval);
            timeSettingForm.Controls.Add(txtSTimeTurn);
            timeSettingForm.Controls.Add(txtSTimeInterval);
            timeSettingForm.Controls.Add(butSTimeOnOrOff);
            timeSettingForm.Controls.Add(butBack);
            timeSettingForm.Controls.Add(butSave);
            butSave.Text = "Save Change";
        }

        private void DrawSizeSettingForm(Form sizeSettingForm)
        {
            DrawCommonForm(ref sizeSettingForm, "Size Setting");
            lblName1Row.Text = "Row";
            lblName2Column.Text = "Column";
            txtName1Row.Text = CONST.NUMBER_OF_ROW.ToString();
            txtName2Column.Text = CONST.NUMBER_OF_COLUMN.ToString();
            sizeSettingForm.Controls.Add(lblName1Row);
            sizeSettingForm.Controls.Add(lblName2Column);
            sizeSettingForm.Controls.Add(txtName1Row);
            sizeSettingForm.Controls.Add(txtName2Column);
            sizeSettingForm.Controls.Add(butSave);
            sizeSettingForm.Controls.Add(butBack);
            butSave.Text = "Save Change";
        }

        private void DrawSoundSettingForm(Form soundSettingForm)
        {
            DrawCommonForm(ref soundSettingForm, "Sound Setting");
            soundSettingForm.Controls.Add(lblSSound);
            soundSettingForm.Controls.Add(numSound);
            soundSettingForm.Controls.Add(butSave);
            soundSettingForm.Controls.Add(butBack);
        }

        private void DrawLoadGame(Form loadForm)
        {
            int Y = 20, count = 1;
            if (CONST.saveData.GameSaveList.Count == 0)
            {
                Label info = new Label()
                {
                    Text = "Nothing To Load",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(200, 30),
                    Location = new Point(120, Y)
                };
                Y += 40;
                loadForm.Controls.Add(info);
            }
            else
            {
                foreach (GameSave item in CONST.saveData.GameSaveList)
                {
                    string butText = count.ToString() + "." + item.PlayerName1 + " vs " + item.PlayerName2 + "; row: "
                        + item.NumberOfRow + "/ column: " + item.NumberOfColumn;
                    Button button = new Button()
                    {
                        Text = butText,
                        Size = new Size(200, 30),
                        Location = new Point(70, Y)
                    };
                    Button buttonDelete = new Button()
                    {
                        Tag = count,
                        Text = "X",
                        Size = new Size(30, 30),
                        Location = new Point(270, Y)
                    };
                    button.Click += Button_Click;
                    buttonDelete.Click += ButtonDelete_Click;
                    loadForm.Controls.Add(button);
                    loadForm.Controls.Add(buttonDelete);
                    Y += 40; count++;
                }
            }
            //loadForm.ClientSize = new Size(400, Y + 60);
            DrawCommonForm(ref loadForm, "Load Game", 400, Y + 60);
            butLoadBack.Location = new Point(170, Y + 10);
            loadForm.Controls.Add(butLoadBack);
        }

        private void DrawAboutGame(Form aboutForm)
        {
            DrawCommonForm(ref aboutForm, "About", 210, 120);
            aboutForm.Icon = new Icon("./Image/about.ico");
            aboutForm.Controls.Add(rtbAbout);
        }
        #endregion
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}
