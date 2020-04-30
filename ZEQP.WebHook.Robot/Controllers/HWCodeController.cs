using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZEQP.WebHook.Robot.Models;
using ZEQP.WebHook.Robot.Service;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace ZEQP.WebHook.Robot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HWCodeController : ControllerBase
    {
        public HWCodeService HWCodeSvc { get; set; }
        public ILogger<HWCodeController> Logger { get; set; }
        public HWCodeController(HWCodeService svc,ILogger<HWCodeController> logger)
        {
            this.HWCodeSvc = svc;
            this.Logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<object> Get()
        {
            var result = new
            {
                DateTime = DateTime.Now,
                IP = ControllerContext.HttpContext.Request.Host
            };
            return result;
        }
        [HttpPost]
        public Task Post(object body)
        {
            var json = JsonConvert.SerializeObject(body);
            this.Logger.LogInformation($"接收数据：{Environment.NewLine}{json}");
            var model = JsonConvert.DeserializeObject<HWCodeHookModel>(json);
            return this.HWCodeSvc.SendDingTalkMarkdown(model);
        }
    }
}