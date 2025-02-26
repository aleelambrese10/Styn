using Styn.Domain.DTOs;
using Styn.Domain.Entities.Common;

namespace Styn.Domain.Entities
{
    public class User : BaseEntity
    {
        public ApplicationUser ApplicationUser { get; set; }

    }
}
