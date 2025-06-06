using EFCore_DataAccess.FluentConfig;
using EFCore_Model.FluentConfig;
using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore_DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMap { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            //var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            //optionsBuilder.UseMySql(
            //    "server=127.0.0.1;uid=root;pwd=root@39;database=ecommerce3",
            //    serverVersion
            //    ).LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);

            //optionsBuilder.UseSqlServer("")
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ///Fluent API//////////////////////
            ///

            //Fluent_BookDetail
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());



            modelBuilder.Entity<Book>().Property(u=>u.Price).HasPrecision(10,5);

            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });


            //modelBuilder.Entity<Book>().HasData(
            //    new Book { Book_Id = 1, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m },
            //    new Book { Book_Id = 2, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m },
            //    new Book { Book_Id = 2, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m },
            //    new Book { Book_Id = 3, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m }
            //);

            //var bookList = new Book[] {
            //    new Book { Book_Id = 4, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m },
            //    new Book { Book_Id = 5, Title = "Advtures od Tintin", ISBN = "12345", Price = 100m },
            //};
            //modelBuilder.Entity<Book>().HasData(bookList);
        }
    }
}
