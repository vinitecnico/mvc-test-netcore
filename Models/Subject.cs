using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTest.Models
{
  public class Subject
  {
    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }

    [ForeignKey("Course")]
    public int CourseID { get; set; }
    public virtual Course Course { get; set; }
    

    [ForeignKey("Teacher")]
    public int TeacherID { get; set; }

    public virtual Teacher Teacher { get; set; }
    

  }
}