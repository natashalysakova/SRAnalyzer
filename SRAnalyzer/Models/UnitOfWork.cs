using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRAnalyzer.Models.PlayerModels;
using SRAnalyzer.Models.ScoreItemsModels;
using SRAnalyzerLibrary;
using SRAnalyzerLibrary.Repositories;

namespace SRAnalyzer.Models
{
    public class UnitOfWork
    {
        private readonly IRepository<Player> _playeRepository;
        private readonly IRepository<ScoreItem> _scoreRepository;


        public UnitOfWork(IRepository<Player> playeRepository, IRepository<ScoreItem> scoreRepository)
        {
            _playeRepository = playeRepository;
            _scoreRepository = scoreRepository;
        }

        internal MainPageViewModel GetMainPageView()
        {
            MainPageViewModel model = new MainPageViewModel();

            var players = _playeRepository.GetAll().ToList();
            model.PlayerViewModels = PlayerViewModel.Convert(players);


            var dates = players.Select(x => x.ScoreItems.Select(y => y.DateTime));

            foreach (var date in dates)
            {
                foreach (var dateTime in date)
                {
                    if (!model.ChartItems.ContainsKey(dateTime))
                    {
                        model.ChartItems.Add(dateTime, new int[players.Count()][]);
                    }
                }
            }

            for (int i = 0; i < players.Count; i++)
            {
                foreach (var playerScoreItem in players[i].ScoreItems.GroupBy(x => x.DateTime))
                {
                    model.ChartItems[playerScoreItem.Key][i] = playerScoreItem.Select(x => x.Score).ToArray();
                }
            }

            return model;
        }

        internal SelectList GetPlayersSelectList()
        {
            var players = _playeRepository.GetAll().OrderBy(x => x.Name);

            return  new SelectList(players.Select(player => new { id = player.Id, name = player.Name}), "id", "name");
        }

        internal void AddBatchOfScores(AddBatchScoreModel model)
        {
            var player = _playeRepository.Get(model.PlayerId);

            var scores = model.Scores.Split(new char[] {'\n', ' ', ',', '.'}, StringSplitOptions.RemoveEmptyEntries);
            var dateTime = model.DateTime == DateTime.MinValue ? DateTime.Today : model.DateTime;

            foreach (var score in scores)
            {
                if (Int32.TryParse(score, out var scoreNumeric))
                {
                    player.ScoreItems.Add(new ScoreItem() { DateTime = dateTime, Player = player, Score = scoreNumeric });
                }
            }

            _playeRepository.Update(player);
        }
    }
}
