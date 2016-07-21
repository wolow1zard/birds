using System.ComponentModel.DataAnnotations;

namespace BirdsApi.Models
{
    public class BirdPersistedDto : BirdDto
    {
        /// <summary>
        /// Object id from the database
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Date the bird was added to the registry. Format YYYY-MM-DD
        /// </summary>
        [Required]
        public string Added { get; set; }
    }
}