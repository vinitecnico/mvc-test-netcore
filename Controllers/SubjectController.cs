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
      var subjects = repositoryContext.SubjectRepository.Get();
      return View(subjects.ToList());
    }

    // GET: Subject/Details/5
    public ActionResult Details(int? id)
    {
      Subject subject = repositoryContext.SubjectRepository.GetByID(id);

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

    // public ActionResult Statistics()
    // {
    //   var subjects = repositoryContext.SubjectRepository.Get().ToList();
    //   List<SubjectStatistic> studentsStatistics = new List<SubjectStatistic>();
    //   subjects.ForEach(s =>
    //   {
    //     SubjectStatistic subjectStatistic = new SubjectStatistic();
    //     subjectStatistic.Name = repositoryContext.SubjectRepository.GetByID(s.ID).Name;
    //     subjectStatistic.ID = s.Id;
    //     var enrollements = repositoryContext.EnrollmentRepository
    //           .Get()
    //           .Where(e => e.SubjectID == s.Id)
    //           .ToList();

    //     enrollements.ForEach(e =>
    //           {
    //         subjectStatistic.Students.Add(new StudentGrade
    //         {
    //           Name = repositoryContext.StudentRepository.GetByID(e.StudentID).Name,
    //           Grade = e.GradeValue
    //         });
    //       });

    //     studentsStatistics.Add(subjectStatistic);
    //   });

    //   return Json(studentsStatistics, JsonRequestBehavior.AllowGet);
    // }

    // public ActionResult GetTeacherOfSubject(int? id)
    // {
    //   Subject subject = repositoryContext.SubjectRepository.GetByID(id);

    //   return Json(subject.Teacher, JsonRequestBehavior.AllowGet);
    // }

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
