using Styn.Domain.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

public class Colaboradores : BaseEntity
{

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string DNI { get; set; }

    public DateTime FechaAlta { get; set; }

    public string Rol { get; set; }
}
