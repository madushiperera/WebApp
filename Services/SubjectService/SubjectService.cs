using System;
using WebApplication1.DTOs;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Models;
using WebApplication1.Services.StudentService;

namespace WebApplication1.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {
        //variable to store application db context
        private readonly ApplicationDbContext context;
        private long id;

        public SubjectService(ApplicationDbContext applicationDbContext) 
        {
            //get db context through DI
            context = applicationDbContext;
        }

        public BaseResponse CreateSubject(CreateSubjectRequest request)
        {
            BaseResponse response;

            try
            {
                //create new instance of subject model
                SubjectModel newSubject = new SubjectModel();
                newSubject.subject_name = request.subject_name;

                using (context)
                {
                    context.Add(newSubject);
                    context.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully created the new subject" }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal  server error : " + ex.Message }
                };

                return response;

            }

            throw new NotImplementedException();
        }

        public BaseResponse DeleteSubjectById(long id)
        {
            BaseResponse response;

            try
            {
                using (context)
                {
                    SubjectModel subjectToDelete = context.Subjects.Where(subject => subject.id == id).FirstOrDefault();

                    if (subjectToDelete != null)
                    {
                        context.Subjects.Remove(subjectToDelete);
                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Student deleted successfully" }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No student found" }
                        };
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };
                return response;
            }

            throw new NotImplementedException();
        }

        public BaseResponse GetSubjectById(long id)
        {
            BaseResponse response;

            try
            {

                SubjectDTO subject = new SubjectDTO();

                using (context)
                {

                    SubjectModel filteredSubject = context.Subjects.Where(subject => subject.id == id).FirstOrDefault();

                    if (filteredSubject != null)
                    {
                        subject.id = filteredSubject.id;
                        subject.subject_name = filteredSubject.subject_name;
                    }
                    else
                    {
                        subject = null;
                    }
                }

                if (subject != null)
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { subject }
                    };
        
        }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status400BadRequest,
                        data = new { message = "No student found" }
                    };
                }
                return response;
            }

            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };
                return response;
            }

            throw new NotImplementedException();
        }

        public BaseResponse SubjectList()
        {
            BaseResponse response;

            try
            {
                List<SubjectDTO> subjects = new List<SubjectDTO>();
                using (context)
                {
                    //get all subjects from database and add to subjects list after convert them to subject dto
                    context.Subjects.ToList().ForEach(subject => subjects.Add(new SubjectDTO
                    {
                        id = subject.id,
                        subject_name = subject.subject_name,
                    }));
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { subjects }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };

                return response;
            }

            throw new NotImplementedException();
        }

        public BaseResponse UpdateSubjectById(long id, UpdateSubjectRequest request)
        {
            BaseResponse response;

            try
            {

                using (context)
                {
                    SubjectModel filteredSubject = context.Subjects.Where(subject => subject.id == id).FirstOrDefault();

                    if (filteredSubject != null)
                    {
                        filteredSubject.subject_name = request.subject_name;

                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Student updated successfully" }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No student found" }
                        };
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };
                return response;
            }

            throw new NotImplementedException();
        }
    }
}
