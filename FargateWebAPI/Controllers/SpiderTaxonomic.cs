using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UploadSpiders.Model;
using Microsoft.Extensions.Configuration;
using FargateWebAPI.Util;

namespace FargateWebAPI.Controllers
{
    [Route("api/spiders")]
    [ApiController]
    public class SpiderTaxonomic : ControllerBase
    {
        private IConfiguration _config;
        private IOptions<Parameters> _parameters;

        public SpiderTaxonomic(IConfiguration config, IOptions<Parameters> options)
        {
            this._config = config;
            this._parameters = options;
        }

        [HttpGet]
        public string Get()
        {
            return "{}";
        }

        [HttpGet("family")]
        public string Get(string family)
        {
            string result = "";
            List<Family> families = new List<Family>();
            using (var context = new SpidersContext(_parameters.Value.ConnectionString)) 
            {
                var all = context.Families.Where(x => x.Name == family).Select(x => x);
                foreach (var f in all)
                {
                    if (f != null) 
                        families.Add(f);
                }
            }
            result = "[";
            foreach (var f in families)
            {
                result += $"{{\"Id\"=\"{f.Id}\",\"Name\"=\"{f.Name}\"}}";
            }
            result += "]";
            return result;
        }

        [HttpGet("family/genus")]
        public string Get(string family, string genus)
        {
            return "{}";
        }

    }
}
