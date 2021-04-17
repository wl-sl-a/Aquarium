using System.Threading.Tasks;
using Aquarium.Core;
using Aquarium.Core.Repositories;
using Aquarium.DAL.Repository;

namespace Aquarium.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private FishRepository _fishRepository;
        private AquaRepository _aquaRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IFishRepository Fishes => _fishRepository = _fishRepository ?? new FishRepository(_context);

        public IAquaRepository Aquariums => _aquaRepository = _aquaRepository ?? new AquaRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
