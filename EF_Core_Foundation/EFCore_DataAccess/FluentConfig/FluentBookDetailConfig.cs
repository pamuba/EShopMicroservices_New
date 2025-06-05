using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Model.FluentConfig
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_BookDetails");
            modelBuilder.Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters").IsRequired();
            modelBuilder.HasKey(u => u.BookDetail_Id);
            modelBuilder.HasOne(u => u.Fluent_Book).WithOne(u => u.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(u => u.Book_Id);
        }
    }
}
