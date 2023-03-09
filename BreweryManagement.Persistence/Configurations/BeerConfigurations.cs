using BreweryManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreweryManagement.Persistence.Configurations
{
    public class BeerConfigurations : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> b)
        {
            b.HasKey(x => x.Id);
           
            b.Property(x => x.Id).ValueGeneratedNever();

            b.Property(x => x.Name).IsRequired();
            b.Property(x => x.Name).HasMaxLength(maxLength: 200);

            b.HasMany(m => m.WholesalerStocks)
             .WithOne(o => o.Beer)
             .HasForeignKey(f => f.BeerId)
             .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
