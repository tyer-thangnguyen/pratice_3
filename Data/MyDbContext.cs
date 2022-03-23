using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) { }


        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FormType> FormTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e => {
                e.ToTable("Customer");
                //e.HasKey(cus => cus.Id);

                e.HasOne(e => e.Tenant)
                .WithMany(e => e.Customers)
                .HasForeignKey(e => e.TenantsId)
                .HasConstraintName("FK_tenants");

                e.HasOne(e => e.formType)
                .WithMany(e => e.Customers)
                .HasForeignKey(e => e.FormType)
                .HasConstraintName("FK_FormType");
            });

            modelBuilder.Entity<FormType>(entity => {
                entity.ToTable("FormType");
                //entity.HasKey(e => e.Code);
            });
        }
    }
}
