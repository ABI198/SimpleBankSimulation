using ABISoft.BankApp1.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Firstname).IsRequired();
            builder.Property(x => x.Firstname).HasMaxLength(100);

            builder.Property(x => x.Lastname).IsRequired();
            builder.Property(x => x.Lastname).HasMaxLength(100);

           //builder.HasMany(x => x.Accounts).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
