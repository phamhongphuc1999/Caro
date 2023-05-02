using System;
using System.Drawing;
using static CaroGame.Program;
using CaroGame.Configuration;
using CaroGame.Controls;
using MaterialSkin.Controls;

namespace CaroGame.Views.Components
{
  public class PlayerPanel : BaseCaroPanel
  {
    protected CaroTextBox player1Tb, player2Tb;
    protected MaterialLabel lbl1, lbl2;
    protected CaroButton backBut, nextBut;

    public PlayerPanel(bool isAutoSize) : base(isAutoSize)
    {
      this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
      DrawBasePanel();
    }

    protected override void DrawBasePanel()
    {
      lbl1 = new MaterialLabel
      {
        Size = new Size(150, 45),
        Location = new Point(30, 85),
        Text = CaroService.Language.GetString(Constants.PLAYER1_DEFAULT_NAME)
      };
      lbl2 = new MaterialLabel()
      {
        Size = new Size(150, 45),
        Location = new Point(30, 170),
        Text = CaroService.Language.GetString(Constants.PLAYER2_DEFAULT_NAME)
      };
      player1Tb = new CaroTextBox()
      {
        TextWidth = 360,
        Size = new Size(400, 80),
        Location = new Point(185, 85),
        RequiredText = CaroService.Language.GetString("invalid"),
        ValidateText = (text) =>
        {
          if (string.IsNullOrEmpty(text)) return false;
          if (!string.IsNullOrEmpty(player2Tb.InfoText))
            if (text.Equals(player2Tb.InfoText)) return false;
          return true;
        }
      };
      player2Tb = new CaroTextBox()
      {
        TextWidth = 360,
        Location = new Point(185, 170),
        Size = new Size(400, 80),
        RequiredText = CaroService.Language.GetString("invalid"),
        ValidateText = (text) =>
        {
          if (string.IsNullOrEmpty(text)) return false;
          if (!string.IsNullOrEmpty(player1Tb.InfoText))
          {
            if (text.Equals(player1Tb.InfoText)) return false;
          }
          return true;
        }
      };
      backBut = new CaroButton()
      {
        Location = new Point(20, 300),
        Text = CaroService.Language.GetString("back"),
        Size = new Size(70, 30)
      };
      nextBut = new CaroButton()
      {
        Location = new Point(455, 300),
        Text = CaroService.Language.GetString("next"),
        Size = new Size(70, 30)
      };
      backBut.Click += BackBut_Click;
      nextBut.Click += NextBut_Click;
      this.Controls.Add(lbl1);
      this.Controls.Add(lbl2);
      this.Controls.Add(player1Tb);
      this.Controls.Add(player2Tb);
      this.Controls.Add(backBut);
      this.Controls.Add(nextBut);
    }

    private void BackBut_Click(object sender, EventArgs e)
    {
      routes.Routing(Constants.SIZE_SETTING);
    }

    private void NextBut_Click(object sender, EventArgs e)
    {
      if (player1Tb.TextValidate && player2Tb.TextValidate)
      {
        CaroService.Player.PlayerName1 = player1Tb.InfoText;
        CaroService.Player.PlayerName2 = player2Tb.InfoText;
        routes.Routing(Constants.MAIN);
      }
    }
  }
}
