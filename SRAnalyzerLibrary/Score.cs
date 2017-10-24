using System;
using System.Collections.Generic;
using System.Text;

namespace SRAnalyzerLibrary
{
    public class ScoreItem : Entity
    {
        public DateTime DateTime { get; set; }
        public int Score { get; set; }

        public Player Player { get; set; }  
    }
}
