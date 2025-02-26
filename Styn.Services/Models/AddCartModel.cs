namespace Styn.Domain.Models
{
    public class AddCartModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int InsumoId { get; set; }
        public int Cantidad { get; set; }

    }
}
