using CaroGame.Configuration;
using CaroGame.Entities;
using CaroGame.SQLData;
using CaroGame.SQLData.Workers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static CaroGame.Program;

namespace CaroGame.Services.Services
{
  public class StorageService
  {
    private SQLConnecter connecter;
    private SaveGameWorker gameWorker;

    public List<GameSaveData> GameList
    {
      get
      {
        return gameWorker.GetListGames(connecter).ToList();
      }
    }

    public int CurrentIndex
    {
      get; set;
    }

    public StorageService()
    {
      string currentPath = Utils.GetCurrentDirectory();
      string projectDirectory = Directory.GetParent(currentPath).Parent.FullName;
      connecter = SQLConnecter.GetInstance(string.Format("Data Source={0}; Version = 3;",
          projectDirectory + @"\Resources\data\data.sqlite"));
      connecter.OpenConnection();
      gameWorker = new SaveGameWorker();

      CurrentIndex = -1;
      InitializeConfiguration();
      LoadGame();
    }

    private void InitializeConfiguration()
    {
      using (StreamReader sr = File.OpenText("../../Resources/data/settings.json"))
      {
        string data = sr.ReadToEnd();
        SettingEntity configEntity = JsonConvert.DeserializeObject<SettingEntity>(data);
        SettingConfig.Columns = configEntity.column;
        SettingConfig.Rows = configEntity.row;
        SettingConfig.IsTime = configEntity.isOnTime;
        SettingConfig.IsPlayMusic = configEntity.isPlayMusic;
        SettingConfig.VolumnSize = configEntity.volumeSize;
        SettingConfig.TimeTurn = configEntity.timeTurn;
        SettingConfig.Interval = configEntity.interval;
        SettingConfig.Language = configEntity.language;
      }
    }

    private void SaveConfiguration()
    {
      SettingEntity configEntity = new SettingEntity
      {
        column = SettingConfig.Columns,
        row = SettingConfig.Rows,
        isOnTime = SettingConfig.IsTime,
        isPlayMusic = SettingConfig.IsPlayMusic,
        volumeSize = SettingConfig.VolumnSize,
        timeTurn = SettingConfig.TimeTurn,
        interval = SettingConfig.Interval,
        language = SettingConfig.Language
      };
      StreamWriter sw = new StreamWriter("../../Resources/data/settings.json");
      string data = JsonConvert.SerializeObject(configEntity);
      sw.WriteLine(data);
      sw.Close();
    }

    private void LoadGame()
    {
      gameWorker.CreateTable(connecter);
    }

    public void SaveGame(string caroBoard, int turn)
    {
      GameSaveData gameSave = new GameSaveData
      {
        Row = SettingConfig.Rows,
        Column = SettingConfig.Columns,
        PlayerName1 = CaroService.Player.PlayerName1,
        PlayerName2 = CaroService.Player.PlayerName2,
        CaroBoard = caroBoard,
        Turn = turn,
        GameMode = SettingConfig.GameMode
      };
      if (CurrentIndex >= 0) gameWorker.UpdateGameById(CurrentIndex, gameSave, connecter);
      else CurrentIndex = gameWorker.InsertGame(gameSave, connecter);
    }

    public void DeleteGame(int id)
    {
      gameWorker.DeleteGameById(id, connecter);
    }

    public void Exit()
    {
      SaveConfiguration();
      connecter.CloseConnection();
    }
  }
}
