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
    public class MarcaAutoServicesTest
    {
        private TestHelper helper;
        private IMarcaAutoRepository repository;
        private IMarcaAutosService marcaAutosService;
        public MarcaAutoServicesTest() 
        {
            //Arrange
            helper = new TestHelper();
            repository = helper.GetMarcaAutoRepository();
            marcaAutosService = new MarcaAutoService(repository);
        }


        [Fact]
        public async Task GetAllAsync()
        {        

            var marcaAutos = helper.GetMarcaAutosMock();

            foreach (MarcaAuto marcaAuto in marcaAutos)
            {
                repository.Create(marcaAuto).GetAwaiter();
            }

            //ACt
            var result = await marcaAutosService.GetAll();
            //Assert
            Assert.True(result.ToList().Count > 0);           
        }
      
    }
}
