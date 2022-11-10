using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChessPairer.Models;

namespace ChessPairer.Data
{
    public class ChessPairerContext : DbContext
    {
        public ChessPairerContext (DbContextOptions<ChessPairerContext> options)
            : base(options)
        {
        }

        public DbSet<ChessPairer.Models.Tournament> Tournament { get; set; } = default!;

        public DbSet<ChessPairer.Models.Player> Player { get; set; }

        public DbSet<ChessPairer.Models.PlayerGroup> PlayerGroup { get; set; }

        public DbSet<ChessPairer.Models.Game> Game { get; set; }

        public DbSet<ChessPairer.Models.Round> Round { get; set; }

       
    }
}
