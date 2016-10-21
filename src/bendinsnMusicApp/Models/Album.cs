using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bendinsnMusicApp.Models
{
    public class Album
    {
        public Album()
        {
            Title = "no title specified";
            Price = 0.01M;
        }

        public int AlbumID { get; set; }
        [Required(ErrorMessage = "You must enter a title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You must enter a price.")]
        [DataType(DataType.Currency)]
        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        
    }
}
