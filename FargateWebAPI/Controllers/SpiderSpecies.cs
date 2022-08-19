using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FargateWebAPI.Controllers
{
    [Route("api/species")]
    [ApiController]
    public class SpiderSpecies : ControllerBase
    {
        [HttpGet("genus/species")]
        public string Get(string genus, string species)
        {
            return "{}";
        }
    }
}
