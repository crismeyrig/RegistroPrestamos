using Microsoft.EntityFrameworkCore;
using RegistroPrestamos;
using RegistroPrestamos.Entidades;

public class Contexto:DbContext
{
    public DbSet <Prestamos> Prestamos {get; set;}
    public DbSet <Personas> Personas{get; set;}
     
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=Prestamos.db");
        }

}