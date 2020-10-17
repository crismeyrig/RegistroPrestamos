using Microsoft.EntityFrameworkCore;
using RegistroPrestamos;
using RegistroPrestamos.Entidades;
using System;

namespace RegistroPrestamos.DAL
{

    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        public DbSet<Prestamos> Prestamos { get; set; }

        public DbSet<Moras> Moras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Prestamos.db");
        }
    }
}