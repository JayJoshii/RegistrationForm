using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistrationForm.Models;

namespace RegistrationForm.Data
{
    public class RegistrationFormContext : DbContext
    {
        public RegistrationFormContext (DbContextOptions<RegistrationFormContext> options)
            : base(options)
        {
        }

        public DbSet<RegistrationForm.Models.UserModel> UserModel { get; set; } = default!;
    }
}
