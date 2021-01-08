using CaroGame.Presentation.CaroPanel;
using System.Drawing;

namespace CaroGame.Presentation
{
    partial class SettingForm
    {
        private SettingPanel settingPnl;
        private SoundPanel soundPanel;
        private TimePanel timePanel;
        private TwoTextPanel playerNamePanel;
        private SettingSizePanel settingSizePanel;
        private GameModePanel gameModePanel;

        private void DrawCommonSetting()
        {
            settingPnl = new SettingPanel()
            {
                Location = new Point(0, 0),
                Visible = false,
                NextText = "Save",
                CancelText = "Cancel"
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

        private void DrawSoundSetting()
        {
            soundPanel = new SoundPanel()
            {
                Location = new Point(0, 0),
                Visible = false,
                NextText = "Save",
                CancelText = "Cancel"
            };
            soundPanel.NextActionClickEvent += SoundPanel_NextActionClickEvent;
            soundPanel.CancelActionClickEvent += SoundPanel_CancelActionClickEvent;
            this.Controls.Add(soundPanel);
        }

        private void DrawTimeSetting()
        {
            timePanel = new TimePanel()
            {
                Location = new Point(0, 0),
                Visible = false,
                NextText = "Save",
                CancelText = "Cancel"
            };
            timePanel.NextActionClickEvent += TimePanel_NextActionClickEvent;
            timePanel.CancelActionClickEvent += TimePanel_CancelActionClickEvent;
            this.Controls.Add(timePanel);
        }

        private void DrawPlayerNamePanel()
        {
            playerNamePanel = new TwoTextPanel
            {
                Location = new Point(0, 0),
                Visible = false,
                LabelText1 = "Player1",
                LabelText2 = "Player2",
                NextText = "Save",
                CancelText = "Cancel"
            };
            playerNamePanel.NextActionClickEvent += PlayerNamePanel_NextActionClickEvent;
            playerNamePanel.CancelActionClickEvent += PlayerNamePanel_CancelActionClickEvent;
            this.Controls.Add(playerNamePanel);
        }

        private void DrawSettingSize()
        {
            settingSizePanel = new SettingSizePanel()
            {
                Location = new Point(0, 0),
                Visible = false,
                LabelText1 = "Hàng",
                LabelText2 = "Cột",
                NextText = "Save",
                CancelText = "Cancel"
            };
            settingSizePanel.NextActionClickEvent += SettingSizePanel_NextActionClickEvent;
            settingSizePanel.CancelActionClickEvent += SettingSizePanel_CancelActionClickEvent;
            this.Controls.Add(settingSizePanel);
        }

        private void DrawGameMode()
        {
            gameModePanel = new GameModePanel
            {
                Location = new Point(0, 0),
                Visible = false,
                CancelText = "Cancel"
            };
            gameModePanel.TwoPlayerClickEvent += GameModePanel_TwoPlayerClickEvent;
            gameModePanel.AIModeClickEvent += GameModePanel_AIModeClickEvent;
            gameModePanel.LanModeClickEvent += GameModePanel_LanModeClickEvent;
            gameModePanel.LoadGameClickEvent += GameModePanel_LoadGameClickEvent;
            gameModePanel.CancelActionClickEvent += GameModePanel_CancelActionClickEvent;
            this.Controls.Add(gameModePanel);
        }
    }
}