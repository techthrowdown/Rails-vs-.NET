using System;
using ProductDevelopment.Models;

namespace ProductDevelopment.Web.Models
{
    public class Defect : Entity
    {
        public int DefectId { get; set; }
        public Project Project { get; set; }
        public string Summary { get; set; }
        public string StepsToReproduce { get; set; }
        public User CreatorUserId { get; set; }
        public User AssignedToUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public Severity Severity { get; set; }
    }
}