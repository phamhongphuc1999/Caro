using MaterialSkin.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views
{
  public partial class BaseForm : MaterialForm
  {
    public BaseForm(string title, Icon icon)
    {
      InitializeComponent(title, icon);
      this.FormClosing += BaseForm_FormClosing;
    }

    protected virtual void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Utils.ApplicationExit();
    }

    protected Point SetCenterLocation(Point baseLocation, Size baseSize, Size size)
    {
      int setY = (baseSize.Height - size.Height) / 2;
      int setX = (baseSize.Width - size.Width) / 2;
      return new Point(baseLocation.X - setX, baseLocation.Y - setY);
    }

    public void Show(Form baseForm)
    {
      this.Location = SetCenterLocation(baseForm.Location, baseForm.Size, this.Size);
      this.Show();
    }

    public void ShowDialog(Form baseForm)
    {
      this.Location = SetCenterLocation(baseForm.Location, baseForm.Size, this.Size);
      this.ShowDialog();
    }
  }
}
