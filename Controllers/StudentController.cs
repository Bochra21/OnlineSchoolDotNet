﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineSchoolWebApp.Models;
using OnlineSchoolWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace OnlineSchoolWebApp.Controllers
{
    public class StudentController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<IActionResult> DisplayStudents()
        {
            var roleId = await _dbContext.Roles
                .Where(r => r.Name == "Student")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            if (roleId == null)
            {
                // Handle the case where the "Student" role does not exist
                // e.g., display an error message or redirect to an error page
            }

            var userIds = await _dbContext.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToListAsync();

            var students = await _dbContext.Users
                .OfType<ApplicationUser>()
                .Where(u => userIds.Contains(u.Id))
                .Select(u => new ApplicationUser
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName
                })
                .ToListAsync();

            return View(students);
        }

    }
}
