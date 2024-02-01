using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("student")]
    public class StudentModel
    {
        internal object student_id;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public long id { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required] 
        public string address { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string contact_number { get; set; }

        
      
    }
}
