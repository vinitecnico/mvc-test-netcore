using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MvcTest.Data;
using MvcTest.Models;

namespace MvcTest.Controllers
{
  public class EnrollmentController : Controller
  {
    private readonly ILogger<EnrollmentController> _logger;
    private readonly ApplicationDbContext _context;
    private RepositoryContext repositoryContext;

    public EnrollmentController(ILogger<EnrollmentController> logger, ApplicationDbContext context)
    {
      _logger = logger;
      _context = context;
      repositoryContext = new RepositoryContext(_context);
    }

    // GET: Enrollment
    public ActionResult Index()
    {
      var enrollments = repositoryContext.EnrollmentRepository.Get().ToList();

      foreach (var enrollment in enrollments)
      {
        enrollment.Subject = repositoryContext.SubjectRepository.GetByID(enrollment.SubjectID);
        enrollment.Student = repositoryContext.StudentRepository.GetByID(enrollment.StudentID);
      }

      return View(enrollments);
    }

    // GET: Enrollment/Details/5
    public ActionResult Details(int? id)
    {
      Enrollment enrollment = repositoryContext.EnrollmentRepository.GetByID(id);
      return View(enrollment);
    }

    // GET: Enrollment/Create
    public ActionResult Create()
    {
      ViewBag.StudentID = new SelectList(repositoryContext.StudentRepository.Get(), "ID", "Name");
      ViewBag.SubjectID = new SelectList(repositoryContext.SubjectRepository.Get(), "ID", "Name");
      return View();
    }

    // POST: Enrollment/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Enrollment enrollment)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.EnrollmentRepository.Insert(enrollment);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }

      ViewBag.StudentID = new SelectList(repositoryContext.StudentRepository.Get(), "ID", "Name");
      ViewBag.SubjectID = new SelectList(repositoryContext.SubjectRepository.Get(), "ID", "Name");
      return View(enrollment);
    }

    // GET: Enrollment/Edit/5
    public ActionResult Edit(int? id)
    {
      Enrollment enrollment = repositoryContext.EnrollmentRepository.GetByID(id);

      ViewBag.StudentID = new SelectList(repositoryContext.StudentRepository.Get(), "ID", "Name");
      ViewBag.SubjectID = new SelectList(repositoryContext.SubjectRepository.Get(), "ID", "Name");
      return View(enrollment);
    }

    // POST: Enrollment/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Enrollment enrollment)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.EnrollmentRepository.Update(enrollment);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }
  
      ViewBag.StudentID = new SelectList(repositoryContext.StudentRepository.Get(), "ID", "Name");
      ViewBag.SubjectID = new SelectList(repositoryContext.SubjectRepository.Get(), "ID", "Name");
      return View(enrollment);
    }

    // GET: Enrollment/Delete/5
    public ActionResult Delete(int? id)
    {
      Enrollment enrollment = repositoryContext.EnrollmentRepository.GetByID(id);
      return View(enrollment);
    }

    // POST: Enrollment/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Enrollment enrollment = repositoryContext.EnrollmentRepository.GetByID(id);
      repositoryContext.EnrollmentRepository.Delete(enrollment);
      repositoryContext.Save();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        repositoryContext.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
