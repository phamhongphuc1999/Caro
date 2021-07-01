using CaroGame.Configuration;
using System;
using System.Drawing;

namespace CaroGame.Views.Components.SettingComponents
{
    public class TimeSettingPanel : BaseSettingPanel
    {
        public TimeSettingPanel(bool isAutoSize, bool isSave) : base(isAutoSize, isSave)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        protected override void DrawBasePanel()
        {
            base.DrawBasePanel();
        }

        protected override void SaveBut_Click(object sender, EventArgs e)
        {
            SaveClickEvent(sender, e);
        }

        protected override void CancelBut_Click(object sender, EventArgs e)
        {
            CancelClickEvent(sender, e);
        }
    }
}
