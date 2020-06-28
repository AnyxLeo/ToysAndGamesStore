using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGamesStore.Models
{
    public static class SeedData
    {
        public static void AddTestData(DataBaseContext context)
        {
            var list = new List<Game>
            {
                new Game { Id = 1, Name = "Barbie Developer", AgeRestriction = 12, Price = 25.99M, Company = "Mattel", Description = "Be more than a Barbie, be a Developer"  },
                new Game { Id = 2, Name = "Aironman", AgeRestriction = 4, Price =75.50M, Company = "Marvel", Description = "The best super hero" },
                new Game { Id = 3, Name = "Super Mario Kart", AgeRestriction = 18, Price =99.99M, Company = "Nintendo", Description = "Your personal driving triner"  },
                new Game { Id = 4, Name = "Mortal Combat", AgeRestriction = 18, Price =99.99M, Company = "XBox"  },
                new Game { Id = 5, Name = "Boss Bunny plush",  Price = 49.99M, Company = "Looney Tunes"  },
            };

            context.Games.AddRange(list);

            context.SaveChanges();
        }
    }
}
