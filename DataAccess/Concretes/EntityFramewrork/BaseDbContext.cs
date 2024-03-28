using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramewrork
{
    //Veritabanını temsil eden dosya
    public class BaseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //Db ile çalışan metot
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KUBRA;Database=Tobeto4A2;Integrated Security=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        //Model Özellikleri ile çalışan metot
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasOne(i => i.Category);
            modelBuilder.Entity<Product>().Property(i => i.Name).HasColumnName("Name").HasMaxLength(50);

            //Seed Data => CodeFirst'de çok kullanılır.Veritabanını oluştururken kullanabileceğimiz test verilerini otomatik eklemek demektir.Genellikle development ortamındaki db için kullanılır.
            //Identify için parametre tanımlayıp daha sonra soluna ++ yazarsak kendi kendine artar.

            Category category = new Category(1, "Giyim");
            Category category1 = new Category(2, "elektronik");
            Product product = new Product(1, "Kazak", 500, 50, 1);

            modelBuilder.Entity<Category>().HasData(category, category1);
            modelBuilder.Entity<Product>().HasData(product);
            base.OnModelCreating(modelBuilder);
        }


    }
}
