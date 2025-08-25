using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Microsoft.EntityFrameworkCore;
namespace Bank.Infrastructure.Data
{
    partial class BankDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Persona
            var personEntity = modelBuilder.Entity<Person>();
            personEntity.Property(c => c.PersonId).ValueGeneratedOnAdd();
            personEntity.HasKey(c => c.PersonId);
            #endregion

            #region Client
            var clientEntity = modelBuilder.Entity<Client>();
            clientEntity.Property(c => c.ClientId).ValueGeneratedOnAdd();
            clientEntity.HasKey(c => c.ClientId);
            clientEntity.HasOne(x => x.Person).WithOne().HasForeignKey<Client>(p => p.PersonId);
            #endregion Client

            #region Account
            var accountEntity = modelBuilder.Entity<Account>();
            accountEntity.Property(c => c.AccountId).ValueGeneratedOnAdd();
            accountEntity.HasKey(c => c.AccountId);
            accountEntity.HasOne(x => x.Client).WithMany(x => x.Accounts).HasForeignKey(p => p.ClientId).HasPrincipalKey(p => p.ClientId);
            accountEntity.HasOne(x => x.AccountType).WithMany().HasForeignKey(p => p.AccountTypeId);
            accountEntity.HasOne(x => x.StatusAccount).WithMany().HasForeignKey(p => p.StatusAccountId);
            #endregion Account

            #region Account
            var accountTypeEntity = modelBuilder.Entity<AccountType>();
            accountTypeEntity.Property(c => c.AccountTypeId).ValueGeneratedOnAdd();
            accountTypeEntity.HasKey(c => c.AccountTypeId);
            #endregion Account

            #region StatusAccount
            var statusAccountEntity = modelBuilder.Entity<StatusAccount>();
            statusAccountEntity.Property(c => c.StatusAccountId).ValueGeneratedOnAdd();
            statusAccountEntity.HasKey(c => c.StatusAccountId);
            #endregion Account


            #region Transaction
            var transactionEntity = modelBuilder.Entity<Transaction>();
            transactionEntity.Property(c => c.TransactionId).ValueGeneratedOnAdd();
            transactionEntity.HasKey(c => c.TransactionId);
            transactionEntity.HasOne(x => x.Account).WithMany(x => x.Transactions).HasForeignKey(p => p.AccountId).HasPrincipalKey(x => x.AccountId);
            #endregion Transaction
        }
    }
}