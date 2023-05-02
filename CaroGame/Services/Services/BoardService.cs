using CaroGame.Configuration;
using CaroGame.Controls;
using CaroGame.Entities;
using CaroGame.Views.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Services.Services
{
  public class BoardService
  {
    private Panel caroBoardView;
    private Dictionary<BoardPosition, Button> caroBoard;
    private TextBox playerTxt;

    public void InitMainView(MainPanel mainView)
    {
      caroBoardView = mainView.caroBoardView;
      playerTxt = mainView.playerTxt;
    }

    public void InitCaroBoard()
    {
      playerTxt.Text = CaroService.Player.CurrentPlayerName;
      playerTxt.BackColor = CaroService.Player.CurrentPlayerColor;
      caroBoard = new Dictionary<BoardPosition, Button>();
    }

    public void DrawCaroBoard()
    {
      caroBoardView.Controls.Clear();
      caroBoardView.Enabled = true;
      caroBoard.Clear();
      int count = 0;
      for (int i = 0; i < SettingConfig.Rows; i++)
        for (int j = 0; j < SettingConfig.Columns; j++)
        {
          if (SettingConfig.BoardPattern[count] != Constants.VOID_POSITION)
          {
            BoardButton but = new BoardButton
            {
              Size = new Size(Constants.CHESS_WIDTH, Constants.CHESS_HEIGHT),
              Location = new Point(Constants.CHESS_WIDTH * j, Constants.CHESS_HEIGHT * i),
              Rows = i,
              Columns = j
            };
            if (SettingConfig.BoardPattern[count] == Constants.PLAYER1_POSITION) but.BackColor = CaroService.Player.PlayerColor1;
            else if (SettingConfig.BoardPattern[count] == Constants.PLAYER2_POSITION) but.BackColor = CaroService.Player.PlayerColor2;
            but.Click += But_Click;
            caroBoard.Add(new BoardPosition(i, j), but);
            caroBoardView.Controls.Add(but);
          }
          count++;
        }
    }

    public string ConvertBoardToString()
    {
      string board = "";
      Color playerColor1 = CaroService.Player.PlayerColor1;
      Color playerColor2 = CaroService.Player.PlayerColor2;
      for (int i = 0; i < SettingConfig.Rows; i++)
        for (int j = 0; j < SettingConfig.Columns; j++)
        {
          BoardPosition position = new BoardPosition(i, j);
          if (caroBoard.ContainsKey(new BoardPosition(i, j)))
          {
            Button button = caroBoard[position];
            if (button.BackColor == playerColor1) board += Constants.PLAYER1_POSITION;
            else if (button.BackColor == playerColor2) board += Constants.PLAYER2_POSITION;
            else board += Constants.EMPTY_POSITION;
          }
          else board += Constants.VOID_POSITION;
        }
      return board;
    }

    public void CreateNewGame(int turn)
    {
      CaroService.Player.Turn = turn;
      CaroService.Action.ResetAction();
      InitCaroBoard();
      DrawCaroBoard();
      SettingConfig.NewGame();
      CaroService.Winner.NewGameHanlde(turn);
    }

    public void UndoGame(int row, int column, string playerName)
    {
      Button but = caroBoard[new BoardPosition(row, column)];
      but.BackColor = Color.Transparent;
      but.FlatStyle = FlatStyle.Standard;
      playerTxt.Text = playerName;
    }

    public void RedoGame(int row, int column, string playerName, Color playerColor)
    {
      Button but = caroBoard[new BoardPosition(row, column)];
      but.BackColor = playerColor;
      playerTxt.Text = playerName;
      but.FlatStyle = FlatStyle.Standard;
    }

    private void ExecuteNewGame()
    {
      DialogResult result = MessageBox.Show("Bạn có muốn chơi trò chơi mới?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
      if (result == DialogResult.OK) CreateNewGame(CaroService.Player.Turn);
      throw new StayOldGameException();
    }

    private void DrawWinner(Button eventBut)
    {
      caroBoardView.Enabled = false;
      int[] check = CaroService.Winner.check;
      if (check[0] == 1)
      {
        foreach (BoardPosition item in CaroService.Winner.arrRow)
          caroBoard[item].FlatStyle = FlatStyle.Flat;
      }
      if (check[1] == 1)
      {
        foreach (BoardPosition item in CaroService.Winner.arrColumn)
          caroBoard[item].FlatStyle = FlatStyle.Flat;
      }
      if (check[2] == 1)
      {
        foreach (BoardPosition item in CaroService.Winner.arrMainDiagonal)
          caroBoard[item].FlatStyle = FlatStyle.Flat;
      }
      if (check[3] == 1)
      {
        foreach (BoardPosition item in CaroService.Winner.arrSubDiagomal)
          caroBoard[item].FlatStyle = FlatStyle.Flat;
      }
      eventBut.FlatStyle = FlatStyle.Flat;
    }

    private void Winner(Button eventBut)
    {
      DrawWinner(eventBut);
      if (SettingConfig.GameMode == Constants.TWO_PLAYER_GAME_MODE)
      {
        MessageBox.Show($"Người chơi {CaroService.Player.CurrentPlayerName} chiến thắng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        try
        {
          ExecuteNewGame();
        }
        catch { }
      }
    }

    private void EndGame()
    {
      caroBoardView.Enabled = false;
      if (SettingConfig.GameMode == Constants.TWO_PLAYER_GAME_MODE)
      {
        MessageBox.Show("Trò chơi kết thúc, không ai giành chiến thắng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        try
        {
          ExecuteNewGame();
        }
        catch { }
      }
    }

    private void But_Click(object sender, EventArgs e)
    {
      BoardButton but = sender as BoardButton;
      if (!CaroService.Winner.CheckExtist(but.Rows, but.Columns))
      {
        but.BackColor = CaroService.Player.CurrentPlayerColor;
        CaroService.Winner.DrawCaroBoard(but.Rows, but.Columns);
        CaroService.Action.UpdateTurn(but);
        if (CaroService.Winner.IsWiner(but.Rows, but.Columns).Result) Winner(but);
        else if (CaroService.Winner.IsEndGame()) EndGame();
        else
        {
          CaroService.Player.Turn = CaroService.Player.Turn + 1;
          CaroService.Winner.Turn = 1 - CaroService.Winner.Turn;
          CaroService.Timer.TurnTimer();
        }
      }
    }
  }
}
