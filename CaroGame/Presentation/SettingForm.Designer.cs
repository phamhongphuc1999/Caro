using CaroGame.Presentation.CustomPanel;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    partial class SettingForm
    {
        public PlayerPanel playerPanel;
        public SizePanel sizePanel;
        public SettingPanel settingPanel;
        public TimePanel timePanel;
        public SoundPanel soundPanel;
        private Panel currentPnl;

        private void InitializeController()
        {
            settingPanel = new SettingPanel()
            {
                Location = new Point(0, 0)
            };
            settingPanel.butGameMode.Click += Common_ButGameMode_Click;
            settingPanel.butTimer.Click += Common_ButTimer_Click;
            settingPanel.butNamePlayer.Click += Common_ButNamePlayer_Click;
            settingPanel.butSizeBoard.Click += Common_ButSizeBoard_Click;
            settingPanel.butSound.Click += Common_ButSound_Click;

            playerPanel = new PlayerPanel()
            {
                Location = new Point(0, 0),
                Visible = false
            };
            playerPanel.nextActionBut.Click += Player_NextActionBut_Click;
            playerPanel.cancelActionBut.Click += Player_CancelActionBut_Click;

            sizePanel = new SizePanel()
            {
                Location = new Point(0, 0),
                Visible = false
            };
            sizePanel.nextActionBut.Click += Size_NextActionBut_Click;
            sizePanel.cancelActionBut.Click += Size_CancelActionBut_Click;

            timePanel = new TimePanel()
            {
                Location = new Point(0, 0),
                Visible = false
            };
            timePanel.nextActionBut.Click += Time_NextActionBut_Click;
            timePanel.cancelActionBut.Click += Time_CancelActionBut_Click;
            timePanel.butStatusTime.Click += Time_ButStatusTime_Click1;

            soundPanel = new SoundPanel()
            {
                Location = new Point(0, 0),
                Visible = false
            };
            soundPanel.nextActionBut.Click += Sound_NextActionBut_Click;
            soundPanel.cancelActionBut.Click += Sound_CancelActionBut_Click;
        }

        public void DrawSettingForm()
        {
            currentPnl = settingPanel;
            this.Controls.Add(playerPanel);
            this.Controls.Add(sizePanel);
            this.Controls.Add(settingPanel);
            this.Controls.Add(timePanel);
            this.Controls.Add(soundPanel);
        }
    }
}