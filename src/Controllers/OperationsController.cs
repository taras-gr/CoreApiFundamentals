using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private IConfiguration _config;

        public OperationsController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpOptions("reloadconfig")]
        public IActionResult ReloadConfig()
        {
            try
            {
                var root = (IConfigurationRoot) _config;
                root.Reload();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
