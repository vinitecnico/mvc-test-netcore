using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTest.Models
{
  public class Course
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CourseID { get; set; }

    [StringLength(50, MinimumLength = 3)]
    public string Title { get; set; }
    
    public virtual ICollection<Enrollment> Enrollments { get; set; }
    public virtual ICollection<Subject> Subjects { get; set; }
    public virtual Teacher Teacher { get; set; }

  }
}
