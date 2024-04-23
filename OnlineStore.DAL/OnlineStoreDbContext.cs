using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Context.EntitiesConfiguration;
using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext()
        {
            Database.EnsureCreated();
        }
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
        : base(options)
        {

        }
        public virtual DbSet<Category> Categorys => Set<Category>();
        public virtual DbSet<Order> Orders => Set<Order>();
        public virtual DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public virtual DbSet<Product> Products => Set<Product>();
        public virtual DbSet<User> Users => Set<User>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
