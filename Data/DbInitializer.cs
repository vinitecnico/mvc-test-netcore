using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Models;

namespace MvcTest.Data
{
  public class DbInitializer
  {
    public static void Initialize(ApplicationDbContext context)
    {
      context.Database.EnsureCreated();

      // Look for any students.
      if (context.Student.Any())
      {
        return;   // DB has been seeded
      }

      var students = new List<Student>
            {
            new Student{Name="Carson",Birthday=DateTime.Parse("2005-09-01"), EnrollmentDate = DateTime.Now},
            new Student{Name="Meredith",Birthday=DateTime.Parse("2002-09-01"), EnrollmentDate = DateTime.Now},
            new Student{Name="Arturo",Birthday=DateTime.Parse("2003-09-01"), EnrollmentDate = DateTime.Now},
            new Student{Name="Gytis",Birthday=DateTime.Parse("2002-09-01"), EnrollmentDate = DateTime.Now},
            new Student{Name="Yan",Birthday=DateTime.Parse("2002-09-01"), EnrollmentDate = DateTime.Now},
            new Student{Name="Peggy",Birthday=DateTime.Parse("2001-09-01"), EnrollmentDate = DateTime.Now},
            new Student{Name="Laura",Birthday=DateTime.Parse("2003-09-01"), EnrollmentDate = DateTime.Now},
            new Student{Name="Nino",Birthday=DateTime.Parse("2005-09-01"), EnrollmentDate = DateTime.Now}
            };

      students.ForEach(s => context.Student.Add(s));
      context.SaveChanges();
      

      // var courses = new List<Course>
      //       {
      //       new Course{CourseID=1050,Title="Chemistry"},
      //       new Course{CourseID=4022,Title="Microeconomics"},
      //       new Course{CourseID=4041,Title="Macroeconomics"},
      //       new Course{CourseID=1045,Title="Calculus"},
      //       new Course{CourseID=3141,Title="Trigonometry"},
      //       new Course{CourseID=2021,Title="Composition"},
      //       new Course{CourseID=2042,Title="Literature"}
      //       };
      // var courses = new List<Course>
      // {
      // new Course{CourseID=1050,Title="Chemistry",Credits=3,},
      // new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
      // new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
      // new Course{CourseID=1045,Title="Calculus",Credits=4,},
      // new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
      // new Course{CourseID=2021,Title="Composition",Credits=3,},
      // new Course{CourseID=2042,Title="Literature",Credits=4,}
      // };
      // courses.ForEach(s => context.Courses.Add(s));
      // context.SaveChanges();
      // var enrollments = new List<Enrollment>
      // {
      // new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
      // new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
      // new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
      // new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
      // new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
      // new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
      // new Enrollment{StudentID=3,CourseID=1050},
      // new Enrollment{StudentID=4,CourseID=1050,},
      // new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
      // new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
      // new Enrollment{StudentID=6,CourseID=1045},
      // new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
      // };
      // enrollments.ForEach(s => context.Enrollments.Add(s));
      // context.SaveChanges();
    }
  }
}