using Stefanini.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Stefanini.Data
{
    public class StefaniniContext : DbContext
    {
        public StefaniniContext() : base("stefanini") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<UserSys>()
                .HasRequired<UserRole>(u => u.userRole);               

            modelBuilder.Entity<Customer>()
                .HasRequired<Gender>(c => c.gender)
                .WithMany()
                .Map(m => m.MapKey("GenderId"));           

            modelBuilder.Entity<Customer>()
                .HasRequired<City>(c => c.city)
                .WithMany()
                .Map(m => m.MapKey("CityId"));

            modelBuilder.Entity<Customer>()
                .HasRequired<Classification>(c => c.classification);                

            modelBuilder.Entity<Customer>()
                .HasRequired<UserSys>(c => c.userSys)
                .WithMany()
                .Map(m => m.MapKey("UserId"));           

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<City> City { get; set; }
        public DbSet<Classification> Classification { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserSys> UserSys { get; set; }
    }    
}