using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRAnalyzer.Models.PlayerModels;

namespace SRAnalyzer.Models
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            PlayerViewModels = new List<PlayerViewModel>();
            ChartItems = new Dictionary<DateTime, int[][]>();
        }

        public IEnumerable<PlayerViewModel> PlayerViewModels { get; set; }
        public Dictionary<DateTime, int[][]> ChartItems { get; set; }
    }
}
