using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Requests
{
    public class CreateSubjectRequest
    {
        [Required]
        public string subject_name { get; set; }

    }
}

