using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcTest.Data;
using MvcTest.Models;

namespace MvcTest.Controllers
{
  public class StudentController : Controller
  {

    private readonly ILogger<StudentController> _logger;
    private readonly ApplicationDbContext _context;
    private RepositoryContext repositoryContext;

    public StudentController(ILogger<StudentController> logger, ApplicationDbContext context)
    {
      _logger = logger;
      _context = context;
      repositoryContext = new RepositoryContext(_context);
    }

    // GET: Student
    public IActionResult Index()
    {
      var students = repositoryContext.StudentRepository.Get().ToList();
      return View(students);
    }


    // GET: Student/Create
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Student student)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.StudentRepository.Insert(student);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }

      return View(student);
    }

    // GET: Student/Edit/5
    public ActionResult Edit(int? id)
    {
      Student student = repositoryContext.StudentRepository.GetByID(id);

      return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Student student)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.StudentRepository.Update(student);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }
      return View(student);
    }

    public ActionResult Delete(int? id)
    {
      Student student = repositoryContext.StudentRepository.GetByID(id);

      return View(student);
    }

    // POST: Student/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Student student = repositoryContext.StudentRepository.GetByID(id);
      repositoryContext.StudentRepository.Delete(student);
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