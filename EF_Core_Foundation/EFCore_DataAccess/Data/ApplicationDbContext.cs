using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql(
                "server=127.0.0.1;uid=root;pwd=root@39;database=ecommerce3",
                serverVersion
                );

            //optionsBuilder.UseSqlServer("")
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(u=>u.Price).HasPrecision(10,5);

            modelBuilder.Entity<Book>().HasData(
                new Book { IDBook = 1, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m },
                new Book { IDBook = 2, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m },
                new Book { IDBook = 3, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m }
            );

            var bookList = new Book[] {
                new Book { IDBook = 4, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m },
                new Book { IDBook = 5, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m },
            };
            modelBuilder.Entity<Book>().HasData(bookList);
        }
    }
}
