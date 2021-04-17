using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aquarium.Core.Models;

namespace Aquarium.Core.Services
{
    public interface IAquaService
    {
        Task<IEnumerable<AquariumM>> GetAll(string iden);
        Task<AquariumM> GetAquariumById(int id, string iden);
        Task<AquariumM> CreateAquarium(AquariumM newAquarium);
        Task UpdateAquarium(int id, AquariumM aquarium);
        Task DeleteAquarium(AquariumM aquarium);
    }
}
