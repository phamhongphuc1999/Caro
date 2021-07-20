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

using CaroGame.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace CaroGame.SQLData.Workers
{
    public class SaveGameWorker : BaseWorker
    {
        public override void CreateTable(SQLConnecter connecter)
        {
            string createCommand = string.Format("CREATE TABLE IF NOT EXISTS Game {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                "([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT",
                "Row int", "Column int", "PlayerName1 varchar(100)",
                "PlayerName2 varchar(100)", "GameMode varchar(20)",
                "Turn int", "CaroBoard varchar(1000)");
            SQLiteCommand command = new SQLiteCommand(createCommand, connecter.connection);
            command.ExecuteNonQuery();
        }

        public int InsertGame(GameSaveData insertData, SQLConnecter connecter)
        {
            string insertCommand = string.Format("INSERT INTO Game(Row,Column,PlayerName1,PlayerName2,GameMode,Turn,CaroBoard) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
             insertData.Row, insertData.Column, insertData.PlayerName1, insertData.PlayerName2, insertData.GameMode, insertData.Turn, insertData.CaroBoard);
            if (ExecuteCommand(insertCommand, connecter.connection))
            {
                string getIdCoommand = "SELECT last_insert_rowid()";
                int _id = Convert.ToInt32(ExecuteScalar(getIdCoommand, connecter.connection));
                return _id;
            }
            else return -1;
        }

        public GameSaveData GetGameById(int gameId, SQLConnecter connecter)
        {
            DataSet data = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(
                string.Format("select id, Row, Column, PlayerName1, PlayerName2, GameMode, Turn, CaroBoard from Game where id='{0}'", gameId),
                connecter.connection);
            adapter.Fill(data);
            DataRow entity = data.Tables[0].Rows[0];
            return Utils.ToObject<GameSaveData>(entity);
        }

        public IEnumerable<GameSaveData> GetListGames(SQLConnecter connecter)
        {
            DataSet data = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(
                string.Format("select id, Row, Column, PlayerName1, PlayerName2, GameMode, Turn, CaroBoard from Game"),
                connecter.connection);
            adapter.Fill(data);
            DataRowCollection dataList = data.Tables[0].Rows;
            int count = dataList.Count;
            for (int i = 0; i < count; i++)
                yield return Utils.ToObject<GameSaveData>(dataList[i]);
        }

        public bool UpdateGameById(int gameId, GameSaveData update, SQLConnecter connecter)
        {
            string updateCommand = string.Format("UPDATE Game set Row='{0}', Column='{1}', PlayerName1='{2}', PlayerName2='{3}', GameMode='{4}', Turn='{5}', CaroBoard='{6}' where id='{5}'",
             update.Row, update.Column, update.PlayerName1, update.PlayerName2, update.GameMode, update.Turn, update.CaroBoard, gameId);
            return ExecuteCommand(updateCommand, connecter.connection);
        }

        public bool DeleteGameById(int gameId, SQLConnecter connecter)
        {
            string updateCommand = string.Format("DELETE FROM Game where id='{0}'", gameId);
            return ExecuteCommand(updateCommand, connecter.connection);
        }
    }
}
