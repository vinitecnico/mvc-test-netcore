using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcTest.Data;
using MvcTest.Models;

namespace MvcTest.Controllers
{
  public class CourseController : Controller
  {
    private readonly ILogger<CourseController> _logger;
    private readonly ApplicationDbContext _context;
    private RepositoryContext repositoryContext;

    public CourseController(ILogger<CourseController> logger, ApplicationDbContext context)
    {
      _logger = logger;
      _context = context;
      repositoryContext = new RepositoryContext(_context);
    }

    // GET: Course
    public ActionResult Index()
    {
      var courses = repositoryContext.CourseRepository.Get();
      return View(courses.ToList());
    }

    // GET: Course/Details/5
    public ActionResult Details(int? id)
    {
      Course course = repositoryContext.CourseRepository.GetByID(id);

      return View(course);
    }

    // GET: Course/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Course/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Course course)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.CourseRepository.Insert(course);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }

      return View(course);
    }

    // GET: Course/Edit/5
    public ActionResult Edit(int? id)
    {
      Course course = repositoryContext.CourseRepository.GetByID(id);

      return View(course);
    }

    // POST: Course/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Course course)
    {
      if (ModelState.IsValid)
      {
        repositoryContext.CourseRepository.Update(course);
        repositoryContext.Save();
        return RedirectToAction("Index");
      }

      return View(course);
    }

    // GET: Course/Delete/5
    public ActionResult Delete(int? id)
    {
      Course course = repositoryContext.CourseRepository.GetByID(id);
      return View(course);
    }

    // POST: Course/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Course course = repositoryContext.CourseRepository.GetByID(id);
      repositoryContext.CourseRepository.Delete(id);
      repositoryContext.Save();
      return RedirectToAction("Index");
    }

    [HttpGet]
    // public ActionResult Statistics()
    // {
    //   List<CourseStatistics> courseStatistics = new List<CourseStatistics>();
    //   unitOfWork.CourseRepository.Get()
    //       .ToList()
    //       .ForEach(c =>
    //       {
    //         var subjects = unitOfWork.SubjectRepository.Get().Where(s => s.CourseID == c.ID);
    //         var subjectsIDs = subjects.Select(s => s.ID);
    //         int subjectsCount = subjects.Where(s => s.CourseID == c.ID).Count();
    //         int teachersCount = subjects.Select(t => t.TeacherID).Distinct().Count();
    //         var enrollments = unitOfWork.EnrollmentRepository.Get().Where(e => subjectsIDs.Contains(e.SubjectID));
    //         double avg = 0;
    //         if (enrollments.Count() > 0) avg = enrollments.Average(e => e.GradeValue);

    //         courseStatistics.Add(new CourseStatistics
    //         {
    //           Name = c.Name,
    //           TeachersCount = teachersCount,
    //           SubjectsCount = subjectsCount,
    //           Average = avg
    //         });
    //       });

    //   return Json(courseStatistics, JsonRequestBehavior.AllowGet);
    // }

    protected override void Dispose(bool disposing)
    {
      repositoryContext.Dispose();
      base.Dispose(disposing);
    }

    // class CourseStatistics
    // {
    //   public string Name { get; set; }
    //   public int TeachersCount { get; set; }
    //   public int SubjectsCount { get; set; }
    //   public double Average { get; set; }
    // }
  }
}
