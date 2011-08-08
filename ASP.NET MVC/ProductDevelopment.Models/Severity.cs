namespace ProductDevelopment.Models
{
    public class Severity : EntityBase
    {
        public int SeverityId { get; set; }
        public string SeverityDescription { get; set; }
        public int SortOrder { get; set; }
    }
}