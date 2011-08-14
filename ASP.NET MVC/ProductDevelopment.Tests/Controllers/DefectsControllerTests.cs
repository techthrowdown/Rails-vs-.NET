using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using ProductDevelopment.Models;
using ProductDevelopment.Web.Controllers;
using ProductDevelopment.Web.Infrastructure.Data;
using ProductDevelopment.Web.Models;
using Should;

namespace ProductDevelopment.Tests.Controllers
{
    [TestFixture]
    public class DefectsControllerTests
    {
        [Test]
        public void Should_return_view_with_search_results()
        {
            // Arrange
            var mockProject = new Project
                              {
                                  Name = "Tech Throwdown Test Project",
                                  Active = true,
                              };
            var mockUser = new User
                           {
                               Username = "test user",
                               Password = "test password",
                           };
            var mockSeverity = new Severity
                                   {
                                       SeverityDescription = "No Worries",
                                       SortOrder = 1
                                   };
            var mockDefects = new List<Defect>
                                  {
                                      new Defect
                                          {
                                              Project = mockProject,
                                              Summary = "Test defect summary 1",
                                              StepsToReproduce = "Test steps to reproduce 1",
                                              CreatorUserId = mockUser,
                                              AssignedToUserId = mockUser,
                                              CreateDate = DateTime.Now.AddDays(-3),
                                              ModifyDate = DateTime.Now.AddDays(-2),
                                              Severity = mockSeverity
                                          },
                                      new Defect
                                          {
                                              Project = mockProject,
                                              Summary = "This is a test defect summary 3",
                                              StepsToReproduce = "Test steps to reproduce 3",
                                              CreatorUserId = mockUser,
                                              AssignedToUserId = mockUser,
                                              CreateDate = DateTime.Now.AddMonths(-2),
                                              ModifyDate = DateTime.Now.AddMonths(-1),
                                              Severity = mockSeverity
                                          }
                                  };
            var mockRepo = new Mock<IRepository<Defect>>();
            mockRepo.Setup(x => x.All()).Returns(mockDefects.AsQueryable());
            var controller = new DefectsController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            result.ShouldBeType<ViewResult>();

            var model = (IEnumerable<DefectSearchResultsViewModel>) result.Model;

            model.First().Project.ShouldEqual("Tech Throwdown Test Project");
            model.First().Summary.ShouldEqual("Test defect summary 1");
            model.First().Severity.ShouldEqual("No Worries");
            model.First().CreatedBy.ShouldEqual("test user");
            model.First().AssignedTo.ShouldEqual("test user");

            model.Last().Project.ShouldEqual("Tech Throwdown Test Project");
            model.Last().Summary.ShouldEqual("This is a test defect summary 3");
            model.Last().Severity.ShouldEqual("No Worries");
            model.Last().CreatedBy.ShouldEqual("test user");
            model.Last().AssignedTo.ShouldEqual("test user");
        }
    }
}