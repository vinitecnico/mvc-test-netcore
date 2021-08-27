using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTest.Models
{
  public class Course
  {
    [Key]
    [Column(Order=1)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; }

  }
}
