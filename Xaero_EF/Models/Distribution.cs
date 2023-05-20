using System.ComponentModel.DataAnnotations;

namespace EF_Core.Models
{
    public class Distribution
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public string TelePhone { get; set; }

        public IList<MovieDistribution> MovieDistribution { get; set; }
    }
}
