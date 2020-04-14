using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H5ProjectChatAPI.Tools
{
    public class MessageHandler
    {
        SQLiteAccess access = new SQLiteAccess();

        //create injection protection
        public void AddMessage(ChatItem chatItem)
        {
            access.CreateMessage(chatItem);
        }

        public List<ChatItem> LoadMessages(int LastID, int amount)
        {
            List<ChatItem> Messages = new List<ChatItem>();
            //if LastID = 0 then load the latest
            if(LastID == 0)
            {
                Messages = access.LoadMessages(access.LatestChatId(), amount);
            }
            else if(amount > LastID)
            {
                Messages = access.LoadMessages(access.LatestChatId(), LastID);
            }
            else
            {
                Messages = access.LoadMessages(LastID, amount);
            }

            return Messages;
        }

        public int LastID()
        {
            return access.LatestChatId();
        }
    }
}
