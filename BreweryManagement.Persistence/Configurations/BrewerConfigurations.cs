using BreweryManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreweryManagement.Persistence.Configurations
{
    public class BrewerConfigurations : IEntityTypeConfiguration<Brewer>
    {
        public void Configure(EntityTypeBuilder<Brewer> b)
        {
            b.HasKey(x => x.Id);
           
            b.Property(x => x.Id).ValueGeneratedNever();

            b.Property(x => x.Name).IsRequired();
            b.Property(x => x.Name).HasMaxLength(maxLength: 200);

            b.HasMany(m => m.Beers)
           .WithOne(o => o.Brewer)
           .HasForeignKey(f => f.BrewerId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
