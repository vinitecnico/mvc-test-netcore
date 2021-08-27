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

      if (context.Students.Any())
      {
        return;
      }

      var students = new List<Student>
            {
                new Student{Id=1, Name="Student 1",DateBirth=DateTime.Parse("1989-07-30")},
                new Student{Id=2,Name="Student 2",DateBirth=DateTime.Parse("1990-03-21")},
                new Student{Id=3,Name="Student 3",DateBirth=DateTime.Parse("1990-06-01")},
            };

      students.ForEach(s => context.Students.Add(s));
      context.SaveChanges();


      var courses = new List<Course>
            {
                new Course{Id=1,Name="Course 1"},
                new Course{Id=2,Name="Course 2"},
                new Course{Id=3,Name="Course 3"}
            };
      courses.ForEach(s => context.Courses.Add(s));
      context.SaveChanges();

      var teachers = new List<Teacher>
            {
                new Teacher{Id=1,Name="Teacher 1", DateBirth=DateTime.Parse("1956-07-01"), Salary=2000},
                new Teacher{Id=2,Name="Teacher 2", DateBirth=DateTime.Parse("1962-04-23"), Salary=1500},
                new Teacher{Id=3,Name="Teacher 3", DateBirth=DateTime.Parse("1970-01-31"), Salary=5000}
            };
      teachers.ForEach(s => context.Teachers.Add(s));
      context.SaveChanges();

      var subjects = new List<Subject>
            {
                new Subject{Id=1 ,CourseID=1,Name="Subject 1", TeacherID=1},
                new Subject{Id=2, CourseID=1,Name="Subject 2", TeacherID=2},
                new Subject{Id=3, CourseID=1,Name="Subject 3", TeacherID=3}
            };
      subjects.ForEach(s => context.Subjects.Add(s));
      context.SaveChanges();

      var enrollments = new List<Enrollment>
            {
                new Enrollment { StudentID=1, SubjectID=1, GradeValue=12 },
                new Enrollment { StudentID=1, SubjectID=2, GradeValue=14 },
            };
      enrollments.ForEach(s => context.Enrollments.Add(s));
      context.SaveChanges();
    }
  }
}