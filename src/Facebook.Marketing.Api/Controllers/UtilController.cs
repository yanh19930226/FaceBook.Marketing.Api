using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Facebook.Marketing.Api.Application.Dtos.Dingding;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Facebook.Marketing.Api.Controllers
{
    public class UtilController : Controller
    {
        [HttpPost("GetDingRoBot")]
        //public async Task<IActionResult> GetDingRoBot([FromBody] dingRotBotDto input)
        //{
        //    //var phone = await _fuluDing.GetUserPhone(input.senderStaffId);//获取发送人的电话，回复消息的时候可以@对应的发送人。
        //    //if (input.text.content.Contains("[XXXX]"))///input.text.content就是接受到的消息，  可以通过改字段进行消息过滤
        //    //{
        //    //    var s = input.text.content.Split(']')[1];
        //    //    var text = await todo...;//调用自己的方法，返回需要回复的消息
        //    //    SendMessage(text, phone); //发送回复的消息
        //    //}
        //    //else
        //    //{
        //    //    await SendMessage("请输入正确的命令:[流水上账查询]XXXX", phone);
        //    //}
        //    //return Ok(ResponseResult.Execute("0", null, $"发送成功"));
        //}
        public void SendMessage(string text, string atMobiles)//发送消息
        {
            //DingDingMessage message = new DingDingMessage();
            //message.msgtype = "text";
            //message.text.content = text;
            //message.at.atMobiles.Add(atMobiles);
            //String data = JsonConvert.SerializeObject(message);//Json将对象序列化
            //var json = await _client.PostAsync("xxxxx", new StringContent(data, Encoding.UTF8, "application/json"));//post 发起一个请求到 配置该机器人群的 Webhook 地址xxxxx
        }
    }
}
