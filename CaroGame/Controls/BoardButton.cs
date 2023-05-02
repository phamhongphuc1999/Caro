using System.Windows.Forms;

namespace CaroGame.Controls
{
  public class BoardButton : Button
  {
    public int Rows
    {
      get; set;
    }
    public int Columns
    {
      get; set;
    }
    public BoardButton() : base() { }
  }
}
