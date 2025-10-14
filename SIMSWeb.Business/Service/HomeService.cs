using Microsoft.Extensions.Logging;
using SIMSWeb.Business.IService;
using SIMSWeb.Model.Models;
using SIMSWeb.Model.ViewModels.ProfileModels;

namespace SIMSWeb.Business.Service
{
    public class HomeService : IHomeService
    {
        private readonly ILogger<HomeService> _logger;
        private readonly IUserService _userService;
        private readonly UserSession _session;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public HomeService(ILogger<HomeService> logger, IUserService userService,
            UserSession session, ICourseService courseService, ITeacherService teacherService,
            IStudentService studentService)
        {
            _logger = logger;
            _userService = userService;
            _session = session;
            _courseService = courseService;
            _teacherService = teacherService;
            _studentService = studentService;
        }
        public async Task<AdminProfile> GetAdminProfile()
        {
            var adminProfile = new AdminProfile();

            adminProfile.Status = new ProfileStatus();

            var userCount = await _userService.GetUserCount(string.Empty, string.Empty);
            var coursesCount = await _courseService.GetActiveCoursesCount();
            var avgSizeClass = await _courseService.AverageClassSize();

            adminProfile.Status.TotalUsers = userCount;
            adminProfile.Status.ActiveCourses = coursesCount;
            adminProfile.Status.AvgClassSizePerCourse = avgSizeClass;

            adminProfile.User = new User();
            var user = await _userService.GetUserByEmail(_session.Email);
            adminProfile.User = user;

            adminProfile.RecentEnrollments = new List<RecentEnrollment>();
            var enrollments = await _studentService.GetRecentEnrolledStudents();

            var recentEnrollments = enrollments.Select(e => new RecentEnrollment
            {
                EnrollmentDate = e.Student.EnrollmentDate,
                Name = e.Student.User.Name,
                CourseName = e.Course.Name,
            }).ToList();

            adminProfile.RecentEnrollments = recentEnrollments;

            var assignmentsDueIn7Days = await _courseService.GetCourseDueInSevenDays(_session.Role, null);

            var assignmentsDueIn7DaysInfo = assignmentsDueIn7Days.Select(a => new PendingAssignments
            {
                CourseName = a.Name,
                AssignmentStatus = true
            }).ToList();

            adminProfile.PendingAssignments = assignmentsDueIn7DaysInfo;

            return adminProfile;
        }

        public async Task<StudentProfile> GetStudentProfile()
        {
            var studentProfile = new StudentProfile();

            studentProfile.User = new User();
            var user = await _userService.GetUserByEmail(_session.Email);
            studentProfile.User = user;

            var enrolledCourses = await _courseService.GetCoursesByUserId(_session.Id, 0, string.Empty, 0, 0);

            var enrolledCoursesInfo = enrolledCourses.Select(c => new EnrolledCourses
            {
                Id = c.Id,
                CourseName = c.Name,
                AssignmentCreated = c.Assignments.Select(a => a.Title).ToList(),
            }).ToList();

            studentProfile.EnrolledCourses = enrolledCoursesInfo;

            studentProfile.StudentProfileMetrics = new StudentProfileMetrics();

            studentProfile.StudentProfileMetrics.ActiveCourses = enrolledCourses.Count;

            studentProfile.StudentProfileMetrics.ActiveAssignments = enrolledCoursesInfo
                .Select(e => e.AssignmentCreated.Count).FirstOrDefault();

            studentProfile.StudentProfileMetrics.CompletedAssignmentsCount = enrolledCourses
            .SelectMany(course => course.Assignments)
            .SelectMany(assignment => assignment.Submissions)
            .Where(submission => submission.Student.UserId == _session.Id)
            .Count(submission => submission.SubmittedAt != null);

            var studentSubmissions = enrolledCourses
                .SelectMany(course => course.Assignments)
                .SelectMany(assignment => assignment.Submissions)
                .Where(submission => submission.Student.UserId == _session.Id);

            if (studentSubmissions.Any())
            {
                studentProfile.StudentProfileMetrics.MaximumMarks = studentSubmissions.Max(submission => submission.Score);
            }
            else
            {
                studentProfile.StudentProfileMetrics.MaximumMarks = 0;
            }


            var studentProgress = await _courseService.GetProgressofStudent(_session.Id);

            studentProfile.AssignmentProgress = studentProgress;

            return studentProfile;
        }

        public async Task<TeacherProfile> GetTeacherProfile()
        {
            var teacherProfile = new TeacherProfile();

            teacherProfile.User = new User();
            var user = await _userService.GetUserByEmail(_session.Email);
            teacherProfile.User = user;

            teacherProfile.RecentlyEnrolledStudents = new List<RecentlyEnrolledStudents>();
            var enrollments = await _studentService.GetStudentEnrolledByUserId(_session.Id);

            var recentEnrollments = enrollments.Select(e => new RecentlyEnrolledStudents
            {
                EnrollmentDate = e.Student.EnrollmentDate,
                Name = e.Student.User.Name,
                CourseName = e.Course.Name,
            }).ToList();

            teacherProfile.RecentlyEnrolledStudents = recentEnrollments;

            var coursesByTeacher = await _courseService.GetCoursesByUserId(_session.Id, 0, string.Empty, 0, 0);

            var coursesByTeacherInfo = coursesByTeacher.Select(c => new TeacherCourses
            {
                Id = c.Id,
                CourseName = c.Name,
                StudentsEnrolled = c.Enrollments.Select(e => e.Student.User.Name).ToList(),
                AssignmentCreated = c.Assignments.Select(a => new AssignmentList
                {
                    AssignmentId = a.Id,
                    AssignmentName = a.Title
                }).ToList(),
            }).ToList();

            teacherProfile.TeacherCourses = coursesByTeacherInfo;

            teacherProfile.TeacherProfileMetrics = new TeacherProfileMetrics();

            teacherProfile.TeacherProfileMetrics.ActiveCourses = coursesByTeacher.Count;
            teacherProfile.TeacherProfileMetrics.TotalStudentsTaught = enrollments.Count;
            teacherProfile.TeacherProfileMetrics.TotalAssignmentsCreated = coursesByTeacher.Sum(c =>
                c.Assignments.Count);

            return teacherProfile;
        }
    }
}
