
using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Alertas
    public interface IAlertasService : IGenericService<AlertasDTO>
    {
    }

    public class AlertasService : GenericService<Alertas, AlertasDTO>, IAlertasService
    {
        public AlertasService(IGenericRepository<Alertas> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
