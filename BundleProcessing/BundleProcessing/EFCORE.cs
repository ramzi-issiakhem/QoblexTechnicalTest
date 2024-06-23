using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{

    class BundleContext : DbContext
    {
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<FinalProduct> FinalProducts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bundle.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BundleBundle>()
                .HasKey(bb => new { bb.ParentBundleId, bb.SubBundleId });

            modelBuilder.Entity<BundleBundle>()
                .HasOne(bb => bb.ParentBundle)
                .WithMany(b => b.SubBundles)
                .HasForeignKey(bb => bb.ParentBundleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BundleBundle>()
                .HasOne(bb => bb.SubBundle)
                .WithMany()
                .HasForeignKey(bb => bb.SubBundleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

   


    


    public class Inventory
    {
        public int Id { get; set; }

        public int Amount { get; set; }


        public FinalProduct FinalProduct { get; set; }

        



    }


    public class Bundle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<FinalProduct> FinalProducts { get; } = [];

        public List<BundleFinalProduct> BundleFinalProducts { get; } = [];

        public List<BundleBundle> SubBundles { get; } = [];
    }

    public class BundleBundle
    {
        public int Id { get; set; }

        public int ParentBundleId { get; set; }
        public Bundle ParentBundle { get; set; }

        public int SubBundleId { get; set; }
        public Bundle SubBundle { get; set; }

        public int Amount { get; set; }
    }

    public class FinalProduct
    {
        public string Id { get; set; }

        public string ProductName { get; set; }

        public Inventory Inventory { get; set; }

        public int InventoryId { get; set; }

        public List<BundleFinalProduct> BundleFinalProducts { get; } = [];


    }

    public class BundleFinalProduct
    {
        public int Id { get; set; }

        public Bundle Bundle { get; set; } = null!;

        public FinalProduct FinalProduct { get; set; } = null!;

        public int Amount { get; set; }
    }
}