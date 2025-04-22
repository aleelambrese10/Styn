
using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;


// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Celos
    public interface ICelosService : IGenericService<CelosDTO>
    {
    }

    public class CelosService : GenericService<Celos, CelosDTO>, ICelosService
    {
        public CelosService(IGenericRepository<Celos> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
