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
    public class BookRentEntityTypeConfiguration :  IEntityTypeConfiguration<BookRent>
    {
        public void Configure(EntityTypeBuilder<BookRent> builder)
        {
            builder.ToTable("BookRents", b => b.IsTemporal());

            builder.HasKey(bookRent => bookRent.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Borrowed)
                .IsRequired();

            builder
                .Property(b => b.DueDate)
                .IsRequired();

            builder
              .Property(b => b.UserId)
              .IsRequired();


            builder
              .Property(b => b.BookId)
              .IsRequired();

            builder.HasOne(br => br.Book)
                    .WithMany(br => br.BookRents)
                    .HasForeignKey(br => br.BookId)
                    .HasConstraintName("FK_BookRent_Book_BookId").OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(br => br.User)
                    .WithMany(br => br.BookRents)
                    .HasForeignKey(br => br.UserId)
                    .HasConstraintName("FK_BookRent_User_UserId").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
