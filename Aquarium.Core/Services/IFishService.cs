using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aquarium.Core.Models;

namespace Aquarium.Core.Services
{
    public interface IFishService
    {
        Task<IEnumerable<Fish>> GetAllWithAqua();
        Task<Fish> GetAquaById(int id);
        Task<IEnumerable<Fish>> GetFishesByAquaId(int fishId);
        Task<Fish> CreateFish(Fish newFish);
        Task UpdateFish(Fish fishToBeUpdated, Fish fish);
        Task DeleteFish(Fish fish);
    }
}
