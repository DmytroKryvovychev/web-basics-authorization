using AutoMapper;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;

namespace web_basics.business.Domains
{
    public class Owner
    {
        IMapper mapper;
        data.Repositories.Owner repository;

        public Owner(IConfiguration configuration)
        {
            this.repository = new data.Repositories.Owner(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<data.Entities.Owner, ViewModels.Owner>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Owner> Get()
        {
            var owners = repository.Get();
            return owners.Select(owner => mapper.Map<data.Entities.Owner, ViewModels.Owner>(owner));
        }
    }
}
