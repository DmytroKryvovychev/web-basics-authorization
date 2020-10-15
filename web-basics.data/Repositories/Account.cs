using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using web_basics.data.Entities;

namespace web_basics.data.Repositories
{
    public class Account
    {
        WebBasicsDBContext context;

        public Account(IConfiguration configuration)
        {
            this.context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Account> Get()
        {
            var accounts = context.Accounts.ToList();
            return accounts;
        }

        public Entities.Account GetAccount(int id)
        {
            var account = context.Accounts.FirstOrDefault(acc => acc.Id == id);
            return account;
        }

        public int Delete(int id)
        {
            var account = context.Accounts.FirstOrDefault(acc => acc.Id == id && acc.Role != Role.Admin);

            if (account == null) return -1;

            context.Accounts.Remove(account);
            context.SaveChanges();
            return id;
        }


        public int Patch(int id, int role)
        {
            context.Accounts.FirstOrDefault(acc => acc.Id == id).Role = (Role)role;
            context.SaveChanges();
            return role;
        }

        public Entities.Account Post(Entities.Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
            return account;
        }
    }
}
