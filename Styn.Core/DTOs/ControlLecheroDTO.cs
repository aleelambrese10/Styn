using Styn.Domain.Entities.Common;
using System;

public class ControlLecheroDTO  
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string RP { get; set; }

    public int NumeroOrdeñe { get; set; }

    public double Litros { get; set; }

    public double PorcentajeGrasa { get; set; }

    public double PorcentajeProteinas { get; set; }

    public long RCS { get; set; }

    public string Responsable { get; set; }
}
