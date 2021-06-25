using CaroGame.Configuration;
using CaroGame.Views;
using CaroGame.Views.Components.SettingComponents;
using System;

namespace CaroGame.Routers
{
    public class SettingRoutes : BaseRoutes
    {
        public MainSettingPanel MainSettingView { get; set; }

        public SettingRoutes(SettingForm viewForm) : base()
        {
            MainSettingView = new MainSettingPanel();
            viewForm.Controls.Add(MainSettingView);
        }

        public void Routing(string router)
        {
            if (router.Equals(Constants.MAIN_SETTING)) SetCurrentControl(MainSettingView);
            else throw new Exception();
        }
    }
}
