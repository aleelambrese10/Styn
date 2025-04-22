using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Secado
    public interface ISecadoService : IGenericService<SecadoDTO>
    {
    }

    public class SecadoService : GenericService<Secado, SecadoDTO>, ISecadoService
    {
        public SecadoService(IGenericRepository<Secado> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
