using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Services.StudentService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;

        //constructor
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        //endpoints

        [HttpPost("save")]
        public BaseResponse CreateSubject(CreateSubjectRequest request)
        {
            return subjectService.CreateSubject(request);
        }

        [HttpGet("List")]
        public BaseResponse SubjectList()
        {
            return subjectService.SubjectList();
        }

        [HttpGet("{id}")]
        public BaseResponse GetSubjectById(long id)
        {
            return subjectService.GetSubjectById(id);
        }

        [HttpPut("{id}")]
        public BaseResponse UpdateSubjectById(long id, UpdateSubjectRequest request)
        {
            return subjectService.UpdateSubjectById(id, request);
        }

        [HttpDelete("{id}")]
        public BaseResponse DeleteSubjectById(long id)
        {
            return subjectService.DeleteSubjectById(id);
        }
    }
}

