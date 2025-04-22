using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Servicios
    public interface IServiciosService : IGenericService<ServiciosDTO>
    {
    }

    public class ServiciosService : GenericService<Servicios, ServiciosDTO>, IServiciosService
    {
        public ServiciosService(IGenericRepository<Servicios> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
