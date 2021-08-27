using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcTest.Data;
using MvcTest.Models;

namespace MvcTest.Controllers
{
  public class TeacherController : Controller
  {
    private readonly ILogger<TeacherController> _logger;
    private readonly ApplicationDbContext _context;
    private RepositoryContext repositoryContext;

    public TeacherController(ILogger<TeacherController> logger, ApplicationDbContext context)
    {
      _logger = logger;
      _context = context;
      repositoryContext = new RepositoryContext(_context);
    }

    // GET: Teacher
    public ActionResult Index()
    {
      var teachers = repositoryContext.TeacherRepository.Get();
      return View(teachers.ToList());
    }

    // GET: Teacher/Details/5
    public ActionResult Details(int? id)
    {
      Teacher teacher = repositoryContext.TeacherRepository.GetByID(id);
      
      return View(teacher);
    }

    // GET: Teacher/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Teacher/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Teacher teacher)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.TeacherRepository.Insert(teacher);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }

      return View(teacher);
    }

    // GET: Teacher/Edit/5
    public ActionResult Edit(int? id)
    {
      Teacher teacher = repositoryContext.TeacherRepository.GetByID(id);
      return View(teacher);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Teacher teacher)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.TeacherRepository.Update(teacher);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }
      return View(teacher);
    }

    // GET: Teacher/Delete/5
    public ActionResult Delete(int? id)
    {
      Teacher teacher = repositoryContext.TeacherRepository.GetByID(id);
      return View(teacher);
    }

    // POST: Teacher/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Teacher teacher = repositoryContext.TeacherRepository.GetByID(id);
      repositoryContext.TeacherRepository.Delete(teacher);
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
