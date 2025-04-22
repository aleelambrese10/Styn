using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente EventosSanitarios
    public interface IEventosSanitariosService : IGenericService<EventosSanitariosDTO>
    {
    }

    public class EventosSanitariosService : GenericService<EventosSanitarios, EventosSanitariosDTO>, IEventosSanitariosService
    {
        public EventosSanitariosService(IGenericRepository<EventosSanitarios> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
