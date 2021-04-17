using System.Collections.Generic;
using System.Threading.Tasks;
using Aquarium.Core.Models;

namespace Aquarium.Core.Repositories
{
    public interface IAquaRepository : IRepository<AquariumM>
    {
        Task<IEnumerable<AquariumM>> GetAllWithFishAsync();
        Task<AquariumM> GetWithFishesByIdAsync(int id);
        Task<IEnumerable<AquariumM>> GetAllAsync(string iden);
        ValueTask<AquariumM> GetByIdAsync(int id, string iden);
    }
}
