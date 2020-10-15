using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace web_basics.business.Domains
{
    public class Cat
    {
        data.Repositories.Cat repository;
        IMapper mapper;

        public Cat(IConfiguration configuration)
        {
            this.repository = new data.Repositories.Cat(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<data.Entities.Cat, ViewModels.Cat>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Cat> Get()
        {
            var cats = repository.Get();
            return cats.Select(cat => mapper.Map<data.Entities.Cat, ViewModels.Cat>(cat));
        }
    }
}
