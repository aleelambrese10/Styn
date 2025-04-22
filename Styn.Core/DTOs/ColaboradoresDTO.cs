using Styn.Domain.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

public class ColaboradoresDTO
{

    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string DNI { get; set; }


    public DateTime FechaAlta { get; set; }

    public string Rol { get; set; }
}
