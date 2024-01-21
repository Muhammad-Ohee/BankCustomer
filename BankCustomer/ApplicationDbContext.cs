using BankCustomer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCustomer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankCustomer> BankCustomers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankCustomer>()
               .HasKey(bc => new { bc.BankId, bc.CustomerId });

            modelBuilder.Entity<BankCustomer>()
                .HasOne(bc => bc.Bank)
                .WithMany(b => b.Customers)
                .HasForeignKey(bc => bc.BankId);

            modelBuilder.Entity<BankCustomer>()
                .HasOne(bc => bc.Customer)
                .WithMany(c => c.Banks)
                .HasForeignKey(bc => bc.CustomerId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost; Username = postgres; Password = 4444; Database = bank_customer");
        }
    }
}
