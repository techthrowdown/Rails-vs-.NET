using System.Collections.Generic;

namespace ProductDevelopment.Models
{
    public class User : EntityBase
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public ICollection<Project> Projects { get; set; }

        public User()
        {
            Projects = new List<Project>();
        }
    }
}