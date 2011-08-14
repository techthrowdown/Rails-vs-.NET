using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProductDevelopment.Models;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Infrastructure.Data
{
    public class SeedData : DropCreateDatabaseIfModelChanges<ProductDevelopmentContext>
    {
        protected override void Seed(ProductDevelopmentContext context)
        {
            var users = SeedUserData(context);
            var severities = SeedSeverityData(context);
            var project = SeedProjectData(context, users);
            var defects = SeedDefectData(context, severities, project, users);
        }

        private static List<Defect> SeedDefectData(ProductDevelopmentContext context, List<Severity> severities, Project project, List<User> users)
        {
            var defects = new List<Defect>
                              {
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "Test defect summary 1",
                                          StepsToReproduce = "Test steps to reproduce 1",
                                          CreatorUserId = users.First(),
                                          AssignedToUserId = users.Last(),
                                          CreateDate = DateTime.Now.AddDays(-3),
                                          ModifyDate = DateTime.Now.AddDays(-2),
                                          Severity = severities[0]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "This is a test defect summary 2",
                                          StepsToReproduce = "Test steps to reproduce 2",
                                          CreatorUserId = users.First(),
                                          AssignedToUserId = users.First(),
                                          CreateDate = DateTime.Now.AddDays(-2),
                                          ModifyDate = DateTime.Now.AddDays(-1),
                                          Severity = severities[1]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "This is a test defect summary 3",
                                          StepsToReproduce = "Test steps to reproduce 3",
                                          CreatorUserId = users.Last(),
                                          AssignedToUserId = users.Last(),
                                          CreateDate = DateTime.Now.AddMonths(-2),
                                          ModifyDate = DateTime.Now.AddMonths(-1),
                                          Severity = severities[2]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "Test defect summary 4",
                                          StepsToReproduce = "Test steps to reproduce 4",
                                          CreatorUserId = users.First(),
                                          AssignedToUserId = users.Last(),
                                          CreateDate = DateTime.Now.AddMonths(-3),
                                          ModifyDate = DateTime.Now.AddMonths(-2),
                                          Severity = severities[0]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "This is a test defect summary 5",
                                          StepsToReproduce = "Test steps to reproduce 5",
                                          CreatorUserId = users.First(),
                                          AssignedToUserId = users.First(),
                                          CreateDate = DateTime.Now.AddHours(-3),
                                          ModifyDate = DateTime.Now.AddHours(-2),
                                          Severity = severities[1]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "This is a test defect summary 6",
                                          StepsToReproduce = "Test steps to reproduce 6",
                                          CreatorUserId = users.Last(),
                                          AssignedToUserId = users.Last(),
                                          CreateDate = DateTime.Now.AddHours(-2),
                                          ModifyDate = DateTime.Now.AddHours(-1),
                                          Severity = severities[2]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "Test defect summary 7",
                                          StepsToReproduce = "Test steps to reproduce 7",
                                          CreatorUserId = users.First(),
                                          AssignedToUserId = users.Last(),
                                          CreateDate = DateTime.Now.AddMinutes(-3),
                                          ModifyDate = DateTime.Now.AddMinutes(-2),
                                          Severity = severities[0]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "This is a test defect summary 8",
                                          StepsToReproduce = "Test steps to reproduce 8",
                                          CreatorUserId = users.First(),
                                          AssignedToUserId = users.First(),
                                          CreateDate = DateTime.Now.AddMinutes(-2),
                                          ModifyDate = DateTime.Now.AddMinutes(-1),
                                          Severity = severities[1]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "This is a test defect summary 9",
                                          StepsToReproduce = "Test steps to reproduce 9",
                                          CreatorUserId = users.Last(),
                                          AssignedToUserId = users.Last(),
                                          CreateDate = DateTime.Now.AddHours(-5),
                                          ModifyDate = DateTime.Now.AddHours(-4),
                                          Severity = severities[2]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "Test defect summary 10",
                                          StepsToReproduce = "Test steps to reproduce 10",
                                          CreatorUserId = users.First(),
                                          AssignedToUserId = users.Last(),
                                          CreateDate = DateTime.Now.AddHours(-4),
                                          ModifyDate = DateTime.Now.AddHours(-3),
                                          Severity = severities[0]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "This is a test defect summary 11",
                                          StepsToReproduce = "Test steps to reproduce 11",
                                          CreatorUserId = users.First(),
                                          AssignedToUserId = users.First(),
                                          CreateDate = DateTime.Now.AddHours(-2),
                                          ModifyDate = DateTime.Now.AddHours(-1),
                                          Severity = severities[1]
                                      },
                                  new Defect
                                      {
                                          Project = project,
                                          Summary = "This is a test defect summary 12",
                                          StepsToReproduce = "Test steps to reproduce 12",
                                          CreatorUserId = users.Last(),
                                          AssignedToUserId = users.Last(),
                                          CreateDate = DateTime.Now.AddMonths(-5),
                                          ModifyDate = DateTime.Now.AddMonths(-4),
                                          Severity = severities[2]
                                      }
                              };
            defects.ForEach(x => context.Defects.Add(x));
            return defects;
        }

        private static Project SeedProjectData(ProductDevelopmentContext context, List<User> users)
        {
            var project = new Project
                              {
                                  Name = "Tech Throwdown Test Project",
                                  Active = true,
                                  Users = users
                              };
            context.Projects.Add(project);
            return project;
        }

        private static List<Severity> SeedSeverityData(ProductDevelopmentContext context)
        {
            var severities = new List<Severity>
                                 {
                                     new Severity
                                         {
                                             SeverityDescription = "No Worries",
                                             SortOrder = 1
                                         },
                                     new Severity
                                         {
                                             SeverityDescription = "Uh-oh",
                                             SortOrder = 2
                                         },
                                     new Severity
                                         {
                                             SeverityDescription = "FAIL",
                                             SortOrder = 3
                                         }
                                 };
            severities.ForEach(x => context.Severities.Add(x));

            return severities;
        }

        private static List<User> SeedUserData(ProductDevelopmentContext context)
        {
            var users = new List<User>
                            {
                                new User
                                    {
                                        Username = "admin",
                                        Password = "ALgh+ccv1EpIEeBctyhulGb//jgCfW4hXNumgT2Pt1VT1Nc9L0QSISQO2lQni+ADDA==",
                                        //this is a hash for 'password'
                                        Admin = true
                                    },
                                new User
                                    {
                                        Username = "testuser",
                                        Password = "ALgh+ccv1EpIEeBctyhulGb//jgCfW4hXNumgT2Pt1VT1Nc9L0QSISQO2lQni+ADDA==",
                                        Admin = false
                                    }
                            };
            users.ForEach(x => context.Users.Add(x));
            return users;
        }
    }
}