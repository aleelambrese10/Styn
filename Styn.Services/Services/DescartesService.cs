using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    /
    public interface IDescartesService : IGenericService<DescartesDTO>
    {
    }

    public class DescartesService : GenericService<Descartes, DescartesDTO>, IDescartesService
    {
        public DescartesService(IGenericRepository<Descartes> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
