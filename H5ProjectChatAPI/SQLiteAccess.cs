using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace H5ProjectChatAPI
{
    public class SQLiteAccess
    {
        private string cs = "Chatdatabase.db";
        private SQLiteConnection con;
        private SQLiteCommand cmd;

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
            if(OpenConnection())
            {
                string stm = "SELECT * FROM users";
                cmd = new SQLiteCommand(stm,con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    _users.Add(new UserItem { Id = reader.GetInt32(0), Username = reader.GetString(1), Password = reader.GetString(2), lastLogin = reader.GetDateTime(3), Token = reader.GetString(4)});
                }
                CloseConnection();
            }
            return _users;
        }

        public void CreateMessage(ChatItem CI)
        {
            if(OpenConnection())
            {
                string stm = "INSERT INTO chatData (userId, message, postTime) VALUES("+CI.userId+","+CI.message+","+CI.postTime+")";
                cmd = new SQLiteCommand(stm, con);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            

        }

        public void CreateUser(UserItem UI)
        {
            if(OpenConnection())
            {
                string stm = "INSERT INTO users () VALUES("+UI.Username+","+UI.Password+","+UI.lastLogin+")";
                CloseConnection();
            }
            
        }

    }
}


//Tables
//users
//chatData