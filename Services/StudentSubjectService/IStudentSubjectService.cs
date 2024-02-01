using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;

namespace WebApplication1.Services.StudentService
{
    public interface IStudentSubjectService
    {
        BaseResponse CreateStudentSubject(CreateStudentSubjectRequest request);

        BaseResponse StudentSubjectList();

        BaseResponse GetStudentSubjectById(long id);

        BaseResponse UpdateStudentSubjectById(long id, UpdateStudentSubjectRequest request);

        BaseResponse DeleteStudentSubjectById(long id);

        BaseResponse GetEnrolledSubjectById(long student_id);
    }
}

