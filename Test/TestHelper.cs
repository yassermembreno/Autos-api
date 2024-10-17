using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestHelper
    {
        private readonly MarcaAutoDbContext marcaAutoDbContext;

        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<MarcaAutoDbContext>();
            builder.UseInMemoryDatabase(databaseName: "MarcaAutoDbInMemory");

            var dbContextOptions = builder.Options;
            marcaAutoDbContext = new MarcaAutoDbContext(dbContextOptions);
    
            marcaAutoDbContext.Database.EnsureDeleted();
            marcaAutoDbContext.Database.EnsureCreated();
        }

        public IMarcaAutoRepository GetMarcaAutoRepository()
        {
            return new MarcaAutoRepository(marcaAutoDbContext);
        }

        public IEnumerable<MarcaAuto> GetMarcaAutosMock()
        {
            return new List<MarcaAuto>()
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
        }
    }
}
