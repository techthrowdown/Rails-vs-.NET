using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDevelopment.Web.Models
{
    public class UserToken
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public bool Admin { get; set; }
        public bool Authenticated { get; set; }
    }
}