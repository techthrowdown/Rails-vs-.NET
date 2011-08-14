using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ProductDevelopment.Models;

namespace ProductDevelopment.Web.Models
{
    public class DefectInputModel
    {
        [Required]
        public Project Project { get; set; }

        [Required]
        [StringLength(100)]
        public string Summary { get; set; }

        public string StepsToReproduce { get; set; }

        [Required]
        public User CreatorUserId { get; set; }

        [Required]
        public User AssignedToUserId { get; set; }

        [Required]
        public Severity Severity { get; set; }

        public SelectList ProjectSelectList { get; set; }
        public SelectList UserSelectList { get; set; }
    }
}