using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infraestructure.Data;
using Application.Services;
using Application.Interfaces;

namespace autos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaAutoesController : ControllerBase
    {
        private readonly IMarcaAutosService marcaAutoService;

        public MarcaAutoesController(IMarcaAutosService marcaAutoService)
        {
            this.marcaAutoService = marcaAutoService;
        }

        // GET: api/MarcaAutoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaAuto>>> GetmarcaAutosDb()
        {
            return Ok(await marcaAutoService.GetAll());
        }      
    }
}
