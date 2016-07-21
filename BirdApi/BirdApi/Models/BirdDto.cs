using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdsApi.Models
{
    public class BirdDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public List<string> Continents { get; set; }
        public bool Visible { get; set; }

        public bool HasValidState()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Family) &&
                   Continents != null;
        }
    }
}
