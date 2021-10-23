using Microsoft.EntityFrameworkCore;
using RegistracijosPozymiaiWebApi.EntityConfigurations;
using RegistracijosPozymiaiWebApi.Models;

namespace RegistracijosPozymiaiWebApi.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Feature> Features { get; set; }
        public DbSet<DropDownOption> DropDownOptions { get; set; }
        public DbSet<SelectedValue> SelectedValues { get; set; }

        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new DropDownOptionConfiguration());
            modelBuilder.ApplyConfiguration(new SelectedValueConfiguration());
        }
    }
}
