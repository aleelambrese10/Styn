using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente ControlLechero
    public interface IControlLecheroService : IGenericService<ControlLecheroDTO>
    {
    }

    public class ControlLecheroService : GenericService<ControlLechero, ControlLecheroDTO>, IControlLecheroService
    {
        public ControlLecheroService(IGenericRepository<ControlLechero> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
