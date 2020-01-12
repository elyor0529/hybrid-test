using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MaxMind.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hybrid.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeoIP2Controller : ControllerBase
    {
        public IActionResult GetInfo()
        {
            using (var reader = new Reader(Path.Combine(Environment.CurrentDirectory, "wwwroot", "GeoLite2-City.mmdb")))
            {
                var ip = IPAddress.Parse("178.33.123.109");
                var data = reader.Find<Dictionary<string, object>>(ip);

                return Ok(data);
            }
        }
    }
}