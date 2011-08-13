using System.Collections.Generic;
using System.Data.Entity;
using ProductDevelopment.Models;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Infrastructure.Data
{
    public class SeedData : DropCreateDatabaseIfModelChanges<ProductDevelopmentContext>
    {
        protected override void Seed(ProductDevelopmentContext context)
        {
            var users = new List<User>
                            {
                                new User()
                                    {
                                        Username = "admin",
                                        Password = "ALgh+ccv1EpIEeBctyhulGb//jgCfW4hXNumgT2Pt1VT1Nc9L0QSISQO2lQni+ADDA==", //this is a hash for 'password'
                                        Admin = true
                                    },
                                new User()
                                    {
                                        Username = "testuser",
                                        Password = "ALgh+ccv1EpIEeBctyhulGb//jgCfW4hXNumgT2Pt1VT1Nc9L0QSISQO2lQni+ADDA==",
                                        Admin = false
                                    }
                            };
            users.ForEach(u => context.Users.Add(u));
        }
    }
}
