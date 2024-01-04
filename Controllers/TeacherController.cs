using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineSchoolWebApp.Models;
using OnlineSchoolWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace OnlineSchoolWebApp.Controllers
{
    public class TeacherController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public TeacherController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<IActionResult> DisplayTeachers()
        {
            var roleId = await _dbContext.Roles
                .Where(r => r.Name == "Teacher")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            //if (roleId == null)
            //{
               
            //}

            var userIds = await _dbContext.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToListAsync();

            var teachers = await _dbContext.Users
                .OfType<ApplicationUser>()
                .Where(u => userIds.Contains(u.Id))
                .Select(u => new ApplicationUser
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName
                })
                .ToListAsync();

            return View(teachers);
        }

    }
}
