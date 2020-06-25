using System.Windows.Forms;
using System.Drawing;
using Caro.Setting;

namespace Caro
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Form formGameMode;
        private Button butTwoPlayer, butModeLan, butUndo, butRedo;
        private Panel pnlCaroBoard;
        private MenuStrip mainMenu;
        private ToolStripMenuItem toolItemMain, toolItemNewGame, toolItemQuick, toolItemGameMode;
        private TextBox txtPlayer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void CreateMainMenu(int width)
        {
            toolItemGameMode = new ToolStripMenuItem()
            {
                Name = "GameMode",
                Text = "Game Mode"
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
                toolItemGameMode,
                toolItemQuick
            });

            mainMenu = new MenuStrip()
            {
                Name = "mainMenu",
                Text = "Menu",
                GripMargin = new Padding(2, 2, 0, 2),
                ImageScalingSize = new Size(24, 24),
                Location = new Point(0, 0),
                Size = new Size(width, 20),
                TabIndex = 0,
                BackColor = Color.Green
            };

            mainMenu.SuspendLayout();
            this.SuspendLayout();
            mainMenu.Items.AddRange(new ToolStripItem[]
            {
                toolItemMain
            });

            this.Controls.Add(mainMenu);
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
        }

        private void DrawGameModeForm()
        {
            butTwoPlayer = new Button()
            {
                Name = "butMode",
                Text = "Two Player",
                Size = new Size(120, 80),
                Location = new Point(50, 85)
            };

            butModeLan = new Button()
            {
                Name = "butModeLan",
                Text = "LAN Mode",
                Size = new Size(120, 80),
                Location = new Point(230, 85)
            };

            formGameMode = new Form()
            {
                Name = "formGameMode",
                Text = "Game Mode",
                AutoScaleDimensions = new SizeF(9F, 20F),
                ClientSize = new Size(400, 250)
            };

            formGameMode.Controls.Add(butTwoPlayer);
            formGameMode.Controls.Add(butModeLan);
        }

        private void DrawMainForm(int numberOfRow, int numberOfColumn)
        {
            pnlCaroBoard = new Panel()
            {
                Name = "pnlCaroBoard",
                Size = new Size(CONST.WIDTH * numberOfColumn, CONST.HEIGHT * numberOfRow),
                Location = new Point(1, 70)
            };

            this.Width = pnlCaroBoard.Width + numberOfColumn * 2;
            this.Height = pnlCaroBoard.Height + numberOfRow * 4 + 70;

            butUndo = new Button()
            {
                Name = "butUndo",
                Text = "Undo",
                Size = new Size(60, 20),
                Location = new Point(this.Width - 150, 30)
            };

            butRedo = new Button()
            {
                Name = "butRedo",
                Text = "Redo",
                Size = new Size(60, 20),
                Location = new Point(this.Width - 80, 30)
            };

            txtPlayer = new TextBox()
            {
                Name = "txtPlayer",
                ReadOnly = true,
                Location = new Point(this.Width / 3 + 10, 0)
            };
            int temp = 2 * this.Width / 3 - 10;
            if (temp < 200) txtPlayer.Width = temp - 20;
            else txtPlayer.Width = 200;

            CreateMainMenu(this.Width / 3);
            this.Controls.Add(pnlCaroBoard);
            this.Controls.Add(txtPlayer);
            this.Controls.Add(butRedo);
            this.Controls.Add(butUndo);
        }
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Caro";
            this.ResumeLayout(false);

            DrawGameModeForm();
        }

        #endregion
    }
}
