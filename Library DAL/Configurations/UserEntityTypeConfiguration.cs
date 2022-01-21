using Library_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Configurations
{
    public class UserEntityTypeConfiguration :  IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(user => user.Id);

            builder
                .Property(b => b.FirstName)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
            builder
                .Property(b => b.LastName)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
            builder
                .Property(b => b.BirthDate)
                .IsRequired(false);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasMany(usr => usr.UserContacts)
                    .WithOne(usr => usr.User)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
