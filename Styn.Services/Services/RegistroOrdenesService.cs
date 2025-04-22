using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente RegistroOrdenes
    public interface IRegistroOrdenesService : IGenericService<RegistroOrdenesDTO>
    {
    }

    public class RegistroOrdenesService : GenericService<RegistroOrdenes, RegistroOrdenesDTO>, IRegistroOrdenesService
    {
        public RegistroOrdenesService(IGenericRepository<RegistroOrdenes> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
