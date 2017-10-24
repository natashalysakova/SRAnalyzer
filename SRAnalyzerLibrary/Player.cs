using System;
using System.Collections.Generic;

namespace SRAnalyzerLibrary
{
    public class Player : Entity
    {
        public Player()
        {
            ScoreItems = new List<ScoreItem>();;
        }

        public string Name { get; set; }

        public List<ScoreItem> ScoreItems { get; set; }
    }
}
