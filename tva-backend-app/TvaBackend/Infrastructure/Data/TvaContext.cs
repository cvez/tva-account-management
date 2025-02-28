using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; // Add this using directive
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TvaContext : DbContext
    {
        public TvaContext(DbContextOptions<TvaContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");

            modelBuilder.Entity<Transaction>(ConfigureTransaction);
            modelBuilder.Entity<Account>(ConfigureAccount);
        }

        private void ConfigureTransaction(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.Code).HasColumnName("code");
            builder.Property(t => t.AccountCode).HasColumnName("account_code");
            builder.Property(t => t.TransactionDate).HasColumnName("transaction_date").HasColumnType("datetime2(7)");
            builder.Property(t => t.CaptureDate).HasColumnName("capture_date").HasColumnType("datetime2(7)");
            builder.Property(t => t.Amount).HasColumnName("amount").HasColumnType("decimal(18, 2)");
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("text");
        }

        private void ConfigureAccount(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.Code).HasColumnName("code");
            builder.Property(a => a.AccountNumber).HasColumnName("account_number").IsRequired();
            builder.Property(a => a.OutstandingBalance).HasColumnName("outstanding_balance").HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(a => a.PersonCode).HasColumnName("person_code").IsRequired();
            builder.HasOne(a => a.Person).WithMany(p => p.Accounts).HasForeignKey(a => a.PersonCode);
        }
    }
}