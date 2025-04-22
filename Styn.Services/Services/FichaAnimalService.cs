using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente FichaAnimal
    public interface IFichaAnimalService : IGenericService<FichaAnimalDTO>
    {
    }

    public class FichaAnimalService : GenericService<FichaAnimal, FichaAnimalDTO>, IFichaAnimalService
    {
        public FichaAnimalService(IGenericRepository<FichaAnimal> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
