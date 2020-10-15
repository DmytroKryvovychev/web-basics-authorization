using System;
using System.Collections.Generic;
using System.Text;

namespace web_basics.business.ViewModels
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        User,
        Admin
    }
}
