using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProductDevelopment.Models;

namespace ProductDevelopment.DatabaseMappingTests
{
    [TestFixture]
    public class DefectTableTests
    {
        private ProductDevelopmentContext ctx;

        [TestFixtureSetUp]
        public void Setup()
        {
            ctx = new ProductDevelopmentContext();
        }

        [Test]
        public void CreateDefect_ShouldError()
        {
            var defect = CreateDefect();
        }

        private Defect CreateDefect()
        {
            var user = CreateUser();
            var project = CreateProject();
            var defect = new Defect()
                             {
                                 AssignedToUserId = user,
                                 CreatorUserId = user,
                                 CreateDate = DateTime.Now,
                                 StepsToReproduce = "123"
                             };
            ctx.Defects.Add(defect);
            ctx.SaveChanges();
            return defect;
        }

        private Project CreateProject()
        {
            var project = new Project()
            {
                Active = true,
                Name = "TestProject"
            };
            ctx.Projects.Add(project);
            ctx.SaveChanges();
            return project;
        }

        private User CreateUser()
        {
            var user = new User();
            user.Username = "TestUser";
            user.Password = "TestPassword";
            user.Admin = false;
            ctx.Users.Add(user);
            ctx.SaveChanges();
            return user;
        }
    }
}
