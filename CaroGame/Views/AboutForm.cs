using CaroGame.Configuration;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Views
{
  public partial class AboutForm : BaseForm
  {
    public AboutForm(string title, Icon icon) : base(title, icon)
    {
      InitializeComponent(title, icon);
      InitializeController();
    }

    private void GitLlbl_Click(object sender, EventArgs e)
    {
      Process.Start(Constants.GITHUB_LINK);
    }

    protected override void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.Hide();
      CaroService.Timer.StartTimer(false);

    }
  }
}
