using System.Data.SQLite;

namespace CaroGame.SQLData.Workers
{
  public class BaseWorker
  {
    public virtual void CreateTable(SQLConnecter connecter)
    {
    }

    protected virtual bool ExecuteCommand(string commandText, SQLiteConnection connecter)
    {
      SQLiteCommand command = new SQLiteCommand(commandText, connecter);
      return command.ExecuteNonQuery() > 0;
    }

    protected virtual object ExecuteScalar(string commandText, SQLiteConnection connecter)
    {
      SQLiteCommand command = new SQLiteCommand(commandText, connecter);
      return command.ExecuteScalar();
    }

    protected virtual SQLiteDataReader ExecuteReader(string commandText, SQLiteConnection connecter)
    {
      SQLiteCommand command = new SQLiteCommand(commandText, connecter);
      return command.ExecuteReader();
    }
  }
}
