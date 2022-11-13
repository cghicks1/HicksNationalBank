using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Account.Model.Entities;

#nullable disable

namespace Account.Model
{
    public partial class AccountDbContext : DbContext
    {
        public AccountDbContext()
        {
        }

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HicksNationalAccount> HicksNationalAccounts { get; set; }
        public virtual DbSet<HicksNationalAccountOwner> HicksNationalAccountOwners { get; set; }
        public virtual DbSet<HicksNationalAccountOwnerLinkage> HicksNationalAccountOwnerLinkages { get; set; }
        public virtual DbSet<HicksNationalAccountType> HicksNationalAccountTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=HicksNational; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HicksNationalAccount>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.ModifiedOn).HasPrecision(2);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.HicksNationalAccounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .HasConstraintName("FK_Account_AccountType");
            });

            modelBuilder.Entity<HicksNationalAccountOwnerLinkage>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.HicksNationalAccountOwnerLinkages)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Account_Linkage");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.HicksNationalAccountOwnerLinkages)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Owner_Linkage");
            });

            modelBuilder.Entity<HicksNationalAccountType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
