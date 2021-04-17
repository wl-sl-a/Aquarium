using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.Core.Models
{
    public class Fish
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public int AquariumId { get; set; }
        public AquariumM Aquarium { get; set; }
        public int Count { get; set; }
        public string NameCompany { get; set; }
    }
}
