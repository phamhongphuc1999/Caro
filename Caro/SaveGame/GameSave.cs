namespace Caro.SaveGame
{
    public class GameSave
    {
        public int NumberOfRow { get; set; }
        public int NumberOfColumn { get; set; }
        public string PlayerName1 { get; set; }
        public string ColorPlayer1 { get; set; }
        public string PlayerName2 { get; set; }
        public string ColorPlayer2 { get; set; }
        public int Turn { get; set; }
        public string CaroBoard { get; set; }
    }
}
