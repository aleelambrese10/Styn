using Styn.Domain.Entities.Common;
using System;

public class Descartes : BaseEntity
{
    public DateTime Fecha { get; set; }

    public string RP { get; set; }

    public string TipoDescarte { get; set; }

    public string Observacion { get; set; }

    public string Responsable { get; set; }
}
