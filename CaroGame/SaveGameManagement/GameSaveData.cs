using System.Collections.Generic;

namespace CaroGame.SaveGameManagement
{
    public class GameSaveData
    {
        public List<GameSave> GameSaveList { get; set; }

        public GameSaveData()
        {
            GameSaveList = new List<GameSave>();
        }
    }
}
