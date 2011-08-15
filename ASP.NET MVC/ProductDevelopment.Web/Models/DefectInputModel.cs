using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProductDevelopment.Web.Models
{
    public class DefectInputModel
    {
        [Required]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string Summary { get; set; }

        [Display(Name = "Steps to reproduce")]
        public string StepsToReproduce { get; set; }

        [Required]
        [Display(Name = "Created by")]
        public int CreatorUserId { get; set; }

        [Required]
        [Display(Name = "Assigned to")]
        public int AssignedToUserId { get; set; }

        [Required]
        [Display(Name = "Severity")]
        public int SeverityId { get; set; }

        public SelectList ProjectSelectList { get; set; }
        public SelectList UserSelectList { get; set; }
        public SelectList SeveritySelectList { get; set; }
    }
}