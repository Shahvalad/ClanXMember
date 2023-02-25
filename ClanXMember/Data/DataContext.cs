using Microsoft.EntityFrameworkCore;

namespace ClanXMember.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Clan> Clans { get; set; }
    }
}
