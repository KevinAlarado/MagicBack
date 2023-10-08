using Magic.Model.MagicAnalis.Mazo;
using Microsoft.EntityFrameworkCore;

namespace Magic.Context
{
    public class MagicContext : DbContext
    {
        public MagicContext(DbContextOptions<MagicContext> options) : base(options) { }

        public DbSet<Mazo> Mazo { get; set; }
        public DbSet<MazoColor> MazoColor { get; set; }

        public DbSet<MazoDeckList> MazoDeckList { get; set; }
        public DbSet<MazoEstilo> MazoEstilo { get; set; }
        public DbSet<MazoTipo> MazoTipo { get; set; }


    }
}
