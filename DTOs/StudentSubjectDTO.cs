using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class StudentSubjectDTO
    {
        internal object subject_name;

        [Required]
        public long id { get; set; }
        

        [Required]
        public long student_id { get; set; }

        [Required]
        public long subject_id { get; set; }

        
        public int marks { get; set; }

    }
}
