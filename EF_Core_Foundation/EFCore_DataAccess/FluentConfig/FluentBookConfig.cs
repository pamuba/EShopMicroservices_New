
using System.Reflection.Emit;
using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_DataAccess.FluentConfig
{
    internal class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.Property(u => u.ISBN).HasMaxLength(20).IsRequired();
            modelBuilder.HasKey(u => u.Book_Id);
            modelBuilder.HasOne(z => z.Fluent_Publisher).WithMany(z => z.Fluent_Book)
                .HasForeignKey(z => z.Publisher_Id);
            modelBuilder.Ignore(u => u.PriceRange);
        }
    }
}
