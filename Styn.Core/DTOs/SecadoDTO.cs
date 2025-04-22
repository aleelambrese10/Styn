using Styn.Domain.Entities.Common;
using System;

public class SecadoDTO
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string RP { get; set; }

    public string TipoSecado { get; set; }

    public string Tratamiento { get; set; }

    public string Observacion { get; set; }

    public string Responsable { get; set; }
}
