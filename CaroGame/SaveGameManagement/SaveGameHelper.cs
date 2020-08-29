using CaroGame.Configuration;

namespace CaroGame.SaveGameManagement
{
    public class SaveGameHelper
    {
        public static string caroBoard = "";
        public static int turn = -1;
        public static int index = -1;

        public static void SaveCurrentGame()
        {
            if (Config.IS_LOAD_GAME)
            {
                Config.saveData.GameSaveList[index].NumberOfColumn = Config.NUMBER_OF_COLUMN;
                Config.saveData.GameSaveList[index].NumberOfRow = Config.NUMBER_OF_ROW;
                Config.saveData.GameSaveList[index].PlayerName1 = Config.NAME_PLAYER1;
                Config.saveData.GameSaveList[index].PlayerName2 = Config.NAME_PLAYER2;
                Config.saveData.GameSaveList[index].CaroBoard = caroBoard;
                Config.saveData.GameSaveList[index].Turn = turn;
            }
            else if (Config.IS_OLD_GAME)
            {
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].NumberOfColumn = Config.NUMBER_OF_COLUMN;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].NumberOfRow = Config.NUMBER_OF_ROW;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].PlayerName1 = Config.NAME_PLAYER1;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].PlayerName2 = Config.NAME_PLAYER2;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].CaroBoard = caroBoard;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].Turn = turn;
            }
            else
            {
                GameSave gameSave = new GameSave()
                {
                    NumberOfColumn = Config.NUMBER_OF_COLUMN,
                    NumberOfRow = Config.NUMBER_OF_ROW,
                    PlayerName1 = Config.NAME_PLAYER1,
                    PlayerName2 = Config.NAME_PLAYER2,
                    CaroBoard = caroBoard,
                    Turn = turn
                };
                Config.saveData.GameSaveList.Add(gameSave);
                Config.IS_OLD_GAME = true;
                Config.INDEX_OLD_GAME = Config.saveData.GameSaveList.Count - 1;
            }
        }

        public static void DrawSaveGame(GameSave gameSave)
        {
            Config.NAME_PLAYER1 = gameSave.PlayerName1;
            Config.NAME_PLAYER2 = gameSave.PlayerName2;
            Config.NUMBER_OF_COLUMN = gameSave.NumberOfColumn;
            Config.NUMBER_OF_ROW = gameSave.NumberOfRow;
        }
    }
}
