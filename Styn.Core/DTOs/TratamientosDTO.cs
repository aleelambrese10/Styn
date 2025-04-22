using Styn.Domain.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

public class TratamientoDTO 
{
    public int Id { get; set; }
    public string Tipo { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public int Dias { get; set; }
}
