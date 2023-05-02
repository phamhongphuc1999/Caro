using CaroGame.Configuration;
using CaroGame.Controls;
using System;
using System.Drawing;
using static CaroGame.Program;

namespace CaroGame.Views.Components.SettingComponents
{
  public class GameModeSettingPanel : BaseSettingPanel
  {
    protected CaroButton twoPlayerBut, lanModeBut, aiModeBut, loadgameBut;

    public GameModeSettingPanel(bool isAutoSize, bool isSave) : base(isAutoSize, isSave)
    {
      this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
      DrawBasePanel();
    }

    protected override void DrawBasePanel()
    {
      base.DrawBasePanel();
      twoPlayerBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("twoPlayerMode"),
        Size = new Size(130, 40),
        Location = new Point(22, 100)
      };
      lanModeBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("lanMode"),
        Size = new Size(130, 40),
        Location = new Point(202, 100)
      };
      aiModeBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("aiMode"),
        Size = new Size(130, 40),
        Location = new Point(382, 100)
      };
      twoPlayerBut.Click += TwoPlayerBut_Click;
      lanModeBut.Click += LanModeBut_Click;
      aiModeBut.Click += AiModeBut_Click;
      this.Controls.Add(twoPlayerBut);
      this.Controls.Add(lanModeBut);
      this.Controls.Add(aiModeBut);
    }

    private void AiModeBut_Click(object sender, EventArgs e)
    {

    }

    private void LanModeBut_Click(object sender, EventArgs e)
    {

    }

    private void TwoPlayerBut_Click(object sender, EventArgs e)
    {

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
