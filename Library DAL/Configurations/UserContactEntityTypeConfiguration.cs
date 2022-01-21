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
    public class UserContactEntityTypeConfiguration : IEntityTypeConfiguration<UserContact>
    {
        public void Configure(EntityTypeBuilder<UserContact> builder)
        {
            builder.ToTable("UserContacts");

            builder.HasKey(userContact => userContact.Id);

            builder
                .Property(b => b.UserId)
                .HasColumnType("INT")
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(b => b.Type)
                .HasColumnType("TINYINT")
                .IsRequired();

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(br => br.User)
                  .WithMany(br => br.UserContacts)
                  .HasForeignKey(br => br.UserId)
                  .HasConstraintName("FK_UserContact_User_UserId").OnDelete(DeleteBehavior.Cascade);
                  
        }
    }
}
