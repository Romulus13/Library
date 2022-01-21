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
    public class BookInventoryItemEntityTypeConfiguration : IEntityTypeConfiguration<BookInventoryItem>
    {
        public void Configure(EntityTypeBuilder<BookInventoryItem> builder)
        {
            builder.ToTable("BookInventoryItems", b => b.IsTemporal());

            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.BookId)
                .IsRequired();
        
            builder
                .Property(b => b.Status)
                .IsRequired();

            builder
                .Property(b => b.EventDate)
                .IsRequired();

            builder.HasOne(br => br.Book)
                    .WithMany(br => br.BookInventoryItems)
                    .HasForeignKey(br => br.BookId)
                    .HasConstraintName("FK_BookInventoryItem_Book_BookId");

        }
    }
}
