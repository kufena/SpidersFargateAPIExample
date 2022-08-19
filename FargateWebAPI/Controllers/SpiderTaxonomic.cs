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
            string result = "";
            List<Family> families = new List<Family>();
            using (var context = new SpidersContext(_parameters.Value.ConnectionString))
            {
                var all = context.Families.Select(x => x);
                foreach (var f in all)
                {
                    if (f != null)
                        families.Add(f);
                }
            }
            result = "[";
            foreach (var f in families)
            {
                result += f.ToJson();
            }
            result += "]";
            return result;
        }

        [HttpGet("family")]
        public string Get(string family)
        {
            string result = "";
            List<Species> species = new List<Species>();
            using (var context = new SpidersContext(_parameters.Value.ConnectionString)) 
            {
                var all = context.Species.Where(x => x.Family == family).Select(x => x);

                foreach (var f in all)
                {
                    if (f != null) 
                        species.Add(f);
                }
            }
            result = "[";
            foreach (var f in species)
            {
                result += f.ToJson();
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
