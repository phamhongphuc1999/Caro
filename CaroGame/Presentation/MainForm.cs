using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    public partial class MainForm : BaseForm
    {
        public MainForm(string formText, Icon icon): base(formText, icon)
        {
            DrawGameMode();
            DrawOverview();
        }

        private void OverviewPnl_GuideClickEvent(object sender, EventArgs e)
        {

        }

        private void OverviewPnl_NewGameClickEvent(object sender, EventArgs e)
        {
            
        }

        private void GameModePnl_CancelActionClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePnl_NextActionClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePnl_LoadGameClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePnl_LanModeClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePnl_AIModeClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePnl_TwoPlayerClickEvent(object sender, EventArgs e)
        {
        }
    }
}
