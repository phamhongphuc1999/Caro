using Caro.Setting;

namespace Caro.SaveGame
{
    public class SaveGameHelper
    {
        public static string caroBoard = "";
        public static int turn = -1;
        public static int index = -1;

        public static void SaveCurrentGame()
        {
            if (CONST.IS_LOAD_GAME)
            {
                CONST.saveData.GameSaveList[index].NumberOfColumn = CONST.NUMBER_OF_COLUMN;
                CONST.saveData.GameSaveList[index].NumberOfRow = CONST.NUMBER_OF_ROW;
                CONST.saveData.GameSaveList[index].PlayerName1 = CONST.NAME_PLAYER1;
                CONST.saveData.GameSaveList[index].PlayerName2 = CONST.NAME_PLAYER2;
                CONST.saveData.GameSaveList[index].CaroBoard = caroBoard;
                CONST.saveData.GameSaveList[index].Turn = turn;
            }
            else
            {
                GameSave gameSave = new GameSave()
                {
                    NumberOfColumn = CONST.NUMBER_OF_COLUMN,
                    NumberOfRow = CONST.NUMBER_OF_ROW,
                    PlayerName1 = CONST.NAME_PLAYER1,
                    PlayerName2 = CONST.NAME_PLAYER2,
                    CaroBoard = caroBoard,
                    Turn = turn
                };
                CONST.saveData.GameSaveList.Add(gameSave);
            }
        }

        public static void DrawSaveGame(GameSave gameSave)
        {
            CONST.NAME_PLAYER1 = gameSave.PlayerName1;
            CONST.NAME_PLAYER2 = gameSave.PlayerName2;
            CONST.NUMBER_OF_COLUMN = gameSave.NumberOfColumn;
            CONST.NUMBER_OF_ROW = gameSave.NumberOfRow;
        }
    }
}
