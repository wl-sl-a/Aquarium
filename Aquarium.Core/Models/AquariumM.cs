using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Aquarium.Core.Models
{
    public class AquariumM
    {
        public AquariumM()
        {
            Fishes = new Collection<Fish>();
        }
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public int Volume { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string NameCompany { get; set; }
        public ICollection<Fish> Fishes { get; set; }
    }
}
