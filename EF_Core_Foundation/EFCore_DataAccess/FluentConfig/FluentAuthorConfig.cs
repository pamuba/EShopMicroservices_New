using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_DataAccess.FluentConfig
{
    internal class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            modelBuilder.Property(u => u.FirstName)
                .HasMaxLength(50).IsRequired();
            modelBuilder.Property(u => u.LastName).IsRequired();
            modelBuilder.HasKey(u => u.Author_Id);
            modelBuilder.Ignore(u => u.FullName);

        }
    }
}
