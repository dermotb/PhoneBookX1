using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookX1.Models
{
    internal class PhoneBookContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Contacts;Trusted_Connection=False;";

        public DbSet<Contact> Contacts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
