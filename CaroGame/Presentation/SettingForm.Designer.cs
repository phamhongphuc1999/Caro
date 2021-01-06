using CaroGame.Presentation.CaroPanel;
using System.Drawing;

namespace CaroGame.Presentation
{
    partial class SettingForm
    {
        private SettingPanel settingPnl;

        public void DrawCommonSetting()
        {
            settingPnl = new SettingPanel()
            {
                Location = new Point(0, 0)
            };
            settingPnl.GameModeClickEvent += SettingPnl_GameModeClickEvent;
            settingPnl.TimerClickEvent += SettingPnl_TimerClickEvent;
            settingPnl.NamePlayerClickEvent += SettingPnl_NamePlayerClickEvent;
            settingPnl.SizeClickEvent += SettingPnl_SizeClickEvent;
            settingPnl.SoundClickEvent += SettingPnl_SoundClickEvent;
            settingPnl.LoadGameClickEvent += SettingPnl_LoadGameClickEvent;
            settingPnl.SaveGameClickEvent += SettingPnl_SaveGameClickEvent;
            settingPnl.NextActionClickEvent += SettingPnl_NextActionClickEvent;
            settingPnl.CancelActionClickEvent += SettingPnl_CancelActionClickEvent;
            this.Controls.Add(settingPnl);
        }
    }
}