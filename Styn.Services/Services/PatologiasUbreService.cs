using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente PatologiasUbre
    public interface IPatologiasUbreService : IGenericService<PatologiasUbreDTO>
    {
    }

    public class PatologiasUbreService : GenericService<PatologiasUbre, PatologiasUbreDTO>, IPatologiasUbreService
    {
        public PatologiasUbreService(IGenericRepository<PatologiasUbre> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
