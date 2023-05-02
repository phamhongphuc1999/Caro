using CaroGame.Configuration;
using CaroGame.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Views.Components.SettingComponents
{
  public class MainSettingPanel : BaseSettingPanel
  {
    protected CaroButton gameModeBut, timerBut, playerBut, sizeBut, soundBut, languageBut, appearanceBut, loadGameBut, saveGameBut;

    public MainSettingPanel(bool isAutoSize, bool isSave) : base(isAutoSize, isSave)
    {
      this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
      DrawBasePanel();
    }

    protected override void DrawBasePanel()
    {
      base.DrawBasePanel();
      gameModeBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("gameMode"),
        Size = new Size(100, 45),
        Location = new Point(29, 70)
      };
      timerBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("time"),
        Size = new Size(100, 45),
        Location = new Point(158, 70)
      };
      playerBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("player"),
        Size = new Size(100, 45),
        Location = new Point(287, 70)
      };
      sizeBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("sizeBoard"),
        Size = new Size(100, 45),
        Location = new Point(416, 70)
      };
      soundBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("sound"),
        Size = new Size(100, 45),
        Location = new Point(29, 135)
      };
      languageBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("language"),
        Size = new Size(100, 45),
        Location = new Point(158, 135)
      };
      appearanceBut = new CaroButton
      {
        Text = CaroService.Language.GetString("appearance"),
        Size = new Size(100, 45),
        Location = new Point(287, 135)
      };
      loadGameBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("loadGame"),
        Size = new Size(100, 30)
      };
      saveGameBut = new CaroButton()
      {
        Text = CaroService.Language.GetString("saveGame"),
        Size = new Size(80, 30),
        Location = new Point(445, 5)
      };
      if (SettingConfig.GameMode == Constants.LAN_GAME_MODE) loadGameBut.Location = new Point(445, 5);
      else loadGameBut.Location = new Point(325, 5);
      gameModeBut.Click += GameModeBut_Click;
      timerBut.Click += TimerBut_Click;
      playerBut.Click += PlayerBut_Click;
      sizeBut.Click += SizeBut_Click;
      soundBut.Click += SoundBut_Click;
      languageBut.Click += LanguageBut_Click;
      appearanceBut.Click += AppearanceBut_Click;
      loadGameBut.Click += LoadGameBut_Click;
      saveGameBut.Click += SaveGameBut_Click;
      this.Controls.Add(gameModeBut);
      this.Controls.Add(timerBut);
      this.Controls.Add(playerBut);
      this.Controls.Add(sizeBut);
      this.Controls.Add(soundBut);
      this.Controls.Add(languageBut);
      this.Controls.Add(appearanceBut);
      this.Controls.Add(loadGameBut);
      this.Controls.Add(saveGameBut);
    }

    protected override void SaveBut_Click(object sender, EventArgs e)
    {
      if (SettingConfig.PlayerOption)
      {
        CaroService.Player.PlayerName1 = TempConfig.NamePlayer1;
        CaroService.Player.PlayerName2 = TempConfig.NamePlayer2;
      }
      else if (SettingConfig.TimeOption)
      {
        SettingConfig.Interval = TempConfig.Interval;
        SettingConfig.TimeTurn = TempConfig.TimeTurn;
        SettingConfig.IsTime = TempConfig.IsTime;
        CaroService.Timer.StartTimer(true);
      }
      SettingConfig.ResetSettingOption();
      Control parent = this.Parent;
      parent.Hide();
    }

    protected override void CancelBut_Click(object sender, EventArgs e)
    {
      SettingConfig.ResetSettingOption();
      Control parent = this.Parent;
      parent.Hide();
    }

    private void SaveGameBut_Click(object sender, EventArgs e)
    {
      CaroService.Storage.SaveGame(CaroService.Board.ConvertBoardToString(), CaroService.Player.Turn);
    }

    private void LoadGameBut_Click(object sender, EventArgs e)
    {
      settingRoutes.Routing(Constants.LOAD_GAME);
    }

    private void AppearanceBut_Click(object sender, EventArgs e)
    {
      settingRoutes.Routing(Constants.APPEARANCE_SETTING);
    }

    private void LanguageBut_Click(object sender, EventArgs e)
    {
      settingRoutes.Routing(Constants.LANGUAGE_SETTING);
    }

    private void SoundBut_Click(object sender, EventArgs e)
    {
      settingRoutes.Routing(Constants.SOUND_SETTING);
    }

    private void SizeBut_Click(object sender, EventArgs e)
    {
      settingRoutes.Routing(Constants.SIZE_SETTING);
    }

    private void PlayerBut_Click(object sender, EventArgs e)
    {
      settingRoutes.Routing(Constants.PLAYER_SETTING);
    }

    private void TimerBut_Click(object sender, EventArgs e)
    {
      settingRoutes.Routing(Constants.TIME_SETTING);
    }

    private void GameModeBut_Click(object sender, EventArgs e)
    {
      settingRoutes.Routing(Constants.GAME_MODE);
    }
  }
}
