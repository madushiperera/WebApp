using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class SubjectDTO
    {
        

        [Required]
        public long id { get; set; }

        [Required]
        public string subject_name { get; set; }

    }
}
