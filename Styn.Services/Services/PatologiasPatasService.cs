using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente PatologiasPatas
    public interface IPatologiasPatasService : IGenericService<PatologiasPatasDTO>
    {
    }

    public class PatologiasPatasService : GenericService<PatologiasPatas, PatologiasPatasDTO>, IPatologiasPatasService
    {
        public PatologiasPatasService(IGenericRepository<PatologiasPatas> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
