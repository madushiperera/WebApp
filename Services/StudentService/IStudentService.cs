using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;

namespace WebApplication1.Services.StudentService
{
    public interface IStudentService
    {
        BaseResponse CreateStudent(CreateStudentRequest request);

        BaseResponse StudentList();

        BaseResponse GetStudentById(long id);

        BaseResponse UpdateStudentById(long id, UpdateStudentRequest request);

        BaseResponse DeleteStudentById(long id);

       
    }
}
