using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Services.StudentService;
using WebApplication1.Services.StudentSubjectService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectController : ControllerBase
    {
        private readonly Services.StudentService.IStudentSubjectService studentSubjectService;
        private IStudentSubjectService studentsubjectService;

        //constructor
        public StudentSubjectController(Services.StudentService.IStudentSubjectService studentsubjectService)
        {
            this.studentsubjectService = studentsubjectService;
        }

        //endpoints

        [HttpPost("save")]
        public BaseResponse CreateStudentSubject(CreateStudentSubjectRequest request)
        {
            return studentsubjectService.CreateStudentSubject(request);
        }

        [HttpGet("List")]
        public BaseResponse StudentSubjectList()
        {
            return studentsubjectService.StudentSubjectList();
        }

        [HttpGet("{id}")]
        public BaseResponse GetStudentSubjectById(long id)
        {
            return studentsubjectService.GetStudentSubjectById(id);
        }

        [HttpPut("{id}")]
        public BaseResponse UpdateStudentSujectById(long id, UpdateStudentSubjectRequest request)
        {
            return studentsubjectService.UpdateStudentSubjectById(id, request);
        }

        [HttpDelete("{id}")]
        public BaseResponse DeleteStudentSubjectById(long id)
        {
            return studentsubjectService.DeleteStudentSubjectById(id);
        }

        [HttpGet("enrolledSubjects/{studentId}")]

        public BaseResponse GetEnrolledSubjects(long student_id)
        {
            return studentsubjectService.GetEnrolledSubjectById(student_id);
        }
    }
}

