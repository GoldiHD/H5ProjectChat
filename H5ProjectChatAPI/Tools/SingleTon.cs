using H5ProjectChatAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5ProjectChatAPI.Tools
{
    class SingleTon
    {
        private static SQLiteAccess SQLInstance;

        public static SQLiteAccess GetSQL()
        {
            if(SQLInstance == null)
            {
                SQLInstance = new SQLiteAccess();
            }
            return SQLInstance;
        }
    }
}
