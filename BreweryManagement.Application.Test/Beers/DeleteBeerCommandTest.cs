using BreweryManagement.Application.Beers.Commands.Delete;
using BreweryManagement.Application.Exceptions;
using BreweryManagement.Domain;
using BreweryManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryManagement.Application.Test.Beers
{
    public class DeleteBeerCommandTest
    {
        private readonly BreweryDb db;
        public DeleteBeerCommandTest()
        {
            var options = new DbContextOptionsBuilder<BreweryDb>()
                         .UseInMemoryDatabase(databaseName: "MyDatabase")
                         .Options;
            db = new BreweryDb(options);
            db.Database.EnsureCreated();
        }
        [Fact]
        public async Task DeleteBeerCommand_ExistingBeer_RemovesFromDatabase()
        {
            // Arrange
            var beerId = Guid.NewGuid();
            var beer = new Beer { Id = beerId, BrewerId = Guid.NewGuid(), Name = "beer" };
            db.Beers.Add(beer);
            db.SaveChanges();

            var command = new DeleteBeerCommand { Id = beerId };
            var handler = new DeleteBeerCommandHandler(db);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            db.Beers.Any(x => x.Id == beerId).ShouldBe(false);
        }

        [Fact]
        public async Task DeleteBeerCommand_NonExistingBeer_ThrowsNotFoundException()
        {
            // Arrange
            var beer = new Beer { Id = Guid.NewGuid(), BrewerId = Guid.NewGuid(), Name = "beer" };

            var command = new DeleteBeerCommand { Id = Guid.NewGuid() };
            var handler = new DeleteBeerCommandHandler(db);

            // Act & Assert
            Should.Throw<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

        }
    }
}
