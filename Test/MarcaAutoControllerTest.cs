using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MarcaAutoControllerTest
    {
       
        [Fact]
        public async Task GetAllMarcaAutoController()
        {
            //Arrange
            var applicationFixture = new ApplicationFixture();
            await using var _factory = new ApplicationFactoryTest(applicationFixture);

            using var client = _factory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "api/MarcaAutos");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Act
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
