using BreweryManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreweryManagement.Persistence.Configurations
{
    public class WholesalerStockConfigurations : IEntityTypeConfiguration<WholesalerStock>
    {
        public void Configure(EntityTypeBuilder<WholesalerStock> b)
        {
            b.HasKey( "BeerId", "WholesalerId");
           
            b.Property(x => x.BeerId).ValueGeneratedNever();
            b.Property(x => x.WholesalerId).ValueGeneratedNever();

            b.HasOne(m => m.Beer)
             .WithMany(o => o.WholesalerStocks)
             .HasForeignKey(f => f.BeerId)
             .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(m => m.Wholesaler)
             .WithMany(o => o.Stocks)
             .HasForeignKey(f => f.WholesalerId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
