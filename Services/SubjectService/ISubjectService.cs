using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;

namespace WebApplication1.Services.StudentService
{
    public interface ISubjectService
    {
        BaseResponse CreateSubject(CreateSubjectRequest request);

        BaseResponse SubjectList();

        BaseResponse GetSubjectById(long id);

        BaseResponse UpdateSubjectById(long id, UpdateSubjectRequest request);

        BaseResponse DeleteSubjectById(long id);
    }
}

