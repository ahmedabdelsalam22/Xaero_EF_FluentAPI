namespace EF_Core.Models
{
    public class ProductionCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public decimal AnnualReveune { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
