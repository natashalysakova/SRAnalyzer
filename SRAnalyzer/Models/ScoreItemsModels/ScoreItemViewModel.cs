using System;
using System.Collections.Generic;
using System.Linq;
using SRAnalyzer.Models.PlayerModels;
using SRAnalyzerLibrary;

namespace SRAnalyzer.Models.ScoreItemsModels
{
    public class ScoreItemViewModel
    {
        public DateTime DateTime { get; set; }
        public int Score { get; set; }

        internal static IEnumerable<ScoreItemViewModel> Convert(IEnumerable<ScoreItem> scoreItems)
        {
            var scoresModels = new List<ScoreItemViewModel>();
            foreach (var score in scoreItems)
            {
                scoresModels.Add(Convert(score));
            }

            return scoresModels;
        }

        internal static ScoreItemViewModel Convert(ScoreItem scoreItems)
        {
            var model = new ScoreItemViewModel
            {
                DateTime = scoreItems.DateTime,
                Score = scoreItems.Score
            };


            return model;
        }
    }
}