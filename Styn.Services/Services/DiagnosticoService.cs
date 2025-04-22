using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente Diagnostico
    public interface IDiagnosticoService : IGenericService<DiagnosticoDTO>
    {
    }

    public class DiagnosticoService : GenericService<Diagnostico, DiagnosticoDTO>, IDiagnosticoService
    {
        public DiagnosticoService(IGenericRepository<Diagnostico> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
