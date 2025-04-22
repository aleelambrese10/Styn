using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Partos
    public interface IPartosService : IGenericService<PartosDTO>
    {
    }

    public class PartosService : GenericService<Partos, PartosDTO>, IPartosService
    {
        public PartosService(IGenericRepository<Partos> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
