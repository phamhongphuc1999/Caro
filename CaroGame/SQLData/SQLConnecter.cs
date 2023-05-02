using System.Data.SQLite;

namespace CaroGame.SQLData
{
  public class SQLConnecter
  {
    private static SQLConnecter connecter;
    public SQLiteConnection connection
    {
      get; private set;
    }

    private SQLConnecter(string connectString)
    {
      connection = new SQLiteConnection();
      connection.ConnectionString = connectString;
    }

    public static SQLConnecter GetInstance(string connectString)
    {
      if (connecter == null) connecter = new SQLConnecter(connectString);
      return connecter;
    }

    public void OpenConnection()
    {
      connection.Open();
    }

    public void CloseConnection()
    {
      connection.Close();
    }
  }
}
