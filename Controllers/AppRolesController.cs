
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Data;


namespace OnlineSchoolWebApp.Controllers
{

    //[Authorize(Roles = "Admin")]
    public class AppRolesController : Controller

    {
        private readonly RoleManager<IdentityRole> administrateur;
        public AppRolesController(RoleManager<IdentityRole> administrateur)
        {
            this.administrateur = administrateur;
        }

        public IActionResult Index()
        {
            var roles = administrateur.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            //Avoid duplicated roles in our application
            if (!administrateur.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                administrateur.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }

    }
}
