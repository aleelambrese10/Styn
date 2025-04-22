using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Lotes
    public interface ILotesService : IGenericService<LotesDTO>
    {
    }

    public class LotesService : GenericService<Lotes, LotesDTO>, ILotesService
    {
        public LotesService(IGenericRepository<Lotes> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
