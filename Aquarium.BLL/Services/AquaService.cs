using System.Collections.Generic;
using System.Threading.Tasks;
using Aquarium.Core;
using Aquarium.Core.Models;
using Aquarium.Core.Services;

namespace Aquarium.BLL.Services
{
    public class AquaService : IAquaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AquaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<AquariumM> CreateAquarium(AquariumM newAqua)
        {
            await _unitOfWork.Aquariums
                .AddAsync(newAqua);
            await _unitOfWork.CommitAsync();

            return newAqua;
        }

        public async Task DeleteAquarium(AquariumM aquarium)
        {
            _unitOfWork.Aquariums.Remove(aquarium);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<AquariumM>> GetAll(string iden)
        {
            return await _unitOfWork.Aquariums.GetAllAsync(iden);
        }

        public async Task<AquariumM> GetAquariumById(int id, string iden)
        {
            return await _unitOfWork.Aquariums.GetByIdAsync(id, iden);
        }

        public async Task UpdateAquarium(int id, AquariumM aqua)
        {
            aqua.Id = id;
            _unitOfWork.Aquariums.Entry(aqua);
            await _unitOfWork.CommitAsync();
        }
    }
}
