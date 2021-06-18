using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RasorPagesCustomers.Data.Models
{
    public partial class CustomersContext : DbContext
    {
        public CustomersContext()
        {
        }

        public CustomersContext(DbContextOptions<CustomersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(20);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.File).HasMaxLength(255);

                entity.Property(e => e.Prepayment).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_ContractsCustomers");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Account)
                    .HasMaxLength(39)
                    .HasColumnName("account");

                entity.Property(e => e.Account1)
                    .HasMaxLength(28)
                    .HasColumnName("account1");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .HasColumnName("fax");

                entity.Property(e => e.File)
                    .HasMaxLength(255)
                    .HasColumnName("file");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .HasColumnName("mail");

                entity.Property(e => e.NameCompany)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Region)
                    .HasMaxLength(20)
                    .HasColumnName("region");

                entity.Property(e => e.Unp)
                    .HasMaxLength(10)
                    .HasColumnName("UNP");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(10);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Value).HasColumnType("decimal(15, 2)");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.ToTable("Income");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Value).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_IncomeCustomers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
