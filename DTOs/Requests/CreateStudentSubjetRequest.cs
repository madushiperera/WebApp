using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Requests
{
    public class CreateStudentSubjectRequest
    {
        [Required]
        public long student_id { get; set; }

        [Required]
        public long subject_id { get; set; }

        [Required]
        public int marks { get; set; }

      
    }
}

