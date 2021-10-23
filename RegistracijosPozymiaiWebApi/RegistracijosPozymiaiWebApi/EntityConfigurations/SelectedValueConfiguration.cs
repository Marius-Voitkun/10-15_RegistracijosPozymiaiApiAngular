using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistracijosPozymiaiWebApi.Models;

namespace RegistracijosPozymiaiWebApi.EntityConfigurations
{
    public class SelectedValueConfiguration : IEntityTypeConfiguration<SelectedValue>
    {
        public void Configure(EntityTypeBuilder<SelectedValue> builder)
        {
            builder.HasKey(v => new { v.FormId, v.FeatureId });

            builder.Property(v => v.DropDownOptionId)
                .IsRequired();

            builder.HasOne(v => v.Feature)
                .WithMany()
                .HasForeignKey(v => v.FeatureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.DropDownOption)
                .WithMany()
                .HasForeignKey(v => v.DropDownOptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
