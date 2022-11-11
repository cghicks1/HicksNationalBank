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
        public virtual DbSet<HicksNationalAccountType> HicksNationalAccountTypes { get; set; }

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

            modelBuilder.Entity<HicksNationalAccountOwner>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.HicksNationalAccountOwners)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_AccountOwner_Account");
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
