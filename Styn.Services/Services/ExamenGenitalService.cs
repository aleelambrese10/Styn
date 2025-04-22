using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente ExamenGenital
    public interface IExamenGenitalService : IGenericService<ExamenGenitalDTO>
    {
    }

    public class ExamenGenitalService : GenericService<ExamenGenital, ExamenGenitalDTO>, IExamenGenitalService
    {
        public ExamenGenitalService(IGenericRepository<ExamenGenital> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
