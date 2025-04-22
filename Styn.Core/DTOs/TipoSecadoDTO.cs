using Styn.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styn.Domain.Dtos
{
    public class TipoSecadoDTO  
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
