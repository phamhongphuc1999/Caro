namespace CaroGame.Configuration
{
    public static class Constants
    {
        public readonly static int WIDTH_STANDARD = 600;
        public readonly static int HEIGHT_STANDARD = 375;

        public readonly static string TWO_PLAYER_GAME_MODE = "two_palyer";
        public readonly static string LAN_GAME_MODE = "lan_game_mode";
        public readonly static string AI_GAME_MODE = "ai_game_mode";

        public readonly static string PLAYER1_DEFAULT_NAME = "player1";
        public readonly static string PLAYER2_DEFAULT_NAME = "player2";
        public readonly static int PLAYER1_TURN = 0;
        public readonly static int PLAYER2_TURN = 1;

        public readonly static (int, int)[] CARO_SIZE = new (int, int)[] { (5, 5), (10, 5), (10, 10), (15, 10), (15, 15), (20, 15), (20, 20), (25, 20), (25, 25) };

        public readonly static string OVERVIEW = "Overview";
        public readonly static string GAME_MODE = "Game Mode";
        public readonly static string SIZE_SETTING = "Size Setting";
        public readonly static string PLAYER_SETTING = "Player Setting";
    }
}
