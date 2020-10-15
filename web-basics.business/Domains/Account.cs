using AutoMapper;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;
using web_basics.business.ViewModels;

namespace web_basics.business.Domains
{
    public class Account
    {
        IMapper mapper;
        data.Repositories.Account repository;

        public Account(IConfiguration configuration)
        {
            this.repository = new data.Repositories.Account(configuration);
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<data.Entities.Account, ViewModels.Account>();
                cfg.CreateMap<ViewModels.Account, data.Entities.Account>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Account> Get()
        {
            var accounts = repository.Get();
            return accounts.Select(account => mapper.Map<data.Entities.Account, ViewModels.Account>(account));
        }

        public ViewModels.Account GetAccount(int id)
        {
            var account = repository.GetAccount(id);
            return mapper.Map<data.Entities.Account, ViewModels.Account>(account);
        }

        public int Delete(int id)
        {
            repository.Delete(id);
            return id;
        }

        public int Patch(int id, int role)
        {
            repository.Patch(id, role);
            return role;
        }

        public ViewModels.Account Post(ViewModels.Account account)
        {
            var acc = repository.Post(mapper.Map<ViewModels.Account, data.Entities.Account>(account));
            return mapper.Map<ViewModels.Account>(acc);
        }

    }
}
