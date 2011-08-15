using System;
using ProductDevelopment.Models;

namespace ProductDevelopment.Web.Models
{
    public class Defect : Entity
    {
        public int DefectId { get; set; }
        
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        
        public string Summary { get; set; }
        
        public string StepsToReproduce { get; set; }

        public int CreatorUserId { get; set; }
        public User CreatorUser { get; set; }
        
        public int AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; }
        
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public int SeverityId { get; set; }
        public Severity Severity { get; set; }

        public Defect()
        {
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
        }
    }
}