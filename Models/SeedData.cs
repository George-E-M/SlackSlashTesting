using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreboardsAPI.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScoreboardsContext(
                serviceProvider.GetRequiredService<DbContextOptions<ScoreboardsContext>>()))
            {
                // Look for any movies.
                if (context.ScoreboardsItems.Count() > 0)
                {
                    return;   // DB has been seeded
                }

                context.ScoreboardsItems.AddRange(
                    new ScoreboardsItem
                    {
                        Email = "george@email.com",
                        Name = "George",
                        Rank = "1",
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
