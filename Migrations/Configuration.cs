namespace UserManagement.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UserManagement.DataAccess.Concrete.EntityFramework.Context;
    using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto;

    internal sealed class Configuration : DbMigrationsConfiguration<UserManagement.DataAccess.Concrete.EntityFramework.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UserManagement.DataAccess.Concrete.EntityFramework.Context.ApplicationDbContext context)
        {
            //CreateRoles(context);
            //CreateAdmin(context);
        }

        private void CreateAdmin(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = userManager.FindByNameAsync("Admin").Result;
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "ocL_1972",
                    NameSurname = "Kurtuluş Öcal",
                    Email = "kurtulusocal@protonmail.com",
                    IsConfirmed = true,
                    CreatedDate = DateTime.Now.ToLocalTime(),
                    PhoneNumber = "+905444939494",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                userManager.Create(user, "#ocL_2514#");
                userManager.AddToRole(user.Id, "Admin");
            }
            var userInRole = userManager.IsInRole(user.Id, "Admin");
            if (!userInRole)
            {
                userManager.AddToRole(user.Id, "Admin");
            }
        }

        private void CreateRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleName = { "Admin" };
            foreach (var role in roleName)
            {
                if (roleManager.RoleExists(role) == false)
                {
                    var newRole = new IdentityRole { Name = role };
                    roleManager.Create(newRole);
                }
            }
        }
    }
}
