using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MarcaAutoService : IMarcaAutosService
    {
        private IMarcaAutoRepository _repository;

        public MarcaAutoService(IMarcaAutoRepository _repository) 
        { 
            this._repository = _repository;
        }

        public async Task<IEnumerable<MarcaAuto>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
