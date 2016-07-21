using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdsApi.Models
{
    public class BirdPersistedDto : BirdDto
    {
        public string Id { get; set; }
    }
    public class BirdDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public List<string> Continents { get; set; }
        public string Added { get; set; }
        public bool Visible { get; set; }
    }
}
