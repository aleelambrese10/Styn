using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Metodos
    public interface IMetodosService : IGenericService<MetodosDTO>
    {
    }

    public class MetodosService : GenericService<Metodos, MetodosDTO>, IMetodosService
    {
        public MetodosService(IGenericRepository<Metodos> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
