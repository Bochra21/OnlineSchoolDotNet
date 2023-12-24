using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineSchoolWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
