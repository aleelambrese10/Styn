using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Colaboradores
    public interface IColaboradoresService : IGenericService<ColaboradoresDTO>
    {
    }

    public class ColaboradoresService : GenericService<Colaboradores, ColaboradoresDTO>, IColaboradoresService
    {
        public ColaboradoresService(IGenericRepository<Colaboradores> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
