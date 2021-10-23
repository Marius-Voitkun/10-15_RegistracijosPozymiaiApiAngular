using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistracijosPozymiaiWebApi.Models;

namespace RegistracijosPozymiaiWebApi.EntityConfigurations
{
    public class DropDownOptionConfiguration : IEntityTypeConfiguration<DropDownOption>
    {
        public void Configure(EntityTypeBuilder<DropDownOption> builder)
        {
            builder.Property(o => o.Text)
                .IsRequired();
        }
    }
}
