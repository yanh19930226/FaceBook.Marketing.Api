using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Dtos.Dingding
{
    public class dingRotBotDto
    {
        public string msgtype { get; set; }
        public dingText text { get; set; }
        public string msgId { get; set; }
        public string createAt { get; set; }
        public string conversationType { get; set; }
        public string conversationId { get; set; }
        public string conversationTitle { get; set; }
        public string senderId { get; set; }
        public string senderNick { get; set; }
        public string senderCorpId { get; set; }
        public string senderStaffId { get; set; }
        public string chatbotUserId { get; set; }
        public List<dingUser> atUsers { get; set; }
    }
    public class dingText
    {
        public string content { get; set; }
    }
    public class dingUser
    {
        public string dingtalkId { get; set; }

        public string staffId { get; set; }
    }
}
