using Styn.Domain.Entities.Common;
using System;

public class Servicios : BaseEntity
{
    public DateTime Fecha { get; set; }

    public string RP { get; set; }

    public string TipoServicio { get; set; }

    public string Toro { get; set; }

    public string TipoSemen { get; set; } 

    public string Responsable { get; set; }
}
