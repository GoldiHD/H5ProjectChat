using H5ProjectChatDesktop.Entities;
using H5ProjectChatDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H5ProjectChatDesktop.Tools
{
    class MessageUpdater
    {
        public void MessageUpdaterStart()
        {
            RunTime();
        }

        private void RunTime()
        {
            while (true)
            {
                if (SingleTon.GetMessages().Count != 0)
                {
                    if (SingleTon.GetMessages().LastOrDefault().id != SingleTon.GetAPIAccess().CheckLastID().Result)
                    {
                        SingleTon.GetMessages().Clear();
                        List<ChatItem> chatItems = SingleTon.GetAPIAccess().GetMessages(SingleTon.GetMessages().Last().id).Result;
                        if (chatItems.Count != 0)
                        {
                            SingleTon.GetMessages().AddRange(chatItems);
                            ChatController.Updater();
                        }
                    }
                }
                else
                {
                    List<ChatItem> chatItems = SingleTon.GetAPIAccess().GetMessages(0).Result;
                    if (chatItems.Count != 0)
                    {
                        SingleTon.GetMessages().AddRange(chatItems);
                        ChatController.Updater();
                    }
                }
                Thread.Sleep(5000);
            }
        }
    }
}
