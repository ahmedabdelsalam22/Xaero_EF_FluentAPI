using System.ComponentModel.DataAnnotations;

namespace EF_Core.Models
{
    public class MovieDetail
    {
        public int MovieId { get; set; }

        public string Name { get; set; }
        public string Poster { get; set; }
        
        public decimal Budget { get; set; }
        public decimal Gross { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Movie Movie { get; set; }
    }
}
