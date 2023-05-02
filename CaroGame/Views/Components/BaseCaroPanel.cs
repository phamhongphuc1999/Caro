using System.Windows.Forms;

namespace CaroGame.Views.Components
{
  public class BaseCaroPanel : Panel
  {
    public BaseCaroPanel(bool isAutoSize) : base()
    {
      if (isAutoSize)
      {
        this.AutoSize = true;
        this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      }
    }

    protected virtual void DrawBasePanel()
    {
    }
  }
}
