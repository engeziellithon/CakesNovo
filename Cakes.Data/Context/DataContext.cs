using Cakes.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Cakes.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductsCategory { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Ordem> Ordem { get; set; }
        public DbSet<OrdemItem> OrdemItem { get; set; }
        public DbSet<CustomerAdress> CustomerAdress { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Product>(eb =>
                    {
                        eb.ToTable("Product");
                        eb.HasKey(b => b.Id);
                        eb.HasIndex(u => u.Title).IsUnique();
                        eb.Property(v => v.Title).IsRequired();
                        eb.Property(p => p.Description);
                        eb.Property(v => v.ImageUrl);
                        eb.Property(v => v.Price).IsRequired();
                        eb.Property(v => v.Active).IsRequired();
                        eb.Ignore(v => v.Notifications);
                        eb.Ignore(v => v.IsValid);
                        eb.HasOne(p => p.ProductCategory);
                    });

            modelBuilder.Entity<ProductCategory>(eb =>
            {
                eb.ToTable("ProductCategory");
                eb.HasKey(b => b.Id);
                eb.HasIndex(u => u.Name).IsUnique();
                eb.Property(v => v.Name).IsRequired();
                eb.Property(v => v.Active).IsRequired();
                eb.HasMany(p => p.Product);
                eb.Ignore(v => v.Notifications);
                eb.Ignore(v => v.IsValid);
            });

            modelBuilder.Entity<Customer>(eb =>
            {
                eb.ToTable("Customer");
                eb.HasKey(b => b.Id);
                eb.Property(v => v.Name).IsRequired();
                eb.HasIndex(u => u.Email).IsUnique();
                eb.Property(v => v.Email).IsRequired();
                eb.HasMany(p => p.CustomersAdresses);
                eb.Ignore(v => v.Notifications);
                eb.Ignore(v => v.IsValid);
            });

            modelBuilder.Entity<CustomerAdress>(eb =>
            {
                eb.ToTable("CustomerAdress");
                eb.HasKey(b => b.Id);
                eb.Property(v => v.ZipCode).IsRequired();
                eb.Property(v => v.Adress).IsRequired();
                eb.Property(v => v.City).IsRequired();
                eb.Property(v => v.Complement);
                eb.Property(v => v.District).IsRequired();
                eb.Property(v => v.Number).IsRequired();
                eb.Property(v => v.State).IsRequired();
                eb.HasOne(p => p.Customer);
                eb.Ignore(v => v.Notifications);
                eb.Ignore(v => v.IsValid);
            });

            modelBuilder.Entity<Discount>(eb =>
            {
                eb.ToTable("Discount");
                eb.HasKey(b => b.Id);
                eb.Property(v => v.Active).IsRequired();
                eb.HasIndex(u => u.Code).IsUnique();
                eb.Property(v => v.Expire).IsRequired();
                eb.Property(v => v.Amount).IsRequired();
                eb.Property(v => v.Code).IsRequired();
                eb.HasMany(p => p.Ordems);
                eb.Ignore(v => v.Notifications);
                eb.Ignore(v => v.IsValid);
            });

            modelBuilder.Entity<Ordem>(eb =>
            {
                eb.ToTable("Ordem");
                eb.HasKey(b => b.Id);
                eb.HasIndex(u => u.Number).IsUnique();
                eb.Property(v => v.Number).IsRequired();
                eb.Property(u => u.Status).HasConversion<string>();
                eb.Property(v => v.Date).IsRequired();
                eb.Property(v => v.DeliveryFee);
                eb.HasOne(p => p.Customer);
                eb.HasOne(p => p.Discount);
                eb.HasMany(s => s.OrdemItem);
                eb.Ignore(v => v.Notifications);
                eb.Ignore(v => v.IsValid);
            });

            modelBuilder.Entity<OrdemItem>(eb =>
            {
                eb.ToTable("OrdemItem");
                eb.HasKey(b => b.Id);
                eb.Property(v => v.Price).IsRequired();
                eb.Property(u => u.Quantity).IsRequired();
                eb.HasOne(p => p.Product);
                eb.HasOne(p => p.Ordem);
                eb.Ignore(v => v.Notifications);
                eb.Ignore(v => v.IsValid);
            });



        }

        //[DbFunction("unaccent")]
        //public string Unaccent()
        //{
        //    throw new NotSupportedException();
        //}
    }
}
