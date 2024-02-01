using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("studentsubjectmodel")]
    public class StudentSubjectModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        public long id { get; set; }

        [Required]
        public long student_id { get; set; }

        [Required]
        public long subject_id { get; set; }

        public int marks { get; set; }

        
    }
}
