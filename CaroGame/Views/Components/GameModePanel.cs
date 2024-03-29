﻿using CaroGame.Configuration;
using CaroGame.Controls;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Views.Components
{
  public class GameModePanel : BaseCaroPanel
  {
    protected CaroButton twoPlayerBut, lanModeBut, aiModeBut, loadgameBut;
    protected CaroButton backBut;
    protected MaterialLabel orLbl;

    public GameModePanel(bool isAutoSize) : base(isAutoSize)
    {
      this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
      DrawBasePanel();
    }

    protected override void DrawBasePanel()
    {
      twoPlayerBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("twoPlayerMode"),
        Size = new Size(130, 40),
        Location = new Point(22, 45)
      };
      lanModeBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("lanMode"),
        Size = new Size(130, 40),
        Location = new Point(202, 45)
      };
      aiModeBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("aiMode"),
        Size = new Size(130, 40),
        Location = new Point(382, 45)
      };
      orLbl = new MaterialLabel()
      {
        Text = CaroService.Language.GetString("or"),
        Size = new Size(60, 20),
        Location = new Point(242, 147)
      };
      loadgameBut = new CaroButton()
      {
        Location = new Point(202, 200),
        Text = CaroService.Language.GetString("loadGame"),
        Size = new Size(130, 40)
      };
      backBut = new CaroButton()
      {
        Location = new Point(20, 300),
        Text = CaroService.Language.GetString("back"),
        Size = new Size(70, 30)
      };
      twoPlayerBut.Click += TwoPlayerBut_Click;
      lanModeBut.Click += LanModeBut_Click;
      aiModeBut.Click += AiModeBut_Click;
      loadgameBut.Click += LoadgameBut_Click;
      backBut.Click += BackBut_Click;
      this.Controls.Add(twoPlayerBut);
      this.Controls.Add(lanModeBut);
      this.Controls.Add(aiModeBut);
      this.Controls.Add(orLbl);
      this.Controls.Add(loadgameBut);
      this.Controls.Add(backBut);
    }

    private void BackBut_Click(object sender, EventArgs e)
    {
      routes.Routing(Constants.OVERVIEW);
    }

    private void LoadgameBut_Click(object sender, EventArgs e)
    {
      routes.Routing(Constants.LOAD_GAME);
    }

    private void AiModeBut_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Chưa có chức năng này");
    }

    private void LanModeBut_Click(object sender, EventArgs e)
    {

    }

    private void TwoPlayerBut_Click(object sender, EventArgs e)
    {
      SettingConfig.GameMode = Constants.TWO_PLAYER_GAME_MODE;
      routes.Routing(Constants.SIZE_SETTING);
    }
  }
}
