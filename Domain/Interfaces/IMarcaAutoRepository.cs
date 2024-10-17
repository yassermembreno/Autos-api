using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMarcaAutoRepository
    {
        Task<MarcaAuto> Create(MarcaAuto marcaAuto);
        Task<IEnumerable<MarcaAuto>> GetAll();
    }
}
