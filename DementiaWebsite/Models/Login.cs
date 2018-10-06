using System;
using System.Collections.Generic;

namespace DementiaWebsite.Models
{
    public partial class Login
    {
        public Login()
        {
            Person = new HashSet<Person>();
        }

        public string Username { get; set; }
        public string UserPassword { get; set; }

        public ICollection<Person> Person { get; set; }
    }
}
