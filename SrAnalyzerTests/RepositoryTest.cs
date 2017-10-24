using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SRAnalyzerLibrary;
using SRAnalyzerLibrary.Repositories;
using Xunit;

namespace SrAnalyzerTests
{
    public class RepositoryTest : IClassFixture<DataBaseFixture>
    {
        private readonly DataBaseFixture _fixture;
        private readonly Repository<Player> _playerRepository;

        public RepositoryTest(DataBaseFixture fixture)
        {
            _fixture = fixture;
            _playerRepository = new PlayerRepository(_fixture.Db);

        }

        [Fact]
        public void AddGetTest()
        {
            var scoreItems = new List<ScoreItem>()
            {
                new ScoreItem()
                {
                    DateTime = DateTime.Now,
                    Score = 2050
                },
                new ScoreItem()
                {
                    DateTime = DateTime.Now,
                    Score = 2075
                }
            };
            var player = new Player() {Name = "Natasha", ScoreItems = scoreItems};

            var id = _playerRepository.Add(player);
            var playerFromDb = _playerRepository.Get(id);

            Assert.Equal("Natasha", playerFromDb.Name);
            Assert.Equal(id, playerFromDb.Id);
            Assert.NotEmpty(playerFromDb.ScoreItems);
            Assert.Collection(playerFromDb.ScoreItems, FirstItemCheck, SecondItemCheck);

        }

        public void FirstItemCheck(ScoreItem item)
        {
            Assert.Equal(2050, item.Score);
            Assert.Equal("Natasha", item.Player.Name);
        }

        public void SecondItemCheck(ScoreItem item)
        {
            Assert.Equal(2075, item.Score);
            Assert.Equal("Natasha", item.Player.Name);
        }

        [Fact]
        public void AddRangeGetAllTest()
        {
            var players = new List<Player>()
            {
                new Player() {Name = "Natasha"},
                new Player() {Name = "Masha"},
                new Player() {Name = "Sergei"},
                new Player() {Name = "Vova"}
            };

            var ids = _playerRepository.AddRange(players);
                Assert.All(ids, id => Assert.True(id > 0));

            var playersFromDb = _playerRepository.GetAll();

            Assert.NotEmpty(playersFromDb);

            Assert.All(playersFromDb, player =>
            {
                Assert.NotEqual(0, player.Id);
                Assert.NotEqual(string.Empty, player.Name);            
                Assert.Empty(player.ScoreItems);
            });
        }
    }

    public class DataBaseFixture : IDisposable
    {
        public SrAnalyzerDbContext Db { get; }

        public DataBaseFixture()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SrAnalyzerDbContext>();
            optionsBuilder.UseInMemoryDatabase("SrAnalyze");
            Db = new SrAnalyzerDbContext(optionsBuilder.Options);          
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
