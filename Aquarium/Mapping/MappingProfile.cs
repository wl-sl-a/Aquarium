using AutoMapper;
using Aquarium.Resources;
using Aquarium.Core.Models;

namespace Aquarium.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<AquariumM, AquaResources>();
            CreateMap<Fish, FishResource>();

            // Resource to Domain
            CreateMap<AquaResources, AquariumM>();
            CreateMap<FishResource, Fish>();
        }
    }
}
