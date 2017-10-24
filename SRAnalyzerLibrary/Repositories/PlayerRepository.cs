using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SRAnalyzerLibrary.Repositories
{
    public class PlayerRepository : Repository<Player>
    {
        public PlayerRepository(SrAnalyzerDbContext context) : base(context)
        {
        }

        public override IEnumerable<Player> GetAll()
        {
            return _context.Set<Player>().Include("ScoreItems");
        }
    }
}
