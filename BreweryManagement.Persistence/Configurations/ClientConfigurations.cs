using BreweryManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreweryManagement.Persistence.Configurations
{
    public class ClientConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> b)
        {
            b.HasKey(x => x.Id);
           
            b.Property(x => x.Id).ValueGeneratedNever();

       
        }
    }
}
