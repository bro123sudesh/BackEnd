using ApiProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                        .HasKey(c => c.Id);
            modelBuilder.Entity<Category>()
                        .Property(c => c.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>()
                        .Property(c => c.Name)
                        .IsRequired()
                        .HasMaxLength(30);
            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Products)
                        .WithOne(c => c.Category)
                        .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Product>()
                        .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                        .Property(p => p.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
                        .Property(p => p.Name)
                        .IsRequired()
                        .HasMaxLength(50);
            modelBuilder.Entity<Product>()
                        .Property(p => p.QuantityInPackage)
                        .IsRequired();
            modelBuilder.Entity<Product>()
                        .Property(p => p.UnitOfMeasurement)
                        .IsRequired();
            
            modelBuilder.Entity<UserRole>()
                        .HasKey(ur => new { ur.UserId, ur.RoleId });
                       

        }
    }
}
