using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context: Db tabloları ile Projemizin Class'larını ilişkilendirdiğimiz class
    public class NorthwindContext : DbContext  // DbContext EntityFramework nesnesidir.
    {
        // Projemiz hangi veritabanıyla ilişkili olacak bunu belirtiğimiz metot : OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // @ koymamızın nedeni: \ c#'da başka bir anlama gelmekte. Gerçek anlamda kullanacağımız zaman @ koyar \\ koyarız.
            // optionsBuilder.UseSqlServer(@"Server=175.45.1.12"); normalde biz bir ip adresi veririz. Local Projede çalışacağımız için direkt klasör yolu vericez.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true"); // burada db bağlantı için kAdi ve Pass da girilebiliyor.             

        }
        // Hangi    <nesnemiz> Db'deki hangi tabloya denk gelecek -> DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
