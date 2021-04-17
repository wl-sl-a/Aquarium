using System.Collections.Generic;
using System.Threading.Tasks;
using Aquarium.Core;
using Aquarium.Core.Models;
using Aquarium.Core.Services;

namespace Aquarium.BLL.Services
{
    public class FishService : IFishService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FishService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Fish> CreateFish(Fish newFish)
        {
            await _unitOfWork.Fishes.AddAsync(newFish);
            await _unitOfWork.CommitAsync();
            return newFish;
        }

        public async Task DeleteFish(Fish fish)
        {
            _unitOfWork.Fishes.Remove(fish);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Fish>> GetAllWithAqua()
        {
            return await _unitOfWork.Fishes
                .GetAllWithAquaAsync();
        }

        public async Task<Fish> GetAquaById(int id)
        {
            return await _unitOfWork.Fishes
                .GetWithAquaByIdAsync(id);
        }

        public async Task<IEnumerable<Fish>> GetFishesByAquaId(int fishId)
        {
            return await _unitOfWork.Fishes
                .GetAllWithAquaByAquaIdAsync(fishId);
        }

        public async Task UpdateFish(Fish fishToBeUpdated, Fish fish)
        {
            fishToBeUpdated.Id = fish.Id;
            fishToBeUpdated.AquariumId = fish.AquariumId;

            await _unitOfWork.CommitAsync();
        }
    }
}
