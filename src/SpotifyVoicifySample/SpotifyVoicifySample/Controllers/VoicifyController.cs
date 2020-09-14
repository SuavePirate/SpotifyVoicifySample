using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyVoicifySample.Controllers
{
    [Route("api/[controller]")]
    public class VoicifyController : Controller
    {
        [HttpPost("HandleRequest")]
        public async Task<IActionResult> HandleRequest()
        {
            return Ok();
        }
    }
}
