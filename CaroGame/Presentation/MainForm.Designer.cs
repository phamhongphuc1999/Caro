using CaroGame.Presentation.CaroPanel;
using System.Drawing;

namespace CaroGame.Presentation
{
    partial class MainForm
    {
        private OverviewPanel overviewPnl;
        private GameModePanel gameModePnl;
        private TwoTextPanel playerPnl;
        private LanPanel lanPnl;
        private GameBoardPanel gameBoardPanel;
        private LoadGamePanel loadGamePanel;

        private void DrawOverview()
        {
            overviewPnl = new OverviewPanel
            {
                Location = new Point(0, 0),
                Visible = false
            };
            overviewPnl.NewGameClickEvent += OverviewPnl_NewGameClickEvent;
            overviewPnl.GuideClickEvent += OverviewPnl_GuideClickEvent;
            this.Controls.Add(overviewPnl);
        }

        private void DrawGameMode()
        {
            gameModePnl = new GameModePanel
            {
                Location = new Point(0, 0),
                Visible = false,
                CancelText = "Back"
            };
            gameModePnl.TwoPlayerClickEvent += GameModePnl_TwoPlayerClickEvent;
            gameModePnl.AIModeClickEvent += GameModePnl_AIModeClickEvent;
            gameModePnl.LanModeClickEvent += GameModePnl_LanModeClickEvent;
            gameModePnl.LoadGameClickEvent += GameModePnl_LoadGameClickEvent;
            gameModePnl.CancelActionClickEvent += GameModePnl_CancelActionClickEvent;
            this.Controls.Add(gameModePnl);
        }

        private void DrawPayer()
        {
            playerPnl = new TwoTextPanel()
            {
                Location = new Point(0, 0),
                Visible = false,
                LabelText1 = "Player1",
                LabelText2 = "Player2",
                NextText = "Next",
                CancelText = "Back"
            };
            playerPnl.NextActionClickEvent += PlayerPnl_NextActionClickEvent;
            playerPnl.CancelActionClickEvent += PlayerPnl_CancelActionClickEvent;
            this.Controls.Add(playerPnl);
        }

        private void DrawLan()
        {
            lanPnl = new LanPanel
            {
                Location = new Point(0, 0),
                Visible = false,
                LabelText1 = "IP Address",
                LabelText2 = "Port",
                NextText = "Next",
                CancelText = "Back"
            };
            lanPnl.ConnectButClickEvent += Lanpnl_ConnectButClickEvent;
            lanPnl.IPButClickEvent += LanPnl_IPButClickEvent;
            lanPnl.NextActionClickEvent += LanPnl_NextActionClickEvent;
            lanPnl.CancelActionClickEvent += LanPnl_CancelActionClickEvent;
            this.Controls.Add(lanPnl);
        }

        private void DrawGameBoard()
        {
            gameBoardPanel = new GameBoardPanel()
            {
                Location = new Point(0, 0),
                Visible = false
            };
            gameBoardPanel.UndoClickEvent += GameBoardPanel_UndoClickEvent;
            gameBoardPanel.RedoClickEvent += GameBoardPanel_RedoClickEvent;
            gameBoardPanel.NewGameToolClickEvent += GameBoardPanel_NewGameToolClickEvent;
            gameBoardPanel.QuickItemClickEvent += GameBoardPanel_QuickItemClickEvent;
            gameBoardPanel.SettingItemClickEvent += GameBoardPanel_SettingItemClickEvent;
            gameBoardPanel.AboutItemClickEvent += GameBoardPanel_AboutItemClickEvent;
            this.Controls.Add(gameBoardPanel);
        }

        private void DrawLoadGame()
        {
            loadGamePanel = new LoadGamePanel
            {
                Visible = false,
                Location = new Point(0, 0)
            };
            loadGamePanel.CancelActionClickEvent += LoadGamePanel_CancelActionClickEvent;
            loadGamePanel.ButGameClickEvent = LoadGamePanel_ButGameClickEvent;
            loadGamePanel.ButDeleteClickEvent = LoadGamePanel_ButDeleteClickEvent;
            this.Controls.Add(loadGamePanel);
        }
    }
}