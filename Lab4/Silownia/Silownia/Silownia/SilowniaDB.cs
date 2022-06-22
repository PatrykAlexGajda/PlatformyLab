using Microsoft.EntityFrameworkCore;

namespace Silownia
{
    public class SilowniaContext : DbContext
    {
        public SilowniaContext(DbContextOptions<SilowniaContext> options) : base(options)
        {

        }
        public SilowniaContext()
        {
                
        }
        public DbSet<global::Silownia.Komentarz> Komentarz { get; set; }

        public DbSet<global::Silownia.Post> Post { get; set; }

    }
}
