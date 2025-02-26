using Styn.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Styn.Domain.DTOs
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direcion { get; set; }
        public string Dni { get; set; }

        public bool Active { get; set; } = true;
        public DateTime? MembresiaInicio { get; set; }
        public DateTime? MembresiaFin { get; set; }
       

    }
}
