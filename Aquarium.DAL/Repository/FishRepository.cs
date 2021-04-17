using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aquarium.Core.Models;
using Aquarium.Core.Repositories;

namespace Aquarium.DAL.Repository
{
    public class FishRepository : Repository<Fish>, IFishRepository
    {
        public FishRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<IEnumerable<Fish>> GetAllWithAquaAsync()
        {
            return await ApplicationDbContext.Fishes
                .Include(m => m.Aquarium)
                .ToListAsync();
        }

        public async Task<Fish> GetWithAquaByIdAsync(int id)
        {
            return await ApplicationDbContext.Fishes
                .Include(m => m.Aquarium)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Fish>> GetAllWithAquaByAquaIdAsync(int artistId)
        {
            return await ApplicationDbContext.Fishes
                .Include(m => m.Aquarium)
                .Where(m => m.AquariumId == artistId)
                .ToListAsync();
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
