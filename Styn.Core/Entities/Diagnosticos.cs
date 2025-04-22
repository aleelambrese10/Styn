using Styn.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

public class Diagnostico : BaseEntity
{

    public string Grupo { get; set; }

    public string Subgrupo { get; set; }
}
