using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZEQP.WebHook.Robot.Models
{
    public class DingTalkResModel
    {
        public string msgtype { get; set; }
        public DingTalkResMarkdown markdown { get; set; }
        //public DingTalkResText text { get; set; }
        //public DingTalkResAt at { get; set; }
    }

    public class DingTalkResMarkdown
    {
        public string title { get; set; }
        public string text { get; set; }
    }
    //public class DingTalkResText
    //{
    //    public string content { get; set; }
    //}
    //public class DingTalkResAt
    //{
    //    public string[] atMobiles { get; set; }
    //    public bool isAtAll { get; set; }
    //}
}
