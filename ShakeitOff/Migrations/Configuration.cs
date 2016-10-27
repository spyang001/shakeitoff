
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShakeitOff.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
namespace ShakeitOff.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Project Manager" });
            }
            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }
            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });
            }


            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "spyang001@yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "spyang001@yahoo.com",
                    Email = "spyang001@yahoo.com",

                    DisplayName = "AwesomeousPrimO"
                }, "Abc&123!");
            }
            if (!context.Users.Any(u => u.Email == "psyang777@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "psyang777@gmail.com",
                    Email = "psyang777@gmail.com",

                    DisplayName = "PanNeverEndingStory"
                }, "Abc&123!");
            }
            if (!context.Users.Any(u => u.Email == "suav777@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "suav777@gmail.com",
                    Email = "suav777@gmail.com",

                    DisplayName = "Suave"
                }, "Abc&123!");
            }
            if (!context.Users.Any(u => u.Email == "shoua777@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "shoua777@gmail.com",
                    Email = "shoua777@gmail.com",

                    DisplayName = "CrazyHorse"
                }, "Abc&123!");
            }


            var userId = userManager.FindByEmail("spyang001@yahoo.com").Id;
            userManager.AddToRole(userId, "Admin");
            var user_Id = userManager.FindByEmail("psyang777@gmail.com").Id;
            userManager.AddToRole(user_Id, "Project Manager");
            var user_Id1 = userManager.FindByEmail("suav777@gmail.com").Id;
            userManager.AddToRole(user_Id, "Developer");
            var user_Id2 = userManager.FindByEmail("shoua777@gmail.com").Id;
            userManager.AddToRole(user_Id, "Submitter");
        }
    }
}
