using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("subject")]
    public class SubjectModel
    {
        internal object subject_id;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        public long id { get; set; }

        [Required]
        public string subject_name { get; set; }

        

    }
}

