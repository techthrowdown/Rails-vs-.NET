using System.Collections.Generic;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Models
{
    public class Project : Entity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Defect> Defects { get; set; }

        public Project()
        {
            Users = new List<User>();
            Defects = new List<Defect>();
        }
    }
}