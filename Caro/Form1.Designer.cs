using System.Windows.Forms;
using System.Drawing;
using Caro.Setting;

namespace Caro
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Form settingForm;
        private Panel pnlCaroBoard;
        private MenuStrip mainMenu;
        private Timer timer;
        private NumericUpDown numSound;
        private Button butTwoPlayer, butModeLan, butUndo, butRedo;
        private Button butGameMode, butTimer, butNamePlayer, butSizeBoard, butSound, butSave;
        private Button butSTimeOnOrOff, butConnect, butBack, butGetIP, butLoadGame, butSaveGame;
        private ToolStripMenuItem toolItemMain, toolItemNewGame, toolItemQuick, toolItemSetting;
        private TextBox txtPlayer, txtSTimeTurn, txtSTimeInterval, txtName1Row, txtName2Column;
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

            toolItemMain = new ToolStripMenuItem()
            {
                Name = "Main",
                Text = "Menu"
            };
            toolItemMain.DropDownItems.AddRange(new ToolStripItem[]
            {
                toolItemNewGame,
                toolItemSetting,
                toolItemQuick
            });
            toolItemNewGame.Click += ToolItemNewGame_Click;
            toolItemQuick.Click += ToolItemQuick_Click;
            toolItemSetting.Click += ToolItemSetting_Click;

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
                Name = "butMode",
                Text = "Two Player",
                Size = new Size(120, 40),
                Location = new Point(40, 40)
            };
            butModeLan = new Button()
            {
                Name = "butModeLan",
                Text = "LAN Mode",
                Size = new Size(120, 40),
                Location = new Point(240, 40)
            };
            butLoadGame = new Button()
            {
                Name = "butLoadGame",
                Text = "Load Game",
                Size = new Size(120, 40),
                Location = new Point(140, 180)
            };
            lblOr = new Label()
            {
                Name = "lblOr",
                Text = "OR",
                Size = new Size(60, 20),
                Location = new Point(170, 110)
            };
            butTwoPlayer.Click += ButTwoPlayer_Click;
            butModeLan.Click += ButModeLan_Click;
            butLoadGame.Click += ButLoadGame_Click;
            #endregion

            #region Name Player
            lblName1Row = new Label()
            {
                Name = "lblName1Row",
                Size = new Size(50, 30),
                Location = new Point(20, 30)
            };
            lblName2Column = new Label()
            {
                Name = "lblName2Column",
                Size = new Size(50, 30),
                Location = new Point(20, 80)
            };
            txtName1Row = new TextBox()
            {
                Name = "txtName1Row",
                Width = 270,
                Location = new Point(80, 30)
            };
            txtName2Column = new TextBox()
            {
                Name = "txtName2Column",
                Width = 270,
                Location = new Point(80, 80)
            };
            butBack = new Button()
            {
                Name = "butBack",
                Text = "Back",
                Size = new Size(80, 30),
                Location = new Point(170, 200)
            };
            butBack.Click += ButBack_Click;
            #endregion

            #region LAN
            butConnect = new Button()
            {
                Name = "butConnect",
                Size = new Size(220, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(80, 110)
            };
            butGetIP = new Button()
            {
                Name = "butGetIP",
                Text = "Get IP",
                Size = new Size(70, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(310, 30)
            };
            butConnect.Click += ButConnect_Click;
            butGetIP.Click += ButGetIP_Click;
            #endregion

            #region Main
            pnlCaroBoard = new Panel()
            {
                Name = "pnlCaroBoard",
                Location = new Point(1, 70)
            };
            butUndo = new Button()
            {
                Name = "butUndo",
                Text = "Undo",
                Size = new Size(60, 20)
            };
            butRedo = new Button()
            {
                Name = "butRedo",
                Text = "Redo",
                Size = new Size(60, 20)
            };
            txtPlayer = new TextBox()
            {
                Name = "txtPlayer",
                ReadOnly = true
            };
            lblTime = new Label()
            {
                Name = "lblTime",
                Location = new Point(0, 30)
            };
            CreateMainMenu();
            butRedo.Click += ButRedo_Click;
            butUndo.Click += ButUndo_Click;
            #endregion

            #region Setting
            butGameMode = new Button()
            {
                Name = "butGameMode",
                Text = "Game Mode",
                Size = new Size(80, 40),
                Location = new Point(50, 45)
            };
            butTimer = new Button()
            {
                Name = "butTimer",
                Text = "Time",
                Size = new Size(80, 40),
                Location = new Point(160, 45)
            };
            butNamePlayer = new Button()
            {
                Name = "butNamePlayer",
                Text = "Name Player",
                Size = new Size(80, 40),
                Location = new Point(270, 45)
            };
            butSizeBoard = new Button()
            {
                Name = "butSizeBoard",
                Text = "Size Board",
                Size = new Size(80, 40),
                Location = new Point(50, 95)
            };
            butSound = new Button()
            {
                Name = "butSound",
                Text = "Sound",
                Size = new Size(80, 40),
                Location = new Point(160, 95)
            };
            butSave = new Button()
            {
                Name = "butSave",
                Text = "Save Change",
                Size = new Size(80, 30),
                Location = new Point(270, 200)
            };
            butSaveGame = new Button()
            {
                Name = "butSaveGame",
                Text = "Save Game",
                Size = new Size(73, 20),
                Location = new Point(327, 0)
            };
            butGameMode.Click += ButGameMode_Click;
            butTimer.Click += ButTimer_Click;
            butNamePlayer.Click += ButNamePlayer_Click;
            butSizeBoard.Click += ButSizeBoard_Click;
            butSound.Click += ButSound_Click;
            butSave.Click += ButSave_Click;
            butSaveGame.Click += ButSaveGame_Click;
            #endregion

            #region Time Setting
            lblSTimeTurn = new Label()
            {
                Name = "lblSTimeTurn",
                Text = "Time Turn",
                Enabled = CONST.IS_ON_TIMER ? true : false,
                Size = new Size(60, 30),
                Location = new Point(20, 30)
            };

            lblSTimeInterval = new Label()
            {
                Name = "lblSTimeInterval",
                Text = "Interval",
                Enabled = CONST.IS_ON_TIMER ? true : false,
                Size = new Size(60, 30),
                Location = new Point(20, 80)
            };

            txtSTimeTurn = new TextBox()
            {
                Name = "txtSTimeTurn",
                Text = CONST.TIME_TURN.ToString(),
                Enabled = CONST.IS_ON_TIMER ? true : false,
                Width = 220,
                Location = new Point(80, 30)
            };

            txtSTimeInterval = new TextBox()
            {
                Name = "txtSTimeInterval",
                Text = CONST.INTERVAL.ToString(),
                Enabled = CONST.IS_ON_TIMER ? true : false,
                Width = 220,
                Location = new Point(80, 80)
            };

            butSTimeOnOrOff = new Button()
            {
                Name = "butSTimeOnOrOff",
                Text = CONST.IS_ON_TIMER ? "Off Timer" : "On Timer",
                Size = new Size(80, 30),
                Location = new Point(70, 200)
            };
            butSTimeOnOrOff.Click += ButSTimeOnOrOff_Click;
            #endregion

            #region Sound Setting
            lblSSound = new Label()
            {
                Name = "lblSSound",
                Text = "Volume",
                Size = new Size(60, 30),
                Location = new Point(20, 90)
            };
            numSound = new NumericUpDown()
            {
                Name = "numSound",
                Size = new Size(220, 20),
                Location = new Point(80, 90),
                Value = new decimal(CONST.VOLUME_SIZE),
                Maximum = new decimal(100),
                Minimum = new decimal(0),
                ThousandsSeparator = true
            };
            #endregion

            this.Icon = new Icon("./Image/caro.ico");
            settingForm = new Form();
            settingForm.FormClosing += SettingForm_FormClosing;
            settingForm.Icon = new Icon("./Image/setting.ico");
            timer = new Timer()
            {
                Interval = CONST.INTERVAL
            };
            timer.Tick += Timer_Tick;
        }
        #endregion

        #region Draw Form
        private void DrawGameModeForm(Form gameModeForm, string formText)
        {
            gameModeForm.Controls.Clear();
            gameModeForm.Text = formText;
            gameModeForm.AutoScaleDimensions = new SizeF(9F, 20F);
            gameModeForm.ClientSize = new Size(400, 250);
            gameModeForm.Controls.Add(butTwoPlayer);
            gameModeForm.Controls.Add(butModeLan);
            if (formText == "Game Mode Setting") gameModeForm.Controls.Add(butBack);
            else if(formText == "Game Mode")
            {
                gameModeForm.Controls.Add(butLoadGame);
                gameModeForm.Controls.Add(lblOr);
            }
        }

        private void DrawNamePlayerForm(Form namePlayerForm, string formText, string gameMode = "")
        {
            namePlayerForm.Controls.Clear();
            namePlayerForm.Text = formText;
            namePlayerForm.AutoScaleDimensions = new SizeF(9F, 20F);
            namePlayerForm.ClientSize = new Size(400, 250);
            txtName1Row.Text = CONST.NAME_PLAYER1;
            txtName2Column.Text = CONST.NAME_PLAYER2;
            if (gameMode == "LAN") lblName1Row.Text = "Player";
            else
            {
                lblName1Row.Text = "Player 1";
                lblName2Column.Text = "Player 2";
                namePlayerForm.Controls.Add(lblName2Column);
                namePlayerForm.Controls.Add(txtName2Column);
            }
            namePlayerForm.Controls.Add(lblName1Row);
            namePlayerForm.Controls.Add(txtName1Row);
            namePlayerForm.Controls.Add(butBack);
            namePlayerForm.Controls.Add(butSave);
            if (formText == "Name Player") butSave.Text = "Next";
            else if (formText == "Name Player Setting") butSave.Text = "Save Change";
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
            LANForm.Controls.Clear();
            LANForm.Text = "LAN Connection";
            LANForm.AutoScaleDimensions = new SizeF(9F, 20F);
            LANForm.ClientSize = new Size(400, 250);
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
            mainForm.Controls.Clear();
            mainForm.Text = "Caro";
            pnlCaroBoard.Size = new Size(CONST.WIDTH * CONST.NUMBER_OF_COLUMN, CONST.HEIGHT * CONST.NUMBER_OF_ROW);
            mainForm.Size = new Size(pnlCaroBoard.Width + 3 * CONST.NUMBER_OF_ROW / 2 + 5, pnlCaroBoard.Height + 4 * CONST.NUMBER_OF_COLUMN + 70);
            butUndo.Location = new Point(mainForm.Width - 150, 30);
            butRedo.Location = new Point(mainForm.Width - 80, 30);
            txtPlayer.Location = new Point(2 * mainForm.Width / 3- 20, 5);
            txtPlayer.Width = mainForm.Width / 3;

            mainForm.Controls.Add(pnlCaroBoard);
            mainForm.Controls.Add(txtPlayer);
            mainForm.Controls.Add(butRedo);
            mainForm.Controls.Add(butUndo);
            mainForm.Controls.Add(lblTime);
            mainForm.Controls.Add(mainMenu);
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
        }

        private void DrawSettingForm(Form settingForm)
        {
            settingForm.Controls.Clear();
            settingForm.Text = "Setting";
            settingForm.AutoScaleDimensions = new SizeF(9F, 20F);
            settingForm.ClientSize = new Size(400, 250);
            settingForm.Controls.Add(butGameMode);
            settingForm.Controls.Add(butTimer);
            settingForm.Controls.Add(butNamePlayer);
            settingForm.Controls.Add(butSizeBoard);
            settingForm.Controls.Add(butSound);
            settingForm.Controls.Add(butSave);
            settingForm.Controls.Add(butSaveGame);
            butSave.Text = "Save Change";
            if (CONST.GAME_MODE == "TWO_PLAYER") butTimer.Enabled = true;
            else if (CONST.GAME_MODE == "LAN") butTimer.Enabled = false;
        }

        private void DrawTimeSettingForm(Form timeSettingForm)
        {
            timeSettingForm.Controls.Clear();
            timeSettingForm.Text = "Time Setting";
            timeSettingForm.AutoScaleDimensions = new SizeF(9F, 20F);
            timeSettingForm.ClientSize = new Size(400, 250);
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
            sizeSettingForm.Controls.Clear();
            sizeSettingForm.Text = "Size Setting";
            sizeSettingForm.AutoScaleDimensions = new SizeF(9F, 20F);
            sizeSettingForm.ClientSize = new Size(400, 250);
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
            soundSettingForm.Controls.Clear();
            soundSettingForm.Text = "Sound Setting";
            soundSettingForm.AutoScaleDimensions = new SizeF(9F, 20F);
            soundSettingForm.ClientSize = new Size(400, 250);
            soundSettingForm.Controls.Add(lblSSound);
            soundSettingForm.Controls.Add(numSound);
            soundSettingForm.Controls.Add(butSave);
            soundSettingForm.Controls.Add(butBack);
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "Form1";
            this.Text = "Caro";
            this.ResumeLayout(false);
        }
        #endregion
    }
}
