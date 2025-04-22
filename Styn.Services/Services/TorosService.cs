using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Toros
    public interface ITorosService : IGenericService<TorosDTO>
    {
    }

    public class TorosService : GenericService<Toros, TorosDTO>, ITorosService
    {
        public TorosService(IGenericRepository<Toros> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
