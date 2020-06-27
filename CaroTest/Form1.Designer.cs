using System.Windows.Forms;
using System.Drawing;
using CaroTest.Setting;
using CaroTest.ConnectManager;

namespace CaroTest
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Form settingForm;
        private Button butTwoPlayer, butModeLan, butUndo, butRedo;
        private Button butGameMode, butTimer, butNamePlayer, butSizeBoard, butSave;
        private Button butSTimeOnOrOff, butConnect, butBack;
        private Panel pnlCaroBoard;
        private MenuStrip mainMenu;
        private ToolStripMenuItem toolItemMain, toolItemNewGame, toolItemQuick, toolItemSetting;
        private TextBox txtPlayer, txtSTimeTurn, txtSTimeInterval;
        private TextBox txtSSizeRow, txtSSizeColumn;
        private TextBox txtNamePlayer1, txtNamePlayer2;
        private TextBox txtPort, txtIP;
        private System.Windows.Forms.Timer timer;
        private Label lblTime, lblSTimeTurn, lblSTimeInterval;
        private Label lblSSizeRow, lblSSizeColumn;
        private Label lblNamePlayer1, lblNamePlayer2;
        private Label lblPort, lblIP;

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

        private void InitializeGameModeController()
        {
            butTwoPlayer = new Button()
            {
                Name = "butMode",
                Text = "Two Player",
                Size = new Size(120, 80),
                Location = new Point(40, 85)
            };

            butModeLan = new Button()
            {
                Name = "butModeLan",
                Text = "LAN Mode",
                Size = new Size(120, 80),
                Location = new Point(240, 85)
            };
            butTwoPlayer.Click += ButTwoPlayer_Click;
            butModeLan.Click += ButModeLan_Click;
        }

        private void InitializeNamePlayerController()
        {
            lblNamePlayer1 = new Label()
            {
                Name = "lblNamePlayer1",
                Text = "Player 1",
                Size = new Size(60, 30),
                Location = new Point(20, 30)
            };

            lblNamePlayer2 = new Label()
            {
                Name = "lblNamePlayer2",
                Text = "Player 2",
                Size = new Size(60, 30),
                Location = new Point(20, 80)
            };

            txtNamePlayer1 = new TextBox()
            {
                Name = "txtNamePlayer1",
                Text = CONST.NAME_PLAYER1,
                Width = 200,
                Location = new Point(100, 30)
            };

            txtNamePlayer2 = new TextBox()
            {
                Name = "txtNamePlayer2",
                Text = CONST.NAME_PLAYER2,
                Width = 200,
                Location = new Point(100, 80)
            };

            butBack = new Button()
            {
                Name = "butBack",
                Text = "Back",
                Size = new Size(80, 30),
                Location = new Point(150, 200)
            };
            butBack.Click += ButBack_Click;
        }

        private void InitalizeLANController()
        {
            lblIP = new Label()
            {
                Name = "lblIP",
                Text = "IP",
                Size = new Size(60, 30),
                Location = new Point(20, 30)
            };

            lblPort = new Label()
            {
                Name = "lblPort",
                Text = "Port",
                Size = new Size(60, 30),
                Location = new Point(20, 80)
            };

            txtIP = new TextBox()
            {
                Name = "txtIP",
                Text = SocketManager.GetIPv4(),
                Width = 200,
                Location = new Point(100, 30)
            };

            txtPort = new TextBox()
            {
                Name = "txtPort",
                Width = 200,
                Location = new Point(100, 80)
            };

            butConnect = new Button()
            {
                Name = "butConnect",
                Size = new Size(80, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(100, 150)
            };
            butConnect.Click += ButConnect_Click;
        }

        private void InitializeMainController()
        {
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
                Text = CONST.TIME_TURN.ToString(),
                Location = new Point(0, 30)
            };
            CreateMainMenu();

            butRedo.Click += ButRedo_Click;
            butUndo.Click += ButUndo_Click;
        }

        private void InitializeSettingController()
        {
            butGameMode = new Button()
            {
                Name = "butGameMode",
                Text = "Game Mode",
                Size = new Size(100, 40),
                Location = new Point(50, 45)
            };

            butTimer = new Button()
            {
                Name = "butTimer",
                Text = "Time",
                Size = new Size(100, 40),
                Location = new Point(250, 45)
            };

            butNamePlayer = new Button()
            {
                Name = "butNamePlayer",
                Text = "Name Player",
                Size = new Size(100, 40),
                Location = new Point(50, 95)
            };

            butSizeBoard = new Button()
            {
                Name = "butSizeBoard",
                Text = "Size Board",
                Size = new Size(100, 40),
                Location = new Point(250, 95)
            };

            butSave = new Button()
            {
                Name = "butSave",
                Text = "Save Change",
                Size = new Size(80, 30),
                Location = new Point(300, 200)
            };
            butGameMode.Click += ButGameMode_Click;
            butTimer.Click += ButTimer_Click;
            butNamePlayer.Click += ButNamePlayer_Click;
            butSizeBoard.Click += ButSizeBoard_Click;
            butSave.Click += ButSave_Click;
        }

        private void InitializeTimeSettingController()
        {
            lblSTimeTurn = new Label()
            {
                Name = "lblSTimeTurn",
                Text = "Time Turn",
                Size = new Size(60, 30),
                Location = new Point(20, 30)
            };

            lblSTimeInterval = new Label()
            {
                Name = "lblSTimeInterval",
                Text = "Interval",
                Size = new Size(60, 30),
                Location = new Point(20, 80)
            };

            txtSTimeTurn = new TextBox()
            {
                Name = "txtSTimeTurn",
                Text = CONST.TIME_TURN.ToString(),
                Width = 200,
                Location = new Point(100, 30)
            };

            txtSTimeInterval = new TextBox()
            {
                Name = "txtSTimeInterval",
                Text = CONST.INTERVAL.ToString(),
                Width = 200,
                Location = new Point(100, 80)
            };

            butSTimeOnOrOff = new Button()
            {
                Name = "butSTimeOnOrOff",
                Text = CONST.IS_ON_TIMER ? "Off Timer" : "On Timer",
                Size = new Size(60, 30),
                Location = new Point(150, 200)
            };
            butSTimeOnOrOff.Click += ButSTimeOnOrOff_Click;
        }

        private void InitializeSizeSettingController()
        {
            lblSSizeRow = new Label()
            {
                Name = "lblSSizeRow",
                Text = "Row",
                Size = new Size(60, 30),
                Location = new Point(20, 30)
            };

            lblSSizeColumn = new Label()
            {
                Name = "lblSSizeColumn",
                Text = "Column",
                Size = new Size(60, 30),
                Location = new Point(20, 80)
            };

            txtSSizeRow = new TextBox()
            {
                Name = "txtSSizeRow",
                Text = CONST.numberOfRow.ToString(),
                Width = 200,
                Location = new Point(100, 30)
            };

            txtSSizeColumn = new TextBox()
            {
                Name = "txtSSizeColumn",
                Text = CONST.numberOfColumn.ToString(),
                Width = 200,
                Location = new Point(100, 80)
            };
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
        }

        private void DrawNamePlayerForm(Form namePlayerForm, string formText, string gameMode = "")
        {
            namePlayerForm.Controls.Clear();
            namePlayerForm.Text = formText;
            namePlayerForm.AutoScaleDimensions = new SizeF(9F, 20F);
            namePlayerForm.ClientSize = new Size(400, 250);
            if (gameMode == "LAN") lblNamePlayer1.Text = "Player";
            else
            {
                lblNamePlayer1.Text = "Player 1";
                namePlayerForm.Controls.Add(lblNamePlayer2);
                namePlayerForm.Controls.Add(txtNamePlayer2);
            }
            namePlayerForm.Controls.Add(lblNamePlayer1);
            namePlayerForm.Controls.Add(txtNamePlayer1);
            namePlayerForm.Controls.Add(butBack);
            namePlayerForm.Controls.Add(butSave);
            butSave.Text = "Next";

        }

        private void DrawLANForm(Form LANForm)
        {
            LANForm.Controls.Clear();
            LANForm.Text = "LAN Connection";
            LANForm.AutoScaleDimensions = new SizeF(9F, 20F);
            LANForm.ClientSize = new Size(400, 250);
            LANForm.Controls.Add(lblIP);
            LANForm.Controls.Add(lblPort);
            LANForm.Controls.Add(txtIP);
            LANForm.Controls.Add(txtPort);
            LANForm.Controls.Add(butSave);
            butSave.Text = "Next";
            butSave.Enabled = false;
            LANForm.Controls.Add(butConnect);
            butConnect.BackColor = Color.White;
            butConnect.Text = "Connect";
            LANForm.Controls.Add(butBack);
        }

        private void DrawMainForm(Form mainForm)
        {
            mainForm.Controls.Clear();
            mainForm.Text = "Caro";
            pnlCaroBoard.Size = new Size(CONST.WIDTH * CONST.numberOfColumn, CONST.HEIGHT * CONST.numberOfRow);

            mainForm.Width = pnlCaroBoard.Width + CONST.numberOfColumn * 2;
            mainForm.Height = pnlCaroBoard.Height + CONST.numberOfRow * 4 + 70;
            butUndo.Location = new Point(mainForm.Width - 150, 30);
            butRedo.Location = new Point(mainForm.Width - 80, 30);
            txtPlayer.Location = new Point(mainForm.Width / 3 + 10, 5);
            int temp = 2 * mainForm.Width / 3 - 10;
            if (temp < 200) txtPlayer.Width = temp - 20;
            else txtPlayer.Width = 200;
            mainMenu.Size = new Size(mainForm.Width / 3, 20);

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
            settingForm.Controls.Add(butSave);
            butSave.Text = "Save";
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
            timeSettingForm.Controls.Add(butSave);
            butSave.Text = "Save";
        }

        private void DrawSizeSettingForm(Form sizeSettingForm)
        {
            sizeSettingForm.Controls.Clear();
            sizeSettingForm.Text = "Size Setting";
            sizeSettingForm.AutoScaleDimensions = new SizeF(9F, 20F);
            sizeSettingForm.ClientSize = new Size(400, 250);
            sizeSettingForm.Controls.Add(lblSSizeColumn);
            sizeSettingForm.Controls.Add(lblSSizeRow);
            sizeSettingForm.Controls.Add(txtSSizeColumn);
            sizeSettingForm.Controls.Add(txtSSizeRow);
            sizeSettingForm.Controls.Add(butSave);
            butSave.Text = "Save";
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            InitializeGameModeController();
            InitializeNamePlayerController();
            InitalizeLANController();
            InitializeMainController();
            InitializeSettingController();
            InitializeTimeSettingController();
            InitializeSizeSettingController();
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Caro";
            settingForm = new Form();
            timer = new Timer()
            {
                Interval = CONST.INTERVAL
            };
            timer.Tick += Timer_Tick;
            this.ResumeLayout(false);
        }
        #endregion
    }
}
