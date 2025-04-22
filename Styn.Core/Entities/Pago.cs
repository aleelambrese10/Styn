using Styn.Domain.DTOs;
using Styn.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styn.Domain.Entities
{
    public class Pago : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime FechaPago { get; set; }
        public string? Estado { get; set; } 
        public decimal? Monto { get; set; }
    }
}
