using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRAnalyzer.Models.ScoreItemsModels;
using SRAnalyzerLibrary;

namespace SRAnalyzer.Models.PlayerModels
{
    public class PlayerViewModel
    {
        public string Name { get; set; }

        public List<ScoreItemViewModel> ScoreItems { get; set; }

        public PlayerViewModel()
        {
            ScoreItems = new List<ScoreItemViewModel>();
        }

        internal static IEnumerable<PlayerViewModel> Convert(IEnumerable<Player> players)
        {
            return players.Select(Convert);
        }

        internal static PlayerViewModel Convert(Player player)
        {
            var model = new PlayerViewModel
            {
                Name = player.Name,
                ScoreItems = ScoreItemViewModel.Convert(player.ScoreItems).ToList()
            };

            return model;
        }
    }
}
