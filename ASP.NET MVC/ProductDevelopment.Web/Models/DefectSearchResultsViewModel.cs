using System;

namespace ProductDevelopment.Web.Models
{
    public class DefectSearchResultsViewModel
    {
        public int Id { get; set; }
        public string Project { get; set; }
        public string Summary { get; set; }
        public string Severity { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}