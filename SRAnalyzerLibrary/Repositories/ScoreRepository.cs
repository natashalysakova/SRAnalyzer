using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SRAnalyzerLibrary.Repositories
{
    public class ScoreRepository : Repository<ScoreItem>
    {
        public ScoreRepository(SrAnalyzerDbContext context) : base(context)
        {
        }

        public override IEnumerable<ScoreItem> GetAll()
        {
            return _context.Set<ScoreItem>().Include("Player");
        }
    }
}