using ABISoft.BankApp1.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.AccountNumber).IsRequired();

            builder.Property(x => x.Balance).IsRequired();
            builder.Property(x => x.Balance).HasColumnType("decimal(18,4)");

            builder.HasOne(x => x.User).WithMany(x => x.Accounts).HasForeignKey(x => x.UserId);
        }
    }
}
