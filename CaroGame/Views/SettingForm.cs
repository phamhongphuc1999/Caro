using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Views
{
  public partial class SettingForm : BaseForm
  {
    public SettingForm(string title, Icon icon) : base(title, icon)
    {
    }

    protected override void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.Hide();
      CaroService.Timer.StartTimer(false);
    }
  }
}
