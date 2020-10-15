using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        business.Domains.Account domain;

        public AccountController(IConfiguration configuration)
        {
            this.domain = new business.Domains.Account(configuration);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("")]
        public IActionResult Get()
        {
            var accounts = this.domain.Get();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult GetAccount(int id)
        {

            var account = this.domain.GetAccount(id);
            return Ok(account);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == -1)
            {
                return BadRequest();
            }

            this.domain.Delete(id);
            return Ok(id);

        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult Patch(int id, [FromBody]int role)
        {
            if (id == 0 || id == -1)
            {
                return BadRequest();
            }

            this.domain.Patch(id, role);
            return Ok(role);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] business.ViewModels.Account account)
        {
            
            var acc = this.domain.Post(account);
            return Ok(acc);

        }

    }
}
