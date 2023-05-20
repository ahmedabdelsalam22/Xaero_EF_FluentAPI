namespace EF_Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int ProductionCompanyId { get; set; }
        public ProductionCompany ProductionCompany { get; set; }
        public MovieDetail MovieDetail { get; set; }
        public IList<MovieDistribution> MovieDistribution { get; set; }

    }
}
