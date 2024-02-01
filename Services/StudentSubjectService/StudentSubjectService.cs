using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.DTOs;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using WebApplication1.Services.StudentSubjectService;

namespace WebApplication1.Services.StudentSubjectService
{
    public class StudentSubjectService : StudentService.IStudentSubjectService
    {
        private readonly ApplicationDbContext context;
        private object Id;


        public StudentSubjectService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public BaseResponse CreateStudentSubject(CreateStudentSubjectRequest request)
        {
            BaseResponse response;

            try
            {
                //create new instance of studentsubject model
                StudentSubjectModel newStudentSubject = new StudentSubjectModel();
                {
                    newStudentSubject.student_id = request.student_id;
                    newStudentSubject.subject_id = request.subject_id;
                    newStudentSubject.marks = request.marks;

                };

                using (context)
                {
                    context.Add(newStudentSubject);
                    context.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully created the new studentsubject" }
                };
                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error: " + ex.Message }
                };

                return response;
            }

            
        }

        public BaseResponse StudentSubjectList()
        {
            BaseResponse response;

            try
            {
                List<StudentSubjectDTO> studentsubjects = new List<StudentSubjectDTO>();

                foreach (var studentsubject in context.StudentSubjects.ToList())
                {
                    studentsubjects.Add(new StudentSubjectDTO
                    {
                        student_id = studentsubject.student_id,
                        subject_id = studentsubject.subject_id,
                        marks = studentsubject.marks,

                    });
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { studentsubjects }
                };
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error: " + ex.Message }
                };
            }

            return response;
        }

        public BaseResponse GetStudentSubjectById(long id)
        {
            BaseResponse response;

            try
            {
                StudentSubjectDTO studentsubject = new StudentSubjectDTO();
                
                using (context)
                {
                    StudentSubjectModel filteredStudentSubject = context.StudentSubjects.Where(studentsuject => studentsubject.id == id).FirstOrDefault();

                    if (filteredStudentSubject != null)
                    {
                        studentsubject.student_id = filteredStudentSubject.student_id;
                        studentsubject.subject_id = filteredStudentSubject.subject_id;
                        studentsubject.marks = filteredStudentSubject.marks;

                    }
                    else
                    {
                        studentsubject = null;
                    }
                }

                if (studentsubject != null)
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { studentsubject }
                    };
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status400BadRequest,
                        data = new { message = "No studentsubject found" }
                    };
                }
                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error: " + ex.Message }
                };
                return response;
            }

            
        }

        public BaseResponse UpdateStudentSubjectById(long id, UpdateStudentSubjectRequest request)
        {
            BaseResponse response;

            try
            {
                using (context)
                {
                    StudentSubjectModel filteredStudentSubject = context.StudentSubjects.Where(studentsubject => studentsubject.id == id).FirstOrDefault();

                    if (filteredStudentSubject != null)
                    {
                        filteredStudentSubject.student_id = request.student_id;
                        filteredStudentSubject.subject_id = request.subject_id;
                        filteredStudentSubject.marks = request.marks;


                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "StudentSubject updated successfully" }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No studentsubject found" }
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
                    data = new { message = "Internal server error: " + ex.Message }
                };
            }

            return response;
        }

        public BaseResponse DeleteStudentSubjectById(long id)
        {
            BaseResponse response;

            try
            {
                using (context)
                {

                    StudentSubjectModel studentsubjectToDelete = context.StudentSubjects.Where(studentsubject => studentsubject.id == id).FirstOrDefault();

                    if (studentsubjectToDelete != null)
                    {
                        context.StudentSubjects.Remove(studentsubjectToDelete);
                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Studentsubject deleted successfully" }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No studentsubject found" }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error: " + ex.Message }
                };
            }

            return response;
        }

        public BaseResponse GetStudentSubjectById(long id, StudentSubjectModel studentsubject)
        {
            throw new NotImplementedException();
        }

        public BaseResponse GetEnrolledSubjectById(long student_id)
        {

            BaseResponse response;

            try
            {
                StudentSubjectDTO studentsubject = new StudentSubjectDTO();

                using (context)
                {
                    List<StudentSubjectModel> filteredStudentSubject = context.StudentSubjects.Where(studentsuject => studentsubject.id == student_id).ToList();


                    
                    /*if (filteredStudentSubject != null)
                    {
                       
                        studentsubject.subject_id = filteredStudentSubject.subject_id;
                       


                    }
                    else
                    {
                        studentsubject = null;
                    }
                }*/

                    if (filteredStudentSubject != null)
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { filteredStudentSubject }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No studentsubject found" }
                        };
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error: " + ex.Message }
                };
                return response;
            }

            throw new NotImplementedException();
        }
    }
}
