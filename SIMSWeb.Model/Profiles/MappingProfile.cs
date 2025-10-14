using AutoMapper;
using SIMSWeb.Model;
using SIMSWeb.Model.Models;
using SIMSWeb.Model.ViewModels.Course;
using SIMSWeb.Model.ViewModels.StudentsModels;
using SIMSWeb.Model.ViewModels.TeachersModels;
using SIMSWeb.Model.ViewModels.UserModels;

namespace SIMSWeb.Model.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, ManageUsersModel>().ReverseMap();

            CreateMap<Course, CourseViewModel>().ReverseMap();

            CreateMap<Teacher, TeacherViewModel>().ReverseMap();

            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();

            CreateMap<Enrollment, EnrollmentViewModel>().ReverseMap();

            CreateMap<Assignment, AssignmentViewModel>().ReverseMap();

            CreateMap<Submission, SubmissionViewModel>().ReverseMap();

            CreateMap<AddUserModel, UserModel>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();

        }
        
    }
}
