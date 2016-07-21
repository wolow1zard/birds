using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BirdsApi.Models
{
    public class BirdDto
    {
        public BirdDto()
        {
            Visible = false;
        }
        /// <summary>
        /// English bird name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Latin bird family name
        /// </summary>
        [Required]
        public string Family { get; set; }

        /// <summary>
        /// Continents the bird exist on, must be atleast 1
        /// </summary>
        [Required]
        [MinLength(1)]
        public HashSet<string> Continents { get; set; }

        /// <summary>
        /// Defaults to false
        /// </summary>
        public bool Visible { get; set; }

        public bool HasValidState()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Family) &&
                   Continents != null && Continents.Count > 0;
        }
    }
}
