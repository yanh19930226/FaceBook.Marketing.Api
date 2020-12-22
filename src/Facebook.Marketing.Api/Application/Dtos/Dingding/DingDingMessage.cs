using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Dtos.Dingding
{
    public class DingDingMessage
    {
        public DingDingMessage()
        {
            //this.at = new At();
            //this.text = new Text();
            //this.markdown = new MarkDown();
        }
        public string msgtype { set; get; }//消息类型
        public Text text { set; get; }//text类型
        public At at { set; get; }//@
    }

    public class At
    {
        public List<string> atMobiles { get; set; }
        public bool isAtAll { get; set; }
    }
    public class Text
    {
        public string content { get; set; }
    }
}
