using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTest.Models
{
  public class Enrollment
  {
    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }


    [ForeignKey("Subject")]
    public int SubjectID { get; set; }
    public virtual Subject Subject { get; set; }


    [ForeignKey("Student")]
    public int StudentID { get; set; }
    public virtual Student Student { get; set; }


    public double GradeValue { get; set; }
  }
}