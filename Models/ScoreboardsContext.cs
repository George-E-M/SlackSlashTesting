using Microsoft.EntityFrameworkCore;

namespace ScoreboardsAPI.Models
{
    public class ScoreboardsContext : DbContext
    {
        public ScoreboardsContext(DbContextOptions<ScoreboardsContext> options)
            : base(options)
        {
        }

        public DbSet<ScoreboardsItem> ScoreboardsItems { get; set; }
    }
}
