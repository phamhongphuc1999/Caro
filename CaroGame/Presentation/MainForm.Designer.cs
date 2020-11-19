﻿using System.Drawing;
using System.Windows.Forms;
using CaroGame.Configuration;
using CaroGame.SaveGameManagement;

namespace CaroGame.Presentaion
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        
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
                Text = "Setting Game",
                ShortcutKeys = (Keys)Shortcut.CtrlShiftS
            };
            toolItemNewGame = new ToolStripMenuItem()
            {
                Text = "New Game",
                ShortcutKeys = (Keys)Shortcut.CtrlN
            };
            toolItemQuick = new ToolStripMenuItem()
            {
                Text = "Quick Game",
                ShortcutKeys = (Keys)Shortcut.CtrlQ
            };
            bottomQuickSeparator = new ToolStripSeparator();
            toolItemAbout = new ToolStripMenuItem()
            {
                Text = "About"
            };
            toolItemMain = new ToolStripMenuItem()
            {
                Text = "Menu"
            };
            toolItemMain.DropDownItems.AddRange(new ToolStripItem[]
            {
                toolItemNewGame,
                toolItemSetting,
                toolItemQuick,
                bottomQuickSeparator,
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
            #region Overview
            butNewGame = new Button()
            {
                Text = "New Game",
                Size = new Size(150, 65),
                Location = new Point(100, 155),
                FlatStyle = FlatStyle.Flat,
                BackColor = ColorTranslator.FromHtml("#8BC4FC")
            };
            butGuide = new Button()
            {
                Text = "Guide",
                Size = new Size(150, 65),
                Location = new Point(350, 155),
                BackColor = ColorTranslator.FromHtml("#8BC4FC")
            };
            butNewGame.Click += ButNewGame_Click;
            butGuide.Click += ButGuide_Click;
            #endregion

            #region Game Mode
            butTwoPlayer = new Button()
            {
                Text = "Two Player",
                Size = new Size(144, 55),
                Location = new Point(42, 70),
                BackColor = ColorTranslator.FromHtml("#8BC4FC")
            };
            butModeLan = new Button()
            {
                Text = "LAN Mode",
                Size = new Size(144, 55),
                Location = new Point(228, 70),
                BackColor = ColorTranslator.FromHtml("#8BC4FC")
            };
            butModeAI = new Button()
            {
                Name = "butModeAI",
                Text = "One Player",
                Size = new Size(144, 55),
                Location = new Point(414, 70),
                BackColor = ColorTranslator.FromHtml("#8BC4FC")
            };
            lblOr = new Label()
            {
                Name = "lblOr",
                Text = "OR",
                Size = new Size(60, 20),
                Location = new Point(270, 177)
            };
            butTwoPlayer.Click += ButTwoPlayer_Click;
            butModeLan.Click += ButModeLan_Click;
            butModeAI.Click += ButModeAI_Click;
            #endregion

            #region Player Infomation
            lblName1Row = new Label()
            {
                Size = new Size(80, 45),
                Location = new Point(30, 85)
            };
            lblName2Column = new Label()
            {
                Size = new Size(80, 45),
                Location = new Point(30, 170)
            };
            txtName1Row = new TextBox()
            {
                Width = 360,
                Location = new Point(120, 85)
            };
            txtName2Column = new TextBox()
            {
                Width = 360,
                Location = new Point(120, 170)
            };
            butCancel = new Button()
            {
                Text = "Back",
                Size = new Size(90, 40)
            };
            butCancel.Click += ButCancel_Click;
            #endregion

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
            CreateMainMenu();
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

            #region Common Setting
            butGameMode = new Button()
            {
                Text = "Game Mode",
                Size = new Size(144, 55),
                Location = new Point(42, 70)
            };
            butTimer = new Button()
            {
                Text = "Time",
                Size = new Size(144, 55),
                Location = new Point(228, 70)
            };
            butNamePlayer = new Button()
            {
                Text = "Player",
                Size = new Size(144, 55),
                Location = new Point(414, 70)
            };
            butSizeBoard = new Button()
            {
                Text = "Size Board",
                Size = new Size(144, 55),
                Location = new Point(42, 145)
            };
            butSound = new Button()
            {
                Text = "Sound",
                Size = new Size(144, 55),
                Location = new Point(228, 145)
            };
            butSave = new Button()
            {
                Text = "Save Change",
                Size = new Size(90, 40),
                Location = new Point(490, 280)
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
                Enabled = Config.IS_ON_TIMER ? true : false,
                Size = new Size(80, 40),
                Location = new Point(30, 80)
            };

            lblSTimeInterval = new Label()
            {
                Text = "Interval",
                Enabled = Config.IS_ON_TIMER ? true : false,
                Size = new Size(80, 40),
                Location = new Point(30, 170)
            };

            txtSTimeTurn = new TextBox()
            {
                Text = Config.TIME_TURN.ToString(),
                Enabled = Config.IS_ON_TIMER ? true : false,
                Width = 360,
                Location = new Point(120, 85)
            };

            txtSTimeInterval = new TextBox()
            {
                Text = Config.INTERVAL.ToString(),
                Enabled = Config.IS_ON_TIMER ? true : false,
                Width = 360,
                Location = new Point(120, 170)
            };

            butStatusTime = new Button()
            {
                Text = Config.IS_ON_TIMER ? "Off Timer" : "On Timer",
                Size = new Size(90, 40),
                Location = new Point(250, 280)
            };
            butStatusTime.Click += ButStatusTime_Click;
            #endregion

            #region Sound Setting
            lblSSound = new Label()
            {
                Text = "Volume",
                Size = new Size(80, 40),
                Location = new Point(40, 100)
            };
            numSound = new NumericUpDown()
            {
                Size = new Size(350, 30),
                Location = new Point(130, 100),
                Value = new decimal(Config.VOLUME_SIZE),
                Maximum = new decimal(100),
                Minimum = new decimal(0),
                ThousandsSeparator = true
            };
            #endregion

            #region Load And Save Game
            butLoadGame = new Button();
            butLoadGame.Text = "Load Game";
            butSaveGame = new Button()
            {
                Text = "Save Game",
                Size = new Size(110, 40),
                Location = new Point(485, 0)
            };
            butSaveGame.Click += ButSaveGame_Click;
            butLoadGame.Click += ButLoadGame_Click;
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
                Interval = Config.INTERVAL * 1000
            };
            timer.Tick += Timer_Tick;
        }
        #endregion

        #region Draw Form
        private void DrawCommonForm(ref Form form, string formText, int width = 600, int height = 375, bool isClear = true)
        {
            if(isClear) form.Controls.Clear();
            form.Text = formText;
            form.AutoScaleDimensions = new SizeF(9F, 20F);
            form.ClientSize = new Size(width, height);
            Config.caroFlow.Push(formText);
        }

        private void DrawOverviewForm(Form overviewForm, string formText)
        {
            DrawCommonForm(ref overviewForm, formText);
            overviewForm.Controls.Add(butNewGame);
            overviewForm.Controls.Add(butGuide);
        }

        private void DrawGameModeForm(Form gameModeForm, string formText)
        {
            DrawCommonForm(ref gameModeForm, formText);
            butLoadGame.Location = new Point(225, 250);
            butLoadGame.Size = new Size(150, 55);
            gameModeForm.Controls.Add(butTwoPlayer);
            gameModeForm.Controls.Add(butModeLan);
            gameModeForm.Controls.Add(butModeAI);
            if (formText == Config.NAME.GAME_MODE_SETTING)
            {
                butCancel.Location = new Point(370, 280);
                gameModeForm.Controls.Add(butCancel);
            }
            else
            {
                gameModeForm.Controls.Add(butLoadGame);
                gameModeForm.Controls.Add(lblOr);
            }
        }

        private void DrawPlayerForm(Form playerForm, string formText, string gameMode = "")
        {
            DrawCommonForm(ref playerForm, formText);
            txtName1Row.Text = Config.NAME_PLAYER1;
            txtName2Column.Text = Config.NAME_PLAYER2;
            if (gameMode == Config.GAME_MODE.LAN) lblName1Row.Text = "Player";
            else
            {
                lblName1Row.Text = "Player 1";
                lblName2Column.Text = "Player 2";
                playerForm.Controls.Add(lblName2Column);
                playerForm.Controls.Add(txtName2Column);

            }
            playerForm.Controls.Add(lblName1Row);
            playerForm.Controls.Add(txtName1Row);
            butCancel.Location = new Point(370, 280);
            playerForm.Controls.Add(butCancel);
            playerForm.Controls.Add(butSave);
            if (formText == "Player") butSave.Text = "Next";
            else if (formText == Config.NAME.PLAYER_SETTING) butSave.Text = "Save Change";
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
            butCancel.Location = new Point(370, 280);
            DrawCommonForm(ref LANForm, Config.NAME.LAN_CONNECTION);
            LANForm.Controls.Add(lblName1Row);
            LANForm.Controls.Add(lblName2Column);
            LANForm.Controls.Add(txtName1Row);
            LANForm.Controls.Add(txtName2Column);
            LANForm.Controls.Add(butSave);
            LANForm.Controls.Add(butConnect);
            LANForm.Controls.Add(butCancel);
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

        private void DrawSettingForm(Form settingForm)
        {
            DrawCommonForm(ref settingForm, Config.NAME.SETTING);
            settingForm.Icon = new Icon("../../../Resources/Image/setting.ico");
            butLoadGame.Size = new Size(110, 40);
            butLoadGame.Location = new Point(370, 0);
            butCancel.Location = new Point(370, 280);
            settingForm.Controls.Add(butGameMode);
            settingForm.Controls.Add(butTimer);
            settingForm.Controls.Add(butNamePlayer);
            settingForm.Controls.Add(butSizeBoard);
            settingForm.Controls.Add(butSound);
            settingForm.Controls.Add(butSave);
            settingForm.Controls.Add(butCancel);
            settingForm.Controls.Add(butSaveGame);
            settingForm.Controls.Add(butLoadGame);
            butSave.Text = "Save Change";
            if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.TWO_PLAYER) butTimer.Enabled = true;
            else if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN) butTimer.Enabled = false;
        }

        private void DrawTimeSettingForm(Form timeSettingForm)
        {
            DrawCommonForm(ref timeSettingForm, Config.NAME.TIME_SETTING);
            butCancel.Location = new Point(370, 280);
            timeSettingForm.Controls.Add(lblSTimeTurn);
            timeSettingForm.Controls.Add(lblSTimeInterval);
            timeSettingForm.Controls.Add(txtSTimeTurn);
            timeSettingForm.Controls.Add(txtSTimeInterval);
            timeSettingForm.Controls.Add(butStatusTime);
            timeSettingForm.Controls.Add(butCancel);
            timeSettingForm.Controls.Add(butSave);
            butSave.Text = "Save Change";
        }

        private void DrawSizeSettingForm(Form sizeSettingForm)
        {
            DrawCommonForm(ref sizeSettingForm, Config.NAME.SIZE_SETTING);
            butCancel.Location = new Point(370, 280);
            lblName1Row.Text = "Row";
            lblName2Column.Text = "Column";
            txtName1Row.Text = Config.NUMBER_OF_ROW.ToString();
            txtName2Column.Text = Config.NUMBER_OF_COLUMN.ToString();
            sizeSettingForm.Controls.Add(lblName1Row);
            sizeSettingForm.Controls.Add(lblName2Column);
            sizeSettingForm.Controls.Add(txtName1Row);
            sizeSettingForm.Controls.Add(txtName2Column);
            sizeSettingForm.Controls.Add(butSave);
            sizeSettingForm.Controls.Add(butCancel);
            butSave.Text = "Save Change";
        }

        private void DrawSoundSettingForm(Form soundSettingForm)
        {
            DrawCommonForm(ref soundSettingForm, Config.NAME.SOUND_SETTING);
            butCancel.Location = new Point(370, 280);
            soundSettingForm.Controls.Add(lblSSound);
            soundSettingForm.Controls.Add(numSound);
            soundSettingForm.Controls.Add(butSave);
            soundSettingForm.Controls.Add(butCancel);
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
            butCancel.Location = new Point(170, Y + 30);
            loadForm.Controls.Add(butCancel);
        }

        private void DrawAboutGame(Form aboutForm)
        {
            DrawCommonForm(ref aboutForm, Config.NAME.ABOUT, 400, 250);
            aboutForm.Icon = new Icon("../../../Resources/Image/about.ico");
            aboutForm.Controls.Add(rtbAbout);
        }
        #endregion

        private void InitializeComponent()
        {
            this.Icon = new Icon("../../../Resources/Image/caro.ico");
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Opacity = 1;
            this.Text = "MainForm";
        }
        #endregion

        private Timer timer;
        private Form settingForm;
        private MenuStrip mainMenu;
        private NumericUpDown numSound;
        private RichTextBox rtbChat, rtbAbout;
        private Panel pnlCaroBoard, pnlChat;
        private ToolStripSeparator bottomQuickSeparator;
        private Button butTwoPlayer, butModeLan, butModeAI, butUndo, butRedo, butSaveGame, butNewGame;
        private Button butGameMode, butTimer, butNamePlayer, butSizeBoard, butSound, butSave, butGuide;
        private Button butStatusTime, butConnect, butCancel, butGetIP, butLoadGame, butChat;
        private ToolStripMenuItem toolItemMain, toolItemNewGame, toolItemQuick, toolItemSetting, toolItemAbout;
        private TextBox txtPlayer, txtSTimeTurn, txtSTimeInterval, txtName1Row, txtName2Column, txtChat;
        private Label lblTime, lblSTimeTurn, lblSTimeInterval, lblName1Row, lblName2Column, lblSSound, lblOr;
    }
}