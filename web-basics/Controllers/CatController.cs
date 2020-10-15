using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        business.Domains.Cat domain;

        public CatController(IConfiguration configuration) 
        {
            this.domain = new business.Domains.Cat(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cats = this.domain.Get();
            return Ok(cats);
        }
    }
}
