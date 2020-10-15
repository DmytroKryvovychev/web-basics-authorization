using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;

namespace web_basics.data.Repositories
{
    public class Owner
    {
        WebBasicsDBContext context;

        public Owner(IConfiguration configuration)
        {
            this.context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Owner> Get()
        {
            var owners = context.Owners.ToList();
            return owners;
        }
    }
}
