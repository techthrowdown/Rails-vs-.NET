using ProductDevelopment.Models;

namespace ProductDevelopment.Web.Models
{
    public class Severity : Entity
    {
        public int SeverityId { get; set; }
        public string SeverityDescription { get; set; }
        public int SortOrder { get; set; }
    }
}