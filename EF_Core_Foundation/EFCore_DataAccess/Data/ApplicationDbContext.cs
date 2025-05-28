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
    }
}
