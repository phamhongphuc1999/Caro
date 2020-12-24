namespace CaroGame.Entities
{
    public class LanConfigEntity
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public int BuffSize { get; set; }
        public bool IsServer { get; set; }
        public bool IsTurn { get; set; }
        public bool IsLock { get; set; }
    }
}
