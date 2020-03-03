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
        //users
        //chatData
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
                    _users.Add(new UserItem { Id = reader.GetInt32(0), Username = reader.GetString(1) });
                }
            }

            CloseConnection();
            return _users;
        }

    }
}
