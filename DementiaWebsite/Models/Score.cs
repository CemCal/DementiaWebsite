using System;
using System.Collections.Generic;

namespace DementiaWebsite.Models
{
    public partial class Score
    {
        public Score()
        {
            Person = new HashSet<Person>();
        }

        public int ScoreId { get; set; }
        public DateTime? StartDate { get; set; }
        public int? PointTotal { get; set; }
        public int? TimeTotal { get; set; }
        public int? UserDifficulty { get; set; }
        public int? UserLevel { get; set; }
        public int? GameId { get; set; }

        public Game Game { get; set; }
        public ICollection<Person> Person { get; set; }
    }
}
