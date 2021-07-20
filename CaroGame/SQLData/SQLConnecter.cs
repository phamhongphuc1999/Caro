// ---------------CARO GAME---------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//
// Product by: Pham Hong Phuc
//
//
// ----------------------------------------

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
