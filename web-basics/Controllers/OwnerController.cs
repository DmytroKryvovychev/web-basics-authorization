using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private business.Domains.Cat catDomain;
        private business.Domains.Owner ownerDomain;

        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public OwnerController(IConfiguration configuration)
        {
            this.catDomain = new business.Domains.Cat(configuration);
            this.ownerDomain = new business.Domains.Owner(configuration);
        }

        [HttpGet]
        [Authorize (Roles = "User")]
        [Route("")]
        public IActionResult GetPets()
        {
            if (!ownerDomain.Get().Any(owner => owner.UserId == UserId))
            {
                return Ok(Enumerable.Empty<Cat>());
            }

            var catsOwner = ownerDomain.Get().Where(owner => owner.UserId == UserId);
            var cats = catDomain.Get().Where(cat => catsOwner.Any(owner => owner.CatId == cat.Id));

            return Ok(cats);
        }
    }
}
