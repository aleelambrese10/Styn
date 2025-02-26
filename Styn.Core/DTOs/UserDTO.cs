namespace Styn.Domain.DTOs
{
    public class UserDTO
    {

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direcion { get; set; }
        public string Dni { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; } = true;

    }
}
