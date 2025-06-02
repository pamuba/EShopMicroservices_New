using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;

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

            ///Fluent API//////////////////////
            ///

            //Fluent_BookDetail
            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters)
                .HasColumnName("NoOfChapters").IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(u => u.Fluent_Book).WithOne(u => u.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(u=>u.Book_Id);

            //Fluent_Book
            modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Fluent_Book>().HasKey(u => u.Book_Id);
            modelBuilder.Entity<Fluent_Book>().HasOne(z => z.Fluent_Publisher).WithMany(z => z.Fluent_Book)
                .HasForeignKey(z=>z.Publisher_Id);
            modelBuilder.Entity<Fluent_Book>().Ignore(u => u.PriceRange);

            //Fluent_Author
            modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName)
                .HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().HasKey(u => u.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Ignore(u => u.FullName);

            //Fluent_Pulisher
            modelBuilder.Entity<Fluent_Publisher>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<Fluent_Publisher>().HasKey(u => u.Publisher_Id);



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
