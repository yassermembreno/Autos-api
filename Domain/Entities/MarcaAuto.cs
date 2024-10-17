using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MarcaAuto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string marca { get; set; }
        public required string pais  { get; set; }
        public string? url { get; set; }
    }
}
