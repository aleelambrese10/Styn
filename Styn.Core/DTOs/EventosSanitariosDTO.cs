using Styn.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styn.Domain.Dtos
{
    public class EventosSanitariosDTO  
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }
        public string RP { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Observacion { get; set; }
        public string Responsable { get; set; }
    }
}
