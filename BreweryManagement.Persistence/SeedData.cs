using BreweryManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace BreweryManagement.Persistence
{
    public static class SeedData
    {
        public static void seed(this BreweryDb db)
        {
            db!.Database.Migrate();
            db.Database.EnsureCreated();
            if (!db.Beers.Any()) db.AddData();
        }

        private static void AddData(this BreweryDb db)
        {
            var brewerId = Guid.NewGuid();
            db.Brewers.Add(new Brewer
            {
                Id = brewerId,
                Name = "Abbaye de Leffe"
            });

            var leffeBlondeId = Guid.NewGuid();
            db.Beers.AddRange(new Beer[]
            {
                    new Beer
                    {
                        Id = leffeBlondeId,
                        BrewerId = brewerId,
                        Name = "Leffe Blonde",
                        AlcoholContent = 6.6m,
                        Price= 2.2m,
                        Quantity= 200,
                    },
                    new Beer
                    {
                        Id = Guid.NewGuid(),
                        BrewerId = brewerId,
                        Name = "Leffe Brown",
                        AlcoholContent = 1.6m,
                        Price= 2.5m,
                        Quantity= 200,
                    }
            });

            var wholesalerId = Guid.NewGuid();
            db.Wholesalers.Add(new Wholesaler
            {
                Id = wholesalerId,
                Name = "GeneDrinks"
            });

            db.WholesalerStocks.Add(new WholesalerStock
            {
                BeerId = leffeBlondeId,
                WholesalerId = wholesalerId,
                Quantity = 10,
            });

            db.SaveChanges();
        }
    }
}
