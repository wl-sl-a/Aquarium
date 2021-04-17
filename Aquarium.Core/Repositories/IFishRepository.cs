using System.Collections.Generic;
using System.Threading.Tasks;
using Aquarium.Core.Models;

namespace Aquarium.Core.Repositories
{
    public interface IFishRepository : IRepository<Fish>
    {
        Task<IEnumerable<Fish>> GetAllWithAquaAsync();
        Task<Fish> GetWithAquaByIdAsync(int id);
        Task<IEnumerable<Fish>> GetAllWithAquaByAquaIdAsync(int aquaId);
    }
}
