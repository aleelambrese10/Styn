using Styn.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

public class Lotes : BaseEntity
{

    public string Nombre { get; set; }

    public string Descripcion { get; set; }
}
