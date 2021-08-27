using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MvcTest.Data;
using MvcTest.Models;

namespace MagniFinanceExercise.Controllers
{
  public class SubjectController : Controller
  {
    private readonly ILogger<SubjectController> _logger;
    private readonly ApplicationDbContext _context;
    private RepositoryContext repositoryContext;

    public SubjectController(ILogger<SubjectController> logger, ApplicationDbContext context)
    {
      _logger = logger;
      _context = context;
      repositoryContext = new RepositoryContext(_context);
    }

    // GET: Subject
    public ActionResult Index()
    {
      var subjects = repositoryContext.SubjectRepository
      .Get()
      .ToList();

      foreach (var subject in subjects)
      {
        subject.Teacher = repositoryContext.TeacherRepository.GetByID(subject.TeacherID);
        subject.Course = repositoryContext.CourseRepository.GetByID(subject.CourseID);
      }

      return View(subjects);
    }

    // GET: Subject/Details/5
    public ActionResult Details(int? id)
    {
      Subject subject = repositoryContext.SubjectRepository.GetByID(id);
      subject.Teacher = repositoryContext.TeacherRepository.GetByID(subject.TeacherID);
      subject.Course = repositoryContext.CourseRepository.GetByID(subject.CourseID);

      return View(subject);
    }

    // GET: Subject/Create
    public ActionResult Create()
    {
      ViewBag.CourseID = new SelectList(repositoryContext.CourseRepository.Get(), "ID", "Name");
      ViewBag.TeacherID = new SelectList(repositoryContext.TeacherRepository.Get(), "ID", "Name");
      return View();
    }

    // POST: Subject/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Subject subject)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.SubjectRepository.Insert(subject);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }

      ViewBag.CourseID = new SelectList(repositoryContext.CourseRepository.Get(), "ID", "Name", subject.CourseID);
      ViewBag.TeacherID = new SelectList(repositoryContext.TeacherRepository.Get(), "ID", "Name", subject.TeacherID);
      return View(subject);
    }

    // GET: Subject/Edit/5
    public ActionResult Edit(int? id)
    {
      Subject subject = repositoryContext.SubjectRepository.GetByID(id);
      subject.Teacher = repositoryContext.TeacherRepository.GetByID(subject.TeacherID);
      subject.Course = repositoryContext.CourseRepository.GetByID(subject.CourseID);

      ViewBag.CourseID = new SelectList(repositoryContext.CourseRepository.Get(), "ID", "Name", subject.CourseID);
      ViewBag.TeacherID = new SelectList(repositoryContext.TeacherRepository.Get(), "ID", "Name", subject.TeacherID);
      return View(subject);
    }

    // POST: Subject/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Subject subject)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.SubjectRepository.Update(subject);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }
      ViewBag.CourseID = new SelectList(repositoryContext.CourseRepository.Get(), "ID", "Name", subject.CourseID);
      ViewBag.TeacherID = new SelectList(repositoryContext.TeacherRepository.Get(), "ID", "Name", subject.TeacherID);
      return View(subject);
    }

    // GET: Subject/Delete/5
    public ActionResult Delete(int? id)
    {
      Subject subject = repositoryContext.SubjectRepository.GetByID(id);

      return View(subject);
    }

    // POST: Subject/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Subject subject = repositoryContext.SubjectRepository.GetByID(id);
      repositoryContext.SubjectRepository.Delete(subject);
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
