using Styn.Domain.Entities.Common;
using System;

public class Prenez : BaseEntity
{
    public DateTime Fecha { get; set; }

    public string RP { get; set; }

    public string Metodo { get; set; }

    public DateTime FPP { get; set; } 

    public string Tratamiento { get; set; }

    public string Observacion { get; set; }

    public string Responsable { get; set; }
}
