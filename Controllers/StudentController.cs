using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineSchoolWebApp.Models;

namespace OnlineSchoolWebApp.Controllers
{
    public class StudentController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> DisplayStudents()
        {
            var studentsUsers = await _userManager.GetUsersInRoleAsync("Student");

            return View(studentsUsers);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
