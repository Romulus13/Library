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
    public class BookEntityTypeConfiguration :  IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.ToTable("Books");
            builder.HasKey(book => book.Id);

            builder.HasIndex(book => book.SerialNumber).IsUnique();

            builder
                .Property(b => b.Title)
                .HasColumnType("nvarchar(200)")
                .IsUnicode(true)
                .IsRequired();
            builder
                .Property(b => b.ISBN)
                .HasColumnType("nvarchar(20)")
                .IsRequired();
            builder
                .Property(b => b.SerialNumber)
                .HasColumnType("nvarchar(36)")
                .IsRequired();

            builder
               .Property(b => b.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

       
        }
    }
}
