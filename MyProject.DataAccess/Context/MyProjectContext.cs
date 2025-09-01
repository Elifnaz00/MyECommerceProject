using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
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
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }   
        public DbSet<Subscrabe> Subscrabes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        //*******    Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Varsayılan Identity yapılandırmalarını uygula
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Basket>()
                .HasMany(x => x.BasketItems)
                .WithOne(x => x.Basket)
                .HasForeignKey(x => x.BasketId);

            modelBuilder.Entity<AppUser>()
                .HasMany(x => x.Baskets)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.AppUserId);

            modelBuilder.Entity<BasketItem>()
                .HasOne(x => x.Product)
                .WithMany(x => x.BasketItems)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Basket>()
                .HasOne(x => x.Order)
                .WithOne(x => x.Basket)
                .HasForeignKey<Order>(x => x.BasketId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.OrderStatus)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.OrderStatusId);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.PaymentStatus)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.PaymentStatusId);


            modelBuilder.Entity<Order>()
    .Property(o => o.PaymentStatusId)
    .HasDefaultValue(Guid.Parse("11111111-1111-1111-1111-111111111111")); 


            modelBuilder.Entity<Order>()
                .Property(o => o.OrderStatusId)
                .HasDefaultValue(Guid.Parse("22222222-2222-2222-2222-222222222222")); 


            modelBuilder.Entity<PaymentStatus>().HasData(
          new PaymentStatus { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Pending" }, //Beklemede
          new PaymentStatus { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Paid" },//ödendi
          new PaymentStatus { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Refunded" }//geri ödeme yapıldı
      );

            modelBuilder.Entity<OrderStatus>().HasData(
          new OrderStatus { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Await Payment" },//Ödeme Bekleniyor
          new OrderStatus { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Processing" }, //İşleniyor
          new OrderStatus { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Shipped" }, //Kargolandı
          new OrderStatus { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "Delivered" }, //Teslim Edildi
          new OrderStatus { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "Cancelled" }//İptal Edildi
      );
        }

    }
}
