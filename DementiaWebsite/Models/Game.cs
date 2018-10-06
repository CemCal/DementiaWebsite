using System;
using System.Collections.Generic;

namespace DementiaWebsite.Models
{
    public partial class Game
    {
        public Game()
        {
            Score = new HashSet<Score>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; }
        public int? GameDifficulty { get; set; }
        public int? GameCategory { get; set; }
        public byte? GameMultiplayer { get; set; }
        public int? GameHighscore { get; set; }
        public int? GameTime { get; set; }

        public ICollection<Score> Score { get; set; }
    }
}
