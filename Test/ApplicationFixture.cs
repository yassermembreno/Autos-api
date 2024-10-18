using Application.Interfaces;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ApplicationFixture
    {
        public readonly Mock<IMarcaAutoRepository> marcaAutoRepository;
        public readonly Mock<IMarcaAutosService> marcaAutoService;

        public ApplicationFixture() 
        {
           marcaAutoRepository = new Mock<IMarcaAutoRepository>();
           marcaAutoService = new Mock<IMarcaAutosService>();

        }
    }
}
