using System;
using System.Threading.Tasks;
using Aquarium.Core.Repositories;

namespace Aquarium.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAquaRepository Aquariums { get; }
        IFishRepository Fishes { get; }
        Task<int> CommitAsync();
    }
}
