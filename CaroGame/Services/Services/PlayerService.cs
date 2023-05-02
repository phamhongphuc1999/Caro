using CaroGame.Configuration;
using CaroGame.Entities;
using CaroGame.Views.Components;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Services.Services
{
  public class PlayerService
  {
    private Player player1;
    private Player player2;
    private TextBox playerTxt;

    public PlayerService()
    {
      player1 = new Player(Constants.PLAYER1_DEFAULT_NAME, Color.Green, true);
      player2 = new Player(Constants.PLAYER2_DEFAULT_NAME, Color.Red, false);
    }

    public PlayerService(string playerName1, string playerName2)
    {
      player1 = new Player(playerName1, Color.Green, true);
      player2 = new Player(playerName2, Color.Red, false);
    }

    public void InitMainView(MainPanel mainView)
    {
      playerTxt = mainView.playerTxt;
    }

    public int Turn
    {
      get
      {
        return player1.IsTurn ? Constants.PLAYER1_TURN : Constants.PLAYER2_TURN;
      }
      set
      {
        if (value % 2 == 0)
        {
          player1.IsTurn = true;
          player2.IsTurn = false;
        }
        else if (value % 2 == 1)
        {
          player1.IsTurn = false;
          player2.IsTurn = true;
        }
        playerTxt.Text = this.CurrentPlayerName;
        playerTxt.BackColor = this.CurrentPlayerColor;
      }
    }

    public string PlayerName1
    {
      get
      {
        return player1.NamePlayer;
      }
      set
      {
        player1.NamePlayer = value;
        playerTxt.Text = this.CurrentPlayerName;
      }
    }

    public string PlayerName2
    {
      get
      {
        return player2.NamePlayer;
      }
      set
      {
        player2.NamePlayer = value;
        playerTxt.Text = this.CurrentPlayerName;
      }
    }

    public Color PlayerColor1
    {
      get
      {
        return player1.ColorPlayer;
      }
      set
      {
        player1.ColorPlayer = value;
        playerTxt.BackColor = this.CurrentPlayerColor;
      }
    }

    public Color PlayerColor2
    {
      get
      {
        return player2.ColorPlayer;
      }
      set
      {
        player2.ColorPlayer = value;
        playerTxt.BackColor = this.CurrentPlayerColor;
      }
    }

    public string CurrentPlayerName
    {
      get
      {
        if (player1.IsTurn) return player1.NamePlayer;
        return player2.NamePlayer;
      }
    }

    public Color CurrentPlayerColor
    {
      get
      {
        if (player1.IsTurn) return player1.ColorPlayer;
        return player2.ColorPlayer;
      }
    }

    public string OtherPlayerName
    {
      get
      {
        if (player1.IsTurn) return player2.NamePlayer;
        return player1.NamePlayer;
      }
    }

    public Color OtherPlayerColor
    {
      get
      {
        if (player1.IsTurn) return player2.ColorPlayer;
        return player1.ColorPlayer;
      }
    }
  }
}
