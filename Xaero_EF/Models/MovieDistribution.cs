namespace EF_Core.Models
{
    public class MovieDistribution
    {
        public int MovieId { get; set; }
        public Movie Movies { get; set; }
        public int DistributionId { get; set; }
        public Distribution Distributions { get; set; }
    }
}
