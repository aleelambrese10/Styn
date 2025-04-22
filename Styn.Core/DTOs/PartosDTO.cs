using Styn.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class PartosDTO
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string RP { get; set; } 

    public string TipoDeParto { get; set; }

    public int CantidadDeCrias { get; set; }

    public string Observacion { get; set; }

    public string Responsable { get; set; }
    public int Crias { get; set; }

    
}
