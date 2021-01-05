using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Configuration.Config;

namespace CaroGame.Presentation
{
    public partial class MainForm : BaseForm
    {
        private GameMode gameMode;

        public MainForm(string formText, Icon icon): base(formText, icon)
        {
            DrawOverview();
            DrawGameMode();
            DrawPayer();
            currentPnl = overviewPnl;
        }

        private void OverviewPnl_GuideClickEvent(object sender, EventArgs e)
        {

        }

        private void OverviewPnl_NewGameClickEvent(object sender, EventArgs e)
        {
            this.SetCurrentPanel(gameModePnl);
        }

        private void GameModePnl_CancelActionClickEvent(object sender, EventArgs e)
        {
            this.SetCurrentPanel(overviewPnl);
        }

        private void GameModePnl_NextActionClickEvent(object sender, EventArgs e)
        {
            this.SetCurrentPanel(gameModePnl);
        }

        private void GameModePnl_LoadGameClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePnl_LanModeClickEvent(object sender, EventArgs e)
        {
            this.gameMode = GameMode.LAN;
            playerPnl.CaroVisible = false;
            playerPnl.LabelText1 = "Player";
            this.SetCurrentPanel(playerPnl);
        }

        private void GameModePnl_AIModeClickEvent(object sender, EventArgs e)
        {
            this.gameMode = GameMode.AI;
            playerPnl.LabelText1 = "Player";
            playerPnl.CaroVisible = false;
            this.SetCurrentPanel(playerPnl);
        }

        private void GameModePnl_TwoPlayerClickEvent(object sender, EventArgs e)
        {
            this.gameMode = GameMode.TWO_PLAYER;
            playerPnl.LabelText1 = "Player1";
            playerPnl.LabelText2 = "Player2";
            playerPnl.CaroVisible = true;
            this.SetCurrentPanel(playerPnl);
        }

        private void PlayerPnl_CancelActionClickEvent(object sender, EventArgs e)
        {
            this.SetCurrentPanel(gameModePnl);
        }

        private void PlayerPnl_NextActionClickEvent(object sender, EventArgs e)
        {
            (bool, string) result = playerPnl.IsFill();
            if (!result.Item1)
            {
                MessageBox.Show(result.Item2, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                playerPnl.Text1 = playerPnl.Text2 = "";
                return;
            }

        }
    }
}
