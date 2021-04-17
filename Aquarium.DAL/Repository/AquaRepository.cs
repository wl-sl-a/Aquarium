using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aquarium.Core.Models;
using Aquarium.Core.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace Aquarium.DAL.Repository
{
    public class AquaRepository : Repository<AquariumM>, IAquaRepository
    {
        public AquaRepository(ApplicationDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<AquariumM>> GetAllWithFishAsync()
        {
            return await ApplicationDbContext.Aquariums
                .Include(a => a.Fishes)
                .ToListAsync();
        }

        public Task<AquariumM> GetWithFishesByIdAsync(int id)
        {
            return ApplicationDbContext.Aquariums
                .Include(a => a.Fishes)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AquariumM>> GetAllAsync(string iden)
        {
            return await Context.Set<AquariumM>().Where(p => p.NameCompany == iden).ToListAsync();
        }

        public ValueTask<AquariumM> GetByIdAsync(int id, string iden)
        {
            var a = Context.Set<AquariumM>().Where(p => p.NameCompany == iden).Where(p => p.Id == id).ToList();
            if(a.Count == 1)
            {
                var aquarium = Context.Set<AquariumM>().FindAsync(id);
                return aquarium;
            }
            return new ValueTask<AquariumM>();
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
