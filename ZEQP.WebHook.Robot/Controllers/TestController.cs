using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZEQP.WebHook.Robot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public ActionResult<object> Post(object body)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
            return body;
        }
    }
}