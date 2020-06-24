using System.Windows.Forms;
using System.Drawing;
using Caro.Setting;

namespace Caro
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Form formGameMode, formPlayer;
        private Button butMode, butModeLan;
        private Panel pnlCaroBoard;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void DrawGameModeForm()
        {
            butMode = new Button()
            {
                Name = "butMode",
                Text = "One Computer",
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

            formGameMode.Controls.Add(butMode);
            formGameMode.Controls.Add(butModeLan);
        }

        private void DrawPlayerForm()
        {

        }

        private void DrawMainForm(int numberOfRow, int numberOfColumn)
        {
            pnlCaroBoard = new Panel()
            {
                Name = "pnlCaroBoard",
                Size = new Size(CONST.WIDTH * numberOfColumn, CONST.HEIGHT * numberOfRow),
                Location = new Point(1, 20)
            };

            this.Width = pnlCaroBoard.Width + numberOfColumn * 2;
            this.Height = pnlCaroBoard.Height + numberOfRow * 4 + 20;

            this.Controls.Add(pnlCaroBoard);
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
