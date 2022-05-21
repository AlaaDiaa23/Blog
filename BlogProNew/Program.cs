using BlogPro.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProNew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            try
            {
                var scope = host.Services.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                var user = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var role = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                ctx.Database.EnsureCreated();
                var adminrole = new IdentityRole("Admin");
                if (!ctx.Roles.Any())
                {
                    role.CreateAsync(adminrole).GetAwaiter().GetResult();

                }
                if (!ctx.Users.Any(m => m.UserName == "Admin"))
                {
                    var adminuser = new IdentityUser()
                    {
                        UserName = "Admin",
                        Email = "admin@a.com",

                    };
                    var res = user.CreateAsync(adminuser, "password").GetAwaiter().GetResult();

                    user.AddToRoleAsync(adminuser, adminrole.Name).GetAwaiter().GetResult();

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }       
               host .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
