using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Data;
using MvcTest.Models;

namespace MvcTest.Data
{
  public class RepositoryContext : IDisposable
  {
    internal ApplicationDbContext context;
    public RepositoryContext(ApplicationDbContext context)
    {
      this.context = context;
    }


    private GenericRepository<Student> studentRepository;
    private GenericRepository<Course> courseRepository;
    private GenericRepository<Subject> subjectRepository;
    private GenericRepository<Enrollment> enrollmentRepository;
    private GenericRepository<Teacher> teacherRepository;

    public GenericRepository<Student> StudentRepository
    {
      get
      {

        if (this.studentRepository == null)
        {
          this.studentRepository = new GenericRepository<Student>(context);
        }
        return studentRepository;
      }
    }

    public GenericRepository<Course> CourseRepository
    {
      get
      {

        if (this.courseRepository == null)
        {
          this.courseRepository = new GenericRepository<Course>(context);
        }
        return courseRepository;
      }
    }

    public GenericRepository<Subject> SubjectRepository
    {
      get
      {

        if (this.subjectRepository == null)
        {
          this.subjectRepository = new GenericRepository<Subject>(context);
        }
        return subjectRepository;
      }
    }


    public GenericRepository<Enrollment> EnrollmentRepository
    {
      get
      {

        if (this.enrollmentRepository == null)
        {
          this.enrollmentRepository = new GenericRepository<Enrollment>(context);
        }
        return enrollmentRepository;
      }
    }

    public GenericRepository<Teacher> TeacherRepository
    {
      get
      {

        if (this.teacherRepository == null)
        {
          this.teacherRepository = new GenericRepository<Teacher>(context);
        }
        return teacherRepository;
      }
    }

    public void Save()
    {
      context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}