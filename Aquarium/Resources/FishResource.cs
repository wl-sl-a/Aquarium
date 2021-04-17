using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aquarium.Core.Models;

namespace Aquarium.Resources
{
    public class FishResource
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public int AquariumId { get; set; }
        public int Count { get; set; }
        public string NameCompany { get; set; }
    }
}
