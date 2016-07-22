using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirdsApi.Models;

namespace BirdApi.Tests.Builders
{
    class BirdDtoBuilder
    {
        public string _name = "name";
        public string _family = "fam";
        public bool _visible = false;
        public HashSet<string> _continents = new HashSet<string>() {"a","b"};


        public BirdDto Build()
        {
            return new BirdDto()
            {
                Continents = _continents,
                Visible = _visible,
                Family = _family,
                Name = _name
            };
        }
    }
}
