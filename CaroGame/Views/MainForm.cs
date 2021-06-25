using CaroGame.Configuration;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Views
{
    public partial class MainForm : BaseForm
    {
        private Routes routes;

        public MainForm(string title, Icon icon) : base(title, icon)
        {
            CreateRoute();
            HandleEvent();
            caroBoardManager.InitMainView(routes.MainView);
        }

        private void CreateRoute()
        {
            routes = new Routes(this);
            routes.RoutingEvent += (sender, e) =>
            {
                Control control = sender as Control;
                if (control != null)
                {
                    this.Text = e.title;
                }
            };
            routes.MainViewEvent += Routes_MainViewEvent;
            routes.Routing(Constants.OVERVIEW);
        }

        private void Routes_MainViewEvent(object sender, EventArgsRoute e)
        {
            caroBoardManager.InitCaroBoard();
            caroBoardManager.DrawCaroBoard();
        }

        private void HandleEvent()
        {
            //Overview
            routes.OverviewView.NewGameClickEvent += OverviewView_NewGameClickEvent;
            routes.OverviewView.GuideClickEvent += OverviewView_GuideClickEvent;
            // Game Mode
            routes.GameModeView.TwoPlayerClickEvent += GameModeView_TwoPlayerClickEvent;
            routes.GameModeView.LanModeClickEvent += GameModeView_LanModeClickEvent;
            routes.GameModeView.AIModeClickEvent += GameModeView_AIModeClickEvent;
            routes.GameModeView.LoadGameClickEvent += GameModeView_LoadGameClickEvent;
            routes.GameModeView.BackClickEvent += GameModeView_BackClickEvent;
            // Size
            routes.SizeView.ClickEvent = SizeView_ActionClickEvent;
            routes.SizeView.BackClickEvent += SizeView_BackClickEvent;
            // Player Setting
            routes.PlayerView.BackClickEvent += PlayerView_BackClickEvent;
            routes.PlayerView.NextClickEvent = PlayerView_ActionClickEvent;
        }

        #region Overview
        private void OverviewView_GuideClickEvent(object sender, EventArgs e)
        {

        }

        private void OverviewView_NewGameClickEvent(object sender, EventArgs e)
        {
            routes.Routing(Constants.GAME_MODE);
        }
        #endregion

        #region Game Mode
        private void GameModeView_LoadGameClickEvent(object sender, EventArgs e)
        {

        }

        private void GameModeView_AIModeClickEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa có chức năng này");
        }

        private void GameModeView_LanModeClickEvent(object sender, EventArgs e)
        {

        }

        private void GameModeView_TwoPlayerClickEvent(object sender, EventArgs e)
        {
            SettingConfig.GameMode = Constants.TWO_PLAYER_GAME_MODE;
            routes.Routing(Constants.SIZE_SETTING);
        }

        private void GameModeView_BackClickEvent(object sender, EventArgs e)
        {
            routes.Routing(Constants.OVERVIEW);
        }
        #endregion

        #region Size
        private void SizeView_ActionClickEvent(object sender, EventArgs e)
        {
            routes.Routing(Constants.PLAYER_SETTING);
        }

        private void SizeView_BackClickEvent(object sender, EventArgs e)
        {
            routes.Routing(Constants.GAME_MODE);
        }
        #endregion

        #region Player Setting
        private void PlayerView_BackClickEvent(object sender, EventArgs e)
        {
            routes.Routing(Constants.SIZE_SETTING);
        }

        private void PlayerView_ActionClickEvent(object sender, EventArgs e)
        {
            routes.Routing(Constants.MAIN);
        }
        #endregion
    }
}
