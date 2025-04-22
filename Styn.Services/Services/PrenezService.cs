using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Prenez
    public interface IPrenezService : IGenericService<PrenezDTO>
    {
    }

    public class PrenezService : GenericService<Prenez, PrenezDTO>, IPrenezService
    {
        public PrenezService(IGenericRepository<Prenez> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
