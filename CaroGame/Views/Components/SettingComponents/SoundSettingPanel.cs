using CaroGame.Configuration;
using System;
using System.Drawing;
using static CaroGame.Program;

namespace CaroGame.Views.Components.SettingComponents
{
  public class SoundSettingPanel : BaseSettingPanel
  {
    public SoundSettingPanel(bool isAutoSize, bool isSave) : base(isAutoSize, isSave)
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

    }

    protected override void CancelBut_Click(object sender, EventArgs e)
    {
      settingRoutes.Routing(Constants.MAIN_SETTING);
    }
  }
}
