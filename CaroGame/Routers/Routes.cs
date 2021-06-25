using CaroGame.Configuration;
using CaroGame.Views.Components;
using System;
using System.Windows.Forms;

namespace CaroGame.Routers
{
    public class Routes : BaseRoutes
    {
        public OverviewPanel OverviewView { get; set; }
        public GameModePanel GameModeView { get; set; }
        public SizePanel SizeView { get; set; }
        public PlayerPanel PlayerView { get; set; }
        public MainPanel MainView { get; set; }

        private event EventHandler<EventArgsRoute> routeingEvent;
        public event EventHandler<EventArgsRoute> RoutingEvent
        {
            add { routeingEvent += value; }
            remove { routeingEvent -= value; }
        }

        private event EventHandler<EventArgsRoute> mainViewEvent;
        public event EventHandler<EventArgsRoute> MainViewEvent
        {
            add { mainViewEvent += value; }
            remove { mainViewEvent -= value; }
        }

        public Routes(Form viewForm) : base()
        {
            OverviewView = new OverviewPanel() { Visible = false };
            GameModeView = new GameModePanel() { Visible = false };
            SizeView = new SizePanel() { Visible = false };
            PlayerView = new PlayerPanel() { Visible = false };
            MainView = new MainPanel() { Visible = false };
            viewForm.Controls.Add(OverviewView);
            viewForm.Controls.Add(GameModeView);
            viewForm.Controls.Add(SizeView);
            viewForm.Controls.Add(PlayerView);
            viewForm.Controls.Add(MainView);
        }

        public void Routing(string router)
        {
            EventArgsRoute e = new EventArgsRoute(router);
            if (router.Equals(Constants.OVERVIEW))
            {
                routeingEvent(OverviewView, e);
                SetCurrentControl(OverviewView);
            }
            else if (router.Equals(Constants.GAME_MODE))
            {
                routeingEvent(GameModeView, e);
                SetCurrentControl(GameModeView);
            }
            else if (router.Equals(Constants.SIZE_SETTING))
            {
                routeingEvent(SizeView, e);
                SetCurrentControl(SizeView);
            }
            else if (router.Equals(Constants.PLAYER_SETTING))
            {
                routeingEvent(PlayerView, e);
                SetCurrentControl(PlayerView);
            }
            else if (router.Equals(Constants.MAIN))
            {
                mainViewEvent(MainView, e);
                routeingEvent(MainView, e);
                SetCurrentControl(MainView);
            }
            else throw new Exception();
        }
    }
}
