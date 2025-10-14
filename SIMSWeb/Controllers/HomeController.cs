using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIMSWeb.Business.IService;
using SIMSWeb.Model.Models;
using SIMSWeb.Model.ViewModels.Common;
using SIMSWeb.Model.ViewModels.ProfileModels;

namespace SIMSWeb.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserSession _session;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IUserService userService,
            UserSession session, ICourseService courseService, ITeacherService teacherService,
            IStudentService studentService, IHomeService homeService)
        {
            _session = session;
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Profile", "Home");
            }

            if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("TeacherProfile", "Home");
            }

            return RedirectToAction("StudentProfile", "Home");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Profile()
        {

            if (string.IsNullOrEmpty(_session.Email))
            {
                return View(new AdminProfile());
            }

            var adminProfile = await _homeService.GetAdminProfile();

            return View(adminProfile);

        }


        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult> TeacherProfile()
        {
            if (string.IsNullOrEmpty(_session.Email))
            {
                return View(new TeacherProfile());
            }

            var teacherProfile = await _homeService.GetTeacherProfile();

            return View(teacherProfile);

        }

        [Authorize(Roles = "Student")]
        public async Task<ActionResult> StudentProfile()
        {

            if (string.IsNullOrEmpty(_session.Email))
            {
                return View(new StudentProfile());
            }

            var studentProfile = await _homeService.GetStudentProfile();

            return View(studentProfile);
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public IActionResult Error(int statusCode)
        {
            var _statusCode = statusCode > 0 ? statusCode : HttpContext.Response.StatusCode;

            var model = new ErrorViewModel
            {
                StatusCode = _statusCode
            };

            model.ErrorMessage = statusCode switch
            {
                404 => "Oops! The page you requested could not be found.",
                500 => "Something went wrong on our server. Please try again later.",
                403 => "You don't have permission to view this page.",
                400 => "The request is invalid. Please check and try again.",
                502 => "There seems to be a problem with the server.",
                503 => "The service is temporarily unavailable. Please try again later.",
                _ => "An unexpected error occurred. Please try again later."
            };

            return View(model);
        }
    }
}
