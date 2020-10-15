using System;
using System.Collections.Generic;
using System.Text;

namespace web_basics.data.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CatId { get; set; }
    }
}
