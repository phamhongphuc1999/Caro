using CaroGame.Configuration;
using CaroGame.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Views.Components.SettingComponents
{
  public class TimeSettingPanel : BaseSettingPanel
  {
    protected NumericUpDown intervalNud, turnNud;
    protected Label lbl1, lbl2;
    protected ToggleButton timerTBut;

    public TimeSettingPanel(bool isAutoSize, bool isSave) : base(isAutoSize, isSave)
    {
      this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
      DrawBasePanel();
      this.VisibleChanged += TimeSettingPanel_VisibleChanged;
    }

    protected override void DrawBasePanel()
    {
      base.DrawBasePanel();
      lbl1 = new Label
      {
        Size = new Size(80, 45),
        Location = new Point(30, 85),
        Text = "Interval"
      };
      lbl2 = new Label()
      {
        Size = new Size(80, 45),
        Location = new Point(30, 170),
        Text = "Time turn"
      };
      intervalNud = new NumericUpDown
      {
        Location = new Point(120, 85),
        Width = 360,
        Minimum = 1,
        Maximum = 5
      };
      turnNud = new NumericUpDown
      {
        Location = new Point(120, 170),
        Width = 360,
        Minimum = 5,
        Maximum = 60
      };
      timerTBut = new ToggleButton
      {
        Location = new Point(120, 200)
      };
      timerTBut.CheckedChanged += TimerTBut_CheckedChanged;
      this.Controls.Add(lbl1);
      this.Controls.Add(lbl2);
      this.Controls.Add(intervalNud);
      this.Controls.Add(turnNud);
      this.Controls.Add(timerTBut);
    }

    protected override void SaveBut_Click(object sender, EventArgs e)
    {
      SettingConfig.TimeOption = true;
      TempConfig.IsTime = timerTBut.Checked;
      TempConfig.Interval = ((int)intervalNud.Value) * 1000;
      TempConfig.TimeTurn = (int)turnNud.Value;
      settingRoutes.Routing(Constants.MAIN_SETTING);
    }

    protected override void CancelBut_Click(object sender, EventArgs e)
    {
      SettingConfig.TimeOption = false;
      settingRoutes.Routing(Constants.MAIN_SETTING);
    }

    private void TimerTBut_CheckedChanged(object sender, EventArgs e)
    {
      if (timerTBut.Checked)
      {
        intervalNud.Enabled = true;
        turnNud.Enabled = true;
        lbl1.Enabled = true;
        lbl2.Enabled = true;
      }
      else
      {
        intervalNud.Enabled = false;
        turnNud.Enabled = false;
        lbl1.Enabled = false;
        lbl2.Enabled = false;
      }
    }

    private void TimeSettingPanel_VisibleChanged(object sender, EventArgs e)
    {
      Panel mainPanel = sender as Panel;
      if (mainPanel != null)
      {
        if (mainPanel.Visible)
        {
          intervalNud.Value = SettingConfig.Interval / 1000;
          intervalNud.Enabled = SettingConfig.IsTime;
          turnNud.Value = SettingConfig.TimeTurn;
          turnNud.Enabled = SettingConfig.IsTime;
          timerTBut.Checked = SettingConfig.IsTime;
        }
      }
    }
  }
}
