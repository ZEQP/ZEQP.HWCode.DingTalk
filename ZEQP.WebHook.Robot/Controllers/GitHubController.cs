using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ZEQP.WebHook.Robot.Models;
using ZEQP.WebHook.Robot.Service;

namespace ZEQP.WebHook.Robot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        public GitHubService CodeSvc { get; set; }
        public ILogger<GitHubController> Logger { get; set; }
        public GitHubController(GitHubService svc, ILogger<GitHubController> logger)
        {
            this.CodeSvc = svc;
            this.Logger = logger;
        }

        [HttpPost]
        public Task Post(object body)
        {
            var json = JsonConvert.SerializeObject(body);
            this.Logger.LogInformation($"接收数据：{Environment.NewLine}{json}");
            var model = JsonConvert.DeserializeObject<GitHubPushModel>(json);
            return this.CodeSvc.SendDingTalkMarkdown(model);
        }
    }
}