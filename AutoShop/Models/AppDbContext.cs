using AutoShop.Models;
using System;
using System.Data.Entity;
using AutoShop.Domain.Entities;

namespace AutoShop.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaulConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DetailItem> DetailItems { get; set; }
        public DbSet<BrandItem> BrandItems { get; set; }
        public DbSet<TypeItem> TypeItems { get; set; }
        public DbSet<CarItem> CarItems { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailItem>().HasMany(c => c.CarItems)
                                            .WithMany(d => d.DetailItems)
                                            .Map(t => t.MapLeftKey("DetailItemId")
                                            .MapRightKey("CarItemId")
                                            .ToTable("DetailCar"));

            base.OnModelCreating(modelBuilder);
        }

        public class UserDbInitializer : DropCreateDatabaseAlways<AppDbContext>
        {
            protected override void Seed(AppDbContext db)
            {
                db.Roles.Add(new Role { Id = new Guid("1462940b-7b7b-4ae4-8c05-abfc14b13905"), Name = "admin" });
                db.Roles.Add(new Role { Id = new Guid("77c9ca9a-7c63-407e-98a5-3d6c2059fb4d"), Name = "user" });
                db.Users.Add(new User
                {
                    Id = new Guid("7359e6a6-3714-4b43-a76a-a69507532630"),
                    Email = "dani666dani@mail.ru",
                    Password = "566589",
                    RoleId = new Guid("1462940b-7b7b-4ae4-8c05-abfc14b13905")
                });
                base.Seed(db);
            }
        }
    }
}
