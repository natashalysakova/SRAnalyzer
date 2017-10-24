using System;

namespace SRAnalyzer.Models.ScoreItemsModels
{
    public class AddBatchScoreModel
    {
        public int PlayerId { get; set; }
        public string Scores { get; set; }
        public DateTime DateTime { get; set; }
    }
}