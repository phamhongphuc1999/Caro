namespace CaroGame.Entities
{
  public struct BoardPosition
  {
    public int Row
    {
      get; private set;
    }
    public int Column
    {
      get; private set;
    }

    public BoardPosition(int row, int column)
    {
      this.Row = row;
      this.Column = column;
    }
  }
}
