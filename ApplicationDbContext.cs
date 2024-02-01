using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class ApplicationDbContext : DbContext
    {
        internal IEnumerable<object> Studentsubjects;

        //constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }

        //add models to database context
        public virtual DbSet<StudentModel> Students { get; set; }

        public virtual DbSet<SubjectModel> Subjects {  get; set; }

        public virtual DbSet<StudentSubjectModel> StudentSubjects { get; set; }


   
        
    }
}
