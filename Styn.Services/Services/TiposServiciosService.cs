using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente TiposServicios
    public interface ITiposServiciosService : IGenericService<TiposServiciosDTO>
    {
    }

    public class TiposServiciosService : GenericService<TiposServicios, TiposServiciosDTO>, ITiposServiciosService
    {
        public TiposServiciosService(IGenericRepository<TiposServicios> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
