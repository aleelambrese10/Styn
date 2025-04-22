using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente TipoAlerta
    public interface ITipoAlertaService : IGenericService<TipoAlertaDTO>
    {
    }

    public class TipoAlertaService : GenericService<TipoAlerta, TipoAlertaDTO>, ITipoAlertaService
    {
        public TipoAlertaService(IGenericRepository<TipoAlerta> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
