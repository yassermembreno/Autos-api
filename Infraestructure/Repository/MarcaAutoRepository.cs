using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class MarcaAutoRepository : IMarcaAutoRepository
    {
        private readonly MarcaAutoDbContext _dbContext;
        public MarcaAutoRepository(MarcaAutoDbContext _dbContext) 
        {
           this._dbContext = _dbContext;
        }
        public async Task<IEnumerable<MarcaAuto>> GetAll()
        {
            return await _dbContext.marcaAutosDb.ToListAsync<MarcaAuto>();
        }
    }
}
