using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Context
{
    public class MyProjectContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MyProjectContext(DbContextOptions<MyProjectContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUserTokens> ApplicationUserTokens { get; set; }
        public DbSet<WhyUs> WhyUses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
       
        public DbSet<Subscrabe> Subscrabes { get; set; }

        public DbSet<Product> Products { get; set; }
       

        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }




        //*******    Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Varsayılan Identity yapılandırmalarını uygula
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Order>().HasKey(x => x.Id);

            modelBuilder.Entity<Basket>()
                .HasOne(x => x.Order)
                .WithOne(x => x.Basket)
                .HasForeignKey<Order>(x => x.Id);




        }

    }
}
