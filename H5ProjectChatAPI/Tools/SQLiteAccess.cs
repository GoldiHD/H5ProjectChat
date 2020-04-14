using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace H5ProjectChatAPI
{
    public class SQLiteAccess
    {
        private string cs = "Data Source=Chatdatabase.db";
        private SQLiteConnection con;
        private SQLiteCommand cmd;
        private object Lock;
        private bool OpenConnection()
        {
            try
            {
                con = new SQLiteConnection(cs);
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<UserItem> AccessUser()
        {
            List<UserItem> _users = new List<UserItem>();
            if (OpenConnection())
            {
                string stm = "SELECT * FROM users";
                cmd = new SQLiteCommand(stm, con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _users.Add(new UserItem { Id = reader.GetInt32(0), Username = reader.GetString(1), Password = reader.GetString(2), lastLogin = DateTime.Parse(reader.GetString(3)) });
                }
                CloseConnection();
            }
            return _users;
        }
        public void CreateMessage(ChatItem CI)
        {
            if (OpenConnection())
            {
                string stm = "INSERT INTO chatData (userId, message, postTime) VALUES('" + CI.posterName + "','" + CI.message + "','" + CI.postTime + "')";
                cmd = new SQLiteCommand(stm, con);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void CreateUser(UserItem UI)
        {
            if (OpenConnection())
            {
                string stm = "INSERT INTO users (username, password, lastLogin) VALUES('" + UI.Username + "','" + UI.Password + "','" + DateTime.Now + "')";
                cmd = new SQLiteCommand(stm, con);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public List<ChatItem> LoadMessages(int id, int amount)
        {
            List<ChatItem> messages = new List<ChatItem>();
            if (OpenConnection())
            {
                string stm = "SELECT * FROM chatData LIMIT " + amount + " OFFSET " + (id - amount);
                cmd = new SQLiteCommand(stm, con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    messages.Add(new ChatItem { id = reader.GetInt32(0), posterName = reader.GetString(1), message = reader.GetString(2), postTime = DateTime.Parse(reader.GetString(3)) });
                }
                CloseConnection();
            }
            return messages;
        }
        public int LatestChatId()
        {
            if (OpenConnection())
            {
                string stm = "SELECT* FROM chatData WHERE id IN(SELECT max(id) FROM chatData)";
                cmd = new SQLiteCommand(stm, con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                CloseConnection();
            }

            return 0;
        }

    }
}