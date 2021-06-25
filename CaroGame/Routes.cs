using CaroGame.Configuration;
using CaroGame.Views.Components;
using System;
using System.Windows.Forms;

namespace CaroGame
{
    public class EventArgsRoute : EventArgs
    {
        public string title { get; private set; }

        public EventArgsRoute(string router) : base()
        {
            this.title = router;
        }
    }

    public class Routes
    {
        public OverviewPanel OverviewView { get; set; }
        public GameModePanel GameModeView { get; set; }
        public SizePanel SizeView { get; set; }
        public PlayerPanel PlayerView { get; set; }
        public MainPanel MainView { get; set; }
        private Control currentControl;

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

        public Routes(Form viewForm)
        {
            OverviewView = new OverviewPanel() { Visible = false };
            GameModeView = new GameModePanel() { Visible = false };
            SizeView = new SizePanel() { Visible = false };
            PlayerView = new PlayerPanel() { Visible = false };
            MainView = new MainPanel() { Visible = false };
            currentControl = new Control();
            viewForm.Controls.Add(OverviewView);
            viewForm.Controls.Add(GameModeView);
            viewForm.Controls.Add(SizeView);
            viewForm.Controls.Add(PlayerView);
            viewForm.Controls.Add(MainView);
        }

        private void SetCurrentControl(Control control)
        {
            if (currentControl != null) currentControl.Visible = false;
            currentControl = control;
            currentControl.Visible = true;
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
