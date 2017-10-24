using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace SRAnalyzerLibrary
{
    public class SrAnalyzerDbContext : DbContext
    {

        public SrAnalyzerDbContext(DbContextOptions<SrAnalyzerDbContext> options)
            : base(options) { }


        public DbSet<Player> Players { get; set; }
        public DbSet<ScoreItem> Scores { get; set; }
    }
}
