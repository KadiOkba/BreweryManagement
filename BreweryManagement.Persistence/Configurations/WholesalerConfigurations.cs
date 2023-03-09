using BreweryManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreweryManagement.Persistence.Configurations
{
    public class WholesalerConfigurations : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> b)
        {
            b.HasKey(x=>x.Id);
           
            b.Property(x => x.Id).ValueGeneratedNever();

            b.Property(x => x.Name).IsRequired();
            b.Property(x => x.Name).HasMaxLength(maxLength: 200);

        }
    }
}
