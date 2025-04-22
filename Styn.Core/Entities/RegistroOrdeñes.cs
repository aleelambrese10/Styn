using Styn.Domain.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

public class RegistroOrdenes : BaseEntity
{

    public DateTime Fecha { get; set; }

    public string Lote { get; set; }

    public int NumeroOrdeñe { get; set; }

    public int CantidadVacas { get; set; }

    public double LitrosGuachera { get; set; }

    public double LitrosNoAptos { get; set; }

    public string Responsable { get; set; }


}
