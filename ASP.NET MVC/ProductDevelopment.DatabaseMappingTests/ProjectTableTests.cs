using System;
using System.Linq;
using NUnit.Framework;
using ProductDevelopment.Models;

namespace ProductDevelopment.DatabaseMappingTests
{
    [TestFixture]
    public class ProjectTableTests
    {
        private ProductDevelopmentContext ctx;

        [TestFixtureSetUp]
        public void Setup()
        {
            ctx = new ProductDevelopmentContext();
        }

        [Test]
        public void CreateProject_ShouldReturnProject()
        {
            var project = CreateProject();
            Assert.IsTrue(project.ProjectId > 0);
        }

        [Test]
        public void AddUserToProject_ShouldHaveOneUser()
        {
            var project = CreateProject();
            project.Users.Add(CreateUser());
            ctx.SaveChanges();
            var newProject = ctx.Projects.Where(p => p.ProjectId == project.ProjectId).SingleOrDefault();
            Assert.AreEqual(project.Users.Count, 1);
        }

        [Test]
        public void AddUserToProject_UserShouldHaveOneProject()
        {
            var project = CreateProject();
            var user = CreateUser();
            project.Users.Add(user);
            ctx.SaveChanges();
            var newUser = ctx.Users.Find(user.UserId);
            Assert.AreEqual(newUser.Projects.Count, 1);
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