using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class MarcaAutoDbContext : DbContext
    {
        public MarcaAutoDbContext(DbContextOptions<MarcaAutoDbContext> options):base(options) { }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var marcaAutos = new List<MarcaAuto>()
            {
                new MarcaAuto()
                {
                    marca = "Subaru", pais = "Japon", url = "https://www.worldsubaru.com/"
                },
                new MarcaAuto()
                {
                    marca = "BMW", pais = "Alemania", url = "https://www.bmw.com/en/index.html"
                },
                new MarcaAuto()
                {
                    marca = "Ford", pais = "Estados Unidos", url = "https://www.ford.com/"
                }
            };

            modelBuilder.Entity<MarcaAuto>().HasData(marcaAutos);
        }

        public DbSet<MarcaAuto> marcaAutosDb { get; set; }
    }
}
