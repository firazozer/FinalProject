using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : Context nesnesi Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Bu metot sayesınde hangı verıtabanı ıle ılıskılısın onu belırlıeyecek metot
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\projectsv13;Database=Northwind;Trusted_Connection=true");//sql server bağlantısı
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Custormers { get; set; }

        public DbSet<Order> Orders { get; set; }


    }
}
