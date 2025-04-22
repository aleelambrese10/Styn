using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Raza
    public interface IRazaService : IGenericService<RazaDTO>
    {
    }

    public class RazaService : GenericService<Raza, RazaDTO>, IRazaService
    {
        public RazaService(IGenericRepository<Raza> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
