namespace Styn.Domain.Models
{
    public class AddPedidoModel
    {
        public int Id { get; set; }
        public int CarritoId { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int CodigoPostal { get; set; }
        public string Celular { get; set; }
        public decimal Total { get; set; }


    }
}
