using System;
using System.Collections.Generic;

namespace DementiaWebsite.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Username { get; set; }
        public int? ScoreId { get; set; }

        public Score Score { get; set; }
        public Login UsernameNavigation { get; set; }
    }
}
