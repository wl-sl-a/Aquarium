using System.Threading.Tasks;
using Aquarium.Core.DTOs;

namespace Aquarium.Core.Services
{
    public interface IAuthService
    {
        public Task<TokenDTO> LoginAsync(LoginDTO loginDto);
    }
}
