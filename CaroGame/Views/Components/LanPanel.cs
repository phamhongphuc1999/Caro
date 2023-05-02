using CaroGame.Configuration;
using System.Drawing;

namespace CaroGame.Views.Components
{
  public class LanPanel : BaseCaroPanel
  {
    public LanPanel(bool isAutoSize) : base(isAutoSize)
    {
      this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
      DrawBasePanel();
    }

    protected override void DrawBasePanel()
    {

    }
  }
}
