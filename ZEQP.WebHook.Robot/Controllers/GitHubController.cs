using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ZEQP.WebHook.Robot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        public ILogger<GitHubController> Logger { get; set; }
        public GitHubController(ILogger<GitHubController> logger)
        {
            this.Logger = logger;
        }

        [HttpPost]
        public Task Post(object body)
        {
            var json = JsonConvert.SerializeObject(body);
            this.Logger.LogInformation($"接收数据：{Environment.NewLine}{json}");
            return Task.CompletedTask;
        }
    }
}