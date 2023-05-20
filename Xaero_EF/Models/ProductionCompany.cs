using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace EF_Core.Models
{
    public class ProductionCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        
        public decimal AnnualReveune { get; set; }
        public string EstablishmentDate { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
