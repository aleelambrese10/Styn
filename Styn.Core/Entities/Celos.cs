using Styn.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styn.Domain.Entities
{
    public class Celos : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public string RP { get; set; }
        public string Responsable { get; set; }
    }
}
