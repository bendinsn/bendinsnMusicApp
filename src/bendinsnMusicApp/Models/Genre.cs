using System.ComponentModel.DataAnnotations;

namespace bendinsnMusicApp.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required(ErrorMessage = "The genre must be given a name.")]
        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "The maximum length for a genre name is 20 characters.")]
        public string Name { get; set; }

    }
}