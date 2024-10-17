using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MarcaAutoTest
    {
        private TestHelper helper;
        private IMarcaAutoRepository repository;
        private IMarcaAutosService marcaAutosService;
        public MarcaAutoTest() 
        {
            helper = new TestHelper();
            repository = helper.GetMarcaAutoRepository();
            marcaAutosService = new MarcaAutoService(repository);

            var marcaAutos = helper.GetMarcaAutosMock();

            foreach (MarcaAuto marcaAuto in marcaAutos)
            {
                repository.Create(marcaAuto).GetAwaiter();
            }
        }


        [Fact]
        public async Task RepositoryGetAllAsync()
        {          

            var result = repository.GetAll().GetAwaiter().GetResult();

            Assert.True(result.ToList().Count > 0);
        }

        [Fact]
        public async Task ServiceGetAllAsync()
        {

            var result =  marcaAutosService.GetAll().GetAwaiter().GetResult();

            Assert.True(result.ToList().Count > 0);

        }
    }
}
