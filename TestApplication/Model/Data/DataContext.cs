using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication.Model.Data
{
    class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestProjectDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                new User { User_Id = 1, Login = "Login1", Pass = "password" },
                new User { User_Id = 2, Login = "Login2", Pass = "qwerty" },
                new User { User_Id = 3, Login = "Login3", Pass = "podsolnuh" },

                });
            modelBuilder.Entity<Nomenclature>().HasData(
                new Nomenclature[]
                {
                    new Nomenclature { Nomenclature_Id = 1, Name = "Nom1", Price = 10000, FromDate = DateTime.Now, ToDate = DateTime.Now },
                    new Nomenclature { Nomenclature_Id = 2, Name = "Nom2", Price = 20000, FromDate = DateTime.Now, ToDate = DateTime.Now },
                    new Nomenclature { Nomenclature_Id = 3, Name = "Nom3", Price = 30000, FromDate = DateTime.Now, ToDate = DateTime.Now },
                });
        }
    }
}

