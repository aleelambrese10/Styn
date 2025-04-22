using Styn.Domain.Entities.Common;
using System;

public class AlertasDTO 
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }

    public string RpOLote { get; set; }

    public string TipoAlerta { get; set; }

    public string Observacion { get; set; }

    public int DuracionAlerta { get; set; } 

    public string Responsable { get; set; }
}
