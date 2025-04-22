using Styn.Domain.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class FichaAnimal : BaseEntity
{    
    public string RP { get; set; }

    public string Origen { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string Raza { get; set; }

    public string Madre { get; set; }

    public string Padre { get; set; }
}
