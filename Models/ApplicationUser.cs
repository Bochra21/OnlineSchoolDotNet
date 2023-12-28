using Microsoft.AspNetCore.Identity;

namespace OnlineSchoolWebApp.Models

{


    public class ApplicationUser : IdentityUser
    {
        public string Discriminator { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Tel { get; set; }

    }
}
